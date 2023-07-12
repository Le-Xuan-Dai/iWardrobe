const listOfItem = document.querySelectorAll('.item');
const btnChooseVoucher = document.querySelector('.btn-voucher');

listOfItem.forEach((item) => {
    var currentAmount = item.querySelector('.amount').innerHTML;
    var increaseBtn = item.querySelector('.increase-btn');
    var decreaseBtn = item.querySelector('.decrease-btn');
    const price = item.querySelector('.original-price').innerHTML;
    var currentPrice = item.querySelector('.price').innerHTML;

    increaseBtn.addEventListener('click', () => {
        currentAmount++;
        item.querySelector('.amount').innerHTML = currentAmount;
        item.querySelector('.price').innerHTML = price * currentAmount;
        item.querySelector('.quantity').value = currentAmount;
    })

    decreaseBtn.addEventListener('click', () => {
        if (currentAmount <= 1) {
            return;
        } else {
            currentAmount--;
            item.querySelector('.amount').innerHTML = currentAmount;
            item.querySelector('.price').innerHTML = price * currentAmount;
            item.querySelector('.quantity').value = currentAmount;
        }
    })
})
btnChooseVoucher.addEventListener('click', () => {
    document.querySelector('.voucher-wrapper').style.display = 'block';
})
document.querySelector('.btn-close').addEventListener('click', () => {
    document.querySelector('.voucher-wrapper').style.display = 'none';
})