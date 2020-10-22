$(document).ready(function () {
    $(".active").removeClass('active');
    $("#IngredientsNav").addClass('active');
    $("#HeaderToggle").on("click", toggleHeader);
    $("#HeaderEdit").on("keyup", updateHeader);

    //Todo: Add form validation function
    $("form input:not([id=HeaderEdit],[id=IngredientID])").on("keyup", validateNumericInput);
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
    //todo: implement method to check for valid input on field
    //
    // if invalid, give css class with red border
    // disable submit button

}