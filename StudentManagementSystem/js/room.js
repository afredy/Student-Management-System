var Roomsetup = function () {

    var save = function () {
        var url = "../RoomSetup/Save";
        var roomId = $('#RoomId').val();
        var roomCode = $('#RoomCode').val();
        var roomDetails = $('#RoomDetails').val();
        var departmentId = $('#DepartmentId').val();

        if (roomId == "" || roomId == null) {
            alert("room id required");
            return;
        }
        if (roomCode == "" || roomCode == null) {
            alert("room code required");
            return;
        }

        $.ajax({
            type: 'POST',
            url: url,
            data: {
                RoomId: roomId,
                RoomCode: roomCode,
                RoomDetails: roomDetails,
                DepartmentId: departmentId
            },
            async: false,
            success: function (data) {
                alert("Room Saved Successfully");
                clear();
                loadRoom();
            },
            error: function () { }



        });


    };
    var clear = function () {
        $('#RoomId').val("0");
        $('#RoomCode').val('');
        $('#RoomDetails').val('');
        $('#DepartmentId').val('');

    }

    var onEdit = function (roomId) {
        var url = "../RoomSetup/Get";
        $.ajax({

            type: 'GET',
            url: url,
            data: { roomId: roomId },
            async: false,
            success: function (data) {
                $('#RoomId').val(data.RoomId);
                $('#RoomCode').val(data.RoomCode);
                $('#RoomDetails').val(data.RoomDetails);
                $('#DepartmentId').val(data.DepartmentId);
            },
            error: function (data) { }
        });
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    };

    var onDelete = function (roomId) {
        var url = "../RoomSetup/Delete";
        bootbox.confirm("Are you sure", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { roomId: roomId },
                    async: false,
                    success: function (data) {
                        clear();
                        loadRoom();
                    }, error: function () { }

                });
            }
        })
    }
    var getAllDepartment = function () {
        var url = " ../Common/GetAllDepartment ";

        $.ajax({
            type: 'GET',
            url: url,
            data: {},
            async: false,
            success: function (data) {
                $('#DepartmentId').append("<option value = ''>-----select-----</option>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#DepartmentId").append(option);
                })
            },
            error: function () { }
        });
    }
    var loadRoom = function () {
        var param = {}
        $.getJSON("../RoomSetup/GetAll", param, function (data) {
            console.log(data);
            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.RoomId + '</td>';
                row += '<td>' + item.RoomCode + '</td>';
                row += '<td>' + item.RoomDetails + '</td>';
                row += '<td>' + item.DepartmentName + '</td>';

                row += '<td><button class="btn btn-outline-info btn-xs" onclick = "Roomsetup.onEdit(' + "\'" + item.RoomId + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
                row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "Roomsetup.onDelete(' + "\'" + item.RoomId + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';
            });
            MakePaginationWithDataTableWithoutButton('RoomTable', row);


        });
    }

    var eventInitialize = function () {

        $('#btnSave').click(save);
        $('#btnClear').click(clear);
    };
    return {

        init: function () {

            eventInitialize();
            loadRoom();
            getAllDepartment();
        },
        onEdit: onEdit,
        onDelete: onDelete
    };

}();