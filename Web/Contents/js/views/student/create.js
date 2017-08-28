$(function () { // document ready
  $.ajax({
    url: '/lookup/cities',
    method: 'get',
    success: function (data, status, jqXHR) {
      var $cityId = $("#CityId");
      for (var i = 0; i < data.length; i++) {
        var city = data[i];
        $cityId.append("<option value='"+city.Id+"'>"+city.Name+"</option>");
      }
    },
    error: function (jqXHR, status, error) {
      console.error(error);
    }
  });




  $("#submit").click(function (event) {
  });

  $("#student-form").submit(function (event) {
    event.preventDefault(); // stop form posting

    var firstName = $("#FirstName").val();
    var lastName = $("#LastName").val();
    var age = $("#Age").val();
    var gpa = $("#GPA").val();

    $("#submit")
      .prop("disabled", true)
      .html("<i class='glyphicon glyphicon-cog'></i>Kaydediliyor...");


    setTimeout(function () {
      $.ajax({
        url: '/student/create',
        method: 'post',
        accepts: 'application/json',
        data: {
          firstName: firstName,
          lastName: lastName,
          age: age,
          gpa: gpa
        },
        success: function (data, status, jqXHR) {
          window.location.href = data;
        },
        error: function (jqXHR, status, error) {
        }
      });
    }, 300); // call ajax after 300ms delay

  });
});