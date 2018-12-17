var UIExtendedModals = function () {


    return {
        //main function to initiate the module
        init: function () {

            // general settings
            $.fn.modal.defaults.spinner = $.fn.modalmanager.defaults.spinner =
                '<div class="loading-spinner" style="width: 200px; margin-left: -100px;">' +
                '<div class="progress progress-striped active">' +
                '<div class="progress-bar" style="width: 100%;"></div>' +
                '</div>' +
                '</div>';


            //dynamic demo:
            $('.dynamic .demo').click(function () {
                var tmpl = [
                    // tabindex is required for focus
                    '<div class="modal hide fade" tabindex="-1">',
                    '<div class="modal-header">',
                    '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>',
                    '<h4 class="modal-title">Modal header</h4>',
                    '</div>',
                    '<div class="modal-body">',
                    '<p>Test</p>',
                    '</div>',
                    '<div class="modal-footer">',
                    '<a href="#" data-dismiss="modal" class="btn btn-default">Close</a>',
                    '<a href="#" class="btn btn-primary">Save changes</a>',
                    '</div>',
                    '</div>'
                ].join('');

                $(tmpl).modal();
            });

            //ajax demo:
            var $modal = $('#ajax-modal');

            $('.ajax-demo').on('click', function () {

                // create the backdrop and wait for next modal to be triggered
                $('body').modalmanager('loading');

                var el = $(this);

                setTimeout(function () {
                    var $iframe = $modal.find('iframe');
                    if ($iframe.length) {
                        $iframe.attr('src', el.attr('data-url') + '?iframe=-1');
                        $modal.modal();
                    } else {
                        alert('iframe');
                    }
                    $iframe.attr('src', '');            
                }, 1000);
            });

            $('.ajax-refresh').on('click', function () {
                alert('Running!');
                //alert('Running!');
                // create the backdrop and wait for next modal to be triggered
                var modalManager = $('body').modalmanager('loading');
                var el = $(this);
                setTimeout(function () {
                    var $dropdownListId = el.attr('data-dropdownlistid');
                    var $tableName = el.attr('data-table-name');
                    var $dropdownList = $('#' + $dropdownListId);
                    $('#' + $dropdownListId).empty();
                    $.getJSON(el.attr('data-url'), { tableName: $tableName }, function (data) {
                        if (data.length != 0) {
                            $.each(data, function () {
                                $dropdownList.append('<option value=' + this.Value + '>' + this.Text + '</option>');
                            });
                        } else {
                            //$dropdownList.append('<option value=""> Please Select </option>');
                        }
                    });
                    $('body').modalmanager('removeLoading');
                }, 1000);
            });

            $modal.on('click', '.update', function () {
                $modal.modal('loading');
                setTimeout(function () {
                    $modal
                        .modal('loading')
                        .find('.modal-body')
                        .prepend('<div class="alert alert-info fade in">' +
                            'Updated!<button type="button" class="close" data-dismiss="alert">&times;</button>' +
                            '</div>');
                }, 1000);
            });
        }

    };

}();

jQuery(document).ready(function () {
    UIExtendedModals.init();
});