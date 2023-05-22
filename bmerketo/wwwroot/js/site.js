
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

        const price = number * parseFloat(document.getElementById('price').getAttribute('data-price'));
        document.getElementById('price').innerHTML = '$' + price.toFixed(0);

        const discount = number * parseFloat(document.getElementById('discount').getAttribute('data-price'));
        document.getElementById('discount').innerHTML = '$' + discount.toFixed(0);
    }
}

function displayImage(url) {
    document.getElementById("image-preview").innerHTML = "";

    const img = document.createElement("img");
    img.setAttribute("src", url);
    img.style.width = "75px";
    img.style.height = "75px";
    img.style.margin = "20px";

    document.getElementById("image-preview").appendChild(img);
}

function validationScript() {
    const myInput = document.getElementById("psw");
    const confirm = document.getElementById("cfm-psw");
    const firstName = document.getElementById("firstname");
    const lastName = document.getElementById("lastname");
    const phoneNumber = document.getElementById("phonenumber");
    const email = document.getElementById("email");
    const postalCode = document.getElementById("postalcode");
    const city = document.getElementById("city");

    const letter = document.getElementById("letter");
    const capital = document.getElementById("capital");
    const number = document.getElementById("number");
    const length = document.getElementById("length");
    const compare = document.getElementById("compare");
    const special = document.getElementById("special");
    const fName = document.getElementById("fnameCheck");
    const lName = document.getElementById("lnameCheck");
    const phone = document.getElementById("phoneCheck");
    const emailCheck = document.getElementById("emailCheck");
    const postalCheck = document.getElementById("postalCheck");
    const cityCheck = document.getElementById("cityCheck");

    const regName = /^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$/;
    const regPhone = /^07[02369]\d{7}$/;
    const regEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    const regPostal = /^(?:SE-)?\d{3}\s?\d{2}$/;
    const regCity = /^[a-zA-ZåäöÅÄÖ]{3,}$/;
    const numbers = /[0-9]/g;
    const specCharReg = /^(?=.*[!@#$%^&*()_\-+=\[\]{};':"\\|,.<>\/?]).*$/;

    myInput.onkeyup = function () {

        const lowerCaseLetters = /[a-z]/g;

        if (myInput.value.match(lowerCaseLetters)) {
            letter.classList.remove("invalid");
            letter.classList.add("valid");
        } else {
            letter.classList.remove("valid");
            letter.classList.add("invalid");
        }

        if (myInput.value.match(specCharReg)) {
            special.classList.remove("invalid");
            special.classList.add("valid");
        } else {
            special.classList.remove("valid");
            special.classList.add("invalid");
        }

        const upperCaseLetters = /[A-Z]/g;

        if (myInput.value.match(upperCaseLetters)) {
            capital.classList.remove("invalid");
            capital.classList.add("valid");
        } else {
            capital.classList.remove("valid");
            capital.classList.add("invalid");
        }

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


    confirm.onkeyup = function () {
        if (confirm.value.match(myInput.value)) {
            compare.classList.remove("invalid");
            compare.classList.add("valid");
        } else {
            compare.classList.remove("valid");
            compare.classList.add("invalid");
        }
    }

    firstName.onkeyup = function () {
        if (firstName.value.match(regName)) {
            fName.style.display = "none";
            fName.classList.remove("invalid");
            fName.classList.add("valid");
        } else {
            fName.style.display = "block";
            fName.classList.remove("valid");
            fName.classList.add("invalid");
        }
    }

    lastName.onkeyup = function () {
        if (lastName.value.match(regName)) {
            lName.style.display = "none";
            lName.classList.remove("invalid");
            lName.classList.add("valid");
        } else {
            lName.style.display = "block";
            lName.classList.remove("valid");
            lName.classList.add("invalid");
        }
    }

    phoneNumber.onkeyup = function () {
        if (phoneNumber.value.match(regPhone)) {
            phone.style.display = "none";
            phone.classList.remove("invalid");
            phone.classList.add("valid");
        } else {
            phone.style.display = "block";
            phone.classList.remove("valid");
            phone.classList.add("invalid");
        }
    }

    email.onkeyup = function () {
        if (email.value.match(regEmail)) {
            emailCheck.style.display = "none";
            emailCheck.classList.remove("invalid");
            emailCheck.classList.add("valid");
        } else {
            emailCheck.style.display = "block";
            emailCheck.classList.remove("valid");
            emailCheck.classList.add("invalid");
        }
    }

    postalCode.onkeyup = function () {
        if (postalCode.value.match(regPostal)) {
            postalCheck.style.display = "none";
            postalCheck.classList.remove("invalid");
            postalCheck.classList.add("valid");
        } else {
            postalCheck.style.display = "block";
            postalCheck.classList.remove("valid");
            postalCheck.classList.add("invalid");
        }
    }

    city.onkeyup = function () {
        if (city.value.match(regCity)) {
            cityCheck.style.display = "none";
            cityCheck.classList.remove("invalid");
            cityCheck.classList.add("valid");
        } else {
            cityCheck.style.display = "block";
            cityCheck.classList.remove("valid");
            cityCheck.classList.add("invalid");
        }
    }
}

function contactValidation() {
    const fullName = document.getElementById("fullname");
    const phoneNumber = document.getElementById("phonenumber");
    const email = document.getElementById("email");
    const comment = document.getElementById("comment");
    const company = document.getElementById("company");

    const fName = document.getElementById("nameCheck");
    const phone = document.getElementById("phoneCheck");
    const emailCheck = document.getElementById("emailCheck");
    const commentCheck = document.getElementById("commentCheck");
    const companyCheck = document.getElementById("companyCheck");

    const regName = /^[a-öA-Ö\s]+(?:[é'-][a-öA-Ö\s]+)*$/;
    const regPhone = /^07[02369]\d{7}$/;
    const regEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    const regComment = /^[\s\S]{0,500}$/;
    const regCompany = /^[\s\S]{0,100}$/;



    fullName.onkeyup = function () {
        if (fullName.value.match(regName)) {
            fName.style.display = "none";
            fName.classList.remove("invalid");
            fName.classList.add("valid");
        } else {
            fName.style.display = "block";
            fName.classList.remove("valid");
            fName.classList.add("invalid");
        }
    }

    phoneNumber.onkeyup = function () {
        if (phoneNumber.value.match(regPhone)) {
            phone.style.display = "none";
            phone.classList.remove("invalid");
            phone.classList.add("valid");
        } else {
            phone.style.display = "block";
            phone.classList.remove("valid");
            phone.classList.add("invalid");
        }
    }

    email.onkeyup = function () {
        if (email.value.match(regEmail)) {
            emailCheck.style.display = "none";
            emailCheck.classList.remove("invalid");
            emailCheck.classList.add("valid");
        } else {
            emailCheck.style.display = "block";
            emailCheck.classList.remove("valid");
            emailCheck.classList.add("invalid");
        }
    }

    comment.onkeyup = function () {

        const commentValue = comment.value;
        const signCount = commentValue.length;
        commentCheck.innerHTML = signCount + "/500 characters";

        if (commentValue.match(regComment)) {
            commentCheck.style.color = "black";
        } else {
            commentCheck.style.color = "red";
        }
    }

    company.onkeyup = function () {

        const companyValue = company.value;
        const charCount = companyValue.length;
        companyCheck.innerHTML = charCount + "/100 characters";

        if (companyValue.match(regCompany)) {
            companyCheck.style.color = "black";
        } else {
            companyCheck.style.color = "red";
        }
    }
}

function productValidation() {
    const isOnSaleCheckbox = document.getElementById("tag-OnSale-4");
    const discountPriceDiv = document.getElementById("discount-price-div");

    isOnSaleCheckbox.addEventListener("change", function () {
        if (this.checked) {
            discountPriceDiv.style.display = "block";
        } else {
            discountPriceDiv.style.display = "none";
            discountPrice.value = "";
        }
    });

    const productName = document.getElementById("name");
    const productPrice = document.getElementById("price");
    const productImage = document.getElementById("image");
    const discountPrice = document.getElementById("discountPrice");

    const nameCheck = document.getElementById("nameCheck");
    const priceCheck = document.getElementById("priceCheck");
    const imageCheck = document.getElementById("imageCheck");
    const discountCheck = document.getElementById("discountCheck");

    const regProductName = /^(?!.*_)[\w\s"-]*$/;
    const regProductPrice = /^\d+(\.\d{1,2})?$/;
    const regImage = /^(https?|ftp):\/\/[^\s/$.?#].[^\s]*$/;
    const regDiscount = /^\d+(\.\d{1,2})?$/;

    productName.onkeyup = function () {
        if (productName.value.match(regProductName)) {
            nameCheck.style.display = "none";
            nameCheck.classList.remove("invalid");
            nameCheck.classList.add("valid");
        } else {
            nameCheck.style.display = "block";
            nameCheck.classList.remove("valid");
            nameCheck.classList.add("invalid");
        }
    }

    productPrice.onkeyup = function () {
        if (productPrice.value.match(regProductPrice)) {
            priceCheck.style.display = "none";
            priceCheck.classList.remove("invalid");
            priceCheck.classList.add("valid");
        } else {
            priceCheck.style.display = "block";
            priceCheck.classList.remove("valid");
            priceCheck.classList.add("invalid");
        }
    }

    productImage.onkeyup = function () {
        if (productImage.value.match(regImage)) {
            imageCheck.style.display = "none";
            imageCheck.classList.remove("invalid");
            imageCheck.classList.add("valid");
        } else {
            imageCheck.style.display = "block";
            imageCheck.classList.remove("valid");
            imageCheck.classList.add("invalid");
        }
    }

    discountPrice.onkeyup = function () {
        if (discountPrice.value.match(regDiscount)) {
            discountCheck.style.display = "none";
            discountCheck.classList.remove("invalid");
            discountCheck.classList.add("valid");
        } else {
            discountCheck.style.display = "block";
            discountCheck.classList.remove("valid");
            discountCheck.classList.add("invalid");
        }
    }
}