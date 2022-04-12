var Departmentsetup = function () {

    var save = function () {
        var url = "../DepartmentSetup/Save";
        var departmentId = $('#DepartmentId').val();
        var departmentCode = $('#DepartmentCode').val();
        var departmentName = $('#DepartmentName').val();

        if (departmentCode == "" || departmentCode == null) {
            alert("department code required");
            return;
        }
        if (departmentName == "" || departmentName == null) {
            alert("department name required");
            return;
        }

        $.ajax({
            type: 'POST',
            url: url,
            data: {
                DepartmentId: departmentId,
                DepartmentCode: departmentCode,
                DepartmentName: departmentName
            },
            async: false,
            success: function (data) {
                alert("Department Saved Successfully");
                clear();
                loadDepartment();
            },
            error: function () { }



        });


    };
    var clear = function ()
    {
        $('#DepartmentId').val("0");
        $('#DepartmentCode').val('');
        $('#DepartmentName').val('');
    }

    var onEdit = function (DepartmentId) {
        var url = "../DepartmentSetup/Get";
        $.ajax({

            type: 'GET',
            url: url,
            data: { DepartmentId: DepartmentId },
            async: false,
            success: function (data) {
                $('#DepartmentId').val(data.DepartmentId);
                $('#DepartmentCode').val(data.DepartmentCode);
                $('#DepartmentName').val(data.DepartmentName);
            },
            error: function (data) { }
        });
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    };

    var onDelete = function (DepartmentId)
    {
        var url = "../DepartmentSetup/Delete";
        bootbox.confirm("Are you sure", function(result){
            if(result){
                $.ajax({
                    type: 'POST',
                    url: url,
                    data:{DepartmentId: DepartmentId},
                    async: false,
                    success: function(data){
                        clear();
                        loadDepartment();
                    },error: function(){}
                
                });
            }
        })
     }
      
    var loadDepartment = function ()
    {
        var param = {}
        $.getJSON("../DepartmentSetup/GetAll", param ,function (data) {
            console.log(data);
            var row = "";
            $.each(data, function (index, item) {

                row += '<tr>';
                row += '<td>' + item.DepartmentId + '</td>';
                row += '<td>' + item.DepartmentCode + '</td>';
                row += '<td>' + item.DepartmentName + '</td>';

                row += '<td><button class="btn btn-outline-info btn-xs" onclick = "Departmentsetup.onEdit(' + "\'" + item.DepartmentId + "\'" + ')"><i class="fa fa-edit"></i> EDIT</button></td>';
                row += '<td><button class="btn btn-outline-danger btn-xs" onclick = "Departmentsetup.onDelete(' + "\'" + item.DepartmentId + "\'" + ')"><i class="fa fa-trash"></i> DELETE</button></td>';
                row += '</tr>';
            });
            MakePaginationWithDataTableWithoutButton('DepartmentTable', row);


        });
    }

    var eventInitialize = function () {

        $('#btnSave').click(save);
        $('#btnClear').click(clear);
    };
    return {

        init: function () {

            eventInitialize();
            loadDepartment();
        },
        onEdit: onEdit,
        onDelete: onDelete
    };

}();