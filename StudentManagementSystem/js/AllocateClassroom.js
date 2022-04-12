AllocateClassroomSetup = function () {

    var save = function () {
        var url = "../AllocateRoomSetup/Save";

        var classId = $('#ClassId').val();
        var courseId = $('#CourseId').val();
        var roomId = $('#RoomId').val();
        var dayId = $('#DayId').val();
        var from = $('#From').val();
        var to = $('#To').val();

        if (courseId == "" || courseId == null) {
            alert("course id required.");
            return;
        }

        if (roomId == "" || roomId == null) {
            alert("room id required.");
            return;
        }
        if (dayId == "" || dayId == null) {
            alert("day name required.");
            return;
        }
        if (from == "" || from == null) {
            alert("from column needs to be fill up.");
            return;
        }
        if (to == "" || to == null) {
            alert("To column needs to be fill up.");
            return;
        }
        $.ajax({
            type: 'POST',
            url: url,
            data:
                {
                    ClassId: classId,
                    CourseId: courseId,
                    RoomId: roomId,
                    DayId: dayId,
                    From: from,
                    To: to
                },
            async: false,
            success: function (data) {
                alert("Saved Successfully.");
                clear();
                loadAllocateClassroom();
            },
            error: function () { }
        });
    };

    var clear = function () {

        $('#ClassId').val("0");
        $('#CourseId').val('');
        $('#RoomId').val('');
        $('#DayId').val('');
        $('#From').val('');
        $('#To').val('');
    }
   
    var onDelete = function (classId) {
        var url = "../AllocateRoomSetup/Delete";
        bootbox.confirm("Are you sure?", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { classId },
                    asynse: false,
                    success: function (data) {
                        clear();
                        loadAllocateClassroom();
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

    var GetAllRoom = function (departmentId) {
        var departmentId = $("#DepartmentId").val();
        var url = " ../Common/GetAllRoom";

        $.ajax({
            type: 'GET',
            url: url,
            data: { departmentId: departmentId },
            async: false,
            success: function (data) {
                $('#RoomId').append("<option value = ''>-----select-----<select>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#RoomId").append(option);

                })
            },
            error: function () { }
        });
    }
    var getAllDay = function () {
        var url = "../Common/GetAllDay";

        $.ajax({
            type: 'GET',
            url: url,
            data: { },
            async: false,
            success: function (data) {
                $('#DayId').append("<option value = ''>-----select-----<select>");
                $.each(data, function (index, item) {
                    var option = "<option value='" + item.Value + "'>" + item.Text + "</option>"
                    $("#DayId").append(option);
                })
            },
            error: function () { }
        });
    }
    var loadAllocateClassroom = function (departmentId) {
        var departmentId = $("#DepartmentId").val();
        var param = { departmentId: departmentId }

        $.getJSON("../AllocateRoomSetup/GetAll", param, function (data) {
            console.log(data)

            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.ClassId + '</td>';
                row += '<td>' + item.CourseCode + '</td>';
                row += '<td>' + item.CourseName + '</td>';
                row += '<td>' + item.RoomDetails +','+ item.DayName+',' + item.From+' To ' + item.To + '</td>';
                

                //row += '<td><button class="btn btn-outline-info btn-xs" onclick = "TeacherSetup.onEdit(' + "\'" + item.TeacherId + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
                row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "AllocateClassroomSetup.onDelete(' + "\'" + item.ClassId + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';

            });
            MakePaginationWithDataTableWithoutButton('AllocateClassroomTable', row);
        });
    };
    var departmentChanged = function () {
        var departmentId = $("#DepartmentId").val();
       
        GetAllRoom(departmentId);
        getAllCourse(departmentId);
    }


    var eventInitialize = function () {
        $('#btnSave').click(save);
        $('#btnClear').click(clear);
        $("#DepartmentId").change(departmentChanged);
       // $("#CourseId").change(getCourseDetails);
        $("#DepartmentId").change(loadAllocateClassroom);
    };

    return {
        init: function () {

            eventInitialize();
            getAllDay();
            //loadAssignCourse();
            // getAllTeacher();
            // getAllCourse();
            getAllDepartment();
        },
        onDelete: onDelete
    }

}();