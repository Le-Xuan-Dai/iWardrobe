const body = document.querySelector("body"),
    sidebar = body.querySelector("nav");
sidebarToggle = body.querySelector(".sidebar-toggle");

localStorage.setItem("status", "close");

sidebarToggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
    if (sidebar.classList.contains("close")) {
        localStorage.setItem("status", "close");
    } else {
        localStorage.setItem("status", "open");
    }
});