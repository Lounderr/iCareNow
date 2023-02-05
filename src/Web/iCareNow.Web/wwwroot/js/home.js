const userQuotes = document.querySelectorAll('.user-quote');
const userQuotesDots = document.querySelectorAll('.user-quote-dot');

let currentSlide = 0;
let cycleTimeout = setTimeout(cycleNext, 8000);

function showSlide(n) {
    userQuotes[currentSlide].classList.toggle('active');
    userQuotes[n].classList.toggle('active');

    userQuotesDots[currentSlide].classList.toggle('active');
    userQuotesDots[n].classList.toggle('active');
    currentSlide = n;
}

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