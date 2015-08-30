[assembly: WebActivator.PreApplicationStartMethod(typeof(MusicBattlWebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(MusicBattlWebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace MusicBattlWebAPI.App_Start
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using MusicBattlBLL;
    using MusicBattlBLL.interfaces;
    using MusicBattlBLL.models;
    using MusicBattlBLL.repositories;
    using MusicBattlDAL;
    using MusicBattlDAL.interfaces;
    using MusicBattlDAL.models.interfaces;
    using MusicBattlWebAPI.Helpers;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;
    using System.Web.Http;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            // Install our Ninject-based IDependencyResolver into the Web API config
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            IDataBaseAccess databaseAccess = DataBaseFactory.Instance.GetDataBaseAccess(DataBaseFactoryType.SQLServer, WebConfigHelper.ConnectionString);

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.SetDatabaseProviderFactory(factory);
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase();

            //ViewPastBattls
            kernel.Bind<IRepository<IViewPastBattls>>().ToConstructor(ctorArg => new ViewPastBattlsRepository(db));
            kernel.Bind<IRepositoryBLL<IViewPastBattls>>().To<ViewPastBattlsRepositoryBLL>();
            kernel.Bind<IViewPastBattlsBLL>().To<ViewPastBattlsBLL>();

            //ViewAlbumArtistSongTotalVotes
            kernel.Bind<IRepository<IViewAlbumArtistSongTotalVotes>>().ToConstructor(ctorArg => new ViewAlbumArtistSongTotalVotesRepository(db));
            kernel.Bind<IRepositoryBLL<IViewAlbumArtistSongTotalVotes>>().To<ViewAlbumArtistSongTotalVotesRepositoryBLL>();
            kernel.Bind<IViewAlbumArtistSongTotalVotesBLL>().To<ViewAlbumArtistSongTotalVotesBLL>();

            //ViewAlbumArtistSongTotalVotesByArtist
            kernel.Bind<IRepository<IViewAlbumArtistSongTotalVotesByArtist>>().ToConstructor(ctorArg => new ViewAlbumArtistSongTotalVotesByArtistRepository(db));
            kernel.Bind<IRepositoryBLL<IViewAlbumArtistSongTotalVotesByArtist>>().To<ViewAlbumArtistSongTotalVotesByArtistRepositoryBLL>();
            kernel.Bind<IViewAlbumArtistSongTotalVotesByArtistBLL>().To<ViewAlbumArtistSongTotalVotesByArtistBLL>();

            //ViewUserTotalVotes
            kernel.Bind<IRepository<IViewUserTotalVotes>>().ToConstructor(ctorArg => new ViewUserTotalVotesRepository(db));
            kernel.Bind<IRepositoryBLL<IViewUserTotalVotes>>().To<ViewUserTotalVotesRepositoryBLL>();
            kernel.Bind<IViewUserTotalVotesBLL>().To<ViewUserTotalVotesBLL>();

            //ViewUserBattlResult
            kernel.Bind<IRepository<IViewUserBattlResult>>().ToConstructor(ctorArg => new ViewUserBattlResultRepository(db));
            kernel.Bind<IRepositoryBLL<IViewUserBattlResult>>().To<ViewUserBattlResultRepositoryBLL>();
            kernel.Bind<IViewUserBattlResultBLL>().To<ViewUserBattlResultBLL>();

            //ViewUserFavoritesSongs
            kernel.Bind<IRepository<IViewUserFavoritesSongs>>().ToConstructor(ctorArg => new ViewUserFavoritesSongsRepository(db));
            kernel.Bind<IRepositoryBLL<IViewUserFavoritesSongs>>().To<ViewUserFavoritesSongsRepositoryBLL>();
            kernel.Bind<IViewUserFavoritesSongsBLL>().To<ViewUserFavoritesSongsBLL>();

            //ViewTopSongs
            kernel.Bind<IRepository<IViewTopSongs>>().ToConstructor(ctorArg => new ViewTopSongsRepository(db));
            kernel.Bind<IRepositoryBLL<IViewTopSongs>>().To<ViewTopSongsRepositoryBLL>();
            kernel.Bind<IViewTopSongsBLL>().To<ViewTopSongsBLL>();

            //ViewTopUsers
            kernel.Bind<IRepository<IViewTopUsers>>().ToConstructor(ctorArg => new ViewTopUsersRepository(db));
            kernel.Bind<IRepositoryBLL<IViewTopUsers>>().To<ViewTopUsersRepositoryBLL>();
            kernel.Bind<IViewTopUsersBLL>().To<ViewTopUsersBLL>();

            //ViewTopAlbums
            kernel.Bind<IRepository<IViewTopAlbums>>().ToConstructor(ctorArg => new ViewTopAlbumsRepository(db));
            kernel.Bind<IRepositoryBLL<IViewTopAlbums>>().To<ViewTopAlbumsRepositoryBLL>();
            kernel.Bind<IViewTopAlbumsBLL>().To<ViewTopAlbumsBLL>();

            //ViewGenderTotals
            kernel.Bind<IRepository<IViewGenderTotal>>().ToConstructor(ctorArg => new ViewGenderTotalRepository(db));
            kernel.Bind<IRepositoryBLL<IViewGenderTotal>>().To<ViewGenderTotalRepositoryBLL>();
            kernel.Bind<IViewGenderTotalBLL>().To<ViewGenderTotalBLL>();

            //ViewUserAgesTotal
            kernel.Bind<IRepository<IViewUserAges>>().ToConstructor(ctorArg => new ViewUserAgesRepository(db));
            kernel.Bind<IRepositoryBLL<IViewUserAges>>().To<ViewUserAgesRepositoryBLL>();
            kernel.Bind<IViewUserAgesTotalBLL>().To<ViewUserAgesTotalBLL>();

            //ViewArtists
            kernel.Bind<IRepository<IViewArtists>>().ToConstructor(ctorArg => new ViewArtistsRepository(db));
            kernel.Bind<IRepositoryBLL<IViewArtists>>().To<ViewArtistsRepositoryBLL>();
            kernel.Bind<IViewArtistsBLL>().To<ViewArtistsBLL>();

            //ViewActivityByHour
            kernel.Bind<IRepository<IViewActivityByHour>>().ToConstructor(ctorArg => new ViewActivityByHourRepository(db));
            kernel.Bind<IRepositoryBLL<IViewActivityByHour>>().To<ViewActivityByHourRepositoryBLL>();
            kernel.Bind<IViewActivityByHourBLL>().To<ViewActivityByHourBLL>();

            //AccountBLL
            kernel.Bind<IRepository<IUsuario>>().ToConstructor(ctorArg => new UsuarioRepository(db));
            kernel.Bind<IRepositoryBLL<IUsuario>>().To<UsuarioRepositoryBLL>();
            kernel.Bind<IRepository<IProfile>>().ToConstructor(ctorArg => new ProfileRepository(db));
            kernel.Bind<IRepositoryBLL<IProfile>>().To<ProfileRepositoryBLL>();
            kernel.Bind<IAccountBLL>().To<AccountBLL>();

            //Battl
            kernel.Bind<IRepository<IBattl>>().ToConstructor(ctorArg => new BattlRepository(db));
            kernel.Bind<IRepositoryBLL<IBattl>>().To<BattlRepositoryBLL>();
            kernel.Bind<IBattlBLL>().To<BattlBLL>();

            //VoteBLL
            kernel.Bind<IVote>().To<Vote>();
            kernel.Bind<IRepository<IVote>>().ToConstructor(ctorArg => new VoteRepository(db));
            kernel.Bind<IRepositoryBLL<IVote>>().To<VoteRepositoryBLL>();
            kernel.Bind<IVoteBLL>().To<VoteBLL>();

            //ViewBattl
            kernel.Bind<IRepository<IViewBattl>>().ToConstructor(ctorArg => new ViewBattlRepository(db));
            kernel.Bind<IRepositoryBLL<IViewBattl>>().To<ViewBattlRepositoryBLL>();

            //ViewBattlResults
            kernel.Bind<IRepository<IViewBattlResults>>().ToConstructor(ctorArg => new ViewBattlResultsRepository(db));
            kernel.Bind<IRepositoryBLL<IViewBattlResults>>().To<ViewBattlResultsRepositoryBLL>();

            //ViewArtistContact
            kernel.Bind<IRepository<IViewArtistContact>>().ToConstructor(ctorArg => new ViewArtistContactRepository(db));
            kernel.Bind<IRepositoryBLL<IViewArtistContact>>().To<ViewArtistContactRepositoryBLL>();
            kernel.Bind<IViewArtistContactBLL>().To<ViewArtistContactBLL>();

            //AccountBLL
            kernel.Bind<IRepository<IActivityLog>>().ToConstructor(ctorArg => new ActivityLogRepository(db));
            kernel.Bind<IRepositoryBLL<IActivityLog>>().To<ActivityLogRepositoryBLL>();

            //ILoadSongsViewModel
            //kernel.Bind<ILoadSongsViewModel>().To<LoadSongsViewModel>();

            //Usuario
            kernel.Bind<IUsuario>().To<Usuario>();
            kernel.Bind<IAlbum>().To<Album>();
            kernel.Bind<IArtist>().To<Artist>();
            kernel.Bind<IDiscography>().To<Discography>();
            kernel.Bind<ISong>().To<Song>();
        }
    }
}