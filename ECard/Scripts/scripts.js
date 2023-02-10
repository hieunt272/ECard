AOS.init({
    once: true,
});

function homeJs() {
    $(".partner-list").slick({
        dots: false,
        infinite: true,
        slidesToShow: 5,
        slidesToScroll: 1,
        speed: 1000,
        autoplay: true,
        autoplaySpeed: 3000,
        prevArrow: '<button class="chevron-prev"><i class="far fa-chevron-left"></i></button>',
        nextArrow: '<button class="chevron-next"><i class="far fa-chevron-right"></i></button>',
        responsive: [
            {
                breakpoint: 900,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1,
                }
            }
        ]
    });

    $(".testimonial-list").slick({
        dots: false,
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 1,
        speed: 1000,
        autoplay: true,
        autoplaySpeed: 3000,
        prevArrow: '<button class="chevron-prev"><i class="far fa-chevron-left"></i></button>',
        nextArrow: '<button class="chevron-next"><i class="far fa-chevron-right"></i></button>',
        responsive: [
            {
                breakpoint: 900,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1,
                }
            }
        ]
    });
}

$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 200) {
            $(".sticky-h ").addClass("active");
            $(".btn-scroll").fadeIn(200);
        } else {
            $(".sticky-h ").removeClass("active");
            $(".btn-scroll").fadeOut(200);
        }
    });

    $(".btn-scroll").click(function (event) {
        event.preventDefault();
        $("html, body").animate({ scrollTop: 0 }, 300);
    });

    $(".hamburger").click(function () {
        $(".menu-mb").addClass("active");
    });

    $(".close").click(function () {
        $(".menu-mb").removeClass("active");
    });

    $(".expand-bar").click(function () {
        $(this).toggleClass('open');
        $(this).siblings('.sub-nav-mb').slideToggle();
    });
})

$(function () {
    $(".contact-form").on("submit", function (e) {
        e.preventDefault();
        if ($(".contact-form").valid()) {
            $.post("/Home/ContactForm", $(this).serialize(), function (data) {
                if (data.status) {
                    $.toast({
                        heading: "Gửi liên hệ thành công",
                        text: data.msg,
                        icon: "success",
                        position: "bottom-right"
                    });
                    $(".contact-form").trigger("reset");
                } else {
                    $.toast({
                        heading: "Liên hệ không thành công",
                        text: data.msg,
                        icon: "error",
                        position: "bottom-right"
                    });
                }
            });
        }
    });
});