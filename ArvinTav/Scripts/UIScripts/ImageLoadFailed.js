const images = document.getElementsByTagName('img');
for (let image of images) {
    image.setAttribute("onerror", "imageError(this)")
}

function imageError(image) {
    image.onerror = "";
    image.src = "img/Admin/userPro.png";

    return true;
}