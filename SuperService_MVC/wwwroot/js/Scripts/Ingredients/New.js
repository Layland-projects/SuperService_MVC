$(document).ready(function () {
    $(".active").removeClass('active');
    $("#IngredientsNav").addClass('active');
    $("#HeaderToggle").on("click", toggleHeader);
    $("#HeaderEdit").on("keyup", updateHeader);

    $("form input:not([id=HeaderEdit],[id=IngredientID])").on("keyup", validateNumericInput);
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
validateNumericInput = function () {
    var exp = /^[0-9]+\.?[0-9]*$/;
    let valItem = $("#" + this.id + "Validation");
    if (!exp.test(this.value)) {
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
validateStringInput = function () {
    var exp = /^\S[\w:,!&? -]*$/;
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