$(document).ready(function () {
    $('#tbGeneric').DataTable({
        fixedHeader: true,
        initComplete: function () {
            
        },
        "aaSorting": [0, 'desc']
    });

    $('#tbBad').DataTable({
        "aaSorting": [0,'desc']
    });
});

$('[data-toggle="tooltip"]').tooltip();

$("#voy-alert").hide();
$("#msg-alert").hide();

$('#voy-alert').addClass("alert alert-success");

$("#voy-alert").fadeTo(2000, 500).slideUp(500, function () {
    $("#voy-alert").slideUp(500);
});

$('#bad-alert').addClass("alert alert-success");
$("#bad-alert").fadeTo(2000, 500).slideUp(500, function () {
    $("#bad-alert").slideUp(500);
});

$('#ct-alert').addClass("alert alert-success");
$("#ct-alert").fadeTo(2000, 500).slideUp(500, function () {
    $("#ct-alert").slideUp(500);
});

function btnSaveAndSend(id) {

    $.ajax({
        url: `/Bad/GetBadByID/${id}`,
        type: 'GET',
        contentType: 'application/json;charset=utf-8',  
        dataType: 'json',
        success: function (result) {
            //console.log(result);
            $('#badID').val(id);
            $('#exampleModal').modal('show');
        },
        error: function (err) {
            console.log(err);
        }

    })

}

function submitConfirmSaveAndSend() {
    let id = $('#badID').val();
    let modalPassword = $('#inputPassword').val()
    $.ajax({
        url: `/Bad/SaveAndSend/${id}`,
        type: 'GET',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        data: { modalPassword: modalPassword },
        success: function (result) {
            //console.log(result);

            $('#exampleModal').modal('hide');
            if (result.Success == "Success") {
                $('#btnSaveAndSend').prop('disabled', true);
                $('#createContainer').hide();

                successAlert(result.Success, result.Message);
            }

            failedAlert(result.Success, result.Message);
        },
        error: function (err) {
            console.log(err);
        }
    })
    $('#exampleModal').modal('hide');
}

function saveVoyageSubmit() {
    console.log("saveVoyageSubmit");

    var data = $('#addVoyageForm').serialize();
    $.ajax({
        type: 'POST',
        url: '/Voyage/CreateVoyage',
        data: data,
        success: function (res) {
            if (res == "success") {
                $('#form-modal').modal('hide')
                var msg = "Voyage is added successfully";
                successAlert("Success", msg);
            }
        },
        error: function (err) {
            var msg = "Failure to add travel";
            failedAlert("Failed", msg);
        }
    })
}

function successAlert(title, msg) {
    $('#isSuccess').text(title);
    $('#message').text(msg);

    $('#msg-alert').addClass("alert alert-success");

    $("#msg-alert").fadeTo(2000, 500).slideUp(500, function () {
        $("#msg-alert").slideUp(500);
    });
}

function failedAlert(title, msg) {
    $('#isSuccess').text(title);
    $('#message').text(msg);

    $('#msg-alert').addClass("alert alert-warning");

    $("#msg-alert").fadeTo(2000, 500).slideUp(500, function () {
        $("#msg-alert").slideUp(500);
    });
}
