EnrollStudentSetup = function () {

    var save = function () {
        var url = "../EnrollStudent/Save";

        var id = $('#EnrollStudentId').val();
        var semesterId = $('#SemesterId').val();
        var courseId = $('#CourseId').val();
        var regId = $('#RegId').val();
        var date = $('#Date').val();

        if (semesterId == "" || semesterId == null) {
            alert("Semester  required.");
            return;
        }

        if (courseId == "" || courseId == null) {
            alert("course required.");
            return;
        }
        if (date == "" || date == null) {
            alert("date required.");
            return;
        }
        $.ajax({
            type: 'POST',
            url: url,
            data:
                {
                    Id: id,
                    SemesterId: semesterId,
                    CourseId: courseId,
                    RegId: regId,
                    Date: date
                },
            async: false,
            success: function (data) {
                alert("Saved Successfully.");
                clear();
                loadEnrollStudent();
            },
            error: function () { }
        });
    };

    var clear = function () {

        $('#EnrollStudentId').val("0");
        $('#StudentName').val('');
        $('#Email').val('');
        $('#DepartmentId').val('');
        $('#SemesterId').val('');
        $('#CourseId').val('');
        $('#RegId').val("0");
        $('#Date').val('');
    }


    var onDelete = function (id) {
        var url = "../EnrollStudent/Delete";
        bootbox.confirm("Are you sure?", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { id: id },
                    asynse: false,
                    success: function (data) {
                        clear();
                        $("#DepartmentId").val('');
                        loadEnrollStudent('');
                    },
                    error: function () { }
                });
            }

        })


    }
    var onEdit = function (id) {
        var url = "../EnrollStudent/Get";
        $.ajax({
            type: 'GET',
            url: url,
            data: { id : id },
            async: false,
            success: function (data) {
                $('#EnrollStudentId').val(data.Id);
                $('#StudentName').val(data.StudentName);
                $('#Email').val(data.Email);
                $('#DepartmentId').val(data.DepartmentId);
                $('#SemesterId').val(data.SemesterId);
                $('#CourseId').val(data.CourseId);
                $('#RegId').val(data.RegNo);
                $('#Date').val(data.Date);
            },
            error: function () { }

        });
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    };
    var getAllRegistration = function () {
        var url = " ../Common/GetAllRegistration ";

        $.ajax({
            type: 'GET',
            url: url,
            data: {},
            async: false,
            success: function (data) {
                $('#RegId').append("<option value = ''>-----select-----</option>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#RegId").append(option);
                })
            },
            error: function () { }
        });
    }
    var getStudentsById = function (studentId) {
        var studentId = $('#RegId').val();
        console.log()
        var url = "../RegisterStudent/Get";
        $.ajax({
            type: 'GET',
            url: url,
            data: { studentId: studentId },
            async: false,
            success: function (data) {
                $('#StudentName').val(data.StudentName);
                $('#Email').val(data.Email);
                $('#DepartmentId').val(data.DepartmentId);
            },
            error: function () { }

        });
    };

    var getAllCourse = function () {
        var url = "../Common/GetAllCourseMassSelection";

        $.ajax({
            type: 'GET',
            url: url,
            data: { },
            async: false,
            success: function (data) {
                $('#CourseId').append("<option value = ''>-----select-----<select>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#CourseId").append(option);
                })
            },
            error: function () { }
        });
    }
    var getAllSemester = function () {
        var url = "../Common/GetAllSemester";

        $.ajax({
            type: 'GET',
            url: url,
            data: {  },
            async: false,
            success: function (data) {
                $('#SemesterId').append("<option value = ''>-----select-----<select>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#SemesterId").append(option);
                })
            },
            error: function () { }
        });
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
    var loadEnrollStudent = function (departmentId) {
        var departmentId = $("#DepartmentId").val();
        var param = { departmentId: departmentId }

        $.getJSON("../EnrollStudent/GetAll", param, function (data) {
            console.log(data)

            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.Id + '</td>';
                row += '<td>' + item.StudentName + '</td>';
                row += '<td>' + item.RegNo + '</td>';
                row += '<td>' + item.DepartmentName + '</td>';
                row += '<td>' + item.SemesterName + '</td>';
                row += '<td>' + item.CourseName + '</td>';
                row += '<td>' + item.Date + '</td>';



                row += '<td><button class="btn btn-outline-info btn-xs" onclick = "EnrollStudentSetup.onEdit(' + "\'" + item.Id + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
                row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "EnrollStudentSetup.onDelete(' + "\'" + item.Id + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';

            });
            MakePaginationWithDataTableWithoutButton('EnrollStudentTable', row);
        });
    };
    var RegistrationNumberChanged = function () {
        var regId = $("#RegId").val();
        getStudentsById(regId);
        
    }
    var DepartmentIdChanged = function () {
        var departmentId = $("#DepartmentId").val();
        loadEnrollStudent(departmentId);

    }

    var eventInitialize = function () {
        $('#btnSave').click(save);
        $('#btnClear').click(clear);
        $("#RegId").change(RegistrationNumberChanged);
        getAllCourse();
        //getAllDepartment();
        loadEnrollStudent();
        $("#DepartmentId").change(loadEnrollStudent);
    };

    return {
        init: function () {

            eventInitialize();
            getAllRegistration();
            getAllSemester();
            getAllDepartment();
        },
        onDelete: onDelete,
        onEdit : onEdit
    }

}();