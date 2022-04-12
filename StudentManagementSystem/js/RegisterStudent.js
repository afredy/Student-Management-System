RegisterStudentSetup = function () {

    var save = function () {
        var url = "../RegisterStudent/Save";

        var studentId = $('#StudentId').val();
        var studentName = $('#StudentName').val();
        var email = $('#Email').val();
        var regNo = $('#RegNo').val();
        var contactNo = $('#ContactNo').val();
        var address = $('#Address').val();
        var departmentId = $('#DepartmentId').val();
        var date = $('#Date').val();

        if (studentName == "" || studentName == null) {
            alert("Student name required.");
            return;
        }

        if (email == "" || email == null) {
            alert("student email required.");
            return;
        }
        if (regNo == "" || regNo == null) {
            alert("registration number required.");
            return;
        }
        if (contactNo == "" || contactNo == null) {
            alert("contact number column needs to be fill up.");
            return;
        }
        if (address == "" || address == null) {
            alert("address column needs to be fill up.");
            return;
        }

        $.ajax({
            type: 'POST',
            url: url,
            data:
                {
                    StudentId: studentId,
                    StudentName: studentName,
                    Email: email,
                    RegNo: regNo,
                    ContactNo: contactNo,
                    Address: address,
                    DepartmentId: departmentId,
                    Date: date
                },
            async: false,
            success: function (data) {
                alert("Saved Successfully.");
                clear();
                loadRegisterStudent();
            },
            error: function () { }
        });
    };

    var clear = function () {

        $('#StudentId').val("0");
        $('#StudentName').val('');
        $('#Email').val('');
        $('#RegNo').val('');
        $('#ContactNo').val('');
        $('#Address').val('');
        $('#DepartmentId').val('');
        $('#Date').val('');

    }
    var onEdit = function (studentId) {
        var url = "../RegisterStudent/Get";
        $.ajax({
            type: 'GET',
            url: url,
            data: { studentId : studentId },
            async: false,
            success: function (data) {
                $('#StudentId').val(data.StudentId);
                $('#StudentName').val(data.StudentName);
                $('#Email').val(data.Email);
                $('#RegNo').val(data.RegNo);
                $('#ContactNo').val(data.ContactNo);
                $('#Address').val(data.Address);
                $('#DepartmentId').val(data.DepartmentId);
                $('#Date').val(data.Date);
            },
            error: function () { }

        });
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    };
    var onDelete = function (studentId) {
        var url = "../RegisterStudent/Delete";
        bootbox.confirm("Are you sure?", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { studentId },
                    asynse: false,
                    success: function (data) {
                        clear();
                        loadRegisterStudent();
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

    var loadRegisterStudent = function () {
        var param = {  }

        $.getJSON("../RegisterStudent/GetAll", param, function (data) {
           

            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.StudentId + '</td>';
                row += '<td>' + item.StudentName + '</td>';
                row += '<td>' + item.Email + '</td>';
                row += '<td>' + item.RegNo + '</td>';
                row += '<td>' + item.ContactNo + '</td>';
                row += '<td>' + item.Address + '</td>';
                row += '<td>' + item.DepartmentId + '</td>';
                row += '<td>' + item.Date + '</td>';
                
                row += '<td><button class="btn btn-outline-info btn-xs" onclick = "RegisterStudentSetup.onEdit(' + "\'" + item.StudentId + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
                row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "RegisterStudentSetup.onDelete(' + "\'" + item.StudentId + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';

            });
            MakePaginationWithDataTableWithoutButton('RegisterStudentTable', row);
        });
    };
  

    var eventInitialize = function () {
        $('#btnSave').click(save);
        $('#btnClear').click(clear);
        //$("#DepartmentId").change(departmentChanged);
        // $("#CourseId").change(getCourseDetails);
       // $("#DepartmentId").change(loadAllocateClassroom);
    };

    return {
        init: function () {

            eventInitialize();
            loadRegisterStudent();
            //getAllDay();
            //loadAssignCourse();
            // getAllTeacher();
            // getAllCourse();
            getAllDepartment();
        },
        onDelete: onDelete,
        onEdit: onEdit
    }

}();