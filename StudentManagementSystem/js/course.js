CourseSetup = function () {

    var save = function () {
        var url = "../CourseSetup/Save";

        var courseId = $('#CourseId').val();
        var courseCode = $('#CourseCode').val();
        var courseName = $('#CourseName').val();
        var courseCredit =$('#CourseCredit').val();
        var discription = $('#Discription').val();
        var departmentId = $('#DepartmentId').val();
        var semesterId = $('#SemesterId').val();

        if (courseCode == "" || courseCode == null) {
            alert("course code required.");
            return;
        }
        if (courseName == "" || courseName == null) {
            alert("course name required.");
            return;
        }
        if (courseCredit == "" || courseCredit == null || parseInt(courseCredit) < 1 || parseInt(courseCredit) > 9) {
            alert("course credit required or course credit must be in range between 1 to 9.");
            return;
        }
        if (discription == "" || discription == null) {
            alert("discription required.");
            return;
        }

        $.ajax({
            type: 'POST',
            url: url,
            data:
                {
                    CourseId: courseId,
                    CourseCode: courseCode,
                    CourseName: courseName,
                    CourseCredit: courseCredit,
                    Discription: discription,
                    DepartmentId: departmentId,
                    SemesterId: semesterId,
                },
            async: false,
            success: function (data) {
                clear();
                loadCourse();
            },
            error: function () { }
        });
    };

    var clear = function () {
        $('#CourseId').val("0");
        $('#CourseCode').val('');
        $('#CourseName').val('');
        $('#CourseCredit').val('');
        $('#Discription').val('');
        $('#DepartmentId').val('');
        $('#SemesterId').val('');
    }

    var onEdit = function (courseId) {
        var url = "../CourseSetup/Get";
        $.ajax({
            type: 'GET',
            url: url,
            data: { courseId },
            async: false,
            success: function (data) {
                $('#CourseId').val(data.CourseId);
                $('#CourseCode').val(data.CourseCode);
                $('#CourseName').val(data.CourseName);
                $('#CourseCredit').val(data.CourseCredit);
                $('#Discription').val(data.Discription);
                $('#DepartmentId').val(data.DepartmentId);
                $('#SemesterId').val(data.SemesterId);
            },
            error: function () { }

        });
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    };

    var onDelete = function (courseId) {
        var url = "../CourseSetup/Delete";
        bootbox.confirm("Are you sure?", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { courseId: courseId },
                    asynse: false,
                    success: function (data) {
                        clear();
                        loadCourse();
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
    var getAllSemester = function () {
        var url = " ../Common/GetAllSemester ";

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

    var loadCourse = function () {
        var param = {}
        $.getJSON("../CourseSetup/GetAll", param, function (data) {


            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.CourseId + '</td>';
                row += '<td>' + item.CourseCode + '</td>';
                row += '<td>' + item.CourseName + '</td>';
                row += '<td>' + item.CourseCredit + '</td>';
                row += '<td>' + item.Discription + '</td>';
                row += '<td>' + item.DepartmentName + '</td>';
                row += '<td>' + item.SemesterName + '</td>';

                row += '<td><button class="btn btn-outline-info btn-xs" onclick = "CourseSetup.onEdit(' + "\'" + item.CourseId + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
                row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "CourseSetup.onDelete(' + "\'" + item.CourseId + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';

            });
            MakePaginationWithDataTableWithoutButton('CourseTable', row);
        });
    };

    var eventInitialize = function () {
        $('#btnSave').click(save);
        $('#btnClear').click(clear);
    };

    return {
        init: function () {

            eventInitialize();
            loadCourse();
            getAllSemester();
            getAllDepartment();
        },
        onEdit: onEdit,
        onDelete: onDelete
    }

}();