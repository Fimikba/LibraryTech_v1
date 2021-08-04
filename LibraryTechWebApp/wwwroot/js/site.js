// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function agreeForm(checkbox, hiden) {
    if (document.getElementById(checkbox).checked) {
        document.getElementById(hiden).disabled = true;
    } else {
        document.getElementById(hiden).disabled = false;
    }
}

function viewDiv() {
    document.getElementById("div1").style.display = "block";
};