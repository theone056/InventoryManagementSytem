(function (ns) {

    function OnChangeQty(code,price) {
        var idqty = "#qty-" + code;
        var idsubTotal = "#subtotal-" + code;
        var qty = $(idqty).val();
        $(idsubTotal).text(qty * price);
        Calculate_Total();
    }

    function Calculate_Total() {
        var sum = 0;
        $(".subtotal").each(function () {
            sum += parseFloat($(this).text());
        })

        $("#total-value").text(sum.toLocaleString());
    }

    function OnClickRemove(code) {
        var trash = $("#row-" + code);
        var product = $("#" + code);
        trash.remove();
        product.attr("disabled", false);
        Calculate_Total();
    }

    function OnAddProduct(id) {
        $("#" + id).attr("disabled", true);
        $.ajax({
            type: 'GET',
            url: "../ajax/Sales/GetProduct",
            data: { id: id },
            success: function (data) {
                $("#purchase-table > tbody").append(data);

                Calculate_Total();
            },
            error: function () {

            }
        })
    }

    ns.OnAddProduct = OnAddProduct;
    ns.OnChangeQty = OnChangeQty;
    ns.OnClickRemove = OnClickRemove;

})(window.Sales = window.Sales || {});

