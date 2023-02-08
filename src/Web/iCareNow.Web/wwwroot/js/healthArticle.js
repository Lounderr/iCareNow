window.onbeforeunload = (event) => {
    synth.cancel();
}

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


        setTimeout(() => {
            if (synth.getVoices().map(x => x.lang).includes("bg-BG")) {
                const utterContent = new SpeechSynthesisUtterance(inputTxt);
                utterContent.lang = "bg-BG";
                synth.speak(utterContent);
            }
            else {
                const noPackError = "Error. Bulgarian speech pack not installed!";
                const utterError = new SpeechSynthesisUtterance(noPackError);
                utterError.lang = "en-GB";
                synth.speak(utterError);
            }
        }, 30)

    }

    toggleButtonState();
}

function toggleButtonState() {
    const readArticleButton = document.querySelector(".tts-speaker-container");

    for (let i = 0; i < readArticleButton.children.length; i++) {
        readArticleButton.children[i].classList.toggle("active");
    }
}

function toggleArticleDeleteConfirmation() {
    let deleteOverlay = document.querySelector(".admin-delete-confirm-darken");
    deleteOverlay.classList.toggle("-hide");
}