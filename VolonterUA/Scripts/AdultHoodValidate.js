$(function () {
    jQuery.validator.addMethod('adulthoodvalidate', function (value, element, params) {
        var today = new Date();
        var adultMaxBirthday = today.setMonth(today.getMonth() - 12 * params["adultyears"]);
        var dateValue = new Date(value);
        if (dateValue < adultMaxBirthday)
            return true;
        else
            return false;
    });

    jQuery.validator.unobtrusive.adapters.add('adulthoodvalidate', ['adultyears'], function (options) {
        var params = {
            adultyears: options.params.adultyears
        };

        options.rules['adulthoodvalidate'] = params;
        if (options.message) {
            options.messages['adulthoodvalidate'] = options.message;
        }
    });
    /*End*/

}(jQuery));