// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



window.addEventListener('load', covidfetch, false)

function covidfetch() {
    alert('this is working');
    const response = await fetch('https://api.apify.com/v2/key-value-stores/Eb694wt67UxjdSGbc/records/LATEST?disableRedirect=true');
    const data = await response.json();
    let deathNoElement = document.getElementById('deathhead');
    deathNoElement.innerHTML = data.deceased;
}
