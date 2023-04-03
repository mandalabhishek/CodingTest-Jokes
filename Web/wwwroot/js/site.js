// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetJokes() {
    $.ajax({
        type: "Get",
        url: "/Jokes/GetJokes",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $("#setup").text(data.setup);
            $("#punchline").text(data.punchline);
        },
        error: function () {
            alert("Error occured!!")
        }
    });
}
$("#nextJoke").click(function () {
    GetJokes();
});

function GetJokesCount() {
    $.ajax({
        type: "Get",
        url: "/Jokes/GetJokesCount",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $('#parentDiv').css('display', '');
            $("#count").text(data);
        },
        error: function () {
            alert("Error occured!!")
        }
    });
}
$("#jokeCount").click(function () {
    GetJokesCount();
});
