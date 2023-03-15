ko.validation.init({

    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    errorClass: 'errorStyle',
    messageTemplate: null

}, true);  

function FormViewModel() {
    var self = this;
    self.cmpName = ko.observable("").extend({
        required: {
            message:"Company Name is Required"
        },
    });
    self.jobTtl = ko.observable("").extend({
        required: {
            message: "Job Title is Required"
        },
    });
    self.cmpLoc = ko.observable("").extend({
        required: {
            message: "Company Location is Required"
        },
    });
    self.jobDesc = ko.observable("").extend({
        required: {
            message: "Job Description is Required"
        },
    });
    
    self.submitForm = function () {
        var data = {
            CompanyName: self.cmpName(),
            CompanyLocation: self.cmpLoc(),
            JobTitle: self.jobTtl(),
            JobDescription: self.jobDesc(),
            UserId : document.getElementById('userId').value,
        };
        // Send data to API here
        $.ajax({
            url: "https://localhost:44327/api/Recruiter/AddNewJob",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            success: function (response) {
                // Handle success response
                /*  alert("Success");*/
                window.location.href = "../../Pages/Recruiter/PostedJobsPage.aspx";
            },
            error: function (xhr, status, error) {
                // Handle error response
                alert("Error: " + status + " " + error);
            }
        });
    }

    self.isValid = ko.computed(function () {
        return self.cmpName() !== "" && self.jobTtl() !== "" && self.cmpLoc() !== "" && self.cmpLoc() !== "";
    });
}

var viewModel = new FormViewModel();
var rootNode = document.getElementById('form');
ko.validation.group(viewModel)
ko.applyBindings(viewModel, rootNode);

