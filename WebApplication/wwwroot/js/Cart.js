const listOfItems = document.querySelectorAll(".table-row");
const btnPurchase = document.querySelector('.btn-purchase');
var cartId = document.querySelector('.cartId');
const errorMessage = document.querySelector('.error-message');

listOfItems.forEach((item) => {
    var checkboxIsChecked = item.querySelector(".product-pick");
    var cartItemId = item.querySelector('.cartIdhidden').innerHTML;
    checkboxIsChecked.addEventListener("change", (e) => {
        hideOtherCheckbox(checkboxIsChecked, cartItemId);
    })
});

setTimeout(() => {
    errorMessage.style.display = "none";
}, 2000)

function hideOtherCheckbox(currentCheckbox, cartItemId) {
    const listOfCheckbox = document.querySelectorAll('.product-pick');

    listOfCheckbox.forEach(checkbox => {
        if (currentCheckbox.checked) {
            if (checkbox !== currentCheckbox) {
                cartId.value = cartItemId;
                checkbox.style.visibility = 'hidden';
                btnPurchase.style.backgroundColor = "rgb(154 205 50)";
                btnPurchase.disabled = false;
            }
        } else {
            cartId.value = 0;
            btnPurchase.style.backgroundColor = "rgba( 169, 169, 169, 1 )";
            btnPurchase.disabled = true;
            checkbox.style.visibility = 'visible';
        }
    })
}


