$(document).ready(function () {
    var i = 1;
    setInterval(function () {
        $('.count').text('(' + i + ')');
        if (i === 5) {
            window.location.href = "/rating";
        }
        i++;
    }, 1000);
});