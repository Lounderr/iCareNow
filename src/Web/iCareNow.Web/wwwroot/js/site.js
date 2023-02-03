const navbar = document.querySelector('.navbar');

window.onload = () => {
    document.body.classList.toggle("preload");
}

window.onresize = () => {
    navbar.classList.remove('--mobile-active');
    document.body.classList.remove('--disable-body-scroll');
    shrinkNavOnScroll();
}

window.onscroll = () => {
    if (window.scrollY > 0) {
        navbar.classList.add('scrolled');
    } else {
        navbar.classList.remove('scrolled');
    }

    shrinkNavOnScroll()
};

showCookieConsent();
togglePasswordVisibility();

function showCookieConsent() {
    if (document.cookie.indexOf('.AspNet.Consent=') == -1) {
        const consentWindow = document.querySelector("#cookieConsent");
        const button = document.querySelector("#cookieConsent .cookieConsentButton");
        button.addEventListener("click", function () {
            document.cookie = button.dataset.cookieString;
            consentWindow.style.display = "none";
        }, false);
    }
}

function togglePasswordVisibility() {
    const eyeIcons = document.querySelectorAll('.-password-show-toggle');

    for (const eyeIcon of eyeIcons) {
        eyeIcon.addEventListener('click', (event) => {
            const inputElement = event.target.parentElement.querySelector('input');

            if (inputElement.type === 'password') {
                inputElement.type = 'text'
            }
            else {
                inputElement.type = 'password'
            }

            const inputEyes = event.target.parentElement.querySelectorAll('.-password-show-toggle');

            for (const inputEye of inputEyes) {
                inputEye.classList.toggle("--active");
            }
        })
    }
}

function shrinkNavOnScroll() {
    if (window.innerWidth > 950 && window.innerWidth < 1100) {
        if (document.body.scrollTop > 0 || document.documentElement.scrollTop > 0) {
            navbar.style.height = "70px";
        } else {
            navbar.style.height = "90px";
        }
    }

    else if (window.innerWidth > 950) {
        if (document.body.scrollTop > 0 || document.documentElement.scrollTop > 0) {
            navbar.style.height = "80px";
        } else {
            navbar.style.height = "120px";
        }
    }
    else {
        navbar.style.height = "";
    }
}

function toggleMenu() {
    navbar.classList.toggle('--mobile-active');
    document.body.classList.toggle('--disable-body-scroll');
}