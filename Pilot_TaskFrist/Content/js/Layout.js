$(document).ready(function () {
 
})

  
toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": true,
    "progressBar": false,
    "positionClass": "toast-top-left",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

function ShowMessage(type, title, message) {
    switch (type) {
        case 'success':
            toastr.success(title, message);
            break;
        case 'warning':
            toastr.warning(title, message);
            break;
        case 'error':
            toastr.error(title, message);
            break;
        default:
    }
}
function select2() {
    $('.select2').select2({
        theme: "bootstrap-5",
    });
}
function MasterDate() {

    var currentdate = new Date();

    var year = currentdate.getFullYear();
    var month = currentdate.getMonth() + 1;
    var day = currentdate.getDate();

    if (month <= 9) {
        month = '0' + month;
    }
    if (day <= 9) {
        day = '0' + day;
    }

    return year + '-' + month + '-' + day;

}

