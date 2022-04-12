var Semestersetup = function () {

    var save = function () {

        var url = "../SemesterSetup/Save";
        var semesterId = $('#SemesterId').val();
        var semesterName = $('#SemesterName').val();

        if (semesterName == "" || semesterName == null) {
            alert("semester name required.");
            return;
        }
        $.ajax({
            type: 'POST',
            url: url,
            data:
                {
                    SemesterId: semesterId,
                    SemesterName: semesterName
                },
            async: false,
            success: function (data) {
                alert("Semester saved Successfully");
                clear();
                loadSemester();
            },
            error: function () { }
        });

    };
    var clear = function ()
    {
        $('#SemesterId').val("0");
        $('#SemesterName').val('');
    }

    var onEdit = function (SemesterId) {
        var url = "../SemesterSetup/Get";
        $.ajax({
            type: 'GET',
            url: url,
            data: { SemesterId: SemesterId },
            async: false,
            success: function (data) {
                $('#SemesterId').val(data.SemesterId);
                $('#SemesterName').val(data.SemesterName);
            },
            error: function () { }

        });
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    };
    var onDelete = function (SemesterId)
    {
        var url = "../SemesterSetup/Delete";

        bootbox.confirm("Are you sure", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { SemesterId: SemesterId },
                    async: false,
                    success: function (data) {
                        alert("Deleted Successfully");
                        clear();
                        loadSemester();
                    }, error: function () { }
                })
            }
        })
    }

    var loadSemester = function ()
    {
        var param = {}
        $.getJSON("../SemesterSetup/GetAll", param, function (data) {
            console.log(data);
            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.SemesterId + '</td>';
                row += '<td>' + item.SemesterName + '</td>';

                row += '<td><button class="btn btn-outline-info btn-xs" onclick = "Semestersetup.onEdit(' + "\'" + item.SemesterId + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
                row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "Semestersetup.onDelete(' + "\'" + item.SemesterId + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';
            });
            MakePaginationWithDataTableWithoutButton('SemesterTable', row);
        });
    }

    var eventInitialize = function () {

        $('#btnSave').click(save);
        $('#btnClear').click(clear);
    };
    return {

        init: function () {
            eventInitialize();
            loadSemester();
        },
        onEdit: onEdit,
        onDelete: onDelete
    };

}();