(function (ns) {
    function OnClickAddProductButton() {
        $.ajax({
            type: 'GET',
            url: "ajax/product/ProductModal",
            success: function (data) {
                $("#product-modal-body").html(data);
            },
            error: function () {

            }
        })
    }

    function OnClickEdit(code) {
        $.ajax({
            type: 'GET',
            url: "ajax/product/ProductModal",
            data: { code: code },
            success: function (data) {
                $("#product-modal-body").html(data);
            },
            error: function () {

            }
        })
    }

    function OnClickDelete(productName) {
        $("#productName-value").text(productName);
    }

    ns.OnClickAddProductButton = OnClickAddProductButton;
    ns.OnClickEdit = OnClickEdit;
    ns.OnClickDelete = OnClickDelete;

})(window.Product = window.Product || {});


$(document).ready(function () {
    $("#product-table").DataTable();

    $("body")
        .on("click", "#add-product-button", function () {
            Product.OnClickAddProductButton();
        });

})