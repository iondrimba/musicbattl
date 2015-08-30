(function ($) {
    /*
     * Translated default messages for the jQuery validation plugin.
     * Locale: PT
     */
    $.extend($.validator.messages, {
        required: "*field required",
        decimalRequired: "*field decimal maior que zero required",
        intRequired: "*field númerico required",
        email: "*Type in a valid e-mail",
        cpf: "*Digite um CPF válido",
        cnpj: "*Digite um CNPJ válido",
        url: "*Digite uma url válida",
        date: "*Type in a valida date",
        datebr: "*Digite uma data válida.",
        dateISO: "Por favor, escribe una fecha (ISO) válida.",
        number: "*Type in a valid number",
        digits: "*Only digits allowed",
        maxlength: $.validator.format("*field permite no máximo {0} caracteres."),
        minlength: $.validator.format("*field requer no minímo {0} caracteres."),
        rangelength: $.validator.format("*field requer um valor entre {0} e {1} caracteres."),
        range: $.validator.format("*field requer um valor entre {0} e {1}."),
        max: $.validator.format("*field requer um valor menor ou igual à {0}."),
        min: $.validator.format("*field requer um valor maior ou igual à {0}.")
    });

    $.validator.addMethod("cpf", function (value, element) {
        value = value.replace('.', '');
        value = value.replace('.', '');
        value = value.replace('-', '');

        var i = 0,
            s = value,
            c = s.substr(0, 9),
            dv = s.substr(9, 2),
            d1 = 0,
            v = false;

        for (i; i < 9; i += 1) {
            d1 += c.charAt(i) * (10 - i);
        }
        if (d1 == 0) {
            v = true;
            return false;
        }
        d1 = 11 - (d1 % 11);
        if (d1 > 9) d1 = 0;
        if (dv.charAt(0) != d1) {
            v = true;
            return false;
        }

        d1 *= 2;
        for (i = 0; i < 9; i++) {
            d1 += c.charAt(i) * (11 - i);
        }
        d1 = 11 - (d1 % 11);
        if (d1 > 9) d1 = 0;
        if (dv.charAt(1) != d1) {
            v = true;
            return false;
        }
        if (!v) {
            return true;
        }

        return retorno;
    });

    $.validator.addMethod("cnpj", function (value, element) {
        var str = value,
            cnpj, numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais;
        str = str.replace('.', '');
        str = str.replace('.', '');
        str = str.replace('-', '');
        str = str.replace('/', '');
        cnpj = str;

        digitos_iguais = 1;
        if (cnpj.length < 14 && cnpj.length < 15)
            return false;
        for (i = 0; i < cnpj.length - 1; i++)
            if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
                digitos_iguais = 0;
                break;
            }
        if (!digitos_iguais) {
            tamanho = cnpj.length - 2
            numeros = cnpj.substring(0, tamanho);
            digitos = cnpj.substring(tamanho);
            soma = 0;
            pos = tamanho - 7;
            for (i = tamanho; i >= 1; i--) {
                soma += numeros.charAt(tamanho - i) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(0))
                return false;
            tamanho = tamanho + 1;
            numeros = cnpj.substring(0, tamanho);
            soma = 0;
            pos = tamanho - 7;
            for (i = tamanho; i >= 1; i--) {
                soma += numeros.charAt(tamanho - i) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(1))
                return false;
            return true;
        }
        else
            return false;
    });

    //validar data formato pt-BR
    $.validator.addMethod("datebr", function (value, element) {
        if (value.length === 0) { return true; }

        //contando chars
        if (value.length !== 10) { return false; }

        // verificando data
        var data = value,
            dia = data.substr(0, 2),
            barra1 = data.substr(2, 1),
            mes = data.substr(3, 2),
            barra2 = data.substr(5, 1),
            ano = data.substr(6, 4);

        if (data.length !== 10 || barra1 !== "/" || barra2 !== "/" || isNaN(dia) || isNaN(mes) || isNaN(ano) || dia > 31 || mes > 12) { return false; }
        if ((mes === 4 || mes === 6 || mes === 9 || mes === 11) && dia === 31) { return false; }
        if (mes === 2 && (dia > 29 || (dia === 29 && ano % 4 !== 0))) { return false; }
        if (ano < 1900) { return false; }

        return true;
    }, "");

    //Validar range de data min-max
    $.validator.addMethod('rangeDate', function (value, element, param) {
        var dateValue,
            min,
            max,
            dateMin,
            dateMax,
            result;

        if (!value) {
            return true; // not testing 'is required' here!
        }

        try {
            dateValue = $.datepicker.parseDate("dd/mm/yy", value);
        } catch (e) {
            return false;
        }

        min = element.attributes["data-val-rangedate-min"].value;
        max = element.attributes["data-val-rangedate-max"].value;
        dateMin = $.datepicker.parseDate("yy/mm/dd", min);
        dateMax = $.datepicker.parseDate("yy/mm/dd", max);
        result = (dateMin <= dateValue && dateValue <= dateMax);

        return result;
    });

    //Validar int required
    $.validator.addMethod('intRequired', function (value, element) {
        var number = parseInt(value, 10),
            result = !isNaN(number) && (number > 0);

        return result;
    });

    //Validar decimal required
    $.validator.addMethod('decimalRequired', function (value, element) {
        var result = (parseFloat(value.replace(",", ".")) > 0.00);
        return result;
    });

    //digite apenas fields numericos
    $(".numbers-only").keydown(function (evt) {
        var code = parseInt(event.keyCode, 10);
        if (!(event.keyCode === 8                                // backspace
                || code === 46                              // delete
                || (code >= 35 && event.keyCode <= 40)     // arrow keys/home/end
                || (code >= 48 && event.keyCode <= 57)     // numbers on keyboard
                || (code >= 96 && event.keyCode <= 105))   // number on keypad
                ) {
            event.preventDefault();     // Prevent character input
        }
    });
}(jQuery));