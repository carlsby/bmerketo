function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element);
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight);

        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen);
        _element.classList.toggle('position-static', isTallerThanScreen);
    } catch { }
}
footerPosition('footer', document.body.scrollHeight, window.innerHeight);


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
