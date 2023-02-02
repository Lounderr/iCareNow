window.onload = () => {
    document.body.classList.toggle("preload");
}

const navbar = document.querySelector('.navbar');

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


addEventListener("resize", (event) => {
    navbar.classList.remove('--mobile-active');
    document.body.classList.remove('--disable-body-scroll');
    shrinkNavOnScroll();
});

function toggleMenu() {
    navbar.classList.toggle('--mobile-active');
    document.body.classList.toggle('--disable-body-scroll');
}

const filtersOpen = document.querySelector('.filters-open');
function toggleFilters() {
    filtersOpen.classList.toggle('hidden');
}

var prevScrollpos = window.pageYOffset;
function hideNavOnScroll() {
    if (!navbar.classList.contains('--mobile-active') && window.innerWidth <= 950) {
        currentScrollPos = window.pageYOffset;
        if (prevScrollpos > currentScrollPos) {
            document.querySelector(".navbar").style.top = "0";
        } else {
            document.querySelector(".navbar").style.top = "-55px";
        }
        prevScrollpos = currentScrollPos;
    }
}

window.onscroll = () => {
    if (window.scrollY > 0) {
        navbar.classList.add('scrolled');
    } else {
        navbar.classList.remove('scrolled');
    }

    //hideNavOnScroll();
    shrinkNavOnScroll()
};

if (document.cookie.indexOf('.AspNet.Consent=') == -1) {
    var consentWindow = document.querySelector("#cookieConsent");
    var button = document.querySelector("#cookieConsent .cookieConsentButton");
    button.addEventListener("click", function () {
        document.cookie = button.dataset.cookieString;
        consentWindow.style.display = "none";
    }, false);
}

const passInputContainers = document.querySelectorAll('.--password');

if (passInputContainers != null) {

    for (const passdInputContainer of passInputContainers) {
        const showHideIcons = Array.from(passdInputContainer.children).filter(x => x.classList.contains("-password-show-toggle"));
        const inputField = Array.from(passdInputContainer.children).filter(x => x.tagName == "INPUT")[0];

        for (const showHideIcon of showHideIcons) {
            showHideIcon.onclick = function () {
                if (inputField.getAttribute("type") == "password") {
                    inputField.setAttribute('type', 'text');
                }
                else {
                    inputField.setAttribute('type', 'password');
                }

                for (const showHideIcon2 of showHideIcons) {
                    showHideIcon2.classList.toggle("--active");
                }
            }
        }
    }
}