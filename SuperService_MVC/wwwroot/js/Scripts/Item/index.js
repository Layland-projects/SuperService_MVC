$(document).ready(function () {
    $('.active').removeClass('active');
    $('#ItemsNav').addClass('active');
    $("#DeleteModal").on("show.bs.modal", function (event) {
        onDeleteModalShow(event);
    });
    $("#InfoModal").on("show.bs.modal", function (event) {

    });
    $("#DeleteModalDelete").on("click", function () {
        window.location.replace($(this).attr("href"));
    })
});
onDeleteModalShow = function (event) {
    var trigger = $(event.relatedTarget);
    var id = trigger.data("id");
    var name = trigger.data("name");
    $("#DeleteModal .modal-title").text("Delete " + name + "?");
    $("#DeleteModal .modal-body").text("Are you sure you want to delete \"" + name + "\"?");
    $("#DeleteModalDelete").attr("href", "/Items/Delete/" + id);
}
onInfoModalShow = function (event) {
    var trigger = $(event.relatedTarget);
    var id = trigger.data("id");
}