var Edittask = false;
$(document).ready(function () {
    MainData();
})
function MainData() {
    $.ajax({
        url: "/Home/_task",
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
function Addtask() {
    $('#taskData').html('ADD Task Data');
    Edittask = false;
    GetProfiles();
    select2();
    $('#Id').val('');
    $('#TaskName').val('');
    $('#TaskDescription').val('');
    $('#StartTime').val(MasterDate());
    $('.mandatoryField').addClass('hide');
    $('#Addtask').modal('show');
}
function EdittaskData(Id) {
    $('#taskData').html('Edit Task Data');
    GetProfiles();
    select2();
    Edittask = true;
    $('.mandatoryField').addClass('hide');
    $.ajax({
        url: "/Home/Gettask",
        type: "GET",
        data: {
            taskID: Id
        },
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#TaskName').val(data.TaskName);
            $('#TaskDescription').val(data.TaskDescription);
            $('#StartTime').val(data.StartTime);
            $('#Status').val(data.Status);
            $('#FkprofileId').val(data.FkprofileId);
            $('#Addtask').modal('show');
        },
        error: function () {
            window.location.href = '/Home/Error';
        }
    })
}
function Deletetask(Id, TaskName) {
    $('#DeletetaskID').val(Id);
    $('#DeletetaskName').html(TaskName);
    $('#Deletetask').modal('show');
}
function ConfirmDelete() {
    var Id = $('#DeletetaskID').val();
    $.ajax({
        url: "/Home/Deletetask",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        data: {
            taskID: Id
        },
        success: function (data) {
            if (data.Result) {
                ShowMessage("success", "", data.Message)
                MainData();
                $('#Deletetask').modal('hide');
            }
            else
                //ShowMessage("warning", "", "This Record Related Another Data")
                ShowMessage("warning", "", data.Message)
        },
        error: function () {
            window.location.href = '/Home/Error';
        }
    })
}
function Savetask() {
    $('.mandatoryField').addClass('hide');
    var valid = true;
    var Id = $('#Id').val();
    var FkprofileId = $('#FkprofileId').val();
    var TaskName = $('#TaskName').val().trim();
    var TaskDescription = $('#TaskDescription').val().trim();
    var StartTime = $('#StartTime').val();
    var Status = $('#Status').val();
    if (TaskName == '') {
        valid = false;
        $('#TaskNameError').removeClass('hide');
    }
    if (StartTime == '') {
        valid = false;
        $('#StartTimeError').removeClass('hide');
    }
    if (TaskDescription == '') {
        valid = false;
        $('#TaskDescriptionError').removeClass('hide');
    }
    if (valid == false) {
        return;
    }
    var task = {
        Id: Id,
        FkprofileId: FkprofileId,
        TaskName: TaskName,
        StartTime: StartTime,
        TaskDescription: TaskDescription,
        Status: Status,
    }
    if (Edittask == false) {
        $.ajax({
            url: "/Home/Addtask",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(task),
            success: function (data) {
                if (data.Result) {
                    MainData();
                    $('#tr-' + data.Result).siblings().css("background", "");
                    $('#tr-' + data.Result).css("background", "#8ee4ff");
                    $('#Addtask').modal('hide');
                    ShowMessage("success", "", data.Message)
                }
                else {
                    ShowMessage("warning", "", data.Message)
                }
            },
            error: function () {
                window.location.href = '/Home/Error';
            }
        })
    }
    else {
        $.ajax({
            url: "/Home/Updatetask",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(task),
            success: function (data) {
                if (data.Result) {
                    MainData();
                    $('#tr-' + Id).siblings().css("background", "");
                    $('#tr-' + Id).css("background", "#8ee4ff");
                    $('#Addtask').modal('hide');
                    ShowMessage("success", "", data.Message)
                }
                else {
                    ShowMessage("warning", "", data.Message)
                }
            },
            error: function () {
                window.location.href = '/Home/Error';
            }
        })
    }
}
function GetProfiles() {
    $.ajax({
        url: "/Home/_GetAllProfile",
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#profileId').html(data);
        },
        error: function () {
            window.location.href = '/Home/Error';
        }
    });
}
