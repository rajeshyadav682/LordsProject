$(document).ready(function () {
    $("#ctl00_ContentPlaceHolder1_btnSearch").click(function () {
        //ksAlert("w", "hey");
        //ctl00_ContentPlaceHolder1_ckhNoticePeriod
        //ctl00_ContentPlaceHolder1_ckhNoticePeriod
        //ctl00_ContentPlaceHolder1_ckhNoticePeriod
        //ctl00_ContentPlaceHolder1_ddlAddMinus
        //ctl00_ContentPlaceHolder1_txtDaysNumber
        //document.getElementById("TblMain").style.display = "table";
        //document.getElementById("tblHeader").style.display = "table";
        GetData();
        setTimeout(function () { BindDetuct(); }, 1100);
        return false;
        //setInterval(BindDetuct, 100);
        //BindDetuct();
        
    });
});

var Flagg = "";
function GetData() {
   
    var ECode = document.getElementById("ctl00_ContentPlaceHolder1_txtSearchEmpName").value;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "FullAndFinalSettelment.aspx/BindDTEmpPersonalDetails",
        data: '{EmpCode: "' + ECode + '" }',
        dataType: "json",
        success: function (data) {
            $("#EmployeeDetails").find("div").remove();
            $("#EmployeeDetails").append("<div class='col-md-12'><div class='row'><div class='col-md-offset-2 col-md-10'> <img src='images/TAILOGO.jpg' /><b style='font-size:25px; font-family:Times New Roman; color:#2B9BEF;'>TAIKISHA ENGINEERING INDIA PVT. LTD.</b></div></div>" +
                                         "<div class='row'><div class='col-md-offset-3 col-md-9'><h3 style='font-family:Times New Roman;'><b>Full And Final Settelment</b></h3></td></div></div>" +
                                         "<b><div class='row'><div class='col-md-2'>Code</div><div class='col-md-6'>" + data.d[0].EmpCode + "</div></div>" +
                                         "<div class='row'><div class='col-md-2'>Name</div><div class='col-md-6'>" + data.d[0].Name + "</div></div>" +
                                         "<div class='row'><div class='col-md-2'>Department</div><div class='col-md-6'>" + data.d[0].DeptName + "</div></div>" +
                                         "<div class='row'><div class='col-md-2'>Branch</div><div class='col-md-6'>" + data.d[0].BranchName + "</div></div>" +
                                         "<div class='row'><div class='col-md-2'>Date Of Joining</div><div class='col-md-6'>" + data.d[0].Dateofjoining + "</div></div>" +
                                         "<div class='row'><div class='col-md-2'>Date Of Resignation</div><div class='col-md-6'>" + data.d[0].ResignationDate + "</div></div>" +
                                         "<div class='row'><div class='col-md-2'>Date Of Relieving</div><div class='col-md-6'>" + data.d[0].leaveDate + "</div></div>" +
                                         "</b><div>");
            //document.getElementById("ctl00_ContentPlaceHolder1_lblEmpCode").innerHTML = '';
            //document.getElementById("ctl00_ContentPlaceHolder1_lblEmpName").innerHTML = '';
            //document.getElementById("ctl00_ContentPlaceHolder1_lbldepartment").innerHTML = '';
            //document.getElementById("ctl00_ContentPlaceHolder1_lblLocation").innerHTML = '';
            //document.getElementById("ctl00_ContentPlaceHolder1_lblDOJ").innerHTML = '';
            //document.getElementById("ctl00_ContentPlaceHolder1_lblDOL").innerHTML = '';
            ////alert(document.getElementById("ctl00_ContentPlaceHolder1_lblEmpCode").innerHTML);

            //document.getElementById("ctl00_ContentPlaceHolder1_lblEmpCode").innerHTML = data.d[0].EmpCode;
            //document.getElementById("ctl00_ContentPlaceHolder1_lblEmpName").innerHTML = data.d[0].Name;
            //document.getElementById("ctl00_ContentPlaceHolder1_lbldepartment").innerHTML = data.d[0].DeptName;
            //document.getElementById("ctl00_ContentPlaceHolder1_lblLocation").innerHTML = data.d[0].BranchName;
            //document.getElementById("ctl00_ContentPlaceHolder1_lblDOJ").innerHTML = data.d[0].Dateofjoining;
            //document.getElementById("ctl00_ContentPlaceHolder1_lblDOL").innerHTML = data.d[0].leaveDate;

        },
        error: function (result) {
            alert("Error");
        }
    });

    //===============================
    $("#EmpDetails").find("tr").remove();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "FullAndFinalSettelment.aspx/BindDTAddition",
        data: '{EmpCode: "' + ECode + '" }',
        dataType: "json",
        success: function (data) {
            $("#EmployeeDetails").append("<b><div class='col-md-12'> "+
                                                    "<div class='row' style='background-color:#5D7B9D; color:white;'><div class='col-md-8' >Particulars</div><div class='col-md-2 text-right'>Rate of Pay</div><div class='col-md-2 text-right'>Earning</div></div>" +
                                        "</div></b>");
                                            
            //$("#EmpDetails").append("<tr style='background-color:#5D7B9D; color:white;'><td style='padding-left:10px;width:30%;'>Particulars</td><td style='width:70%' colspan='2'> <table border='0' cellpadding='0' style='width: 100%;color:white;background-color:#5D7B9D;'><tr><td style='width:50%;border-bottom-right-radius:initial;text-align:right;padding-right:10px;'>Rate of Pay</td><td style='width:50%;border-left:1px solid Black;text-align:right;padding-right:10px;'>Earning</td></tr></table></td></tr>");
            var RateOfPay = 0.00, Earning = 0.00;
            for (var i = 0; i < data.d.length; i++) {

                $("#EmployeeDetails").append("<b><div class='col-md-12'><div class='row'><div class='col-md-8' >" + data.d[i].Description + "</div><div class='col-md-2 text-right'>" + data.d[i].ActualAmount + "</div><div class='col-md-2 text-right'>" + data.d[i].PayableAmount + "</div></div></div></b>");
                //$("#EmpDetails").append("<tr><td style='padding-left:10px;width:30%'><b>" + data.d[i].Description + "</b></td><td style='width:70%' colspan='2'><table border='0' cellpadding='0' style='width: 100%'><tr><td style='width:50%;border-bottom-right-radius:initial;text-align:right;padding-right:10px;'><b>" + data.d[i].ActualAmount + "</b></td><td style='width:50%;border-left:1px solid Black;text-align:right;padding-right:10px;'><b>" + data.d[i].PayableAmount + "</b></td></tr></table></td></tr>");

                RateOfPay = parseFloat(RateOfPay) + parseFloat(data.d[i].ActualAmount);
                Earning = parseFloat(Earning) + parseFloat(data.d[i].PayableAmount);
            }
            //debugger;
            $("#EmployeeDetails").append("<b><div class='col-md-12'> " +
                                                    "<div class='row' style='background-color:#5D7B69; color:white;'><div class='col-md-8' >Total Earning (A) </div><div class='col-md-2 text-right'>" + RateOfPay + "</div><div class='col-md-2 text-right'>" + Earning + "</div></div>" +
                                        "</div></b>");
            document.getElementById("ctl00_ContentPlaceHolder1_hdnEarning").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnEarning").value = Earning.toFixed(0);
            ////alert(document.getElementById('ctl00_ContentPlaceHolder1_hdnEarning').value);
            //$("#EmpDetails").append("<tr style='background-color:#5D7B9D;'><td style='padding-left:10px;width:30%'><b>Total Earning</b></td><td style='width:70%' colspan='2'><table border='0' cellpadding='0' style='width: 100%'><tr><td style='width:50%;border-bottom-right-radius:initial;text-align:right;padding-right:10px;'><b>" + RateOfPay.toFixed(2) + "</b></td><td style='width:50%;border-left:1px solid Black;text-align:right;padding-right:10px;'><b>" + Earning.toFixed(2) + "</b></td></tr></table></td></tr>");
        },
        error: function (result) {
            alert("Error");
        }

    });

}
//=======================
function BindDetuct() {
    var ECode = document.getElementById("ctl00_ContentPlaceHolder1_txtSearchEmpName").value;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "FullAndFinalSettelment.aspx/BindDTDeduction",
        data: '{EmpCode: "' + ECode + '" }',
        dataType: "json",
        success: function (data) {
            debugger;
            //alert('Hi');
            $("#EmployeeDetails").append("<b><div class='col-md-12'> " +
                                                  "<div class='row' style='background-color:#5D7B9D; color:white;'><div class='col-md-8' >Deductions</div></div>" +
                                      "</div></b>");
            //$("#EmpDetails").append("<tr><td colspan='2' style='width:70%' colspan='2'><table border='0' cellpadding='0' style='width: 100%;'><tr><td colspan='2' style='width:50%;text-align:left;padding-left:10px;color:white;background-color:#5D7B9D;'><b>Deduct</b></td></tr></table></td></tr>");
            var RateOfPay = 0.00, Deduct = 0.00;
            for (var i = 0; i < data.d.length; i++) {
                $("#EmployeeDetails").append("<b><div class='col-md-12'><div class='row'><div class='col-md-8' >" + data.d[i].Description + "</div><div class='col-md-4 text-right'>" + data.d[i].PayableAmount + "</div></div></div></b>");
                //$("#EmpDetails").append("<tr><td style='padding-left:10px;width:30%'><b>" + data.d[i].Description + "</b></td><td style='width:70%' colspan='2'><table border='0' cellpadding='0' style='width: 100%'><tr><td colspan='2' style='width:50%;text-align:right;padding-right:10px;'><b>" + data.d[i].PayableAmount + "</b></td></tr></table></td></tr>");
                RateOfPay = parseFloat(RateOfPay) + parseFloat(data.d[i].ActualAmount);
                Deduct = parseFloat(Deduct) + parseFloat(data.d[i].PayableAmount);
            }
            //document.getElementById("ctl00_ContentPlaceHolder1_hdnDeduct").value = "";
            //document.getElementById("ctl00_ContentPlaceHolder1_hdnDeduct").value = Deduct.toFixed(2);
            var Earn = document.getElementById("ctl00_ContentPlaceHolder1_hdnEarning").value;
            //var Dec = document.getElementById("ctl00_ContentPlaceHolder1_hdnDeduct").value;
            var NetAmount = parseFloat(Earn) - parseFloat(Deduct);

            $("#EmployeeDetails").append("<b><div class='col-md-12'> " +
                                                    "<div class='row' style='background-color:#5D7B69; color:white;'><div class='col-md-8' >Total Deduction (B) </div><div class='col-md-4 text-right'>" + Deduct + "</div></div>" +
                                        "</div></b>");

            $("#EmployeeDetails").append("<b><div class='col-md-12'> " +
                                                    "<div class='row' style='background-color:#aa9875; color:white;'><div class='col-md-8' >Net Payable (A - B) </div><div class='col-md-4 text-right'>" + NetAmount + "</div></div>" +
                                        "</div></b>");
           
            //$("#EmpDetails").append("<tr><td style='padding-left:10px;width:30%'><b>Total Deduct</b></td><td style='width:70%' colspan='2'><table border='0' cellpadding='0' style='width: 100%'><tr><td colspan='2' style='width:50%;text-align:right;padding-right:10px;'><b>" + Deduct.toFixed(2) + "</b></td></tr></table></td></tr>");
            //$("#TblNetPayable").find("tr").remove();
            //$("#TblNetPayable").append("<tr><td style='padding-left:10px;width:30%;color:white;background-color:#5D7B9D;'><b>Net Payable</b></td><td style='width:70%' colspan='2'><table border='0' cellpadding='0' style='width: 100%;color:white;background-color:#5D7B9D;'><tr><td colspan='2' style='width:50%;text-align:right;padding-right:10px;'><b>" + NetAmount.toFixed(2) + "</b></td></tr></table></td></tr>");
        },
        error: function (result) {
            alert("Error");
        }
    });
}


