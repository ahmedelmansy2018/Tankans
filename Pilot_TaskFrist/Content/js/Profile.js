var EditProfile = false;
$(document).ready(function () {
    MainData();
})
function MainData() {
    $.ajax({
        url: "/Home/_Profile",
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#MainData').css('display', 'none').html(data).fadeIn(1000);
            $('#MainData .table').dataTable({
                stateSave: true
            });
            $('table tbody tr').click(function () {
                $(this).siblings().css("background", "");
                $(this).css("background", "#8ee4ff");
            });
        },
        error: function () {
            window.location.href = '/Home/Error';
        }
    })
}
function AddProfile() {
    $('#ProfileData').html('ADD Profile Data');

    EditProfile = false;
    $('#Id').val('');
    $('#FirstName').val('');
    $('#LastName').val('');
    $('#Phone').val('');
    $('#Email').val('');
    $('#DateBirth').val(MasterDate());
    $('.mandatoryField').addClass('hide');
    $('#AddProfile').modal('show');
}
function EditProfileData(Id) {
    EditProfile = true;
    $('#ProfileData').html('Edit Profile Data');
    $('.mandatoryField').addClass('hide');
    $.ajax({
        url: "/Home/GetProfile",
        type: "GET",
        data: {
            ProfileID: Id
        },
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#FirstName').val(data.FirstName);
            $('#LastName').val(data.LastName);
            $('#Phone').val(data.Phone);
            $('#Email').val(data.Email);
            $('#DateBirth').val(data.DateBirth);
            $('#AddProfile').modal('show');
        },
        error: function () {
            window.location.href = '/Home/Error';
        }
    })
}
function DeleteProfile(Id, FirstName, LastName) {
    $('#DeleteProfileID').val(Id);
    $('#DeleteProfileName').html(FirstName + " " + LastName);
    $('#DeleteProfile').modal('show');
}
function ConfirmDelete() {
    var Id = $('#DeleteProfileID').val();
    $.ajax({
        url: "/Home/DeleteProfile",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        data: {
            ProfileID: Id
        },
        success: function (data) {
            MainData();
            $('#DeleteProfile').modal('hide');
            if (data.Message == "false") {
                ShowMessage("warning", "", "This Record Related Another Data")
            } else {
                ShowMessage("success", "", data.Message)
            }
        },
        error: function () {
            window.location.href = '/Home/Error';
        }
    })
}
function SaveProfile() {
    $('.mandatoryField').addClass('hide');
    var valid = true;
    var Id = $('#Id').val();
    var FirstName = $('#FirstName').val().trim();
    var LastName = $('#LastName').val().trim();
    var DateBirth = $('#DateBirth').val();
    var Phone = $('#Phone').val().trim();
    var Email = $('#Email').val().trim();
    if (FirstName == '') {
        valid = false;
        $('#FirstNameError').removeClass('hide');
    }
    if (DateBirth == '') {
        valid = false;
        $('#DateBirthError').removeClass('hide');
    }
    if (LastName == '') {
        valid = false;
        $('#LastNameError').removeClass('hide');
    } if (Email == '') {
        valid = false;
        $('#EmailError').removeClass('hide');
    } if (Phone == '') {
        valid = false;
        $('#PhoneError').removeClass('hide');
    }
    if (valid == false) {
        return;
    }
    var Profile = {
        Id: Id,
        FirstName: FirstName,
        LastName: LastName,
        DateBirth: DateBirth,
        Email: Email,
        Phone: Phone,
    }
    if (EditProfile == false) {
        $.ajax({
            url: "/Home/AddProfile",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(Profile),
            success: function (data) {
                if (data.Result) {
                    MainData();
                    $('#tr-' + data.Result).siblings().css("background", "");
                    $('#tr-' + data.Result).css("background", "#8ee4ff");
                    $('#AddProfile').modal('hide');
                }
                ShowMessage("success", "", data.Message)
            },
            error: function () {
                window.location.href = '/Home/Error';
            }
        })
    }
    else {
        $.ajax({
            url: "/Home/UpdateProfile",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(Profile),
            success: function (data) {
                if (data.Result) {
                    MainData();
                    $('#tr-' + Id).siblings().css("background", "");
                    $('#tr-' + Id).css("background", "#8ee4ff");
                    $('#AddProfile').modal('hide');
                }
                ShowMessage("success", "", data.Message)
            },
            error: function () {
                window.location.href = '/Home/Error';
            }
        })
    }
}
