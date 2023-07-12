const listOfItems = document.querySelectorAll(".item");
const config = { childList: true, subtree: true };
var quantity = document.querySelector('.quantity');
var price = document.querySelector('.price');

listOfItems.forEach((item) => {
    const increaseBtn = item.querySelector(".increase-btn");
    const decreaseBtn = item.querySelector(".decrease-btn");
    const pricePerItem = item.querySelector(".original-price").innerHTML;
    var currentAmount = item.querySelector(".amount").innerHTML;
    var checkboxIsChecked = item.querySelector(".buy-checking");



    increaseBtn.addEventListener("click", () => {
        currentAmount++;

        item.querySelector(".amount").innerHTML = currentAmount;
        item.querySelector(".price").innerHTML = pricePerItem * currentAmount;

    });

    decreaseBtn.addEventListener("click", () => {
        if (currentAmount <= 1) return;
        currentAmount--;
        item.querySelector(".amount").innerHTML = currentAmount;

    });
    checkboxIsChecked.addEventListener("change", (e) => {
        hideOtherCheckbox(checkboxIsChecked, currentAmount, pricePerItem * currentAmount, quantity, price);
    })

});


function hideOtherCheckbox(currentCheckbox, quantity, totalPrice, quantityHtml, priceHtml) {
    const listOfCheckbox = document.querySelectorAll('.buy-checking');

    listOfCheckbox.forEach(checkbox => {
        if (currentCheckbox.checked) {
            quantityHtml.value = quantity;
            console.log(quantityHtml.value);
            if (checkbox !== currentCheckbox) {
                checkbox.style.visibility = 'hidden';
            }
        } else {
            quantityHtml.value = 0;
            priceHtml.value = 0;
            console.log(quantityHtml.value);

            checkbox.style.visibility = 'visible';
        }
    })
}

