const navItems = document.querySelector('.nav-items');
const controls = document.querySelector('.menu-controls');

addEventListener("resize", (event) => {
    controls.classList.remove('menu-active');
    navItems.classList.remove('nav-active');
});

function toggleMenu() {
    navItems.classList.toggle('nav-active');
    controls.classList.toggle('menu-active');
}

const filtersOpen = document.querySelector('.filters-open');
function toggleFilters() {
    filtersOpen.classList.toggle('hidden');
}

const navbar = document.querySelector('.top-nav');
window.onscroll = () => {
    if (window.scrollY > 0) {
        navbar.classList.add('scrolled');
    } else {
        navbar.classList.remove('scrolled');
    }
};

// Requires refactoring
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
//