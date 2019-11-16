
function playSound(wordId) {
    var audio = document.getElementById(wordId);
    audio.play();
}

function changeTheme() {
    if ($("#selectedTheme").val() == "Dark") {
        $("#link-theme-css").attr("href", "/Content/dark-theme.css");
    } else if ($("#selectedTheme").val() == "Light") {
        $("#link-theme-css").attr("href", "/Content/light-theme.css");
    }
}

function initializeCKEditor(id) {
    // instance, using default configuration.
    CKEDITOR.replace(id);
    //CKEDITOR.config.font_defaultLabel = 'Tahoma';
    //CKEDITOR.config.fontSize_defaultLabel = '20';
}

function setValueCKEditor(id, value) {
    CKEDITOR.instances[id].setData(value);
}
