//$(document).ready(function () {
//    let searchParams = new URLSearchParams(window.location.search);
//    let jobId = searchParams.get("jobId");

//    //  console.log(jobId);
//    $.ajax({
//        type: "GET",
//        url: `https://localhost:44327/api/Recruiter/GetAllApplicantsForJobId`,
//        data: {
//            JobId: jobId, // Replace with the name and value of your first parameter
//        },
//        contentType: "application/json; charset=utf-8",
//        /* dataType: "json",*/
//        success: function (data) {
//            // Handle the response from the server
//            let frontData = "";
//           // console.log(data);
//            let i = 0;
//            let Status = AddButton();
//            let response;
//            Status.then(function () {
//                response = JSON.parse(Status.responseText);
//               // console.log(response);
//                for (const userData of data) {
//                    for (const key in userData) {
//                        if (key != "UserId" && key != "CreatedAt" && key != "UpdatedAt") {
//                            frontData += "<div class='data-div'><span class='heading'>" + key + ":    </span><span class='content'>" + userData[key] + "</span></div>"
//                        }
//                    }

//                    frontData += "<div class='ApplicationStatus'>";
//                     if (response[i].Status == 2)
//                        frontData += "<td><p style='color:green'>Candidate Selected!</p>";
//                    else if (response[i].Status == 0)
//                        frontData += "<td><p style='color:red'>Candidate Rejected!</p>";
//                    else {
//                         frontData += "<td><button style='color:green' class='applicant-btn' id='select_" + i + "'>Select</button>";
//                         frontData += "<td><button style='color:red' class='applicant-btn' id='reject_" + i + "'>Reject</button>";

//                    }
//                    frontData += "</div><br>"
//                    i += 1;
//                }
//                document.getElementById("content-div").innerHTML = frontData;
//                $(".applicant-btn").click(function () {
//                    let id = this.id;
//                    let ind = id.slice(-1);
//                    let length = id.length;
//                    let type = id.slice(0, length - 2);
//                    let userId = data[ind]["UserId"];
//                    if (type == "select") {
//                        SelectApp(userId, jobId, id);
//                    }
//                    else
//                        RejectApp(userId, jobId, id);
//                });
//            });
//        },
//        error: function (jqXHR, textStatus, errorThrown) {
//            // Handle any errors that occur during the request
//            alert("Error: " + textStatus + " " + errorThrown);
//        }
//    });


//    function AddButton() {

//       return $.ajax({
//            type: "GET",
//            url: "https://localhost:44327/api/Recruiter/GetAllUsersByJobId",
//            data: {
//                JobId: jobId,
//            },

//            contentType: "application/json; charset=utf-8",
//            success: function (data) {
//               //  alert("Selected");
//              //  console.log(data);
//                status = data.Status;
//               // return data;
//            },
//            error: function (jqXHR, textStatus, errorThrown) {
//                alert("Error: " + textStatus + " " + errorThrown);
//            }
//        });
//    }

//});


//var Isrejected = ko.observable(false);
//var Isselected = ko.observable(false);


//    ko.applyBindings({
//        Isrejected: Isrejected,
//        Isselected: Isselected
//    });


//if (Isselected()) {
//    // The checkbox is checked
//    console.log(selected); //2
//}
//else if(Isrejected()){
//    // The checkbox is not checked
//    console.log(rejected);//0
//}

//func(){
//    ajax
//}

let searchParams = new URLSearchParams(window.location.search);
let jobId = searchParams.get("JobId");

//console.log(jobId);
var ViewModel = function () {
    var self = this;
    self.items = ko.observableArray();

    self.getData = function () {

        return $.getJSON('https://localhost:44327/api/Recruiter/GetAllApplicantsForJobId', { JobId: jobId },
            function (data) {
                //console.log(data);
                //self.items.push(data);
                for (const d of data) {
                    if (d) {
                        console.log(d);
                        self.items.push(d);
                    }

                }

            }
        );
    }

    self.getStatus = function (item) {
        if (item.Status === 1) {
            return "Pending";
        } else if (item.Status === 2) {
            return "Selected";
        } else if (item.Status === 0) {
            return "Rejected";
        } else {
            return "Unknown";
        }
    };

    self.onClick_Reject = function (data) {

        let userId = data.UserId;

        $.ajax({
            type: "POST",
            url: '/api/Recruiter/RejectCandidate',
            data: JSON.stringify({
                UserId: userId,
                JobId: jobId,

            }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                location.reload();
                // alert("Success");
                // this.getData;
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error: " + textStatus + " " + errorThrown);
            }
        });
    }

    self.onClick_Select = function (data) {

        let userId = data.UserId;
        console.log(userId);
        console.log(jobId);
        $.ajax({
            type: "POST",
            url: '/api/Recruiter/SelectCandidate',
            data: JSON.stringify({
                UserId: userId,
                JobId: jobId,

            }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                location.reload();
                //alert("Success");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error: " + textStatus + " " + errorThrown);
            }
        });
    }

    self.selectedOption = ko.observable('All');


    self.fetch = function () {
        var selected = self.selectedOption();
        self.items.removeAll();
        var status = 1;
        if (selected == 'All')
        {
            self.getData();
        }
        else {
            if (selected == 'Selected')
                status = 2;
            else if (selected == 'Rejected')
                status = 0;
            console.log(status);
            return $.getJSON('https://localhost:44327/api/Recruiter/GetAllApplicantsForJobIdAndStatus', { JobId: jobId, Status: status },
                function (data) {
                    //console.log(data);
                    //self.items.push(data);
                    for (const d of data) {
                        if (d) {
                            //  console.log(d);
                            self.items.push(d);
                        }

                    }

                }
            );
        }
    }

}
$(document).ready(function () {
    var viewModel = new ViewModel();
    viewModel.getData().done(function () {
        ko.applyBindings(viewModel);
    })
});