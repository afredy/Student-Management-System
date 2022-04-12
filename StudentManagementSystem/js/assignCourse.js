AssignCourseSetup = function () {

    var save = function () {
        var url = "../AssignCourseSetup/Save";

        var id = $('#Id').val();
        var teacherId = $('#TeacherId').val();
        var courseId = $('#CourseId').val();


      
        if (teacherId == "" || teacherId == null) {
            alert("Teacher  required.");
            return;
        }
       
        if (courseId == "" || courseId == null) {
            alert("course required.");
            return;
        }

        $.ajax({
            type: 'POST',
            url: url,
            data:
                {
                    Id: id,
                    TeacherId: teacherId,
                    CourseId: courseId,
                },
            async: false,
            success: function (data) {
                alert("Saved Successfully.");
                clear();
                loadAssignCourse();
            },
            error: function () { }
        });
    };

    var clear = function () {

        $('#Id').val("0");
        $('#DepartmentId').val('');
        $('#TeacherId').val('');
        $('#TeacherCredit').val("");
        $('#CreditTaken').val("");
        $('#RemainingCredit').val("");
        $('#CourseId').val('');
        $('#CourseName').val('');
        $('#CourseCredit').val('');
    }
    var getCreditDetails = function (Id) {
        var url = "../AssignCourseSetup/GetCreditDetails";
        $.ajax({
            type: 'GET',
            url: url,
            data: { Id },
            async: false,
            success: function (data) {
                $('#CreditTaken').val(data.TeacherCredit);
                $('#RemaningCredit').val(data.RemaningCredit);

            }, error: function () { }


        });
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    }
    var getCourseDetails = function () {
        var courseId = $("#CourseId").val();

        var url = "../CourseSetup/Get";
        $.ajax({
            type: 'GET',
            url: url,
            data: { courseId: courseId },
            async: false,
            success: function (data) {
                $('#CourseName').val(data.CourseName);
                $('#CourseCredit').val(data.CourseCredit);

            }, error: function () { }


        });
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    }

    var onDelete = function (id) {
        var url = "../AssignCourseSetup/Delete";
        bootbox.confirm("Are you sure?", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { id },
                    asynse: false,
                    success: function (data) {
                        clear();
                        loadAssignCourse();
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
                $('#DepartmentId').append("<option value = ''>-----select-----</option>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#DepartmentId").append(option);
                })
            },
            error: function () { }
        });
    }
    var getTeacherCreditDetailById = function () {
        var teacherId = $('#TeacherId').val();
        var url = "../TeacherSetup/GetTeacherCreditDetailById";
        $.ajax({
            type: 'GET',
            url: url,
            data: { teacherId: teacherId },
            async: false,
            success: function (data) {
                $('#TeacherCredit').val(data.TeacherCredit);
                $('#CreditTaken').val(data.CreditTaken);
                $('#RemainingCredit').val(data.RemainingCredit);
            },
            error: function () { }

        });
    };

    var getAllTeacher = function (departmentId) {
        var departmentId = $("#DepartmentId").val();
        var url = " ../Common/GetAllTeacher";

        $.ajax({
            type: 'GET',
            url: url,
            data: { departmentId: departmentId },
            async: false,
            success: function (data) {
                $('#TeacherId').append("<option value = ''>-----select-----<select>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#TeacherId").append(option);
                 
                })
            },
            error: function () { }
        });
    }
    var getAllCourse = function (departmentId) {
        var departmentId = $("#DepartmentId").val();
        var url = "../Common/GetAllCourse";

        $.ajax({
            type: 'GET',
            url: url,
            data: { departmentId: departmentId },
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
    var loadAssignCourse = function (departmentId) {
        var departmentId = $("#DepartmentId").val();
        var param = { departmentId: departmentId }

        $.getJSON("../AssignCourseSetup/GetAll", param, function (data) {
            console.log(data)

            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.Id + '</td>';
                row += '<td>' + item.CourseCode + '</td>';
                row += '<td>' + item.CourseName + '</td>';
                row += '<td>' + item.SemesterName + '</td>';
                row += '<td>' + item.TeacherName + '</td>';

                //row += '<td><button class="btn btn-outline-info btn-xs" onclick = "TeacherSetup.onEdit(' + "\'" + item.TeacherId + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
                row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "AssignCourseSetup.onDelete(' + "\'" + item.Id + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';

            });
            MakePaginationWithDataTableWithoutButton('AssignCourseTable', row);
        });
    };
    var departmentChanged = function () {
        var departmentId = $("#DepartmentId").val();
        $('#TeacherCredit').val("");
        $('#CreditTaken').val("");
        $('#RemainingCredit').val("");
        $("#TeacherId").empty();
        getAllTeacher(departmentId);
        getAllCourse(departmentId);
    }


    var eventInitialize = function () {
        $('#btnSave').click(save);
        $('#btnClear').click(clear);
        $("#DepartmentId").change(departmentChanged);
        $("#TeacherId").change(getTeacherCreditDetailById);
        $("#CourseId").change(getCourseDetails);
        $("#DepartmentId").change(loadAssignCourse);
    };

    return {
        init: function () {

            eventInitialize();
            //loadAssignCourse();
            // getAllTeacher();
           // getAllCourse();
            getAllDepartment();
        },
        onDelete: onDelete
    }

}();