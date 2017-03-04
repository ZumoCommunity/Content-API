console.log("'Allo 'Allo!")

$(document).ready(function () {
  $('#btnUpload').click(function () {
    var apiUrl = $('#apiUrl').val()

    if (!!apiUrl) {
      if (document.getElementById('txtUploadFile').value != '') {
        var file = document.getElementById('txtUploadFile').files[0]
        var filePath = '....'
        if (window.FormData !== undefined) {
          var data = new FormData()
          data.append('file', file)

          $.ajax({
            type: 'POST',
            url: apiUrl + '/api/content/upload?BlobName=' + file.name + '&ContainerName=Test',
            contentType: false,
            processData: false,
            data: data,
            success: function (result) {
              alert('File has been successful upload');
              $("#txtUploadFile").val('');
            },
            error: function (xhr, status, p3, p4) {
              var err = 'Error ' + ' ' + status + ' ' + p3 + ' ' + p4
              if (xhr.responseText && xhr.responseText[0] == '{')
                err = JSON.parse(xhr.responseText).Message
              console.log(err)
            }
          })
        }
      }
    }
  })

  $('#btnLinks').click(function () {
    var containerName = $('#txtContainerName').val()

    var apiUrl = $('#apiUrl').val()

    if (!!apiUrl) {
      $.ajax({
        type: 'GET',
        url: apiUrl + '/api/content/links?containerName=' + containerName,
        success: function (result) {
          $.each(result, function (key, value) {
            $('#links').append('<a href="' + value + '" targe="_blank">' + key + '</a><br />')
          })
          console.log(result)
        },
        error: function (xhr, status, p3, p4) {
          var err = 'Error ' + ' ' + status + ' ' + p3 + ' ' + p4
          if (xhr.responseText && xhr.responseText[0] == '{')
            err = JSON.parse(xhr.responseText).Message
          console.log(err)
        }
      })
    }
  })
})
