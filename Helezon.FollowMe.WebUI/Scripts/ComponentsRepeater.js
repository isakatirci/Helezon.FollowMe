
var ComponentsRepeater = (function () {

    var myRepeater = function (selector, validateNumberOfItems) {
        debugger;
        $(selector).each(function () {
            debugger;
            $(this).repeater({
                show: function () {

                    if (typeof validateNumberOfItems !== "undefined" && typeof validateNumberOfItems === "function") {
                        if (!validateNumberOfItems()) {
                            alert("Invalid Number Of Items");
                            $(this).remove();
                            return;
                        }
                    }

                    //if ($('.mt-repeater .normal_iplik').length > parseInt($("#normal_iplik_count").val())) {
                    //    alert("En fazla " + $("#normal_iplik_count").val() + " adet normal iplik seçilebilir");
                    //    $(this).remove();
                    //    return;
                    //}


                    $(this).slideDown();

                    //ajaxTreeFillTermTreeRef($(this).find(".treeElyafCinsiKalitesi"), "/ZetaCodeNormalIplik/JSTreeElyafCinsiveKalitesi");

                    //modulFantezilIplikVm.ajaxTreeFillTermTree("#treeElyafCinsiKalitesi", "/ZetaCodeNormalIplik/JSTreeElyafCinsiveKalitesi");


                    $(selector + ' .select2-container').remove();

                    $(selector +" .select2").each(function () {

                        $(this).select2({
                            placeholder: "Please Select",
                            width: null
                        });

                    });


                    $(selector +' .select2-container').css('width', '100%');

                },

                hide: function (deleteElement) {
                    if (confirm('Are you sure you want to delete this element?')) {
                        $(this).slideUp(deleteElement);
                    }
                },

                ready: function (setIndexes) {


                },
                isFirstItemUndeletable: false

            });
        })
    };

    return {
        //main function to initiate the module
        myRepeater: myRepeater

    };
})();


