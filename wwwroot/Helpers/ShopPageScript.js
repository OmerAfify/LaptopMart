
    var productsList = $(".products-data");
    var categoryFilters = $(".catNamesFilter");



    $(document).ready(function () {

    GetAllItems();
    GetAllCategories();


    function FilterCategories(catId) {

        $("input.custom-control-input").each(function () {

            $(this).click(function () {

                let id = $(this).data("id");

                if (this.checked == false) {

                    document.querySelectorAll(`[data-catId='${id}']`)


                    console.log(document.querySelectorAll(`[data-catId='${id}']`))
                }
                else {

                    let id = $(this).data("id");

                    $.ajax({
                        type: "GET",
                        url: "/api/GetItemsByCatId",
                        data: { catId: id },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {

                            for (let item of response) {

                                $.ajax({
                                    url: '/Item/GetProductBox2ByIdPartial',
                                    data: { id: item.itemId },
                                    success: function (data) {

                                        let box = `<div class="col-xl-3 col-6 col-grid-box" data-catId='${item.categoryId}'>
                                           <div class="product-box">
                                               ${data}
                                          </div></div>`
                                        productsList.append(box);
                                    },
                                    error: function (data) {
                                        alert('Failed to retrieve data.');
                                    }

                                });
                            }
                        },
                        failure: function (response) {
                            console.log(response.responseText);
                        },
                        error: function (response) {
                            console.log(response.responseText);
                        }
                    });

                }

            });
        });


            };


    function GetAllItems() {

        $.ajax({
            type: "GET",
            url: "/api/GetItems",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                for (let item of response) {

                    var box = DrawItem(item);
                    productsList.append(box);

                    //$.ajax({
                    //    url: '/Item/GetProductBox2ByIdPartial',
                    //    data: { id: item.itemId },
                    //    success: function (data) {

                    //        let box = `<div class="col-xl-3 col-6 col-grid-box" data-catId='${item.categoryId}'>
                    //               <div class="product-box">
                    //                   ${data}
                    //              </div></div>`
                    //        productsList.append(box);
                    //    },
                    //    error: function (data) {
                    //        alert('Failed to retrieve data.');
                    //    }

                    //});


                }



            },
            failure: function (response) {
                console.log(response.responseText);
            },
            error: function (response) {
                console.log(response.responseText);
            },
            complete: function () {
                $.getScript("/Helpers/ShoppingCartHelper.js", function () {

                });

            }

        });

            }

    function GetAllCategories() {
        $.ajax({
            type: "GET",
            url: "/api/GetAllCategories",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {


                let allBox = ` <div class="custom-control custom-checkbox collection-filter-checkbox">

                                       <button class="btn btnCatFilter btn-all" onclick="ShopPageFilter.filterSelection('all')">all</button>

                                      </div>
                                       `
                categoryFilters.append(allBox);

                for (let brand of response) {

                    let brandBox = ` <div class="custom-control custom-checkbox collection-filter-checkbox">

                                       <button class="btn btnCatFilter btn-cat-${brand.categoryId}" onclick="ShopPageFilter.filterSelection('cat-${brand.categoryId}')">${brand.categoryName}</button>

                                      </div>
                                       `
                    categoryFilters.append(brandBox);

                }

                FilterCategories(1);

            },
            failure: function (response) {
                console.log(response.responseText);
            },
            error: function (response) {
                console.log(response.responseText);
            }
        })
    }

    function DrawItem(item) {

        let box = `<div class="col-xl-3 col-6 col-grid-box filterDiv cat-${item.categoryId} show" data-catId='${item.categoryId}' >
        <div class="product-box">

            <div class="img-wrapper">
                <div class="front">
                    <a href="#">
                        <img src="/Website/images/pro3/33.jpg"
                            class="img-fluid blur-up lazyload bg-img" alt="">
            </a>
        </div>
                    <div class="back">
                        <a href="#">
                            <img src="/Website/images/pro3/34.jpg"
                                class="img-fluid blur-up lazyload bg-img" alt="">
            </a>
        </div>
                        <div class="cart-info cart-wrap">
                            <button class="add-To-Cart" data-id='${item.itemId}' title="add to cart">
                                <i class="ti-shopping-cart"></i>
                            </button>
                            <a href="javascript:void(0)"
                                title="Add to Wishlist"><i class="ti-heart" aria-hidden="true"></i></a> <a href="#"
                                    data-toggle="modal" data-target="#quick-view" title="Quick View">
                                <i class="ti-search" aria-hidden="true"></i>
                            </a> <a href="compare.html"
                                title="Compare"><i class="ti-reload" aria-hidden="true"></i></a>
                        </div>
                    </div>
                    <div class="product-detail">
                        <div class="rating">
                            <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i>
                        </div>
                        <a href="/Item/ItemDetails/${item.itemId}">
                            <h6> ${item.itemName}</h6>
                        </a>
                        <h4>$ ${item.salesPrice}</h4>
                        <ul class="color-variant">
                            <li class="bg-light0"></li>
                            <li class="bg-light1"></li>
                            <li class="bg-light2"></li>
                        </ul>
                    </div>
                </div></div>`


            return box;
            }


        })

