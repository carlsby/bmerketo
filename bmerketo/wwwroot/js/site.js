try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    toggleBtn.addEventListener('click', function () {
        const element = document.querySelector(toggleBtn.getAttribute('data-target'))

        if (!element.classList.contains('open-menu')) {
            element.classList.add('open-menu')
            toggleBtn.classList.add('btn-outline-dark')
            toggleBtn.classList.add('btn-toggle-white')
        }

        else {
            element.classList.remove('open-menu')
            toggleBtn.classList.remove('btn-outline-dark')
            toggleBtn.classList.remove('btn-toggle-white')
        }
    })

} catch { }

let number = 1;

function Plusnumber() {
    if (number < 20) {
        number++;
        document.getElementById('input-quantity').value = number;
        UpdateNumber();
    }
}

function Minusnumber() {
    if (number != 1) {
        number--;
        document.getElementById('input-quantity').value = number;
        UpdateNumber();
    }
}

function UpdateNumber() {
    if (number < 21) {
        number = parseInt(document.getElementById('input-quantity').value);

        var price = number * parseFloat(document.getElementById('price').getAttribute('data-price'));
        document.getElementById('price').innerHTML = '$' + price.toFixed(0);

        var discount = (number / 2) * parseFloat(document.getElementById('discount').getAttribute('data-price'));
        document.getElementById('discount').innerHTML = '$' + discount.toFixed(0);
    }

}

function displayImage(url) {
    document.getElementById("image-preview").innerHTML = "";

    var img = document.createElement("img");
    img.setAttribute("src", url);
    img.style.width = "75px";
    img.style.height = "75px";
    img.style.margin = "20px";

    document.getElementById("image-preview").appendChild(img);
}

function validationScript() {
    var myInput = document.getElementById("psw");
    var letter = document.getElementById("letter");
    var capital = document.getElementById("capital");
    var number = document.getElementById("number");
    var length = document.getElementById("length");



    myInput.onkeyup = function () {

        var lowerCaseLetters = /[a-z]/g;

        if (myInput.value.match(lowerCaseLetters)) {
            letter.classList.remove("invalid");
            letter.classList.add("valid");
        } else {
            letter.classList.remove("valid");
            letter.classList.add("invalid");
        }

        var upperCaseLetters = /[A-Z]/g;

        if (myInput.value.match(upperCaseLetters)) {
            capital.classList.remove("invalid");
            capital.classList.add("valid");
        } else {
            capital.classList.remove("valid");
            capital.classList.add("invalid");
        }

        var numbers = /[0-9]/g;
        if (myInput.value.match(numbers)) {
            number.classList.remove("invalid");
            number.classList.add("valid");
        } else {
            number.classList.remove("valid");
            number.classList.add("invalid");
        }

        if (myInput.value.length >= 8) {
            length.classList.remove("invalid");
            length.classList.add("valid");
        } else {
            length.classList.remove("valid");
            length.classList.add("invalid");
        }
    }
}
