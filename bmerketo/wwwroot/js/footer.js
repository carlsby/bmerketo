function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element);
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight);

        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen);
        _element.classList.toggle('position-static', isTallerThanScreen);
    } catch { }
}
footerPosition('footer', document.body.scrollHeight, window.innerHeight);