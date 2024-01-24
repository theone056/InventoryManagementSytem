(function (ns) {

    function InitProductDatatable() {
        $("#product-table").DataTable();
    }

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

    function HideProductModal() {
        $("#product-modal").modal("hide");
    }

    function OnSuccess() {
        HideProductModal();
        InitProductDatatable();
    }

    function DeleteOnSuccess() {
        $("#product-modal-delete").modal("hide");
        InitProductDatatable();
    }

    function OnFailure() {
        $("#ErrorDisplay").addClass("show");

        setTimeout(() => {
            var myAlert = document.getElementById('ErrorDisplay')
            var bsAlert = new bootstrap.Alert(myAlert)
            bsAlert.close();
        }, 1500);
     
    }

    function OnClickDelete(productName) {
        $("#productName-value").text(productName);
    }

    ns.OnClickAddProductButton = OnClickAddProductButton;
    ns.OnClickEdit = OnClickEdit;
    ns.OnClickDelete = OnClickDelete;
    ns.HideProductModal = HideProductModal;
    ns.OnSuccess = OnSuccess;
    ns.OnFailure = OnFailure;
    ns.InitProductDatatable = InitProductDatatable;
    ns.DeleteOnSuccess = DeleteOnSuccess;

})(window.Product = window.Product || {});


$(document).ready(function () {
    Product.InitProductDatatable();

    $("body")
        .on("click", "#add-product-button", function () {
            Product.OnClickAddProductButton();
        });
})