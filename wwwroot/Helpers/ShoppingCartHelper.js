function onQtyChange(input) {

    //selections
    let itemPrice = $(input).data('itemprice');

    let totalItemQty = $(input).val();

    let totalItemPrice = $(input).closest("tr").find(".totalItemPrice");

    let totalShoppingCartQty = 0;
    let totalShoppingCartPrice = 0;


    //calculations
    let newTotalPrice = (parseFloat(parseFloat(itemPrice) * parseInt(totalItemQty)).toFixed(2) )
    totalItemPrice.html(newTotalPrice);

  
    $(".cart-item-row").each(function (i) {

       totalShoppingCartQty += parseInt($(this).find(".totalItemQty").val());
        totalShoppingCartPrice += parseFloat($(this).find(".totalItemPrice").html());


    })

    //changing html
    $("#totalShoppingCartQty").html(totalShoppingCartQty);
    $("#totalShoppingCartPrice").html(totalShoppingCartPrice.toFixed(2));




}