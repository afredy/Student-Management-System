
var ShowNotification = function (type, message) {
    if (type === 0 && message == null)
        return;
    toastr.clear();
    var shortCutFunction = type == 1 ? "success" : type == 2 ? "info" : type == 3 ? "warning" : type == 4 ? "error" : "";
    var msg = message ? message : "";
    var title = type == 1 ? "Success" : type == 2 ? "Info" : type == 3 ? "Warning" : type == 4 ? "Error" : "";

    toastr.options = {
        closeButton: true,
        debug: false,
        newestOnTop: false,
        positionClass: 'toast-top-right',
        preventDuplicates: false,
        maxOpened: 1,
        autoDismiss: true,
        onclick: null
    };

    if ($('#addBehaviorOnToastClick').prop('checked')) {
        toastr.options.onclick = function () {
            alert('You can perform some custom action after a toast goes away');
        };
    }

    if (!msg) {
        msg = "I am customized toast";
    }

    var $toast = toastr[shortCutFunction](msg, title); // Wire up an event handler to a button in the toast, if it exists

    if (typeof $toast === 'undefined') {
        return;
    }
};