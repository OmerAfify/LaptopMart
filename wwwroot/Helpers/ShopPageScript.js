
var productsList = $(".products-data");
var categoryFilters = $(".catNamesFilter");


    $(document).ready(function () {

    GetAllItems();
        GetAllCategories();



    function GetItemsByCategory(catId) {

            $.ajax({
                type: "GET",
                url: "/api/GetItemsByCatId/"+catId,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    $('#pagination-shopPage').pagination({
                        dataSource: response,
                        pageSize: 8,
                        showGoInput: true,
                        showGoButton: true,
                        showPrevious: false,
                        showNext: false,
                        autoHidePrevious: true,
                        autoHideNext: true,

                        callback: function (data, pagination) {
                            productsList.html("");
                            var html = "";
                            for (let item of data) {

                                var box = DrawItem(item);
                                html += box;


                            }
                            productsList.html(html);

                        }
                    })





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


            };

    function GetAllItems() {

        $.ajax({
            type: "GET",
            url: "/api/GetItems",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                $('#pagination-shopPage').pagination({
                    dataSource: response,
                    pageSize: 8,
                    showGoInput: true,
                    showGoButton: true,
                    showPrevious: false,
                    showNext: false,
                    autoHidePrevious: true,
                    autoHideNext: true,
                    
                    callback: function (data, pagination) {
                        productsList.html("");
                        var html = "";
                        for (let item of data) {
                            
                            var box = DrawItem(item);
                            html += box;
                           

                        }
                        productsList.html(html);
                        
                    }
                })


               


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

                                       <button class="btn btnCatFilter btn-all" >all</button>

                                      </div>
                                       `
                categoryFilters.append(allBox);


                var btn = document.querySelector(".btn-all");
        
                btn.addEventListener("click", function () {
                    GetAllItems()
                    SetButtonToActive("all");
      
                })



                for (let brand of response) {

                    let brandBox = ` <div class="custom-control custom-checkbox collection-filter-checkbox">

                                       <button class="btn individual btnCatFilter btn-cat-${brand.categoryId}" data-catId='${brand.categoryId}'  )">${brand.categoryName}</button>

                                      </div>
                                       `
                    categoryFilters.append(brandBox);
                    


                }

                var btns = document.querySelectorAll(".individual.btnCatFilter");


                btns.forEach(btn => {

                    btn.addEventListener('click', event => {

                        GetItemsByCategory(btn.getAttribute("data-catId"))
                        SetButtonToActive("cat-"+btn.getAttribute("data-catId"))

                    });

                })


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
                   
                        <img src=${ (item.imageName == null || item.imageName == "") ? "/Website/images/pro3/33.jpg" : "/Uploads/Images/ItemImages/" + item.imageName }
                            class="img-fluid blur-up lazyload bg-img" alt="">
           
        </div>
                    <div class="back">
                       
                              <img src=${ (item.imageName == null || item.imageName == "") ? "/Website/images/pro3/34.jpg" : "/Uploads/Images/ItemImages/" + item.imageName}
                          class="img-fluid blur-up lazyload bg-img" alt="">
          
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


    function SetButtonToActive(activatedCategoryBtn) {


            var current = document.getElementsByClassName("active");

            if (current.length != 0)
                current[0].className = current[0].className.replace(" active", "");

            var activatedBtn = document.querySelector(`.btn-${activatedCategoryBtn}`);


            activatedBtn.className += " active";
        }


        })

