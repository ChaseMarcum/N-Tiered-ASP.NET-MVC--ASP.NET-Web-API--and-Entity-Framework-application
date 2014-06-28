

$(function () {
    $("#application-form").steps({
        titleTemplate: "#title#",
        bodyTag: "fieldset",
        onStepChanging: function (event, currentIndex, newIndex) {
            // Always allow going backward even if the current step contains invalid fields!
            if (currentIndex > newIndex) {
                return true;
            }

            ////////// Forbid suppressing "Warning" step if the user is to young
            ////////if (newIndex === 3 && Number($("#age").val()) < 18) {
            ////////    return false;
            ////////}

            //if (newIndex === 2 && Request.Form["question1"] == null) {
            //    return false;
            //}

            //if (Request.Form["@currentQuestion"] != null)
            //{
            //    selectedAnswers.Add(Request.Form["@currentQuestion"].ToString());
            //}

            var form = $(this);

            // Clean up if user went backward before
            if (currentIndex < newIndex) {
                // To remove error styles
                $(".body:eq(" + newIndex + ") label.error", form).remove();
                $(".body:eq(" + newIndex + ") .error", form).removeClass("error");
            }

            // Disable validation on fields that are disabled or hidden.
            form.validate().settings.ignore = ":disabled,:hidden";

            // Start validation; Prevent going forward if false
            return form.valid();
        },
        onStepChanged: function (event, currentIndex, priorIndex) {
            ////////// Suppress (skip) "Warning" step if the user is old enough.
            ////////if (currentIndex === 2 && Number($("#age").val()) >= 18) {
            ////////    $(this).steps("next");
            ////////}

            ////////// Suppress (skip) "Warning" step if the user is old enough and wants to the previous step.
            ////////if (currentIndex === 2 && priorIndex === 3) {
            ////////    $(this).steps("previous");
            ////////}
        },
        onFinishing: function (event, currentIndex) {
            var form = $(this);

            // Disable validation on fields that are disabled.
            // At this point it's recommended to do an overall check (mean ignoring only disabled fields)
            form.validate().settings.ignore = ":disabled";

            // Start validation; Prevent form submission if false
            return form.valid();
        },
        onFinished: function (event, currentIndex) {
            var form = $(this);

            var passed = true;

            $("input[type=radio]:checked").each(function () {
                if (this.value == "false") {
                    passed = false;
                }
            });
            $("input[type=checkbox]:checked").each(function () {
                if (this.value == "false") {
                    passed = false;
                }
            });

            if (passed == true) {
                form.submit(window.location.href = '/Application/Call/');
            }
            else {
                // Submit form input
                form.submit();
            }

        }
    }).validate({
        errorPlacement: function (error, element) {
            element.before(error);
        },
        rules: {
            confirm: {
                equalTo: "#password"
            }
        }
    });

    function foo() {
        //var url = '@Url.Action("Index", "Home")';
        //window.location.href = url;

        window.location.href = '/OpenJob/Index/';
    }

    //$('form input[type="radio"]').each(function(){
    //    // Do your magic here
    //    if (this.value.match(/\D/)) // regular expression for numbers only.
    //        Error();
    //});
    //$("input[type=radio]:checked").each(function () {
    //    var t = $(this).val();
    //});



});