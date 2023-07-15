const listOfItems = document.querySelectorAll(".item");
const config = { childList: true, subtree: true };
var price = document.querySelector('.price');
var btnPayment = document.querySelector('.btnPayment');
listOfItems.forEach((item) => {
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
            btnPayment.style.backgroundColor = "rgb(154 205 50)";
            btnPayment.disabled = false;
            cartId.value = cartIdhidden;
            priceHtml.value = totalPrice;
            console.log(cartId.value);
            if (checkbox !== currentCheckbox) {
                checkbox.style.visibility = 'hidden';
            }
        } else {
            cartId.value = 0;
            console.log(cartId.value);
            btnPayment.style.backgroundColor = "rgba( 169, 169, 169, 1 )";
            btnPayment.disabled = true;
            checkbox.style.visibility = 'visible';
        }
    })
}

