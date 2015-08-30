(function () {
    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
              ? args[number]
              : match
            ;
        });
    };

    $.fn.serializeObject = function () {
        "use strict";

        var result = {};
        var extend = function (i, element) {
            var node = result[element.name];

            // If node with same name exists already, need to convert it to an array as it
            // is a multi-value field (i.e., checkboxes)

            if ('undefined' !== typeof node && node !== null) {
                if ($.isArray(node)) {
                    node.push(element.value);
                } else {
                    result[element.name] = [node, element.value];
                }
            } else {
                result[element.name] = element.value;
            }
        };

        $.each(this.serializeArray(), extend);
        return result;
    };

    var LoadSongs = Backbone.View.extend({
        el: '.load-songs',
        initialize: function () {
            SC.get('/me', $.proxy(this.onSoundCloudLoad, this));
            this.followings = [];
            this.scId = 0;
            this.page = 0;
            this.offset = 200;
            this.render();
        },
        dispose: function () {
        },
        render: function () {
            return this;
        },
        onSoundCloudLoad: function (data) {
            this.scId = data.id;
            this.followingsLoad(this.page, this.offset);
        },
        followingsLoad: function (page, offset) {
            $.ajax({
                type: 'GET',
                url: 'https://api.soundcloud.com/users/{0}/followings.json?consumer_key={1}&limit=200&offset={2}'.format(this.scId, 'b5b7157a7a37e36206abf96883b3f25a', page * offset)
            }).done($.proxy(this.pageFollings, this, page, offset));
        },
        pageFollings: function (page, offset, data) {
            if (data.length > 0) {
                for (var i in data) {
                    this.followings.push(data[i]);
                }

                page += 1;
                this.followingsLoad(page, offset);
            } else {
                this.displaySoundCloudFollowings(this.followings);
            }
        },
        removeSongsWithoutUrl: function () {
            this.$el.find('.bandcamp-ph').find('.tracks').find('.track').each(function (index, elmt) {
                var linha = $(elmt);

                if (linha.find('.trackUrl').val().length === 0) {
                    linha.remove();
                }
            });

            this.$el.find('.bandcamp-ph').find('.tracks').find('.track').each(function (index, elmt) {
                var linha = $(elmt);

                linha.find('input:text').each(function (j, t) {
                    var input = $(t),
                        name = input.attr('name'),
                        newName = "";

                    newName = name.replace(/\[\d\]/g, '[{0}]'.format(index));

                    input.prop('name', newName);

                });
            });
        },
        save: function () {
            this.removeSongsWithoutUrl();

            var dataPost = this.$el.find('form').serializeObject();
            $.ajax({
                type: 'POST',
                url: '/LoadSongs/Save',
                data: JSON.stringify(dataPost),
                dataType: 'json',
                contentType: 'application/json'
            }).done($.proxy(this.onSaveComplete, this));
        },
        onSaveComplete: function (data) {
            this.$el.find('.artistId').val(data.Artist.ArtistId);
            this.$el.find('.albumId').val(data.Album.AlbumId);
        },
        loadBandcampPageHtml: function () {
            var url = this.$el.find('.url').val();
            $.ajax({
                type: 'POST',
                url: '/LoadSongs/FromBandcamp',
                data: { url: url }
            }).done($.proxy(this.onLoadBandcampPageComplete, this));
        },
        millisToTime: function (ms) {
            var x = ms / 1000;
            var seconds = Math.round(x % 60);
            x /= 60;
            var minutes = Math.round(x % 60);
            x /= 60;
            var hours = Math.round(x % 24);
            x /= 24;
            var days = Math.round(x);

            if (hours < 10) {
                hours = '0{0}'.format(hours);
            }

            if (minutes < 10) {
                minutes = '0{0}'.format(minutes);
            }

            if (seconds < 10) {
                seconds = '0{0}'.format(seconds);
            }

            return { "Days": days, "Hours": hours, "Minutes": minutes, "Seconds": seconds };
        },
        displayAlbumCover: function (cover) {
            var albumCoverEl = this.$el.find('.album-cover');
            albumCoverEl.attr('src', cover);
            this.$el.find('[name="Album.AlbumCover"]').val(cover);
        },
        displayAlbumYear: function (year) {
            this.$el.find('[name="Album.Year"]').val(year.trim().substr(year.trim().length - 4, 4));
        },
        displayArtistName: function (name) {
            this.$el.find('.artistName').val(name.trim());
        },
        displayAlbumName: function (name) {
            this.$el.find('.albumName').val(name.trim());
        },
        displayTrackList: function (list) {
            var tpl = '',
                rows = '';

            tpl += ' <li class="track">';
            tpl += ' <input type="checkbox" name="exist" value="true" class="exist" />';
            tpl += ' <input type="text" name="Songs[{3}].TrackNumber" value="{0}" class="trackNumber" />';
            tpl += ' <input type="text" name="Songs[{3}].Duration" value="{1}" class="trackDuration" />';
            tpl += ' <input type="text" name="Songs[{3}].Name" value="{2}" class="trackName" />';
            tpl += ' <input type="text" name="Songs[{3}].SoundCloudUrl" value="" class="trackUrl" />';
            tpl += ' </li> ';

            list.each(function (index, elmt) {
                var elmt = $(elmt),
                    trackName = '',
                    trackNumber = '',
                    trackDuration = '';

                trackName = elmt.find('.title').find('[itemprop=name]').text();
                trackNumber = elmt.find('.track_number').text().replace('.', '');

                trackDuration = elmt.find('.title').find('.time').text().trim();

                rows += tpl.format(trackNumber, trackDuration, trackName, index);

                //COMPLETE
                if (index === list.length - 1) {
                    $('.bandcamp-ph').find('.tracks').empty().append(rows);
                }
            });
        },
        displaySoundCloudFollowings: function (data) {
            var tpl = '',
                rows = '';

            tpl += ' <li class="artist">';
            tpl += ' <input type="text" name="trackName" value="{0}" class="trackName" />';
            tpl += ' <img src="{1}" width="30" height="30" id="{2}" url="https://api.soundcloud.com/users/{3}.json?consumer_key={4}"  class="btn-load-tracks"/>';

            tpl += ' <ul class="tracks"></ul> ';
            tpl += ' </li> ';

            for (var i in data) {
                var name = data[i].username,
                    image = data[i].avatar_url,
                    id = data[i].id;

                if (name && !name.length) {
                    if (data[i].username === null) {
                        name = data[i].first_name;
                    }
                    if (name && !name.length) {
                        if (data[i].first_name === null) {
                            name = data[i].full_name;
                        }
                    }
                }
                rows += tpl.format(name, image, id, id, 'b5b7157a7a37e36206abf96883b3f25a');
                //COMPLETE
                if (i == data.length - 1) {
                    $('.ph').empty().append(rows);
                }
            }
        },
        displayTracks: function (container, data) {
            var tpl = '',
               rows = '';

            tpl += ' <li>';
            tpl += ' <input type="text" name="trackName" value="{0}" class="trackName" />';
            tpl += ' <input type="hidden" name="trackUrl" value="{2}" class="trackUrl" />';
            tpl += ' </li> ';

            for (var i in data) {
                var name = data[i].title,
                    duration = '{0}:{1}'.format(this.millisToTime(data[i].duration).Minutes, this.millisToTime(data[i].duration).Seconds),
                    url = data[i].permalink_url;

                rows += tpl.format(name, duration, url);

                //COMPLETE
                if (i == data.length - 1) {
                    container.empty().append(rows);
                }
            }
        },
        events: {
            'click .btn-load-bandcamp': 'onBtnLoadBandCampClick',
            'click .btn-load-tracks': 'onBtnLoadTracksClick',
            'click .btn-save': 'onBtnSaveClick',
            'click .btn-reset': 'onBtnResetClick',
            'click .soundcloud-ph .tracks .trackName': 'onSoundCloudTrackClick'
        },
        onBtnResetClick: function(evt) {
            this.$el.find('.info').find('input').val('');
            this.$el.find('.artistId').val('');
            this.$el.find('.albumId').val('');            
        },
        onSoundCloudTrackClick: function (evt) {
            var target = $(evt.currentTarget),
                scUrl = target.next().val();

            this.$el.find('.bandcamp-ph').find('.tracks').find('.trackName').each(function (index, elmt) {
                var input = $(elmt),
                    trackName = input.val();

                if (trackName.trim().toLowerCase() === target.val().trim().toLowerCase()) {
                    input.next().val(scUrl);
                }
            });
        },
        onBtnSaveClick: function (evt) {
            evt.preventDefault();
            this.save();
        },
        onBtnLoadTracksClick: function (evt) {
            var id = $(evt.currentTarget).attr('id'),
                container = $(evt.currentTarget).next();

            if ($(evt.currentTarget).next().children().length === 0) {
                this.$el.find('.soundcloud-ph').find('.tracks').empty();
                this.$el.find('.artist-cover').prop('src', $(evt.currentTarget).attr('src'));
                this.$el.find(':hidden[name="Artist.Picture"]').val($(evt.currentTarget).attr('src'));
                SC.get('/users/{0}/tracks'.format(id), $.proxy(this.displayTracks, this, container));
            } else {
                this.$el.find('.soundcloud-ph').find('.tracks').empty();
            }
        },
        onLoadBandcampPageComplete: function (data) {
            var html = $($.parseHTML(data.html)[83]);
            var albumCover = html.find('#tralbumArt').find('img').attr('src');
            this.displayArtistName(html.find("[itemprop=byArtist]").text());
            this.displayAlbumCover(albumCover);
            this.displayAlbumYear(html.find(".tralbumData.tralbum-credits").text());
            this.displayTrackList(html.find('.track_list').find("tr"));
            this.displayAlbumName(html.find('.trackTitle:eq(0)').text());
        },
        onBtnLoadBandCampClick: function () {
            this.loadBandcampPageHtml();
        }
    });

    jQuery(function () {
        SC.initialize({
            client_id: 'b5b7157a7a37e36206abf96883b3f25a',
            redirect_uri: "http://localhost:20213/callback.html"
        });
        SC.connect(function () {
            new LoadSongs();
        });
    });
}());