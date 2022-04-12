StudentResult = function () {

    var save = function () {
        var url = "../StudentResult/Save";

        var id = $('#Id').val();
        var semesterId = $('#SemesterId').val();
        var courseId = $('#CourseId').val();
        var regNo = $('#RegId').val();
        var gradeId = $('#GradeId').val();

        if (semesterId == "" || semesterId == null) {
            alert("Semester  required.");
            return;
        }

        if (courseId == "" || courseId == null) {
            alert("course required.");
            return;
        }
        if (gradeId == "" || gradeId == null) {
            alert("Grade required.");
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
                    RegNo: regNo,
                    GradeId: gradeId
                },
            async: false,
            success: function (data) {
                alert("Saved Successfully.");
                clear();
                loadStudentResult();
            },
            error: function () { }
        });
    };

    var clear = function () {

        $('#Id').val('');
        $('#RegId').val('');
        $('#StudentName').val('');
        $('#Email').val('');
        $('#DepartmentId').val('');
        $('#SemesterId').val('');
        $('#CourseId').val('');
        $('#GradeId').val('');


    }


    var onDelete = function (id) {
        var url = "../StudentResult/Delete";
        bootbox.confirm("Are you sure?", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { id: id },
                    asynse: false,
                    success: function (data) {
                        clear();
                        loadStudentResult();
                    },
                    error: function () { }
                });
            }

        })


    }
    var onEdit = function (id) {
        var url = "../StudentResult/Get";
        $.ajax({
            type: 'GET',
            url: url,
            data: { id: id },
            async: false,
            success: function (data) {
                $('#Id').val(data.Id);
                $('#RegId').val(data.RegNo);
                $('#StudentName').val(data.SemesterName);
                $('#Email').val(data.Email);
                $('#DepartmentId').val(data.DepartmentId);
                $('#SemesterId').val(data.SemesterId);
                $('#CourseId').val(data.CourseId);
                $('#GradeId').val(data.GradeId);
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
        console.log(studentId)
        var url = "../RegisterStudent/Get";
       
        $.ajax({
            type: 'GET',
            url: url,
            data: { studentId: studentId },
            async: false,
            success: function (data) {
                $('#StudentName').val(data.StudentName);
                $('#Email').val(data.Email);
                $('#DepartmentId').val(data.DepartmentName);
            },
            error: function () { }

        });
    };

    var getAllCourse = function () {
        var url = "../Common/GetAllCourseMassSelection";

        $.ajax({
            type: 'GET',
            url: url,
            data: {},
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
            data: {},
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
    var getAllGrade = function () {
        var url = "../Common/GetAllGrade";

        $.ajax({
            type: 'GET',
            url: url,
            data: {},
            async: false,
            success: function (data) {
                $('#GradeId').append("<option value = ''>-----select-----<select>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#GradeId").append(option);
                })
            },
            error: function () { }
        });
    }
    //var getAllDepartment = function () {
    //    var url = " ../Common/GetAllDepartment ";

    //    $.ajax({
    //        type: 'GET',
    //        url: url,
    //        data: {},
    //        async: false,
    //        success: function (data) {
    //            $('#DepartmentId').append("<option value = ''>-----select-----</option>");
    //            $.each(data, function (index, item) {
    //                var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
    //                $("#DepartmentId").append(option);
    //            })
    //        },
    //        error: function () { }
    //    });
    //}
    var RegistrationNumberChanged = function () {
        var regId = $("#RegId").val();
        getStudentsById(regId);

    }
    var loadStudentResult = function () {
        var param = {  }

        $.getJSON("../StudentResult/GetAll", param, function (data) {
            console.log(data)

            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.Id + '</td>';
                row += '<td>' + item.StudentName + '</td>';
                row += '<td>' + item.RegNo + '</td>';
                row += '<td>' + item.DepartmentName + '</td>';
                row += '<td>' + item.CourseName + '</td>';
                row += '<td>' + item.GradeName + '</td>';



                row += '<td><button class="btn btn-outline-info btn-xs" onclick = "StudentResult.onEdit(' + "\'" + item.Id + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
                row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "StudentResult.onDelete(' + "\'" + item.Id + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';

            });
            MakePaginationWithDataTableWithoutButton('ResultTable', row);
        });
    };
   

    var eventInitialize = function () {
        $('#btnSave').click(save);
        $('#btnClear').click(clear);
        $("#RegId").change(RegistrationNumberChanged);
        getAllCourse();
        //getAllDepartment();
        loadStudentResult();
        getAllGrade();
    };

    return {
        init: function () {

            eventInitialize();
            getAllRegistration();
            getAllSemester();
        },
        onDelete: onDelete,
        onEdit: onEdit
    }

}();