function PolCheck() {

    if (document.getElementById('question_poll').checked) {
        document.getElementById("CroocCategory").selectedIndex=4;
        
    }  
}


function AddCrooc() {
    var CroocTitle = document.getElementById("question-title").value;
    var CroocDetails = document.getElementById("question-details").value;
    var e = document.getElementById("CroocCategory");
    var CroocCategory = e.options[e.selectedIndex].value;

    var crooc = { Title: CroocTitle, Content: CroocDetails, ContentType: CroocCategory };
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: "{crooc:" + JSON.stringify(crooc) + "}",
        url: "/User/CroocAdd",
        success: function (data) {
            if (document.getElementById("question_poll").checked == true) {
                PollItems();
            }
            else {
                alert("Crooc başarıyla eklendi..")
            }
        }
       
    })
    console.log(crooc);
}

function PollItems() {
    var PollItemArray = new Array();
    if (document.getElementById("question_poll").checked == true) {
        var PollItemCount = $("#question_poll_item li").length;
        

        for (var i = 1; i <= PollItemCount; i++) {
            var politem = document.getElementById("ask[" + i + "][title]").value;
            PollItemArray.push(politem);
        }
        
        var formdata = new FormData();
        for (var i = 0; i < PollItemArray.length; i++) {
            formdata.append('PollItem', PollItemArray[i]);
        }

        $.ajax({
            url: '/User/CroocPollItems',
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (data) {
                alert("Crooc başarıyla eklendi..")
            }
             


        });

    } 
    console.log(PollItemArray);

}
