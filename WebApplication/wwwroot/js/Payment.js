const momoPayment = document.querySelector(".momo-payment");
const zaloPayment = document.querySelector(".zalo-payment");
const delivery_detail = document.querySelector(".delivery_detail");
const delivery_method = document.querySelector(".delivery_methods")
const payment_detail = document.querySelector(".payment_detail");
const note = document.querySelector(".note");

const formDeliveryDetail = document.querySelector(".form-delivery_detail");
const formPaymentDetail = document.querySelector(".form-payment_detail");
const formDeliveryMethod = document.querySelector(".form-delivery_method");
const formNote = document.querySelector(".form-note");

momoPayment.addEventListener('click', () => {
    alert("This functionality will launch soon.");
})
zaloPayment.addEventListener('click', () => {
    alert("This functionality will launch soon.");
})

delivery_detail.addEventListener('change', (e) => {
    formDeliveryDetail.value = e.target.value;
})
payment_detail.addEventListener('change', (e) => {
    formPaymentDetail.value = e.target.value;
})
note.addEventListener('change', (e) => {
    formNote.value = e.target.value;
    console.log(formNote.value);
})
delivery_method.value = "Grab"
delivery_method.addEventListener('change', (e) => {
    formDeliveryMethod.value = e.target.value;
    console.log(formNote.value);
})