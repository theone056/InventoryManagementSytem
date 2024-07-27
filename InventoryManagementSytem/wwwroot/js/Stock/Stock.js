(function (ns) {
    function InitStockTable() {
        $("#stock-table").DataTable();
    }

    ns.InitStockTable = InitStockTable;
})(window.Stock = window.Stock || {});

$(document).ready(function () {
    Stock.InitStockTable();
});