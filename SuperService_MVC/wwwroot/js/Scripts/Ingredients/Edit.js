$(document).ready(function () {
    $(".active").removeClass('active');
    $("#IngredientsNav").addClass('active');
    $("#HeaderToggle").on("click", toggleHeader);
    $("#HeaderEdit").on("keyup", updateHeader);

    $("form input:not([id=HeaderEdit],[id=IngredientID],[id=Calories])").on("keyup", function () {
        validateNumericInput(/^[0-9]+\.?[0-9]*$/, this)
    });
    $("#Calories").on("keyup", function () {
        validateNumericInput(/^[0-9]+$/, this);
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
validateNumericInput = function (exp, elem) {
    let valItem = $("#" + elem.id + "Validation");
    if (!exp.test(elem.value)) {
        valItem.attr("hidden", null);
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