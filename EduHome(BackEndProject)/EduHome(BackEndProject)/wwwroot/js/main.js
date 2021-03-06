(function ($) {
"use strict";  
    
/*------------------------------------
	Sticky Menu 
--------------------------------------*/
 var windows = $(window);
    var stick = $(".header-sticky");
	windows.on('scroll',function() {    
		var scroll = windows.scrollTop();
		if (scroll < 5) {
			stick.removeClass("sticky");
		}else{
			stick.addClass("sticky");
		}
	});  
/*------------------------------------
	jQuery MeanMenu 
--------------------------------------*/
	$('.main-menu nav').meanmenu({
		meanScreenWidth: "767",
		meanMenuContainer: '.mobile-menu'
	});
    
    
    /* last  2 li child add class */
    $('ul.menu>li').slice(-2).addClass('last-elements');
/*------------------------------------
	Owl Carousel
--------------------------------------*/
    $('.slider-owl').owlCarousel({
        loop:true,
        nav:true,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        smartSpeed: 2500,
        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
        responsive:{
            0:{
                items:1
            },
            768:{
                items:1
            },
            1000:{
                items:1
            }
        }
    });

    $('.partner-owl').owlCarousel({
        loop:true,
        nav:true,
        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
        responsive:{
            0:{
                items:1
            },
            768:{
                items:3
            },
            1000:{
                items:5
            }
        }
    });  

    $('.testimonial-owl').owlCarousel({
        loop:true,
        nav:true,
        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
        responsive:{
            0:{
                items:1
            },
            768:{
                items:1
            },
            1000:{
                items:1
            }
        }
    });
/*------------------------------------
	Video Player
--------------------------------------*/
    $('.video-popup').magnificPopup({
        type: 'iframe',
        mainClass: 'mfp-fade',
        removalDelay: 160,
        preloader: false,
        zoom: {
            enabled: true,
        }
    });
    
    $('.image-popup').magnificPopup({
        type: 'image',
        gallery:{
            enabled:true
        }
    }); 
/*----------------------------
    Wow js active
------------------------------ */
    new WOW().init();
/*------------------------------------
	Scrollup
--------------------------------------*/
    $.scrollUp({
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });
/*------------------------------------
	Nicescroll
--------------------------------------*/
     $('body').scrollspy({ 
            target: '.navbar-collapse',
            offset: 95
        });
$(".notice-left").niceScroll({
            cursorcolor: "#EC1C23",
            cursorborder: "0px solid #fff",
            autohidemode: false,
            
        });

})(jQuery);

//----------SEARCH--------

$(document).ready(function () {
    var searchedtext;
    if ($("#controller").val() != null) {
        var controller = $("#controller").val().toLowerCase();
    }
    $(document).on('keyup', `#search-${controller}`, function () {
        $(`#${controller}-list`).empty();
        searchedtext = $(this).val();
        $.ajax({
            type: "get",
            url: `/${controller}/search?searchedtext=` + searchedtext,
            success: function (res) {
                $(`#${controller.toLowerCase()}-list`).append(res);
            }
        })
    });
})
var userId = $("#userId").val();
$(document).on('click', '#subscribe', function () {
    $("#subscribe-box").empty();
    $.ajax({
        type: "get",
        url: '/Account/Subscribe?id=' + userId,
        success: function (res) {
            $("#subscribe-box").append(res);
            console.log("salam");
        }
    })
})


$(document).ready(function () {
    var searchedText;
    $(document).on('keyup', `#global-search`, function () {
        $('#search-result').empty();
        searchedText = $(this).val();
        if (searchedText.length > 0) {
            $.ajax({
                type: "get",
                url: `/GlobalSearch/Search?searchedText=` + searchedText,
                success: function (res) {
                    console.log(res);
                    $('#search-result').append(res);
                }
            })
        }
       
    });
})