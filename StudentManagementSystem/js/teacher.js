TeacherSetup = function () {

    var save = function () {
        var url = "../TeacherSetup/Save";

        var teacherId = $('#TeacherId').val();
        var teacherName = $('#TeacherName').val();
        var teacherAddress = $('#TeacherAddress').val();
        var teacherEmail = $('#TeacherEmail').val();
        var teacherContactNo = $('#TeacherContactNo').val();
        var designationId = $('#DesignationId').val();
        var departmentId = $('#DepartmentId').val();
        var teacherCredit = $('#TeacherCredit').val();


        if (teacherName == "" || teacherName == null) {
            alert("Teacher name required.");
            return;
        }
        if (teacherAddress == "" || teacherAddress == null) {
            alert("Teacher address required.");
            return;
        }
        if (teacherEmail == "" || teacherEmail == null) {
            alert("Teacher Email required");
            return;
        }
        if (teacherContactNo == "" || teacherContactNo == null)
        {
            alert("Contact number required.");
            return;
        }
        if (teacherCredit == "" || teacherCredit == null) {
            alert("teacherCredit required.");
            return;
        }
        console.log($('#TeacherContact').val());
        $.ajax({
            type: 'POST',
            url: url,
            data:
                {
                    TeacherId: teacherId,
                    TeacherName: teacherName,
                    TeacherAddress: teacherAddress,
                    TeacherEmail: teacherEmail,
                    TeacherContactNo: teacherContactNo,
                    DesignationId: designationId,
                    DepartmentId: departmentId,
                    TeacherCredit: teacherCredit
                },
            async: false,
            success: function (data) {
                alert("Saved Successfully.");
                clear();
                loadTeacher();
            },
            error: function () { }
        });
    };

    var clear = function () {
        $('#TeacherId').val("0");
        $('#TeacherName').val('');
        $('#TeacherAddress').val('');
        $('#TeacherEmail').val('');
        $('#TeacherContactNo').val('');
        $('#DesignationId').val('');
        $('#DepartmentId').val('');
        $('#TeacherCredit').val('');
    }

    var onEdit = function (teacherId) {
        var url = "../TeacherSetup/Get";
        $.ajax({
            type: 'GET',
            url: url,
            data: { teacherId },
            async: false,
            success: function (data) {
                $('#TeacherId').val(data.TeacherId);
                $('#TeacherName').val(data.TeacherName);
                $('#TeacherAddress').val(data.TeacherAddress);
                $('#TeacherEmail').val(data.TeacherEmail);
                $('#TeacherContactNo').val(data.TeacherContactNo);
                $('#DesignationId').val(data.DesignationId);
                $('#DepartmentId').val(data.DepartmentId);
                $('#TeacherCredit').val(data.TeacherCredit);
            },
            error: function () { }

        });
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    };

    var onDelete = function (teacherId) {
        var url = "../TeacherSetup/Delete";
        bootbox.confirm("Are you sure?", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { teacherId },
                    asynse: false,
                    success: function (data) {
                        clear();
                        loadTeacher();
                    },
                    error: function () { }
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
                $('#DepartmentId').append("<option value = ''>-----select-----<select>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#DepartmentId").append(option);
                })
            },
            error: function () { }
        });
    }
    var getAllDesignation = function () {
        var url = " ../Common/GetAllDesignation ";

        $.ajax({
            type: 'GET',
            url: url,
            data: {},
            async: false,
            success: function (data) {
                $('#DesignationId').append("<option value = ''>-----select-----<select>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#DesignationId").append(option);
                })
            },
            error: function () { }
        });
    }

    var loadTeacher = function () {
        var param = {}
        
        $.getJSON("../TeacherSetup/GetAll", param, function (data) {
            console.log(data)

            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.TeacherId + '</td>';
                row += '<td>' + item.TeacherName + '</td>';
                row += '<td>' + item.TeacherAddress + '</td>';
                row += '<td>' + item.TeacherEmail + '</td>';
                row += '<td>' + item.TeacherContactNo + '</td>';
                row += '<td>' + item.DesignationName + '</td>';
                row += '<td>' + item.DepartmentName + '</td>';
                row += '<td>' + item.TeacherCredit + '</td>';

                row += '<td><button class="btn btn-outline-info btn-xs" onclick = "TeacherSetup.onEdit(' + "\'" + item.TeacherId + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
                row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "TeacherSetup.onDelete(' + "\'" + item.TeacherId + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';

            });
            MakePaginationWithDataTableWithoutButton('TeacherTable', row);
        });
    };

    var eventInitialize = function () {
        $('#btnSave').click(save);
        $('#btnClear').click(clear);
    };

    return {
        init: function () {

            eventInitialize();
            loadTeacher();
            getAllDesignation();
            getAllDepartment();
        },
        onEdit: onEdit,
        onDelete: onDelete
    }

}();