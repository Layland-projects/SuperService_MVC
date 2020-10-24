$(document).ready(function () {
    $('.active').removeClass('active');
    $('#ItemsNav').addClass('active');
    $("#DeleteModal").on("show.bs.modal", function (event) {
        onDeleteModalShow(event);
    });
    $(".info").on("click", function (event) {
        event.preventDefault();
        getInfoModalData(event, this);
    })
    $("#DeleteModalDelete").on("click", function () {
        window.location.replace($(this).attr("href"));
    })
});
onDeleteModalShow = function (event) {
    let trigger = $(event.relatedTarget);
    let id = trigger.data("id");
    let name = trigger.data("name");
    $("#DeleteModal .modal-title").text("Delete " + name + "?");
    $("#DeleteModal .modal-body").text("Are you sure you want to delete \"" + name + "\"?");
    $("#DeleteModalDelete").attr("href", "/Items/Delete/" + id);
}
getInfoModalData = function (event, elem) {
    let trigger = $(elem);
    let id = trigger.data("id");
    let url = window.location.origin + "/api/Items/" + id
    $.ajax({
        url: url,
        dataType: "application/json",
        complete: function (data) {
            populateInfoModalShow(data);
        }
    }).done();
}
populateInfoModalShow = function (data) {
    var item = JSON.parse(data.responseText);
    $("#InfoModal .modal-title").text(item.name);
    $("#modalCost").text("Cost: £" + item.cost.toFixed(2));
    $("#modalCalories").text(item.calories);
    $("#modalProtein").text(item.protein);
    $("#modalCarbohydrates").text(item.carbohydrates);
    $("#modalFat").text(item.fat);
    $("#modalSugar").text(item.sugar);
    $("#modalSalt").text(item.salt);

    //populate ingredients
    $(".ingredient").remove();
    item.ingredients.forEach(function (ingredient) {
        let outOfStockClass = ingredient.numberInStock > 0 ? "" : " border-danger";
        $("#modalIngredients").append("<li class=\"ingredient form-control m-2" + outOfStockClass + "\">" + ingredient.name + "</li>")
    })
    $("#InfoModal").modal("show");
}