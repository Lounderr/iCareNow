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


//addEventListener("scroll", (event) => {
//    const navbar = document.querySelector('.top-nav');
//    navbar.classList.toggle('nav-active');

//    console.log(navbar);

//    if (window.scrollY > 100) {
//        navbar.classList.toggle('nav-active');
//    } else {
//        navbar.classList.remove('nav-active');
//    }
//});


const navbar = document.querySelector('.top-nav');
window.onscroll = () => {
    console.log(window.scrollY);

    if (window.scrollY > 0) {
        navbar.classList.add('scrolled');
    } else {
        navbar.classList.remove('scrolled');
    }
};