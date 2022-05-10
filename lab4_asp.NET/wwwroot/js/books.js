const selectEl = document.getElementById("filter-select");
const cards = document.getElementsByClassName("book-card")

for (let idx = 0; idx < cards.length; idx++) {
    cards[idx].addEventListener("click", function () {
        const a = document.createElement("a")
        a.className = "invisible-a"
        a.setAttribute("hidden", "true")
        a.href = `/Books/book/${cards[idx].id.charAt(cards[idx].id.length - 1)}`
        a.click()
        document.removeChild("invisible-a")
    })
}
