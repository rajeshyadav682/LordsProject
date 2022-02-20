<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultEmployee.aspx.cs" Inherits="DefaultEmployee" MasterPageFile="~/DefaultMasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="clearfix"></div>
    <section class="content">
          <div class="form-group">
            <div class="col-md-8" style="font-size:20px;">
                <b><p>Employee Code&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;<asp:Label ID="lblempcode" runat="server"></asp:Label></p>
                   <p>Employee Name&nbsp;&nbsp;:&nbsp;&nbsp;<asp:Label ID="lblEmpName" runat="server"></asp:Label></p></b>
            </div>  
            <div class="col-md-4 text-right">
                <asp:Image ID="imgProffile2" runat="server" CssClass="user-image" alt="User Image" Height="90px" Width="90px" />
            </div>     
          </div> 
            <ul class="nav nav-tabs">
                <li class="nav active"><a id="fnGeneralDetail" href="#A" data-toggle="tab" >General&nbsp;Detail</a></li>
                <li class="nav"  ><a id="fnPayrollDetail" href="#B" data-toggle="tab">Payroll&nbsp;Detail</a></li>
                <li class="nav" ><a id="fnPersonal" href="#C" data-toggle="tab">Personal</a></li>
                <li class="nav"  ><a id="fnTax" href="#D" data-toggle="tab">Tax</a></li>
                <%--<li class="nav"  ><a id="fnAdministration" href="#E" data-toggle="tab">Administration</a></li>--%>
                <li class="nav" ><a id="FnWorkExperience" href="#F" data-toggle="tab">Work&nbsp;Experience</a></li>
                <li class="nav" ><a id="fnFamilyDetail"  href="#G" data-toggle="tab">Family&nbsp;Detail</a></li>
                <li class="nav"  ><a id="fnQualification" href="#H" data-toggle="tab">Qualification</a></li>
                <li class="nav" ><a id="fnAssets" href="#I" data-toggle="tab">Assets</a></li>
                <li class="nav" ><a id="fnPayElement" href="#E" data-toggle="tab">CTC</a></li>
            </ul>
            <div class="tab-content">
              <div class="tab-pane fade in active" id="A" style="width:100%">
                <div class="box box-default box-body" style="background-color:rgba(255, 255, 255, 0.80);">
                   <div class="form-horizontal" >
                        <div class="form-group">
                            <div class="col-md-2">
                                <label class="control-label" id="Title11">Title</label>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">First Name</label>
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name" MaxLength="50" onkeyup="upper(this)" Enabled="false" ></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Middle Name</label>
                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" placeholder="Middle Name" MaxLength="50" onkeyup="upper(this)" Enabled="false" ></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Last Name</label>
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name" MaxLength="50" onkeyup="upper(this)" Enabled="false" ></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Date of Birth</label>
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="Date of Birth" onkeydown="return DateKeyDown();" Enabled="false" ></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Date of Joining</label>
                                <asp:TextBox ID="txtDOJ" runat="server" CssClass="form-control" placeholder="Date of Joining" onkeydown="return DateKeyDown();" Enabled="false" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2">
                                <label class="control-label">Contact No</label>
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Contact No" MaxLength="10" Enabled="false" ></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Gender</label>
                                <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Division<%--<span style="color:Red">*</span>--%></label>
                                <asp:TextBox ID="txtDevision" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label class="control-label">Department<%--<span style="color:Red">*</span>--%></label>
                                <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Section</label>
                                <asp:TextBox ID="txtSection" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2">
                                <label class="control-label">Sub Section</label>
                                <asp:TextBox ID="txtSubSection" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label class="control-label">Designation<%--<span style="color:Red">*</span>--%></label>
                                <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Grade<%--<span style="color:Red">*</span>--%></label>
                                <asp:TextBox ID="txtGrade" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Sub Grade<%--<span style="color:Red">*</span>--%></label>
                                <asp:TextBox ID="txtSubGrade" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                            </div>
                            <%--
                            <div class="col-md-2">
                                <label class="control-label">Location of Posting</label>
                                <asp:DropDownList ID="ddllocationOfPosting" runat="server" CssClass="form-control"  Width="180px" Enabled="false"> </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Role</label>
                                <asp:TextBox ID="txtRole" runat="server" CssClass="form-control"  Width="180px" Enabled="false"> </asp:TextBox>
                            </div>--%>
                            <div class="col-md-2">
                                <label class="control-label">Branch<%--<span style="color:Red">*</span>--%></label>
                                <asp:TextBox ID="txtBranch" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                            </div>
                        </div>
                       <div class="form-group">
                           <div class="col-md-2">
                                <label class="control-label">Region</label>
                                <asp:TextBox ID="txtRegion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">Techcomm<%--<span style="color:Red">*</span>--%></label>
                                <asp:TextBox ID="txtTechcomm" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                            </div>
                       </div>
                        <%-- <div class="form-group">
                                <div class="col-md-2">
                                <label class="ontrol-label">Employee&nbsp;Type</label>
                                    <asp:TextBox ID="txtEmpType" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">Cost&nbsp;Center</label>
                                    <asp:TextBox ID="txtCostCenter" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">Currency</label>
                                    <asp:TextBox ID="txtCurrency" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">Card No</label>
                                    <asp:TextBox ID="txtCardNo" runat="server" CssClass="form-control" placeholder="Card No" MaxLength="50" Width="180px" Enabled="false"></asp:TextBox>
                                </div>
                        </div>--%>
                        <hr />
                        <div class="form-group">
                            <div class="col-md-4">
                                <label class="control-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email Address"  MaxLength="100" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label class="control-label">Office Email</label>
                                <asp:TextBox ID="txtOfficeEmail" runat="server" CssClass="form-control" placeholder="Office Email Address"  MaxLength="100" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label class="control-label">Office Mobile No<%--<span style="color:Red">*</span>--%></label>
                                <asp:TextBox ID="txtOfficeMobileNo" runat="server" CssClass="form-control" placeholder="Office Mobile Number" MaxLength="15" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label class="control-label">Reporting Person</label>
                                <asp:TextBox ID="txtEmpHead" runat="server" CssClass="form-control" placeholder="Type Employee Name" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <asp:Panel ID="pnlAddress" runat="server" GroupingText="Present Address"  >
                            <div class="form-group">
                                <div class="col-md-4">
                                        <label class="control-label">Address<%--<span style="color:Red">*</span>--%></label>
                                    <asp:TextBox ID="txtCurrentAddress" runat="server" CssClass="form-control" placeholder="Current Address" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="col-md-2 control-label">City<%--<span style="color:Red">*</span>--%></label>
                                    <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control" placeholder="City Name" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="col-md-2 control-label">State<%--<span style="color:Red">*</span>--%></label>
                                    <asp:TextBox ID="txtStateName" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">Country<%--<span style="color:Red">*</span>--%></label>
                                    <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">Pin Code</label>
                                    <asp:TextBox ID="txtpinCode" runat="server" CssClass="form-control" placeholder="Pin Code" MaxLength="6" Enabled="false"></asp:TextBox>
                                </div>          
                            </div>

                            
                            <br />
                        </asp:Panel>
                        <asp:Panel ID="Panel1" runat="server" GroupingText="Permanent Address">
                            <div class="form-group">
                                <div class="col-md-2">
                                    <label class="control-label">Address<%--<span style="color:Red">*</span>--%></label>
                                    <asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="form-control" placeholder="Permanent Address" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">State<%--<span style="color:Red">*</span>--%></label>
                                    <asp:TextBox ID="txtPermanentState" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">Country<%--<span style="color:Red">*</span>--%></label>
                                    <asp:TextBox ID="txtPermantCountry" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">Pin Code<%--<span style="color:Red">*</span>--%></label>
                                    <asp:TextBox ID="txtAddressPinCode" runat="server" CssClass="form-control" Width="180px" placeholder="Pin Code" MaxLength="6" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">City<%--<span style="color:Red">*</span>--%></label>
                                    <asp:TextBox ID="txtPermanentCity" runat="server" CssClass="form-control" placeholder="City Name" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">Contact Number<%--<span style="color:Red">*</span>--%></label>
                                    <asp:TextBox ID="txtPermanentContactNo" runat="server" CssClass="form-control" placeholder="Contact No" MaxLength="10" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            </asp:Panel>            
                        <br />
                        <asp:Panel ID="pnlEmergency" runat="server" GroupingText="Emergency Contact">
                            <div class="form-group">
                                <div class="col-md-2">
                                    <label class="control-label">Person Name</label>
                                    <asp:TextBox ID="txtpersonName" runat="server" CssClass="form-control" placeholder="person Name" MaxLength="100" Enabled="false"></asp:TextBox>
                                </div>  
                                <div class="col-md-2">
                                    <label class="control-label">Address</label>
                                    <asp:TextBox ID="txtpersonAddress" runat="server" CssClass="form-control" placeholder="Person Address" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                </div>   
                                <div class="col-md-2">         
                                    <label class="control-label">City </label>
                                    <asp:TextBox ID="txtpersonCity" runat="server" CssClass="form-control" placeholder="City Name" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class=" control-label">State </label>
                                    <asp:TextBox ID="txtpersonState" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                                </div>    
                                        
                                <div class="col-md-2">
                                    <label class="control-label">Country</label>
                                    <asp:TextBox ID="txtPersonCountry" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                                </div>
                                        
                                <div class="col-md-2">
                                    <label class="control-label">Pin Code</label>
                                    <asp:TextBox ID="txtPersonPincode" runat="server" CssClass="form-control" placeholder="Pin Code" MaxLength="6" Enabled="false"></asp:TextBox>
                                </div>
                                    
                            </div>
                            <div class="form-group">               
                                <div class="col-md-2">
                                    <label class="control-label">Contact No</label>
                                    <asp:TextBox ID="txtpersonMobileno" runat="server" CssClass="form-control" placeholder="Contact Number" MaxLength="10" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label class="control-label">Email</label>
                                    <asp:TextBox ID="txtPersonEmail" runat="server" CssClass="form-control" placeholder="Email Address"  MaxLength="100" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>        
                  </div> 
                 </div>
                </div>
              <div class="tab-pane fade" id="B" >
                <div class="box box-default box-body" style="background-color:rgba(255, 255, 255, 0.80);">
                   <div class="form-horizontal" >
                    <div class="form-group">
                        <div class="col-md-3">
                            <asp:CheckBox ID="ckEntitlementToESI" runat="server" Text="Entitlement to ESI" Checked="true" Enabled="false"></asp:CheckBox>
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="ckEntitlementToPF" runat="server" Text="Entitlement to PF" Checked="true" Enabled="false"></asp:CheckBox>
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="ckPFOnActualSalary" runat="server" Text="Employee PF On Actual Basic" Checked="true" Enabled="false"></asp:CheckBox>
                        </div>
                        <div class="col-md-3">
                            <asp:CheckBox ID="ckEmployerPFOnActualSalary" runat="server" Text="Employer PF On Actual Basic" Checked="true" Enabled="false"></asp:CheckBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3">
                            <asp:CheckBox ID="chkGratuity" runat="server" Text="Entitlement to Gratuity" Checked="true" Enabled="false"></asp:CheckBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2">
                            <label class="control-label">Resignation Date</label>
                            <asp:TextBox ID="txtResignationDate" runat="server" CssClass="form-control"  placeholder="Resignation Date" onkeydown="return DateKeyDown();" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Relieving Date</label>
                            <asp:TextBox ID="txtLeaveDate" runat="server" CssClass="form-control" placeholder="Relieving Date" onkeydown="return DateKeyDown();" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Confirmation Date</label>
                            <asp:TextBox ID="txtConfirmationDate" runat="server" CssClass="form-control" placeholder="Confirmation Date" onkeydown="return DateKeyDown();" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Confirmation Months</label>
                            <asp:TextBox ID="txtNoOfMonthForConfirmation" runat="server" CssClass="form-control" placeholder="Confirmation Months" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <br />
                            <asp:CheckBox ID="chkConfirmed" runat="server" Text="Confirmed" Enabled="false"></asp:CheckBox>
                        </div>
                        <div class="col-md-2">
                            <asp:CheckBox ID="ckSalaryStopped" Text="Hold Salary" runat="server" Enabled="false"></asp:CheckBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label class="control-label">Relieving Remarks</label>
                            <asp:TextBox ID="txtRemarksAdmin" runat="server" CssClass="form-control" placeholder="Relieving Remarks" MaxLength="200" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </div> 
                        <div class="col-md-6">
                            <label class="control-label">Hold Salary Remarks</label>
                            <asp:TextBox ID="txtHoldSalaryRemark" runat="server" CssClass="form-control" placeholder="Hold Salary Remarks" MaxLength="200" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </div> 
                    </div>
                    <div class="form-group">
                        <div class="col-md-2">
                            <label class="control-label">Last Revision Date</label>
                            <asp:TextBox ID="txtLastRevisionDate" runat="server" CssClass="form-control" placeholder="Last Revision Date" onkeydown="return DateKeyDown();" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Old Emp Code</label>
                            <asp:TextBox ID="txtOldEmployeeCode" runat="server" CssClass="form-control" placeholder="Old Employee Code" MaxLength="20" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Status</label>
                            <asp:TextBox ID="txtStatusStatusAdmin" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div> 
                    <asp:Panel ID="PanelchklistLeaveType" runat="server" ScrollBars="Auto" GroupingText="Leave Type"  Font-Bold="true" >
                        <div class="col-md-10">
                            <asp:CheckBoxList ID="chklistLeaveType" runat="server" RepeatDirection="Horizontal" RepeatColumns="6" Width="700px" Enabled="false"></asp:CheckBoxList>
                        </div>
                    </asp:Panel>
                    <hr />
                    <div class="form-group">
                        <div class="col-md-2">
                            <label class="control-label">Payment Method</label>
                            <asp:TextBox ID="txtPaymentMethod" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="control-label">Bank Name</label>
                            <asp:TextBox ID="txtBankCode" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="control-label">Bank Address</label>
                            <asp:TextBox ID="txtBankBranch" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">IFSC Code</label>
                            <asp:TextBox ID="txtifsc" runat="server" placeholder="IFSC Code" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Account Number</label>
                            <asp:TextBox ID="txtAccountNo" runat="server" placeholder="Account Number" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
              <div class="tab-pane fade" id="C">
                <div class="box box-default box-body" style="background-color:rgba(255, 255, 255, 0.80);">
                   <div class="form-horizontal" >
                    <div class="form-group">
                        <div class="col-md-2">
                            <label class="control-label">Father Name<%-- <span style="color:Red">*</span>--%> </label>
                            <asp:TextBox ID="txtperfather" runat="server" CssClass="form-control" placeholder="Father Name" MaxLength="100" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Mother Name</label>
                            <asp:TextBox ID="txtmotherName" runat="server" CssClass="form-control" placeholder="Mother Name" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Blood Group</label>
                            <asp:TextBox ID="txtBloodGroup" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Spouse Name</label>
                            <asp:TextBox ID="txtperSpouseName" runat="server" CssClass="form-control" placeholder="Spouse Name" MaxLength="100" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Marital Status</label>
                            <asp:TextBox ID="txtMaritalStatus" runat="server" CssClass="form-control" Enabled="false">
                            </asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Marriage Date</label>
                            <asp:TextBox ID="txtperMarriageDate" runat="server" CssClass="form-control" onkeydown="return DateKeyDown();" placeholder="Marriage Date" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2">
                            <label class="control-label">ESI No</label>
                            <asp:TextBox ID="txtperESINo" runat="server" CssClass="form-control" placeholder="ESI Number" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">ESI Dispensary</label>
                            <asp:TextBox ID="txtperESIDis" runat="server" CssClass="form-control" placeholder="ESI Dispensary" MaxLength="100" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">PFNo</label>
                            <asp:TextBox ID="txtperPFNo" runat="server" CssClass="form-control" placeholder="PF Number" MaxLength="50" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">UAN No</label>
                            <asp:TextBox ID="txtUANNo" runat="server" CssClass="form-control" placeholder="PF UAN Number" MaxLength="50" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Passport No</label>
                            <asp:TextBox ID="txtpassportNo" runat="server" CssClass="form-control" placeholder="Passport Number" MaxLength="20" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Adhar Card</label>
                            <asp:TextBox ID="txtAdharcard" runat="server" CssClass="form-control" placeholder="Adhar Card Number" MaxLength="20" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2">
                            <label class="control-label">Driving License No</label>
                            <asp:TextBox ID="txtperDL" runat="server" CssClass="form-control" placeholder="Driving License No" MaxLength="100" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Social Security No</label>
                            <asp:TextBox ID="txtperSSN" runat="server" CssClass="form-control" placeholder="Social Security No" MaxLength="50" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Previous Experience</label>
                            <asp:TextBox ID="txtperTotalExp" runat="server" CssClass="form-control" placeholder="Total Experience" Enabled="false">0.0</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="control-label">Current Experience</label>
                            <asp:TextBox ID="txtperRelExp" runat="server" CssClass="form-control" placeholder="Relevant Experience" Enabled="false">0.0</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                        <br />
                            <asp:CheckBox ID="chkOverSeasEligibility" runat="server" Text="Overseas Eligibility" Enabled="false" />
                        </div>
                    </div>
                   </div> 
                </div>
            </div>

              <div class="tab-pane fade" id="D">
                <div class="box box-default box-body" style="background-color:rgba(255, 255, 255, 0.80);">
                   <div class="form-horizontal" >
                        <div class="form-group">
                            <div class="col-md-4">
                                <label class="control-label">PAN No.</label>
                                <asp:TextBox ID="txtPanNo" runat="server" CssClass="form-control" placeholder="PAN Number" MaxLength="50" onkeyup="upper(this)" Enabled="false"></asp:TextBox>
                            </div>
                            
                            <div class="col-md-3">
                                <label class="control-label">Previous Company Income</label>
                                <asp:TextBox ID="txtPreviosCompanyIncome" runat="server" placeholder="Previous Company Income" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label class="control-label">Previous Company TDS</label>
                                <asp:TextBox ID="txtPreviosCompanyTDS" runat="server" placeholder="Previous Company TDS" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

              <div class="tab-pane fade" id="F">
                <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                   <div class="form-horizontal" >
                    <div class="box-body" >
                        <div id="divworkexp" runat="server">
                            <div class="table table-responsive" >     
                              <asp:GridView ID="gvWorkExp" runat="server" AutoGenerateColumns="False"  
                                 DataKeyNames="s,EmpCode" CssClass="table table-responsive"  PageSize="5"
                                AllowPaging="True" AllowSorting="True"  EmptyDataText="No Records Found" EmptyDataRowStyle-CssClass="AdProHead" EmptyDataRowStyle-Font-Size="Large"
                                CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName" />
                                    <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                    <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation" />
                                     <asp:BoundField DataField="LastSalary" HeaderText="Last Salary" SortExpression="LastSalary" />
                                    <asp:BoundField DataField="FromDate" HeaderText="From Date" SortExpression="FromDate" />
                                    <asp:BoundField DataField="ToDate" HeaderText="To Date" SortExpression="ToDate" />
                                           
                                </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                        </div>
                      </div>
                   </div>
                </div>
             </div>
            </div>

              <div class="tab-pane fade" id="G">
                <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                   <div class="form-horizontal" >
                    <div class="box-body" >
                        <div id="divSaveFamilyDetail" runat="server">  
                            <div class="table table-responsive" >     
                            <asp:GridView ID="gvFD" runat="server" AutoGenerateColumns="False"  
                             DataKeyNames="s,EmpCode" CssClass="table table-responsive" PageSize="5"
                             AllowPaging="True" AllowSorting="True" EmptyDataText="No Records Found" EmptyDataRowStyle-CssClass="AdProHead" EmptyDataRowStyle-Font-Size="Large"
                             CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Relation" HeaderText="Relation Name" SortExpression="Relation" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" SortExpression="DateOfBirth" />
                         <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" SortExpression="MobileNo" />
                        <asp:BoundField DataField="QualificationName" HeaderText="Qualification" SortExpression="QualificationName" />
                        <asp:BoundField DataField="Occupation" HeaderText="Occupation" SortExpression="Occupation" />
                        <asp:BoundField DataField="Dependent" HeaderText="Dependent" SortExpression="Dependent" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />  
                             
                    </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
               </div>
                        </div>
                     </div>
                   </div>
               </div>
            </div>

              <div class="tab-pane fade" id="H">
               <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                   <div class="form-horizontal" >
                    <div class="box-body" >
                        
                            <div class="table table-responsive" >     
                       <asp:GridView ID="GvQualification" runat="server" AutoGenerateColumns="False"  
                             DataKeyNames="s,EmpCode" CssClass="table table-responsive" PageSize="5" EmptyDataText="No Records Found" EmptyDataRowStyle-CssClass="AdProHead" EmptyDataRowStyle-Font-Size="Large"
                             AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="QualificationName" HeaderText="Qualification" SortExpression="QualificationName" />
                        <asp:BoundField DataField="Board" HeaderText="Board/University" SortExpression="Board" />
                        <asp:BoundField DataField="FromDate" HeaderText="From Date" SortExpression="FromDate" />
                        <asp:BoundField DataField="ToDate" HeaderText="To Date" SortExpression="ToDate" />
                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                        <asp:BoundField DataField="Grade" HeaderText="Grade" SortExpression="Grade" />
                        <asp:BoundField DataField="Percentage" HeaderText="Percent" SortExpression="Percentage" /> 
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                         
                    </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    </div>
                
                </div>
            </div>
            </div>
            </div>

              <div class="tab-pane fade" id="I">
                <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                  <div class="form-horizontal" >
                    <div class="box-body" >
                        <div class="table table-responsive" >   
                               <asp:GridView ID="gvAssets" runat="server" AutoGenerateColumns="False"  
                                         DataKeyNames="s,EmpCode" CssClass="table table-responsive" PageSize="5" EmptyDataText="No Records Found" EmptyDataRowStyle-CssClass="AdProHead" EmptyDataRowStyle-Font-Size="Large"
                                         AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="AssestsName" HeaderText="Assets" SortExpression="AssetsName" />
                                        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" SortExpression="IssueDate" />
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" /> 
                                        <asp:BoundField DataField="Model" HeaderText="Model No" SortExpression="Model" /> 
                                        <asp:BoundField DataField="SerialNo" HeaderText="Serial No" SortExpression="SerialNo" /> 
                                        <asp:BoundField DataField="PurchaseDate" HeaderText="Purchase Date" SortExpression="Purchase Date" /> 
                                        <asp:BoundField DataField="RecoveryDate" HeaderText="Recovery Date" SortExpression="RecoveryDate" /> 
                                                
                                    </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                             </div>
                        </div>
                   </div>
                </div>
            </div>
                <div class="tab-pane fade" id="E">
                <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                  <div class="form-horizontal" >
                    <div class="box-body" >
                        <div class="table table-responsive" >   
                               <asp:GridView ID="gvPayElement" runat="server" AutoGenerateColumns="false" ShowFooter="true" OnRowDataBound="gvPayElement_RowDataBound"
                                         CssClass="table table-responsive" PageSize="5" EmptyDataText="No Records Found" EmptyDataRowStyle-CssClass="AdProHead" EmptyDataRowStyle-Font-Size="Large"
                                         AllowPaging="false" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                   <Columns>
                                       <asp:BoundField DataField="Description" HeaderText="Description" />
                                       <asp:BoundField DataField="Monthly" HeaderText="Monthly" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right" FooterStyle-CssClass="text-right" />
                                       <asp:BoundField DataField="Yearly" HeaderText="Yearly" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right" FooterStyle-CssClass="text-right" />
                                   </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                             </div>
                        <div class="table table-responsive" >   
                               <asp:GridView ID="gvPayElementReimbursement" runat="server" AutoGenerateColumns="false" ShowFooter="true" OnRowDataBound="gvPayElementReimbursement_RowDataBound"
                                         CssClass="table table-responsive" PageSize="5" EmptyDataText="No Records Found" EmptyDataRowStyle-CssClass="AdProHead" EmptyDataRowStyle-Font-Size="Large"
                                         AllowPaging="false" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                   <Columns>
                                       <asp:BoundField DataField="Description" HeaderText="Description" />
                                       <asp:BoundField DataField="Monthly" HeaderText="Monthly" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right" FooterStyle-CssClass="text-right" />
                                       <asp:BoundField DataField="Yearly" HeaderText="Yearly" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right" FooterStyle-CssClass="text-right" />
                                   </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                             </div>
                            <div class="form-control" style="background-color:#5D7B9D; color:white; text-align:right; padding:4px; height:60px; ">
                                <div class="col-md-2">
                                    <span style="font-weight:600; font-size:25px;">Total CTC</span> 
                                </div> 
                                <div class="col-md-offset-6 col-md-2">
                                     <span class="control-label text-right ">Monthly CTC</span> <br />
                                     <label id="lblMonthCTC" runat="server" class="control-label"></label>
                                </div>
                                <div class="col-md-2">
                                     <span class="control-label text-right"> Yearly CTC </span> <br />
                                     <label id="lblYearlyCTC" runat="server" class="control-label"></label>
                                </div>
                            </div>
                            <%--<div class="form-control" style="background-color:#5D7B9D; color:white; font-size:20px;">
                                <div class="col-md-10">
                                    <span style="color:red;">NOTE: ABOVE CTC IS EXCLUDING EX-GRATIA.</span> 
                                </div> 
                            </div>--%>
                        </div>
                   </div>
                </div>
            </div>
          </div>
 </section>
</asp:Content>