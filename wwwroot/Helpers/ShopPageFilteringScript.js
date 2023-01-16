
ShopPageFilter = {
   
    filterSelection: function (categoryString) {

        ShopPageFilter.setBtnToActive(categoryString);

        var boxElements, i;
        boxElements = document.getElementsByClassName("filterDiv");
        if (categoryString == "all") categoryString = "";
        // Add the "show" class (display:block) to the filtered elements, and remove the "show" class from the elements that are not selected
        for (i = 0; i < boxElements.length; i++) {
            ShopPageFilter.w3RemoveClass(boxElements[i], "show");
            if (boxElements[i].className.indexOf(categoryString) > -1) // checks that if box has categoryElement class . if yes then add show class to it 
                ShopPageFilter.w3AddClass(boxElements[i], "show");
        }

    },

    w3AddClass: function (element, name) {
        var i, arr1, arr2;
        arr1 = element.className.split(" ");
        arr2 = name.split(" ");
        for (i = 0; i < arr2.length; i++) {
            if (arr1.indexOf(arr2[i]) == -1) {
                element.className += " " + arr2[i];
            }
        }
    },

    w3RemoveClass: function (element, name) {
    var i, arr1, arr2;
    arr1 = element.className.split(" ");
    arr2 = name.split(" ");
    for (i = 0; i < arr2.length; i++) {
        while (arr1.indexOf(arr2[i]) > -1) {
            arr1.splice(arr1.indexOf(arr2[i]), 1);
        }
    }
    element.className = arr1.join(" ");
},

    setBtnToActive: function (activatedCategoryBtn) {
    

        var current = document.getElementsByClassName("active");
      
        if (current.length != 0)
            current[0].className = current[0].className.replace(" active", "");

        var activatedBtn = document.querySelector(`.btn-${activatedCategoryBtn}`);
       

        activatedBtn.className += " active";


      
}
}













