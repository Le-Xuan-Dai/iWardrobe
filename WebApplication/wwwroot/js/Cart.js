const listOfItems = document.querySelectorAll(".item");
const config = { childList: true, subtree: true };
var price = document.querySelector('.price');

listOfItems.forEach((item) => {
    const increaseBtn = item.querySelector(".increase-btn");
    const decreaseBtn = item.querySelector(".decrease-btn");
    const pricePerItem = item.querySelector(".original-price").innerHTML;
    var currentAmount = item.querySelector(".amount").innerHTML;
    var checkboxIsChecked = item.querySelector(".buy-checking");
    var cartIdhidden = item.querySelector(".cartIdhidden").innerHTML;

   
    checkboxIsChecked.addEventListener("change", (e) => {
        hideOtherCheckbox(checkboxIsChecked, cartIdhidden, pricePerItem * currentAmount, document.querySelector('.cartId'), price);
    })

});


function hideOtherCheckbox(currentCheckbox, cartIdhidden, totalPrice, cartId, priceHtml) {
    const listOfCheckbox = document.querySelectorAll('.buy-checking');
    var cartId = document.querySelector('.cartId');

    listOfCheckbox.forEach(checkbox => {
        if (currentCheckbox.checked) {

            cartId.value = cartIdhidden;
            priceHtml.value = totalPrice;
            console.log(cartId.value);
            if (checkbox !== currentCheckbox) {
                checkbox.style.visibility = 'hidden';
            }
        } else {
            cartId.value = 0;
            console.log(cartId.value);

            checkbox.style.visibility = 'visible';
        }
    })
}

