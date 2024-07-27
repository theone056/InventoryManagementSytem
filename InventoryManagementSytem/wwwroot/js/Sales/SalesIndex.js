(function (ns) {
    function SalesIndexInit() {
        $("#sales-table").DataTable();
    }

    ns.SalesIndexInit = SalesIndexInit;

})(window.SalesIndex = window.SalesIndex || {});

$(document).ready(function () {
    SalesIndex.SalesIndexInit();
})