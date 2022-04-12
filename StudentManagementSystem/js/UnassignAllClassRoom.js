UnassignAllClassroom = function () {

    var onDelete = function () {
        var url = "../UnallocateClassroom/Delete";
        bootbox.confirm("Are you sure", function (result) {
            if (result) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: {},
                    async: false,
                    success: function (data) {
                        alert("All classroom list has been deleted.");
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