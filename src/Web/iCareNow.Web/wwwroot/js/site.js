// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




function toggleMenu() {
    const navContainer = document.getElementsByClassName('nav-items-container')[0];
    const controls = document.getElementsByClassName('menu-controls')[0];

    controls.classList.toggle('menu-active');
    navContainer.classList.toggle('nav-active');

    if (this.navContainer.classList.contains('nav-active')) {
        document.body.style.overflow = 'hidden';
    } else {
        document.body.style.overflow = 'visible';
    }
}

addEventListener("resize", (event) => {
    let navContainer = document.getElementsByClassName('nav-items-container')[0];
    let controls = document.getElementsByClassName('menu-controls')[0];

    controls.classList.remove('menu-active');
    navContainer.classList.remove('nav-active');
});