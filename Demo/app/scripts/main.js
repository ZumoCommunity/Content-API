console.log('\'Allo \'Allo!');

$(document).ready(function() {
    $("#btnUpload").click(function(){
        debugger;
        if (document.getElementById("txtUploadFile").value != "") {
            var file = document.getElementById("txtUploadFile").files[0];
            var filePath = "....";
            if (window.FormData !== undefined) {
                var data = new FormData();
                data.append("file", file);

                var apiUrl = "http://localhost:40035";

                $.ajax({
                    type: "POST",
                    url: apiUrl + "/api/content/upload?BlobName=" + file.name + "&ContainerName=Test" ,
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        console.log(result);
                    },
                    error: function (xhr, status, p3, p4) {
                        var err = "Error " + " " + status + " " + p3 + " " + p4;
                        if (xhr.responseText && xhr.responseText[0] == "{")
                            err = JSON.parse(xhr.responseText).Message;
                        console.log(err);
                    }
                });
            }
        }
    });    
});

