"use strict"

function onQtyChange(input) {

    //selections
    let itemId = $(input).data('itemid');
    let itemPrice = $(input).data('itemprice');
    let totalItemQty = $(input).val();
    let totalItemPrice = $(input).closest("tr").find(".totalItemPrice");


    if (totalItemQty <= 0) {
        removeFromCart(input);
        return;

    }
    else {

        //add to cart method call
        $.ajax({
            url: '/shoppingcart/addtocart',
            data: { id: itemId, qty: totalItemQty },
            success: function (data) {

                let newTotalPrice = (parseFloat(parseFloat(itemPrice) * parseInt(totalItemQty)).toFixed(2))
                totalItemPrice.html(newTotalPrice);


                //changing Total price + in the DOM too
                UpdateShoppingCartQtyDOM(UpdateShoppingCartQty());
                UpdateShoppingCartPriceDOM(UpdateShoppingCartPrice());

                //update top shopping cart icon
                GetShoppingCart()

            },
            error: function (xhr, ajaxoptions, thrownerror) {
                alert(xhr.responsetext);
            }
        });
    }

  
}

function removeFromCart(obj) {

    let itemId = $(obj).data("itemid");

    //remove from cart method call
    $.ajax({
        url: '/shoppingcart/RemoveFromCart',
        data: { id: itemId },
        success: function (data) {

            obj.closest("tr").remove();

            //changing Total price + in the DOM too
            UpdateShoppingCartQtyDOM(UpdateShoppingCartQty());
            UpdateShoppingCartPriceDOM(UpdateShoppingCartPrice());

            //update top shopping cart icon + top cart list 
            GetShoppingCart()

        },
        error: function (xhr, ajaxoptions, thrownerror) {
            alert(xhr.responsetext);
        }
    });


}


$(document).ready(function () {

    console.log($(".add-To-Cart").length)

    $(".add-To-Cart").on('click', function () {

        console.log("written or clicked")
       

    let id = $(this).data("id");

    $.ajax({
        url: '/shoppingcart/addtocart',
        data: {id: id },
        success: function (data) {
         

                $.notify({
                    icon: 'fa fa-check',
                    title: 'Success!',
                    message: 'Item Successfully added to your cart'
                }, {
                    element: 'body',
                    position: null,
                    type: "success",
                    allow_dismiss: true,
                    newest_on_top: false,
                    placement: {
                        from: "top",
                        align: "right"
                    },
                    offset: 20,
                    spacing: 10,
                    z_index: 1031,
                    delay: 300,
                    animate: {
                        enter: 'animated fadeInDown',
                        exit: 'animated fadeOutUp'
                    },
                    icon_type: 'class',
                    template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                        '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                        '<span data-notify="icon"></span> ' +
                        '<span data-notify="title">{1}</span> ' +
                        '<span data-notify="message">{2}</span>' +
                        '<div class="progress" data-notify="progressbar">' +
                        '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                        '</div>' +
                        '<a href="{3}" target="{4}" data-notify="url"></a>' +
                        '</div>'
                });

              //get shopping cart + get top shopping cart icon + top cart list 
            GetShoppingCart();



                  },
        error:function (xhr, ajaxoptions, thrownerror){
                        alert(xhr.responsetext);
                  }
         });
    });



});



function RemoveFromTopCart(obj) {

    var itemId = $(obj).data("id");

    $.ajax({
        url: '/shoppingcart/RemoveFromCart',
        data: { id: itemId },
        success: function (data) {

            //obj.closest("tr").remove();

            //changing Total price + in the DOM too
            UpdateShoppingCartQtyDOM(UpdateShoppingCartQty());
            UpdateShoppingCartPriceDOM(UpdateShoppingCartPrice());

            ////update top shopping cart icon + top cart list 
            GetShoppingCart()

        },
        error: function (xhr, ajaxoptions, thrownerror) {
            alert(xhr.responsetext);
        }
    });

}



function GetShoppingCart() {

    $.ajax({
        url: '/shoppingcart/GetShoppingCart',
        success: function (data) {

            if (data != null) {

                //update top cart icon number
                $(".TopShoppingCart").html(data.totalShoppingCartQty)


                //update top cart list
                $(".TopCartItemsList").html("");
                for (let item of data.cartItemsList) {

                    let itemBox = `<li> <div class="media">
                                                        <a href="#">
                                                            <img alt="" class="mr-3"
                                                                 src="/Website/images/fashion/product/1.jpg">
                                                        </a>
                                                        <div class="media-body">
                                                            <a href="#">
                                                                <h4> $${item.itemName}</h4>
                                                            </a>
                                                            <h6>
                                                                Price : <span> ${item.itemPrice}</span>
                                                            <br/>
                                                                Qty: <span>${item.totalQty}x</span>
                                                            <br/>
                                                                Total Price: <span> $${item.totalPrice}</span>
                                                           </h6>
                                                        </div>
                                                    </div>
                                                    <div class="close-circle">
                                                        <a data-id="${item.itemId}" onclick='RemoveFromTopCart(this)' >
                                                            <i class="fa fa-times"
                                                               aria-hidden="true"></i>
                                                        </a>
                                                    </div>
                                                </li>`;

                    $(".TopCartItemsList").append(itemBox);

                }


                // update top cart list totalQty and totalPrice
                $("#TopCartItemsQty").html(data.totalShoppingCartQty);
                $("#TopCartItemsPrice").html(data.totalShoppingCartPrice);

            }

        },
        error: function (data) { }
    });


}







//private methods to use 

function UpdateShoppingCartPrice() {

   let totalShoppingCartPrice = 0;

    $(".cart-item-row").each(function (i) {

        totalShoppingCartPrice += parseFloat($(this).find(".totalItemPrice").html());
    })

    return totalShoppingCartPrice;
}

function UpdateShoppingCartQty() {

    let totalShoppingCartQty = 0;

            $(".cart-item-row").each(function (i) {
                totalShoppingCartQty += parseInt($(this).find(".totalItemQty").val());
            })
    return totalShoppingCartQty;

}


function UpdateShoppingCartPriceDOM(shoppingCartPrice) {
    $("#totalShoppingCartPrice").html(shoppingCartPrice.toFixed(2));

}

function UpdateShoppingCartQtyDOM(shoppingCartQty) {
    $("#totalShoppingCartQty").html(shoppingCartQty);

}




