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

    hideNavOnScroll();
    shrinkNavOnScroll()
};

var currentSlide = 0;
const userQuotes = document.querySelectorAll('.user-quote');
const userQuotesDots = document.querySelectorAll('.user-quote-dot');
function showSlide(n) {
    userQuotes[currentSlide].classList.toggle('active');
    userQuotes[n].classList.toggle('active');

    userQuotesDots[currentSlide].classList.toggle('active');
    userQuotesDots[n].classList.toggle('active');
    currentSlide = n;
}

let cycleTimeout = setTimeout(cycleNext, 8000);

function cycleNext() {
    let nextQuote = currentSlide + 1;
    if (nextQuote > userQuotes.length - 1) {
        nextQuote = 0;
    }

    showSlide(nextQuote);

    cycleTimeout = setTimeout(cycleNext, 8000);
}

function userClickSlide(n) {
    clearTimeout(cycleTimeout);
    showSlide(n);
}