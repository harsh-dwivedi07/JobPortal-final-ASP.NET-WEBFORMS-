
var userid = document.getElementById('userId').value;

//(async function Test() {
//    let res = 
//    console.log(res);
//})();

//function ViewModel() {
//    var self = this;
//    /*self.items = ko.observableArray([]);*/
//    return $.getJSON("https://localhost:44327/api/Recruiter/GetAllJobsByUserId/", { UserId: userid }
//        , function (data) {
//        //for (const d of data) {
//        //console.log(d);
//        /*self.items.push(d);*/
//        //}
//            self.items(ko.mapping.fromJSON(JSON.stringify(data)));

//        //   console.log(data);
//        }
//    )
//    self.items = res.responseText;
//    console.log(self.items);
//    //).then((data) => {
//    //    self.items = ko.observableArray([]);
//    //    for (const d of data) {
//    //        //console.log(d);
//    //        self.items.push(d);
//    //    }
//    //    return self.items;

//    //    console.log(self.items);
//    //})

//    //console.log(self.items);

//}

//const viewModel = ViewModel();

//ko.applyBindings(viewModel);
//var data = $.getJSON("https://localhost:44327/api/Recruiter/GetAllJobsByUserId/", { UserId: userid }, function (data) {
//            ko.utils.arrayForEach(data, function (object) {
//                console.log(object);
//                //self.items.push(object);
//            });
//var viewModel = new ViewModel();
/*viewModel.getData();*/
//console.log(viewModel);


//var viewModel = {
//    JobsPosted: ko.observableArray([
//        { Companyname: 'ABC', JobTitle: 'DevOps', CompanyLocation: 'Gurgaon', Description:'Something as desc in here...' },
//        { Companyname: 'DEF', JobTitle: 'Backend', CompanyLocation: 'Lucknow', Description: 'Something as desc in here...' },
//    ])
//};



var ViewModel = function () {
    var self = this;
    self.items = ko.observableArray();

    self.getData = function () {

        return $.getJSON('https://localhost:44327/api/Recruiter/GetAllJobsByUserId/', { UserId: userid },
            function (data) {

                for (const d of data) {
                    if (d) {
                        //console.log(d.CompanyName);
                        self.items.push(d);
                    }

                }
                
            }
        );
    }

    self.delete = function (jobDetails) {

        // console.log(jobDetails);
        JobId = jobDetails.JobId;
        console.log(JobId);
        $.ajax({
            type: "POST",
            url: '/api/Recruiter/DeleteJob',
            data: JSON.stringify({
                jobId: JobId,
              
            }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                location.reload();
                //alert("Success");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log("Error: " + textStatus + " " + errorThrown);
            }
        });
    }

    self.onClick = function (data) {
      //  console.log(data.JobId);
        window.location.href = "../Recruiter/ViewApplicant.aspx?JobId=" + data.JobId;
        return true;
    }

    self.getStatus = function (item) {
        if (item.isActive === 0) {
            return "Closed";
        }  else {
            return "Open";
        }
    };
}

$(document).ready(function () {
    var viewModel = new ViewModel();
    viewModel.getData().done(function () {
        ko.applyBindings(viewModel);
    })
});

