

//$(document).ready(function () {
//    $(".list-group").on("click", ".list-group-item", function () {
//        $(".list-group-item").fadeIn("slow").removeClass("active");
//        $(this).fadeIn("slow").addClass("active");
      
//        getemployee($(this).children(".appended-email").text())
//    })
//    function getemployee(email) {
        
//    // call web api to get a list of product
//        $.ajax({
//            url: '/api/employeeapi/' + email,
//        type: 'get',
//        datatype: 'json',
//        success: function (employees) {
//            console.log("getemployee",employees);
//            alert("ok");
//        },
//        error: function (request, message, error) {
//            alert("error");
//        }
//    });
//    }

   
//})

function result(id) {
    var url = "/Home/GetEmployeeDetails/";
    $.get(url, { id: id })
        .done(function (response) {
            $(".listOfCustomers").html(response);
        });
}

function AddEmployee() {
 
    var url = "/Home/EmployeeForm/";
    $.post(url)
        .done(function (response) {
            $(".listOfCustomers").html(response);
        });
}

function UpdateEmployee(id) {
   
    var url = "/Home/GetEmpUpdateForm/";
    $.post(url, { id: id })
        .done(function (response) {
            $(".listOfCustomers").html(response);
        });
}