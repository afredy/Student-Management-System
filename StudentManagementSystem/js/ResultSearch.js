ResultSearch = function () {

   

    var clear = function () {

        $('#RegId').val('');
        $('#StudentName').val('');
        $('#Email').val('');
        $('#DepartmentId').val('');
     


    }



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

 
   
   
    var loadStudentResult = function (id) {
        var id = $('#RegId').val();
        var param = { id: id }

        $.getJSON("../ResultSearch/Get", param, function (data) {
            console.log(data)

            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.CourseCode + '</td>';
                row += '<td>' + item.CourseName + '</td>';
                row += '<td>' + item.GradeName + '</td>';



                //row += '<td><button class="btn btn-outline-info btn-xs" onclick = "StudentResult.onEdit(' + "\'" + item.Id + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
               // row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "StudentResult.onDelete(' + "\'" + item.Id + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';

            });
            MakePaginationWithDataTableWithoutButton('SearchResultTable', row);
        });
    };
   

    var eventInitialize = function () {
        $('#btnSave').click(loadStudentResult);
        $('#btnClear').click(clear);
        $("#RegId").change(getStudentsById);
       // getAllCourse();
        //getAllDepartment();
        //loadStudentResult();
        //getAllGrade();
        getAllRegistration();
    };

    return {
        init: function () {

            eventInitialize();
           
        },
        
    }

}();