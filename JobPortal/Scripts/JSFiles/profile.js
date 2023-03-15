//$(document).ready(function () {
//    var formData = {

//        UserId: $("#userId").val()
//    };
//    $.ajax({
//        type: "GET",
//        url: `https://localhost:44327/api/Recruiter/GetJobRecruiterByUserId`,
//        data: {
//            UserId: formData.UserId, // Replace with the name and value of your first parameter
//        },
//        contentType: "application/json; charset=utf-8",
//        /* dataType: "json",*/
//        success: function (data) {
//            for (const key in data) {
//                if (key != "UserId" && key != "CreatedAt" && key != "UpdatedAt") {
//                    console.log(key);
//                    //console.log(key, data[key]);
//                    if (data[key] == null)
//                        data[key] = "";
//                    $("#" + key).val(data[key]);
//                    // console.log(document.getElementById(key).textContent);
//                   // console.log($(key).val('hi'));
//                }
//            }
//           // console.log(document.getElementById('firstName'))
//           // document.getElementById("firstName").innerHTML = data["firstName"] || "";
//        },
//        error: function (jqXHR, textStatus, errorThrown) {
//            alert("Error: " + textStatus + " " + errorThrown);
//        }
//    });
//    $("#form1").submit(function (event) {
//        // Prevent the form from submitting normally
//        event.preventDefault();
//        //console.log(UserId);
//        // Get the form data
//        var newformData = {
//            firstName: $("#firstName").val(),
//            lastName: $("#lastName").val(),
//            email: $("#email").val(),
//            Mobile: $("#Mobile").val(),
//            DOB: $("#DOB").val(),
//            CompanyName: $("CompanyName").val()
//        };
//        console.log(newformData);
//        //console.log(JSON.stringify(formData));
//        // Send the data to the server using AJAX
//        $.ajax({
//            type: "POST",
//            url: "https://localhost:44327/api/Recruiter/UpdateJobRecruiterDetails",
//            data: {
//                UserId: JSON.stringify(formData.UserId),
//                Seeker: JSON.stringify(newformData),
//            },

//            contentType: "application/json; charset=utf-8",
//            /* dataType: "json",*/
//            success: function (data) {
//                // Handle the response from the server
//                alert("Data updated successfully!");
//                window.location.href = "../../Pages/Recruiter/.aspx";
//            },
//            error: function (jqXHR, textStatus, errorThrown) {
//                // Handle any errors that occur during the request
//                //console.log(data);
//                alert("Error: " + textStatus + " " + errorThrown);
//            }
//        });
//    });
//});

function FormViewModel() {
    var self = this;
    self.firstName = ko.observable();
    self.lastName = ko.observable();
    self.email = ko.observable();
    self.Mobile = ko.observable();
    self.DOB = ko.observable();
    self.CompanyName = ko.observable();
    self.getData = function () {
        var userId = document.getElementById('userId').value;
        return $.getJSON('https://localhost:44327/api/Recruiter/GetJobRecruiterByUserId', { UserId: userId },
            function (data) {
                //console.log(data);
               
                //console.log(data.firstName);
                self.firstName(data.firstName);
                self.lastName(data.lastName);
                self.CompanyName(data.CompanyName);
                self.DOB(data.DOB);
                self.email(data.email);
                self.Mobile(data.Mobile);
            }
        );
    }
   // console.log(defVal.firstName);
   

    self.submitForm = function () {
        var data = {
            firstName: self.firstName(),
            lastName: self.lastName(),
            email: self.email(),
            Mobile: self.Mobile(),
            CompanyName: self.CompanyName(),
            DOB: self.DOB(),
            UserId: document.getElementById('userId').value,
        };
        $.ajax({
            /*url: "https://localhost:44327/api/Recruiter/UpdateJobRecruiterDetails",*/
            url:"/WebServices/WebService1.asmx/UpdateRecruiterDetails",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                recruiter:data
                }),
            dataType: "json",
            success: function (response) {
                // Handle success response
              //  alert("Success");
            },
            error: function (xhr, status, error) {
                // Handle error response
                alert("Error: " + status + " " + error);
            }
        });
   
    }
}

var viewModel = new FormViewModel();
var defVal = viewModel.getData();
ko.applyBindings(viewModel);