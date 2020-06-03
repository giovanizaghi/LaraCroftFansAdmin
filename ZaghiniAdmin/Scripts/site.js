$(document).ready(function () {

    var menuPos = $("#userMenu").position();
    var dropdown = $(".user-menu");

    var positionleft = (menuPos.left - dropdown.width()) - 20;
    var positionTop = ((menuPos.top) + $("#userMenu").height()) + 5;

    dropdown.css({ top: positionTop, left: positionleft });

    tinymce.init({
        selector: '#formattedText',
        height: 400,
        menubar: true,
        plugins: [
            'advlist autolink lists link image charmap print preview anchor',
            'searchreplace visualblocks advcode fullscreen',
            'insertdatetime media table contextmenu powerpaste tinymcespellchecker a11ychecker linkchecker mediaembed',
            'wordcount'
        ],
        toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | advcode spellchecker  a11ycheck code',
        table_toolbar: "tableprops cellprops tabledelete | tableinsertrowbefore tableinsertrowafter tabledeleterow | tableinsertcolbefore tableinsertcolafter tabledeletecol",
        powerpaste_allow_local_images: true,
        powerpaste_word_import: 'prompt',
        powerpaste_html_import: 'prompt',
        spellchecker_language: 'en',
        spellchecker_dialog: true,
        content_css: [
            '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
            '//www.tinymce.com/css/codepen.min.css']
    });

    $('body').click(function (evt) {
        if (evt.target.id == "UserButton")
            $('.user-menu').show('blind');
        else
            $('.user-menu').hide('blind');


    });


    
setTimeout(function () {
    $("#mceu_40, #mceu_41, #mceu_42, #mceu_43, #mceu_44, #mceu_45").hide();
}, 1500);
    
});

