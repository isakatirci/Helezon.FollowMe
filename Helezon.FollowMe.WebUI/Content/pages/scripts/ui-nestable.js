var UINestable = function () {

    var updateOutput = function (e) {
        var list = e.length ? e : $(e.target),
            output = list.data('output');
        if (window.JSON) {
            output.val(window.JSON.stringify(list.nestable('serialize'))); //, null, 2));
        } else {
            output.val('JSON browser support required for this demo.');
        }
    };


    var onChangeNestableList = function (e) {

        for (var i = 0; i < onChangeFunctions.length; i++) {
            onChangeFunctions[i]();
        }
        updateOutput(e);
    }

    var onChangeFunctions = [];


    return {
        //main function to initiate the module
        init: function () {

            // activate Nestable for list 1
            $('#nestable_list_1').nestable({
                   group: 1,
                   maxDepth : 1
                })
                .on('change', onChangeNestableList);

            // activate Nestable for list 2
            $('#nestable_list_2').nestable({
                group: 1,
                maxDepth: 5,
                onDragStart: function (l, e) {
                    // l is the main container
                    // e is the element that was moved
                    console.log(e);
                }
            })
                .on('change', onChangeNestableList);

            // output initial serialised data
            updateOutput($('#nestable_list_1').data('output', $('#nestable_list_1_output')));
            updateOutput($('#nestable_list_2').data('output', $('#nestable_list_2_output')));

            //$('#nestable_list_menu').on('click', function (e) {
            //    var target = $(e.target),
            //        action = target.data('action');
            //    if (action === 'expand-all') {
            //        $('.dd').nestable('expandAll');
            //    }
            //    if (action === 'collapse-all') {
            //        $('.dd').nestable('collapseAll');
            //    }
            //});

            //$('#nestable_list_3').nestable();

        },
        updateOutput: updateOutput,
        onChangeNestableList: onChangeNestableList,
        onChangeFunctions: onChangeFunctions

    };

}();

jQuery(document).ready(function () {
    UINestable.init();
});