$(document).ready(function () {
    $(".active").removeClass('active');
    $("#ItemsNav").addClass('active');
    $("#HeaderToggle").on("click", toggleHeader);
    $("#HeaderEdit").on("keyup", updateHeader);
    $(document).on("keydown", "form", function (event) {
        return event.key !== "Enter";
    });
    $("#Cost").on("keypress", function (event) {
        preventMoreThan2DP(event, this)
    });
    $("#Cost").on("keyup", function (event) {
        validateNumericInput(/^[0-9]+\.?[0-9]*$/, this);
    });
    $("#Cost").bind("paste", function () {
        let self = this;
        setTimeout(function () {
            if (!/^\d*(\.\d{1,2})+$/.test($(self).val())) {
                $(self).val("");
            }
        }, 0);
    });
    $("#HeaderEdit").on("keyup", validateStringInput);
});
toggleHeader = function () {
    if ($("#HeaderDisplay").attr("hidden") === "hidden") {
        $("#HeaderDisplay").attr("hidden", null);
        $("#HeaderEditContainer").attr("hidden", "hidden");
    }
    else {
        $("#HeaderDisplay").attr("hidden", "hidden");
        $("#HeaderEditContainer").attr("hidden", null);
    }
};
updateHeader = function () {
    let value = $(this).val();
    $("#HeaderDisplay").text(value);
}
preventMoreThan2DP = function (event, elem) {
    let character = String.fromCharCode(event.keyCode)
    let newValue = elem.value + character;
    if (isNaN(newValue) || hasDecimalPlace(newValue, 3)) {
        event.preventDefault();
        return false;
    }
}
hasDecimalPlace = function (value, x) {
    let pointIndex = value.indexOf('.');
    return pointIndex >= 0 && pointIndex < value.length - x;
}
validateNumericInput = function (exp, elem) {
    const max = 2147483647;
    const defaultErrorMsg = "Value must be numeric and none negative";
    let valItem = $("#" + elem.id + "Validation");
    if (!exp.test(elem.value)) {
        valItem.attr("hidden", null);
        valItem.text(defaultErrorMsg);
        $(elem).addClass("validation-err");
        $("form button[type=submit]").attr("disabled", "disabled");
    }
    if (parseInt(elem.value) > max) {
        valItem.attr("hidden", null);
        valItem.text("Value too large");
        $(elem).addClass("validation-err");
        $("form button[type=submit]").attr("disabled", "disabled");
    }
    else {
        valItem.attr("hidden", "hidden");
        $(elem).removeClass("validation-err");
    }
    if ($("input.validation-err").length === 0) {
        $("form button[type=submit]").attr("disabled", null);
    }
}
validateStringInput = function () {
    let exp = /^\S[\w:,!&? '-]*$/;
    let valItem = $("#" + this.id + "Validation");
    if (!exp.test(this.value) || this.value.lastIndexOf(" ") === (this.value.length - 1)) {
        valItem.attr("hidden", null);
        $(this).addClass("validation-err");
        $("form button[type=submit]").attr("disabled", "disabled");
    }
    else {
        valItem.attr("hidden", "hidden");
        $(this).removeClass("validation-err");
    }
    if ($("input.validation-err").length === 0) {
        $("form button[type=submit]").attr("disabled", null);
    }
}