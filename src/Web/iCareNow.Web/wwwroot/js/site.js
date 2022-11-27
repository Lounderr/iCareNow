const navContainer = document.querySelector('.nav-items-container');
const controls = document.querySelector('.menu-controls');

addEventListener("resize", (event) => {
    controls.classList.remove('menu-active');
    navContainer.classList.remove('nav-active');
});

function toggleMenu() {
    navContainer.classList.toggle('nav-active');
    controls.classList.toggle('menu-active');
}