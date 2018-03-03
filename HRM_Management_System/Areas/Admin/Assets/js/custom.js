var count = 0;
$(".add_input").on("click", function () {
    count++; 
    $(".input_contain").append("<div></div>")
    $($(".input_contain").children("div")[count]).addClass("form-group"); 
    $($(".input_contain").children("div")[count]).append("<div></div>");
    $($($(".input_contain").children("div")[count]).children("div")[0]).addClass("col-md-10"); 
    $($($(".input_contain").children("div")[count]).children("div")[0]).append('<input type="text" class="form-control" name="desig_name" />'); 
});

var buttons = $(".status");

for (var i = 0; i < buttons.length; i++) {
    $($(buttons)[i]).on("click", function () {
        if ($(this).attr("name") =="employee_id"){
            $(this).removeAttr("name");
            $($($(this).parent().parent().children()[4]).children()[0]).removeAttr("name");
            $($($(this).parent().parent().children()[3]).children()[0]).removeAttr("name");
        } else {
            $(this).attr("name", "employee_id");
            $($($(this).parent().parent().children()[3]).children()[0]).attr("name", "leave_type_id");
            $($($(this).parent().parent().children()[4]).children()[0]).attr("name", "reason");
        }
        $($($(this).parent().parent().children()[3]).children()[0]).toggle(300);
        $($($(this).parent().parent().children()[4]).children()[0]).toggle(300);
    })
}
