var ComponentsNoUiSliders = (function () {

    var myNoUiSlidersStater = function (id, min, max, step, useParse, decimals) {

        if (typeof useParse === "undefined") {
            useParse = true;
        }
        if (typeof decimals === "undefined") {
            decimals = 0;
        }

        $(id).TouchSpin({
            min: min,
            max: max,
            step: step,
            decimals: decimals,
            //boostat: 5,
            //maxboostedstep: 10,
            //postfix: '%'
        });

        var tooltipSlider = $(id).closest(".form-group").find(".noUi-success")[0];


        function changeSliderValue() {
            var value = useParse ? parseInt($(id).val()) : $(id).val();
            tooltipSlider.noUiSlider.set(value);
        }

        $(id).on('touchspin.on.stopspin', function () {
            changeSliderValue();
        });

        $(id).on('blur', function () {
            changeSliderValue();
        });


        try {
            noUiSlider.create(tooltipSlider, {
                start: [min],
                connect: false,
                //behaviour: 'hover-snap',
                range: {
                    'min': min,
                    'max': max
                },
                tooltips: [wNumb({
                    decimals: decimals
                })],
                step: step
            });


            //// When the slider changes, write the value to the tooltips.
            tooltipSlider.noUiSlider.on('update', function (values, handle) {
                // inputNumber[handle].value = values[handle];

                //tooltips[handle].innerHTML = parseInt(values[handle]);               
                var value = useParse ? parseInt(values[handle]) : values[handle];
                $(id).val(value);
            });

            //inputNumber.addEventListener('oninput', function () {
            //    tooltipSlider.noUiSlider.set([null, this.value]);
            //});              

            var handle = tooltipSlider.querySelector('.noUi-handle');

            handle.addEventListener('keydown', function (e) {

                var value = Number(tooltipSlider.noUiSlider.get());;

                if (e.which === 37) {
                    $(handle).trigger("click");
                    tooltipSlider.noUiSlider.set(value - step);
                }

                if (e.which === 39) {
                    $(handle).trigger("click");
                    tooltipSlider.noUiSlider.set(value + step);
                }
            });

        } catch (e) {
            debugger;
        }
    }

    return {
        //main function to initiate the module
        myNoUiSlidersStater: myNoUiSlidersStater

    };

})();


