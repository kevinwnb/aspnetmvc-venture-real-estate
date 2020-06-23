$(document).ready(function () {
    var menu = 0;
    $('.menuBtn').on('click', function () {
        if(menu == 0){
            $('.submenu').css({ 'display': 'block' });
            menu = 1;
        }
        else{
            $('.submenu').css({ 'display': 'none' });
            menu = 0;
        }
    });
});