UnassignAllCourse = function () {

    var onDelete = function () {
        var url = "../UnassignCourseSetup/Delete";
        bootbox.confirm("Are you sure", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { },
                    async: false,
                    success: function (data) {
                        alert("All Assigned course has been deleted.");
                    }, error: function () { }

                });
            }
        })
    }
    var eventInitialize = function () {

       $('#btnSave').click(onDelete);
    };
    return {

        init: function () {

            eventInitialize();
            
        },
        onDelete: onDelete
    };

}();