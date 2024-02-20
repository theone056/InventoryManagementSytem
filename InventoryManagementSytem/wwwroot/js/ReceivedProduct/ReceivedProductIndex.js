(function (ns) {

    function InitTable() {
        $("#receiveproduct-table").DataTable();
    }

    function HideModal() {
        $("#receiveproduct-modal").modal("hide");
    }

    function OnSuccess() {
        InitTable();
        HideModal();
    }

    function OnFailure() {
        InitTable();
    }

    ns.OnSuccess = OnSuccess;
    ns.OnFailure = OnFailure;
    ns.InitTable = InitTable;
    ns.HideModal = HideModal;

})(window.ReceivedProduct = window.ReceivedProduct || {});


$(document).ready(function () {
    ReceivedProduct.InitTable();
})