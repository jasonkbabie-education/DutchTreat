var productInfo = $(".product-props li");

productInfo.on("click", function () {
    console.log("You clicked on " + $(this).text());
});

var button = $("#buy-button");
button.on("click", function () {
    alert("Nigga! You bought ;)");
});