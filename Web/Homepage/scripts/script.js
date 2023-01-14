document.addEventListener("DOMContentLoaded", main)

function main()
{
    alert("Welcome to the Pool Lounge");
    document.getElementById("submit").addEventListener("click", post);
}

function post()
{
    var name = document.getElementById("username").value;
    var comment = document.getElementById("comment").value;
    var post = `<div class="comment"><h3 class="comment-name">${name}</h3>
                <p class="comment-content">${comment}</p></div>`;
    document.getElementById("commentSection").innerHTML += post;
    document.getElementById("username").value = "";
    document.getElementById("comment").value = "";
}
