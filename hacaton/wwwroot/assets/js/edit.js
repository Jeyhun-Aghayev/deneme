const sidebar_content_edit = document.querySelector(".sidebar_content_edit")
const sidebar_content_edit_inputs = document.querySelector(".sidebar_content_edit_inputs")
const sidebar_content_standart = document.querySelector(".sidebar_content_standart")
sidebar_content_edit.addEventListener("click", function () {
    sidebar_content_edit_inputs.classList.toggle("block")

})