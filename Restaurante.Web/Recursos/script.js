$document.getElementById("new-toast").addEventListener("click", function () {
    Toastify({
        text: "Plato agregado a su pedido",
        duration: 3000,
    }).showToast();
});