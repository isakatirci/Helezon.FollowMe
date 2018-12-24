$(function () {
    'use strict';

    var console = window.console || { log: function () { } };
    var URL = window.URL || window.webkitURL;
    var $image = $('#image');
    //var $download = $('#download');
    var options = {
        viewMode: 1,
        dragMode: 'move',
        restore: false,
        guides: true,
        highlight: false,
        cropBoxMovable: true,
        cropBoxResizable: false,
        preview: '.img-preview',
        crop: function (e) {
            //$dataX.val(Math.round(e.detail.x));
            //$dataY.val(Math.round(e.detail.y));
            //$dataHeight.val(Math.round(e.detail.height));
            //$dataWidth.val(Math.round(e.detail.width));
            //$dataRotate.val(e.detail.rotate);
            //$dataScaleX.val(e.detail.scaleX);
            //$dataScaleY.val(e.detail.scaleY);
        }
    };
    var originalImageURL = $image.attr('src');
    var uploadedImageName = 'cropped.jpg';
    var uploadedImageType = 'image/jpeg';
    var uploadedImageURL;

    // Tooltip
    //$('[data-toggle="tooltip"]').tooltip();


    var cropHeight = 300;
    var cropWidth = 250;


    // Cropper
    $image.on({
        ready: function (e) {
            console.log(e.type);

            $image.cropper('setCropBoxData', {
                //left: (containerData.width - cropWidth) / 2,
                //top: (containerData.height - cropHeight) / 2,
                width: cropWidth,
                height: cropHeight
            });

        },
        //cropstart: function (e) {
        //    console.log(e.type, e.detail.action);
        //},
        //cropmove: function (e) {
        //    console.log(e.type, e.detail.action);
        //},
        //cropend: function (e) {
        //    console.log(e.type, e.detail.action);
        //},
        //crop: function (e) {
        //    console.log(e.type);
        //},
        //zoom: function (e) {
        //    console.log(e.type, e.detail.ratio);
        //}
    }).cropper(options);


    // Methods
    //$('.docs-buttons').on('click', '[data-method]', function () {
    //    var $this = $(this);
    //    var data = $this.data();
    //    var cropper = $image.data('cropper');
    //    var cropped;
    //    var $target;
    //    var result;

    //    if ($this.prop('disabled') || $this.hasClass('disabled')) {
    //        return;
    //    }

    //    if (cropper && data.method) {
    //        data = $.extend({}, data); // Clone a new one

    //        if (typeof data.target !== 'undefined') {
    //            $target = $(data.target);

    //            if (typeof data.option === 'undefined') {
    //                try {
    //                    data.option = JSON.parse($target.val());
    //                } catch (e) {
    //                    console.log(e.message);
    //                }
    //            }
    //        }

    //        cropped = cropper.cropped;

    //        switch (data.method) {
    //            case 'rotate':
    //                if (cropped && options.viewMode > 0) {
    //                    $image.cropper('clear');
    //                }

    //                break;

    //            case 'getCroppedCanvas':
    //                if (uploadedImageType === 'image/jpeg') {
    //                    if (!data.option) {
    //                        data.option = {};
    //                    }

    //                    data.option.fillColor = '#fff';
    //                }

    //                break;
    //        }

    //        result = $image.cropper(data.method, data.option, data.secondOption);

    //        switch (data.method) {
    //            case 'rotate':
    //                if (cropped && options.viewMode > 0) {
    //                    $image.cropper('crop');
    //                }

    //                break;

    //            case 'scaleX':
    //            case 'scaleY':
    //                $(this).data('option', -data.option);
    //                break;

    //            case 'getCroppedCanvas':
    //                if (result) {
    //                    // Bootstrap's Modal
    //                    //$('#getCroppedCanvasModal').modal().find('.modal-body').html(result);

    //                    //if (!$download.hasClass('disabled')) {
    //                    //    download.download = uploadedImageName;
    //                    //    $download.attr('href', result.toDataURL(uploadedImageType));
    //                    //}
    //                }

    //                break;

    //            case 'destroy':
    //                if (uploadedImageURL) {
    //                    URL.revokeObjectURL(uploadedImageURL);
    //                    uploadedImageURL = '';
    //                    $image.attr('src', originalImageURL);
    //                }

    //                break;
    //        }

    //        if ($.isPlainObject(result) && $target) {
    //            try {
    //                $target.val(JSON.stringify(result));
    //            } catch (e) {
    //                console.log(e.message);
    //            }
    //        }
    //    }
    //});

    // Keyboard
    $(document.body).on('keydown', function (e) {
        if (e.target !== this || !$image.data('cropper') || this.scrollTop > 300) {
            return;
        }

        switch (e.which) {
            case 37:
                e.preventDefault();
                $image.cropper('move', -1, 0);
                break;

            case 38:
                e.preventDefault();
                $image.cropper('move', 0, -1);
                break;

            case 39:
                e.preventDefault();
                $image.cropper('move', 1, 0);
                break;

            case 40:
                e.preventDefault();
                $image.cropper('move', 0, 1);
                break;
        }
    });

    // Import image
    var $inputImage = $('#inputImage');

    if (URL) {
        $inputImage.change(function () {
            var files = this.files;
            var file;

            if (!$image.data('cropper')) {
                return;
            }

            if (files && files.length) {
                file = files[0];

                if (/^image\/\w+$/.test(file.type)) {
                    uploadedImageName = file.name;
                    uploadedImageType = file.type;

                    if (uploadedImageURL) {
                        URL.revokeObjectURL(uploadedImageURL);
                    }

                    uploadedImageURL = URL.createObjectURL(file);
                    $image.cropper('destroy').attr('src', uploadedImageURL).cropper(options);
                    $inputImage.val('');
                } else {
                    window.alert('Please choose an image file.');
                }
            }
        });
    } else {
        $inputImage.prop('disabled', true).parent().addClass('disabled');
    }

    $("#browserCrop").click(function (e) {
        var canvasSize = { width: cropWidth, height: cropHeight }; // Canvasın width-height parametresi
        var canvas = $image.cropper('getCroppedCanvas', canvasSize).toDataURL(); // Image Data Url burada <--
        console.log(imageUploadParameters);
        $.ajax({
            type: 'POST',
            url: '/File/SendPicture',
            data: {
                entitytype: imageUploadParameters.entitytype,
                entityId: imageUploadParameters.entityId,
                companyId: imageUploadParameters.companyId,
                imageId:imageUploadParameters.imageId,
                imageBaseData: canvas
            }
        }).done(function (data, status, jqXHR) {
          
            if (data.Failure) {
                swal("Error!", data.Failure, "error");
            } else {
                swal({
                    title: "Success",
                    text: "Term Saved.",
                    type: "info",
                    allowOutsideClick: false,
                    showConfirmButton: true,
                    showCancelButton: false
                },
                    function (isConfirm) {
                        console.log(imageUploadParameters.returnUrl);
                        debugger;
                        $(location).attr("href", imageUploadParameters.returnUrl);

                        });
            }         
        }).fail(function (jqXHR, status, err) {
            swal("Error!", err + '', "error");
        });;
    });

});