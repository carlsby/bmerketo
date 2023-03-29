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

    let number = 1;
    function Plusnumber() {
        number++;
        document.getElementById('input-quantity').value = number;
    }

    function Minusnumber() {
        if (number != 1) {
            number--;
            document.getElementById('input-quantity').value = number;
        }
    }

    function UpdateNumber() {

        if (number.isInteger) {
            number = parseInt(document.getElementById('input-quantity').value);
        }
    }

} catch { }

