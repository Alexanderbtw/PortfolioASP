document.querySelectorAll(".carousel img").forEach(image => {
    image.onclick = () => {
        document.querySelector(".popup-img").style.display = "block";
        document.querySelector(".popup-img img").src = image.src;
        document.querySelector(".popup-img h5").textContent = image.alt;
    }
});

document.querySelector(".popup-img span").onclick = () => {
    document.querySelector(".popup-img").style.display = "none";
}