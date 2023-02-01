const readArticleButton = document.querySelector(".tts-speaker-container");
const synth = window.speechSynthesis;

function clickTtsBtn() {
    if (synth.speaking) {
        synth.cancel();
    }
    else {
        const articleTitle = document.querySelector(".article-title").textContent;
        const articleDescription = document.querySelector(".article-description").textContent;
        const articleContent = document.querySelector(".article-content").textContent;

        const inputTxt = `${articleTitle}. ${articleDescription}. ${articleContent}`;
        const utterThis = new SpeechSynthesisUtterance(inputTxt);
        utterThis.lang = 'bg-BG';
        synth.speak(utterThis);

        utterThis.onstart = (event) => {
            toggleButtonState()
        }

        utterThis.onend = (event) => {
            toggleButtonState()
        }
    }
}

function toggleButtonState() {
    for (var i = 0; i < readArticleButton.children.length; i++) {
        readArticleButton.children[i].classList.toggle("active");
    }
}