var SrcStarNotRating = "/img/star-not-rating.png";
var SrcStarRating = "/img/star.png";

var SrcIconHappy = "/img/emoji/happy.png";
var SrcIconCrying = "/img/emoji/crying.png";
var SrcIconInLove = "/img/emoji/in-love.png";
var SrcIconSad = "/img/emoji/sad.png";
var SrcIconSmile = "/img/emoji/smile.png";
var SrcIconUnhappy = "/img/emoji/unhappy.png";

var TextHappy = "Chấp nhận được";
var TextCrying = "Rất không sạch sẽ";
var TextInLove = "Rất sạch sẽ";
var TextSmile = "Sạch sẽ";
var TextUnhappy = "Chưa sạch sẽ";

$(document).ready(function () {
    $(".star1").click(function () {
        $(".icon-rating").attr("src", SrcIconCrying);
        $(".feedback-content").text(TextCrying);
        $(".star1").attr("src", SrcStarRating);
        $(".star2").attr("src", SrcStarNotRating);
        $(".star3").attr("src", SrcStarNotRating);
        $(".star4").attr("src", SrcStarNotRating);
        $(".star5").attr("src", SrcStarNotRating);
    });
    $(".star2").click(function () {
        $(".icon-rating").attr("src", SrcIconUnhappy);
        $(".feedback-content").text(TextUnhappy);
        $(".star1").attr("src", SrcStarRating);
        $(".star2").attr("src", SrcStarRating);
        $(".star3").attr("src", SrcStarNotRating);
        $(".star4").attr("src", SrcStarNotRating);
        $(".star5").attr("src", SrcStarNotRating);
    });
    $(".star3").click(function () {
        $(".icon-rating").attr("src", SrcIconHappy);
        $(".feedback-content").text(TextHappy);
        $(".star1").attr("src", SrcStarRating);
        $(".star2").attr("src", SrcStarRating);
        $(".star3").attr("src", SrcStarRating);
        $(".star4").attr("src", SrcStarNotRating);
        $(".star5").attr("src", SrcStarNotRating);
    });
    $(".star4").click(function () {
        $(".icon-rating").attr("src", SrcIconSmile);
        $(".feedback-content").text(TextSmile);
        $(".star1").attr("src", SrcStarRating);
        $(".star2").attr("src", SrcStarRating);
        $(".star3").attr("src", SrcStarRating);
        $(".star4").attr("src", SrcStarRating);
        $(".star5").attr("src", SrcStarNotRating);
    });
    $(".star5").click(function () {
        $(".icon-rating").attr("src", SrcIconInLove);
        $(".feedback-content").text(TextInLove);
        $(".star1").attr("src", SrcStarRating);
        $(".star2").attr("src", SrcStarRating);
        $(".star3").attr("src", SrcStarRating);
        $(".star4").attr("src", SrcStarRating);
        $(".star5").attr("src", SrcStarRating);
    });
});

function SendDataFeedBack() {
    var starRating = 0;
    var contentFeedback = "";

    // Get star rating
    var star1 = $('.star1').attr('src');
    var star2 = $('.star2').attr('src');
    var star3 = $('.star3').attr('src');
    var star4 = $('.star4').attr('src');
    var star5 = $('.star5').attr('src');

    if (star1 == SrcStarRating) {
        starRating = 1;
    }
    if (star2 == SrcStarRating) {
        starRating = 2;
    }
    if (star3 == SrcStarRating) {
        starRating = 3;
    }
    if (star4 == SrcStarRating) {
        starRating = 4;
    }
    if (star5 == SrcStarRating) {
        starRating = 5;
    }

    // Get content feedback
    contentFeedback = $(".content-feedback").val();

    var data = { point: starRating, feedback: contentFeedback };

    $.ajax({
        url: "/Rating/AddRating",
        type: "post",
        dataType: "json",
        data: { rating: data },
        cache: false,
        async: false,
        success: function (data) {
            window.location.href = data;
        }, error: function (data) {
            alert("Error");
        }
    }); 
}
