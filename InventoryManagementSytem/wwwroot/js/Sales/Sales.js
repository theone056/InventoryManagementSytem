(function (ns) {
    var itemsPurchased = [];
    function OnChangeQty(code,price) {
        var idqty = "#qty-" + code;
        var idsubTotal = "#subtotal-" + code;
        var qty = $(idqty).val();
        var subTotal = qty * price;

        var index = findIndex(itemsPurchased, code);
        itemsPurchased[index].qty = qty;
        itemsPurchased[index].subTotal = subTotal;

        $(idsubTotal).text(itemsPurchased[index].subTotal);
        Calculate_Total();
    }

    function findIndex(ArrayObj, code) {
        return ArrayObj.findIndex(obj => obj.code == code);
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
        itemsPurchased = itemsPurchased.filter(x => x.code != code);
        Calculate_Total();
        TogglePaymentButton();
    }

    function AddItemtoList(id) {
        $.ajax({
            type: 'GET',
            url: "../api/product/GetProduct",
            data: { id: id },
            success: function (data) {
                itemsPurchased.push({ code: data.code, qty: 1, subTotal: data.price });
                TogglePaymentButton();
            }
        })
    }

    function OnAddProduct(id) {
        $("#" + id).attr("disabled", true);
        $.ajax({
            type: 'GET',
            url: "../ajax/Sales/GetProduct",
            data: { id: id },
            success: function (data) {
                $("#purchase-table > tbody").append(data);
                AddItemtoList(id);
                Calculate_Total();
            },
            error: function () {

            }
        });
    }


    function TogglePaymentButton() {
        if (itemsPurchased.length > 0) {
            $("#paymentButton").attr("disabled", false);
        }
        else {
            $("#paymentButton").attr("disabled", true);
        }
    }

    function Payment() {
        console.log(itemsPurchased);
        $.ajax({
            type: 'POST',
            url: "Payment",
            dataType: 'json',
            data: { itemsPurchased: itemsPurchased },
            success: function () {
                
            },  
            error: function () {

            }
        })
    }

    ns.OnAddProduct = OnAddProduct;
    ns.OnChangeQty = OnChangeQty;
    ns.OnClickRemove = OnClickRemove;
    ns.Payment = Payment;

})(window.Sales = window.Sales || {});

