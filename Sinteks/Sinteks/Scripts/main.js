$(function () {
    $(".btn_json").on("click", function () {
        location.href = "/api/Sale?type=json"; 
    })
    $(".btn_xml").on("click", function () {
        location.href = "/api/Sale?type=xml"
    })

    function calculate() {
        let price = $(".product").find(":selected").data("pro-price");
        let amount = $(".amount").val() == "" ? 1 : $(".amount").val();
        let totalPrice = amount * price;
        $(".total_price").val(totalPrice);
    }

    $(".product").on("change", function () {
        calculate();
    })


    $(".amount").on("input", function () {
        calculate();
    })
})

 