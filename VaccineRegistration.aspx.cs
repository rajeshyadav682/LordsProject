using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
using Reports.DataAccessLayer;
using System.IO;

public partial class VaccineRegistration : System.Web.UI.Page
{
   static string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["SProll"].ConnectionString;
    DataSet FGds = new DataSet();
    int tabLength = 6;
    SqlConnection con = new SqlConnection(connetionString);
    string Tab = "", PersonalTab = "Personal", FatherTab = "Father", MotherTab = "Mother", SpouceTab = "Spouce", CH1Tab = "Child-1", CH2Tab = "Child-2";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CheckPermission();
            if (!IsPostBack)
            {
                string EmpCode = UtilityUI.GetEmpCode(txtemployee.Text.Trim());
                lblmsg.Text = "";
                btnSave.Enabled = true;
                fillvaccine();
                CalendarExtender1.EndDate = System.DateTime.Now.AddDays(0);
                CalendarExtender2.EndDate = System.DateTime.Now.AddDays(0);
                CalendarExtender3.EndDate = System.DateTime.Now.AddDays(0);
                CalendarExtender4.EndDate = System.DateTime.Now.AddDays(0);
                CalendarExtender5.EndDate = System.DateTime.Now.AddDays(0);
                CalendarExtender6.EndDate = System.DateTime.Now.AddDays(0);
                if (EmpCode.Length > 0)
                {
                    GetEmpHeader(EmpCode);
                    GetRecords();
                }
            }

        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }

    void callJs(string TabName)
    {

        string FuncationName = TabName == "Personal" ? "fn80C()" :
                               TabName == "Father" ? "fnVIA()" :
                               TabName == "Mother" ? "fnIntHousingLoan()" :
                               TabName == "Spouce" ? "fnOtherInCome()" :
                               TabName == "Child-1" ? "fn1017()" :
                               TabName == "Child-2" ? "fnOther()" :
                               TabName == "Certificate" ? "fncertificate()" : "";

      
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", FuncationName, true);
    }
    void fillvaccine()
    {
        UtilityUI.FillddlWithSelect(P_ddlvaccine, DBM.getReader("Get_vaccine"), "Name", "ID");
        UtilityUI.FillddlWithSelect(F_ddlvaccine, DBM.getReader("Get_vaccine"), "Name", "ID");
        UtilityUI.FillddlWithSelect(M_ddlvaccine, DBM.getReader("Get_vaccine"), "Name", "ID");
        UtilityUI.FillddlWithSelect(S_ddlvaccine, DBM.getReader("Get_vaccine"), "Name", "ID");
        UtilityUI.FillddlWithSelect(CH1_ddlvaccine, DBM.getReader("Get_vaccine"), "Name", "ID");
        UtilityUI.FillddlWithSelect(CH2_ddlvaccine, DBM.getReader("Get_vaccine"), "Name", "ID");
    }

    public string ErrorMessage { get; set; }
    public decimal filesize { get; set; }


    private bool CheckExistsFile(string Empcode,string Relation)
    {
      
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(connetionString);
            SqlCommand cmdUser = new SqlCommand("checkFile", conUser);
            cmdUser.Parameters.AddWithValue("@EmpCode", Empcode);
            cmdUser.Parameters.AddWithValue("@Relation", Relation);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            string status= dt.Rows[0]["Status"].ToString();
            if (status== "EXISTS")
            {
            return true;
            }
            else
            {
            return false;
            }
        
    }
    public bool UploadUserFile(FileUpload file,string Relation)
    {
        try
        {
            string EmpCode = UtilityUI.GetEmpCode(txtemployee.Text.Trim());
            if (!file.HasFile)
            {
                if (CheckExistsFile(EmpCode, Relation) == true)
                {
                    return true;
                }
            }
            

            filesize = 25000;
            var supportedTypes = new[] { "JPEG", "PNG", "PDF" };
            //   var fileExt = System.IO.Path.GetExtension(file.PostedFile.FileName);
            var fileExt = System.IO.Path.GetExtension(file.FileName).Replace(".", "");

            if (!file.HasFile)
            {
                //callJs(Relation);
                callJs("Certificate");
                ErrorMessage = "Please Upload Certificate";
                lblmsg.Text = ErrorMessage;
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return false;
                
            }
            if (!supportedTypes.Contains(fileExt.ToUpper()))
            {
                //callJs(Relation);
                callJs("Certificate");
                ErrorMessage = "File Extension Is InValid - Only Upload PDF/JPEG/PNG File";
                lblmsg.Text = ErrorMessage;
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (file.PostedFile.ContentLength > (filesize * 1024))
            {
                //callJs(Relation);
                callJs("Certificate");
                ErrorMessage = "File size Should Be UpTo " + filesize + "KB";
                lblmsg.Text = ErrorMessage;
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                //callJs(Relation);
                callJs("Certificate");
                return true;

            }

        }
        catch (Exception ex)
        {
            ErrorMessage = "Upload Container Should Not Be Empty or Contact Admin";
            lblmsg.Text = ErrorMessage;
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string P_Applicable = (P_applicability.SelectedValue);
        string F_Applicable = (F_applicability.SelectedValue);
        string M_Applicable = (M_applicability.SelectedValue);
        string S_Applicable = (S_applicability.SelectedValue);
        string CH1_Applicable = (CH1_applicability.SelectedValue);
        string CH2_Applicable = (CH2_applicability.SelectedValue);
        /////////////// DODE
        string P_Dose = (P_rbndose.SelectedValue);
        string F_Dose = (F_rbndose.SelectedValue);
        string M_Dose = (M_rbndose.SelectedValue);
        string S_Dose = (S_rbndose.SelectedValue);
        string CH1_Dose = (CH1_rbndose.SelectedValue);
        string CH2_Dose = (CH2_rbndose.SelectedValue);

        if (P_Applicable == "")
        {
            callJs(PersonalTab);
            lblmsg.Text = "Please Select Your Eligibility";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            if (P_Applicable == "1")
            {
                if (P_ddlvaccine.SelectedIndex == 0)
                {
                    callJs(PersonalTab);
                    lblmsg.Text = "Please Vaccine Name";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    if (P_Dose == "")
                    {
                        callJs(PersonalTab);
                        lblmsg.Text = "Please Select Dose ";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;

                    }
                    else
                    {
                        if (P_txtdosedate.Text == "")
                        {
                            callJs(PersonalTab);
                            lblmsg.Text = "Please Select Dose Taken Date !";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else
                        {
                            if (UploadUserFile(P_fileupload, "Personal") == true)
                            {
                              
                            }
                            else
                            {
                                callJs("Certificate");
                                return;
                            }

                        }



                    }
                }


            }
            else
            {
                if (P_txtRemarks.Text == "")
                {
                    callJs(PersonalTab);
                    lblmsg.Text = "Please Write Remarks!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
        }

        /////////////////        FATHER
        if (F_Applicable == "")
        {
            callJs(FatherTab);
            lblmsg.Text = "Please Select Father Eligibility !";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            if (F_Applicable == "1")
            {
                if (F_ddlvaccine.SelectedIndex == 0)
                {
                    callJs(FatherTab);
                    lblmsg.Text = "Please Father Vaccine Name !";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;

                }
                else
                {
                    if (F_Dose == "")
                    {
                        callJs(FatherTab);
                        lblmsg.Text = "Please Select Father Dose !";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        if (F_txtdosedate.Text == "")
                        {
                            callJs(FatherTab);
                            lblmsg.Text = "Please Select Father Dose Taken Date !";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else
                        {
                            if (UploadUserFile(F_fileupload, "Father") == true)
                            {

                            }
                            else
                            {
                                callJs("Certificate");
                                return;
                            }

                        }



                    }
                }

            }
            else
            {
                if (F_txtRemarks.Text == "")
                {
                    callJs(FatherTab);
                    lblmsg.Text = "Please Write Father Remarks !";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
        }
        ///////   FATHER END

        /////////////////        MOTHER
        if (M_Applicable == "")
        {
            callJs(MotherTab);
            lblmsg.Text = "Please Select Mother Eligibility !";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            if (M_Applicable == "1")
            {
                if (M_ddlvaccine.SelectedIndex == 0)
                {
                    callJs(MotherTab);
                    lblmsg.Text = "Please Select Mother Vaccine Name !";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    
                    if (M_Dose == "")
                    {
                        callJs(MotherTab);
                        lblmsg.Text = "Please Select Mother Dose !";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        if (M_txtdosedate.Text == "")
                        {
                            callJs(MotherTab);
                            lblmsg.Text = "Please Select Mother Dose Taken Date !";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else
                        {
                            if (UploadUserFile(M_fileupload, "Mother") == true)
                            {

                                
                            }
                            else
                            {
                                callJs("Certificate");
                                return;
                            }

                        }



                    }
                }


            }
            else
            {
                if (M_txtRemarks.Text == "")
                {
                    callJs(MotherTab);
                    lblmsg.Text = "Please Write Mother Remarks !";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
        }
        ///////   MOTHER END

        /////////////////        SPOUCE
        if (S_Applicable == "")
        {
            callJs(SpouceTab);
            lblmsg.Text = "Please Select Spouce Eligibility !";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            if (S_Applicable == "1")
            {
                callJs(SpouceTab);
                if (S_ddlvaccine.SelectedIndex == 0)
                {
                    callJs(SpouceTab);
                    lblmsg.Text = "Please Select Spouce Vaccine Name !";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    if (S_Dose == "")
                    {
                        callJs(SpouceTab);
                        lblmsg.Text = "Please Select Spouce Dose !";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        if (S_txtdosedate.Text == "")
                        {
                            callJs(SpouceTab);
                            lblmsg.Text = "Please Select Spouce Dose Taken Date !";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else
                        {
                            if (UploadUserFile(S_fileupload, "Spouce") == true)
                            {

                            }
                            else
                            {
                                callJs("Certificate");
                                return;
                            }

                        }



                    }
                }


            }
            else
            {

                if (S_txtRemarks.Text == "")
                {
                    callJs(SpouceTab);
                    lblmsg.Text = "Please Write Spouce Remarks!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
        }
        ///////   SPOUCE END

        /////////////////        CH-1
        if (CH1_Applicable == "")
        {
            callJs(CH1Tab);
            UtilityUI.ShowAlert(this, "w", "Please Select Child-1 Eligibility !");
            return;
        }
        else
        {
            if (CH1_Applicable == "1")
            {
                if (CH1_ddlvaccine.SelectedIndex == 0)
                {
                    callJs(CH1Tab);
                    lblmsg.Text = "Please Select Child-1 Vaccine Name !";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    if (CH1_Dose == "")
                    {
                        callJs(CH1Tab);
                        lblmsg.Text = "Please Select Child-1 Dose !";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        if (CH1_txtdosedate.Text == "")
                        {
                            callJs(CH1Tab);
                            lblmsg.Text = "Please Select Child-1 Dose Taken Date !";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else
                        {
                            if (UploadUserFile(CH1_fileupload, "Child-1") == true)
                            {
                              
                            }
                            else
                            {
                                callJs("Certificate");
                                return;
                            }

                        }



                    }
                }


            }
            else
            {
                if (CH1_txtRemarks.Text == "")
                {
                    callJs(CH1Tab);
                    lblmsg.Text = "Please Write Child-1 Remarks !";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
        }
        ///////   SPOUCE END

        /////////////////        CH-2
        if (CH2_Applicable == "")
        {
            callJs(CH2Tab);
            UtilityUI.ShowAlert(this, "w", "Please Select Child-2 Eligibility !");
            return;
        }
        else
        {
            if (CH2_Applicable == "1")
            {
                callJs(CH2Tab);
                if (CH2_ddlvaccine.SelectedIndex == 0)
                {
                    callJs(CH2Tab);
                    lblmsg.Text = "Please Select Child-2 Vaccine Name !";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    if (CH2_Dose == "")
                    {
                        callJs(CH2Tab);
                        lblmsg.Text = "Please Select Child-2 Dose !";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        if (CH2_txtdosedate.Text == "")
                        {
                            callJs(CH2Tab);
                            lblmsg.Text = "Please Select Child-2 Dose Taken Date !";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else
                        {
                            if (UploadUserFile(CH2_fileupload, "Child-2") == true)
                            {

                            }
                            else
                            {
                                callJs("Certificate");
                                return;
                            }

                        }



                    }
                }


            }
            else
            {
                if (CH2_txtRemarks.Text == "")
                {
                    callJs(CH2Tab);
                    lblmsg.Text = "Please Write Child-2 Remarks !";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
        }
        ///////   SPOUCE END
        ///
        if (P_Applicable == "")
        {
            callJs(PersonalTab);
            lblmsg.Text = "Please Select Your Eligibility";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (F_Applicable == "")
        {
            callJs(FatherTab);
            lblmsg.Text = "Please Select father Eligibility";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            F_txtdosedate.Focus();
            return;
        }
        if (M_Applicable == "")
        {
            callJs(MotherTab);
            lblmsg.Text = "Please Select Mother Eligibility !";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;

        }
        if (S_Applicable == "")
        {
            callJs(SpouceTab);
            lblmsg.Text = "Please Select Spouce Eligibility !";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (CH1_Applicable == "")
        {
            callJs(SpouceTab);
            lblmsg.Text = "Please Select Child-1 Eligibility !";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (CH2_Applicable == "")
        {
            callJs(CH2Tab);
            lblmsg.Text = "Please Select Child-2 Eligibility !";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        ////////

        savedatawithLoop();
    }
    private void savedatawithLoop()
    {
        SqlTransaction objTrans = null;
        int LoopCount = 0;
        try
        {
            
            string EmpCode = UtilityUI.GetEmpCode(txtemployee.Text.Trim());
            string P_Applicable = (P_applicability.SelectedValue);
            string F_Applicable = (F_applicability.SelectedValue);
            string M_Applicable = (M_applicability.SelectedValue);
            string S_Applicable = (S_applicability.SelectedValue);
            string CH1_Applicable = (CH1_applicability.SelectedValue);
            string CH2_Applicable = (CH2_applicability.SelectedValue);
            /////////////// DODE
            
            
           
            
            


            if (EmpCode.Length == 0)
            {
                lblmsg.Text = "Select Employee!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            objTrans = con.BeginTransaction();
            for (int i = 0; i < tabLength; i++)
            {
                if (i == 0)
                {
                    if (Convert.ToInt32(P_Applicable) == 1)
                    {
                        string P_Dose = (P_rbndose.SelectedItem.Text);
                        Stream P_fs = P_fileupload.PostedFile.InputStream;
                        BinaryReader P_br = new BinaryReader(P_fs); //reads the   binary files  
                        Byte[] P_bytes = P_br.ReadBytes((Int32)P_fs.Length);
                        string P_fileName = P_fileupload.FileName;
                        string P_fileType = System.IO.Path.GetExtension(P_fileupload.FileName).Replace(".", "");
                        if (P_Dose == "Dose 1")
                        {
                            P_Dose = "1";
                        }
                        if (P_Dose == "Dose 2")
                        {
                            P_Dose = "2";
                        }


                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(P_Applicable), "Personal", P_ddlvaccine.SelectedValue, Convert.ToInt32(P_Dose), P_txtdosedate.Text, Convert.ToInt32(P_Dose), P_txtdosedate.Text, P_bytes, P_fileType, P_fileName, P_txtRemarks.Text);
                    }
                    else
                    {
                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(P_Applicable), "Personal", "", 0, "", 0, "", null, "", "", P_txtRemarks.Text);
                    }
                }
                if (i == 1)
                {
                    if (Convert.ToInt32(F_Applicable) == 1)
                    {
                        string F_Dose = (F_rbndose.SelectedItem.Text);
                        Stream F_fs = F_fileupload.PostedFile.InputStream;
                        BinaryReader F_br = new BinaryReader(F_fs); //reads the   binary files  
                        Byte[] F_bytes = F_br.ReadBytes((Int32)F_fs.Length);
                        LoopCount = LoopCount + 1;
                        string F_fileName = F_fileupload.FileName;
                        string F_fileType = System.IO.Path.GetExtension(F_fileupload.FileName).Replace(".", "");
                        if (F_Dose == "Dose 1")
                        {
                            F_Dose = "1";
                        }
                        if (F_Dose == "Dose 2")
                        {
                            F_Dose = "2";
                        }
                        SaveData(EmpCode, Convert.ToInt32(F_Applicable), "Father", F_ddlvaccine.SelectedValue, Convert.ToInt32(F_Dose), F_txtdosedate.Text, Convert.ToInt32(F_Dose), F_txtdosedate.Text, F_bytes, F_fileType, F_fileName, F_txtRemarks.Text);
                    }
                    else
                    {
                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(F_Applicable), "Father", "", 0, "", 0, "", null, "", "", F_txtRemarks.Text);
                    }
                }
                if (i == 2)
                {
                    if (Convert.ToInt32(M_Applicable) == 1)
                    {
                        string M_Dose = (M_rbndose.SelectedItem.Text);
                        Stream M_fs = M_fileupload.PostedFile.InputStream;
                        BinaryReader M_br = new BinaryReader(M_fs); //reads the   binary files  
                        Byte[] M_bytes = M_br.ReadBytes((Int32)M_fs.Length);
                        string M_fileName = M_fileupload.FileName;
                        string M_fileType = System.IO.Path.GetExtension(M_fileupload.FileName).Replace(".", "");
                        if (M_Dose == "Dose 1")
                        {
                            M_Dose = "1";
                        }
                        if (M_Dose == "Dose 2")
                        {
                            M_Dose = "2";
                        }
                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(M_Applicable), "Mother", M_ddlvaccine.SelectedValue, Convert.ToInt32(M_Dose), M_txtdosedate.Text, Convert.ToInt32(M_Dose), M_txtdosedate.Text, M_bytes, M_fileType, M_fileName, M_txtRemarks.Text);
                    }
                    else
                    {
                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(M_Applicable), "Mother", "", 0, "", 0, "", null, "", "", M_txtRemarks.Text);
                    }
                }
                if (i == 3)
                {
                    if (Convert.ToInt32(S_Applicable) == 1)
                    {
                        
                        string S_Dose = (S_rbndose.SelectedItem.Text);
                        
                        Stream S_fs = S_fileupload.PostedFile.InputStream;
                        BinaryReader S_br = new BinaryReader(S_fs); //reads the   binary files  
                        Byte[] S_bytes = S_br.ReadBytes((Int32)S_fs.Length);
                        string S_fileName = S_fileupload.FileName;
                        string S_fileType = System.IO.Path.GetExtension(S_fileupload.FileName).Replace(".", "");
                        if (S_Dose == "Dose 1")
                        {
                            S_Dose = "1";
                        }
                        if (S_Dose == "Dose 2")
                        {
                            S_Dose = "2";
                        }
                        

                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(S_Applicable), "Spouce", S_ddlvaccine.SelectedValue, Convert.ToInt32(S_Dose), S_txtdosedate.Text, Convert.ToInt32(S_Dose), S_txtdosedate.Text, S_bytes, S_fileType, S_fileName, S_txtRemarks.Text);
                    }
                    else
                    {
                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(S_Applicable), "Spouce", "", 0, "", 0, "", null, "", "", S_txtRemarks.Text);
                    }
                }
                if (i == 4)
                {
                    if (Convert.ToInt32(CH1_Applicable) == 1)
                    {
                        string CH1_Dose = (CH1_rbndose.SelectedItem.Text);
                        
                        Stream CH1_fs = CH1_fileupload.PostedFile.InputStream;
                        BinaryReader CH1_br = new BinaryReader(CH1_fs); //reads the   binary files  
                        Byte[] CH1bytes = CH1_br.ReadBytes((Int32)CH1_fs.Length);

                        string CH1_fileName = CH1_fileupload.FileName;
                        string CH1_fileType = System.IO.Path.GetExtension(CH1_fileupload.FileName).Replace(".", "");
                        if (CH1_Dose == "Dose 1")
                        {
                            CH1_Dose = "1";
                        }
                        if (CH1_Dose == "Dose 2")
                        {
                            CH1_Dose = "2";
                        }
                        
                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(CH1_Applicable), "Child-1", CH1_ddlvaccine.SelectedValue, Convert.ToInt32(CH1_Dose), CH1_txtdosedate.Text, Convert.ToInt32(CH1_Dose), CH1_txtdosedate.Text, CH1bytes, CH1_fileType, CH1_fileName, CH1_txtRemarks.Text);
                    }
                    else
                    {
                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(CH1_Applicable), "Child-1", "", 0, "", 0, "", null, "", "", CH1_txtRemarks.Text);

                    }
                }
                if (i == 5)
                {
                    if (Convert.ToInt32(CH2_Applicable) == 1)
                    {
                        string CH2_Dose = (CH2_rbndose.SelectedItem.Text);
                        Stream CH2_fs = CH2_fileupload.PostedFile.InputStream;
                        BinaryReader CH2_br = new BinaryReader(CH2_fs); //reads the   binary files  
                        Byte[] CH2bytes = CH2_br.ReadBytes((Int32)CH2_fs.Length);
                        string CH2_fileName = CH2_fileupload.FileName;
                        string CH2_fileType = System.IO.Path.GetExtension(CH2_fileupload.FileName).Replace(".", "");
                        if (CH2_Dose == "Dose 1")
                        {
                            CH2_Dose = "1";
                        }
                        if (CH2_Dose == "Dose 2")
                        {
                            CH2_Dose = "2";
                        }
                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(CH2_Applicable), "Child-2", CH2_ddlvaccine.SelectedValue, Convert.ToInt32(CH2_Dose), CH2_txtdosedate.Text, Convert.ToInt32(CH2_Dose), CH2_txtdosedate.Text, CH2bytes, CH2_fileType, CH2_fileName, CH2_txtRemarks.Text);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Saved Successfully')", true);
                    }
                    else
                    {
                        LoopCount = LoopCount + 1;
                        SaveData(EmpCode, Convert.ToInt32(CH2_Applicable), "Child-2", "", 0, "", 0, "", null, "", "", CH2_txtRemarks.Text);
                      
                    }
                }
            }
            if (LoopCount ==6)
            {
                objTrans.Commit();
                lblmsg.Text = "Data Saved";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                GetRecords();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Saved Successfully')", true);
                con.Close();
            }
            else
            {
                objTrans.Rollback();
                con.Close();
            }
        }
        catch (Exception ex)
        {
            objTrans.Rollback();
            con.Close();
        }
    }

    private void GetRecords()
    {
        string EmpCode = UtilityUI.GetEmpCode(txtemployee.Text.Trim());
        DataTable dt = new DataTable();
        SqlConnection conUser = new SqlConnection(connetionString);
        SqlCommand cmdUser = new SqlCommand("getvaccinationDetail", conUser);
        cmdUser.Parameters.AddWithValue("@Empcode", EmpCode);
        cmdUser.Connection = conUser;
        cmdUser.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
        Sqladpter.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblmsg.Text = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    P_applicability.SelectedValue = Convert.ToInt32(dt.Rows[i]["Applicable"]).ToString();
                    string P_Applicable = (P_applicability.SelectedValue);
                    if (P_Applicable == "0")
                    {

                        P_ddlvaccine.Enabled = false;
                        P_rbndose.Enabled = false;
                        P_txtdosedate.Enabled = false;
                        P_fileupload.Enabled = false;
                        P_ddlvaccine.SelectedIndex = 0;
                        P_txtdosedate.Text = "";
                        P_LnkBtn.Text = "";

                    }
                    else
                    {
                        P_applicability.Enabled = true;
                        P_ddlvaccine.Enabled = true;
                        P_rbndose.Enabled = true;
                        P_txtdosedate.Enabled = true;
                        P_txtRemarks.Enabled = true;
                        P_fileupload.Enabled = true;
                    }

                    P_ddlvaccine.SelectedValue = dt.Rows[i]["vaccine"].ToString();
                    if (P_ddlvaccine.SelectedIndex > 0)
                    {
                        P_ddlvaccine.Enabled = false;
                    }
                   
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 1 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 0)
                    {
                        P_rbndose.SelectedValue = "1";
                    }
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 0 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 1)
                    {
                        P_rbndose.SelectedValue = "2";
                    }
                    if(Convert.ToInt32(dt.Rows[i]["dose1"]) == 1 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 1)
                    {
                        P_rbndose.SelectedValue = "2";
                    }
                    if (dt.Rows[i]["dose1date"].ToString() != "")
                    {
                        DateTime date1 = (DateTime)dt.Rows[i]["dose1date"];
                        P_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }
                    else
                    {
                        P_txtdosedate.Text = "";
                    }
                    if (dt.Rows[i]["dose2date"].ToString() != "")
                    {


                        DateTime date1 = (DateTime)dt.Rows[i]["dose2date"];
                        P_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }

                    P_txtRemarks.Text = dt.Rows[i]["remarks"].ToString();
                    P_hdnvalue.Value = dt.Rows[i]["id"].ToString();
                    if (dt.Rows[i]["FileName"].ToString() == "")
                    {
                        P_LnkBtn.Visible = false;
                        P_pnlcertificate.Visible = false;
                    }
                    else
                    {
                        P_LnkBtn.Text = dt.Rows[i]["FileName"].ToString();
                        P_LnkBtn.Visible = true;
                        P_pnlcertificate.Visible = true;
                    }

                }
                if (i == 1)
                {
                    F_applicability.SelectedValue = Convert.ToInt32(dt.Rows[i]["Applicable"]).ToString();
                    string F_Applicable = (F_applicability.SelectedValue);
                    if (F_Applicable == "0")
                    {

                        F_ddlvaccine.Enabled = false;
                        F_rbndose.Enabled = false;
                        F_txtdosedate.Enabled = false;
                        F_fileupload.Enabled = false;
                        F_ddlvaccine.SelectedIndex = 0;
                        F_txtdosedate.Text = "";
                        F_LnkBtn.Text = "";

                    }
                    else
                    {
                        F_applicability.Enabled = true;
                        F_ddlvaccine.Enabled = true;
                        F_rbndose.Enabled = true;
                        F_txtdosedate.Enabled = true;
                        F_txtRemarks.Enabled = true;
                        F_fileupload.Enabled = true;
                    }
                    F_ddlvaccine.SelectedValue = dt.Rows[i]["vaccine"].ToString();
                    if (F_ddlvaccine.SelectedIndex > 0)
                    {
                        F_ddlvaccine.Enabled = false;
                    }
                   
                    //F_rbndose.SelectedValue = dt.Rows[0]["dose1"].ToString();
                    //F_rbndose.SelectedValue = dt.Rows[0]["dose2"].ToString();
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 1 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 0)
                    {
                        F_rbndose.SelectedValue = "1";
                    }
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 0 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 1)
                    {
                        F_rbndose.SelectedValue = "2";
                    }
                    if (dt.Rows[i]["dose1date"].ToString() != "")
                    {
                        DateTime date1 = (DateTime)dt.Rows[i]["dose1date"];
                        F_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }
                    if (dt.Rows[i]["dose2date"].ToString() != "")
                    {


                        DateTime date1 = (DateTime)dt.Rows[i]["dose2date"];
                        F_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }

                    F_txtRemarks.Text = dt.Rows[i]["remarks"].ToString();
                    F_hdnvalue.Value = dt.Rows[i]["id"].ToString();
                    if (dt.Rows[i]["FileName"].ToString() == "")
                    {
                        F_LnkBtn.Visible = false;
                        F_pnlcerificate.Visible = false;
                    }
                    else
                    {
                        F_LnkBtn.Text = dt.Rows[i]["FileName"].ToString();
                        F_LnkBtn.Visible = true;
                        F_pnlcerificate.Visible = true;
                    }
                }
                if (i == 2)
                {
                    M_applicability.SelectedValue = Convert.ToInt32(dt.Rows[i]["Applicable"]).ToString();
                    string M_Applicable = (M_applicability.SelectedValue);
                    if (M_Applicable == "0")
                    {

                        M_ddlvaccine.Enabled = false;
                        M_rbndose.Enabled = false;
                        M_txtdosedate.Enabled = false;
                        M_fileupload.Enabled = false;
                        M_ddlvaccine.SelectedIndex = 0;
                        M_txtdosedate.Text = "";
                        M_LnkBtn.Text = "";

                    }
                    else
                    {
                        M_applicability.Enabled = true;
                        M_ddlvaccine.Enabled = true;
                        M_rbndose.Enabled = true;
                        M_txtdosedate.Enabled = true;
                        M_txtRemarks.Enabled = true;
                        M_fileupload.Enabled = true;
                    }
                    M_ddlvaccine.SelectedValue = dt.Rows[i]["vaccine"].ToString();
                    if (M_ddlvaccine.SelectedIndex > 0)
                    {
                        M_ddlvaccine.Enabled = false;
                    }
                   
                    //M_rbndose.SelectedValue = dt.Rows[0]["dose1"].ToString();
                    //M_rbndose.SelectedValue = dt.Rows[0]["dose2"].ToString();
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 1 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 0)
                    {
                        M_rbndose.SelectedValue = "1";
                    }
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 0 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 1)
                    {
                        M_rbndose.SelectedValue = "2";
                    }
                    if (dt.Rows[i]["dose1date"].ToString() != "")
                    {
                        DateTime date1 = (DateTime)dt.Rows[i]["dose1date"];
                        M_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }
                    if (dt.Rows[i]["dose2date"].ToString() != "")
                    {


                        DateTime date1 = (DateTime)dt.Rows[i]["dose2date"];
                        M_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }

                    M_txtRemarks.Text = dt.Rows[i]["remarks"].ToString();
                    M_hdnvalue.Value = dt.Rows[i]["id"].ToString();
                    if (dt.Rows[i]["FileName"].ToString() == "")
                    {
                        M_LnkBtn.Visible = false;
                        M_pnlcerificate.Visible = false;
                    }
                    else
                    {
                        M_LnkBtn.Text = dt.Rows[i]["FileName"].ToString();
                        M_LnkBtn.Visible = true;
                        M_pnlcerificate.Visible = true;
                    }
                }
                if (i == 3)
                {
                    S_applicability.SelectedValue = Convert.ToInt32(dt.Rows[i]["Applicable"]).ToString();
                    string S_Applicable = (S_applicability.SelectedValue);
                    if (S_Applicable == "0")
                    {

                        S_ddlvaccine.Enabled = false;
                        S_rbndose.Enabled = false;
                        S_txtdosedate.Enabled = false;
                        S_fileupload.Enabled = false;
                        S_ddlvaccine.SelectedIndex = 0;
                        S_txtdosedate.Text = "";
                        S_LnkBtn.Text = "";

                    }
                    else
                    {
                        S_applicability.Enabled = true;
                        S_ddlvaccine.Enabled = true;
                        S_rbndose.Enabled = true;
                        S_txtdosedate.Enabled = true;
                        S_txtRemarks.Enabled = true;
                        S_fileupload.Enabled = true;
                    }
                    S_ddlvaccine.SelectedValue = dt.Rows[i]["vaccine"].ToString();
                    if (S_ddlvaccine.SelectedIndex > 0)
                    {
                        S_ddlvaccine.Enabled = false;
                    }
                   
                    //S_rbndose.SelectedValue = dt.Rows[0]["dose1"].ToString();
                    //S_rbndose.SelectedValue = dt.Rows[0]["dose2"].ToString();
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 1 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 0)
                    {
                        S_rbndose.SelectedValue = "1";
                    }
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 0 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 1)
                    {
                        S_rbndose.SelectedValue = "2";
                    }
                    if (dt.Rows[i]["dose1date"].ToString() != "")
                    {
                        DateTime date1 = (DateTime)dt.Rows[i]["dose1date"];
                        S_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }
                    if (dt.Rows[i]["dose2date"].ToString() != "")
                    {


                        DateTime date1 = (DateTime)dt.Rows[i]["dose2date"];
                        S_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }

                    S_txtRemarks.Text = dt.Rows[i]["remarks"].ToString();
                    S_hdnvalue.Value = dt.Rows[i]["id"].ToString();
                    if (dt.Rows[i]["FileName"].ToString() == "")
                    {
                        S_LnkBtn.Visible = false;
                        S_pnlcerificate.Visible = false;
                    }
                    else
                    {
                        S_LnkBtn.Text = dt.Rows[i]["FileName"].ToString();
                        S_LnkBtn.Visible = true;
                        S_pnlcerificate.Visible = true;
                    }
                }
                if (i == 4)
                {
                    CH1_applicability.SelectedValue = Convert.ToInt32(dt.Rows[i]["Applicable"]).ToString();
                    string CH1_Applicable = (CH1_applicability.SelectedValue);
                    if (CH1_Applicable == "0")
                    {

                        CH1_ddlvaccine.Enabled = false;
                        CH1_rbndose.Enabled = false;
                        CH1_txtdosedate.Enabled = false;
                        CH1_fileupload.Enabled = false;
                        CH1_ddlvaccine.SelectedIndex = 0;
                        CH1_txtdosedate.Text = "";
                        CH1_LnkBtn.Text = "";

                    }
                    else
                    {
                        CH1_applicability.Enabled = true;
                        CH1_ddlvaccine.Enabled = true;
                        CH1_rbndose.Enabled = true;
                        CH1_txtdosedate.Enabled = true;
                        CH1_txtRemarks.Enabled = true;
                        CH1_fileupload.Enabled = true;
                    }
                    CH1_ddlvaccine.SelectedValue = dt.Rows[i]["vaccine"].ToString();
                    if (CH1_ddlvaccine.SelectedIndex > 0)
                    {
                        CH1_ddlvaccine.Enabled = false;
                    }
                  
                    //CH1_rbndose.SelectedValue = dt.Rows[0]["dose1"].ToString();
                    //CH1_rbndose.SelectedValue = dt.Rows[0]["dose2"].ToString();
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 1 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 0)
                    {
                        CH1_rbndose.SelectedValue = "1";
                    }
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 0 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 1)
                    {
                        CH1_rbndose.SelectedValue = "2";
                    }
                    if (dt.Rows[i]["dose1date"].ToString() != "")
                    {
                        DateTime date1 = (DateTime)dt.Rows[i]["dose1date"];
                        CH1_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }
                    if (dt.Rows[i]["dose2date"].ToString() != "")
                    {


                        DateTime date1 = (DateTime)dt.Rows[i]["dose2date"];
                        CH1_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }

                    CH1_txtRemarks.Text = dt.Rows[i]["remarks"].ToString();
                    CH1_hdnvalue.Value = dt.Rows[i]["id"].ToString();
                    if (dt.Rows[i]["FileName"].ToString() == "")
                    {
                        CH1_LnkBtn.Visible = false;
                        CH1_pnlcerificate.Visible = false;
                    }
                    else
                    {
                        CH1_LnkBtn.Text = dt.Rows[i]["FileName"].ToString();
                        CH1_LnkBtn.Visible = true;
                        CH1_pnlcerificate.Visible = true;
                    }
                }
                if (i == 5)
                {
                    CH2_applicability.SelectedValue = Convert.ToInt32(dt.Rows[i]["Applicable"]).ToString();
                    string CH2_Applicable = (CH2_applicability.SelectedValue);
                    if (CH2_Applicable == "0")
                    {

                        CH2_ddlvaccine.Enabled = false;
                        CH2_rbndose.Enabled = false;
                        CH2_txtdosedate.Enabled = false;
                        CH2_fileupload.Enabled = false;
                        CH2_ddlvaccine.SelectedIndex = 0;
                        CH2_txtdosedate.Text = "";
                        CH2_LnkBtn.Text = "";

                    }
                    else
                    {
                        CH2_applicability.Enabled = true;
                        CH2_ddlvaccine.Enabled = true;
                        CH2_rbndose.Enabled = true;
                        CH2_txtdosedate.Enabled = true;
                        CH2_txtRemarks.Enabled = true;
                        CH2_fileupload.Enabled = true;
                    }
                    CH2_ddlvaccine.SelectedValue = dt.Rows[i]["vaccine"].ToString();
                    if (CH2_ddlvaccine.SelectedIndex > 0)
                    {
                        CH2_ddlvaccine.Enabled = false;
                    }
                   
                    //CH2_rbndose.SelectedValue = dt.Rows[0]["dose1"].ToString();
                    //CH2_rbndose.SelectedValue = dt.Rows[0]["dose2"].ToString();
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 1 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 0)
                    {
                        CH2_rbndose.SelectedValue = "1";
                    }
                    if (Convert.ToInt32(dt.Rows[i]["dose1"]) == 0 && Convert.ToInt32(dt.Rows[i]["dose2"]) == 1)
                    {
                        CH2_rbndose.SelectedValue = "2";
                    }
                    if (dt.Rows[i]["dose1date"].ToString() != "")
                    {
                        DateTime date1 = (DateTime)dt.Rows[i]["dose1date"];
                        CH2_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }
                    if (dt.Rows[i]["dose2date"].ToString() != "")
                    {



                        DateTime date1 = (DateTime)dt.Rows[i]["dose2date"];
                        CH2_txtdosedate.Text = date1.ToString("dd/MMM/yyyy");
                    }

                    CH2_txtRemarks.Text = dt.Rows[i]["remarks"].ToString();
                    if (dt.Rows[i]["FileName"].ToString() == "")
                    {
                        CH2_LnkBtn.Visible = false;
                        CH2_pnlcerificate.Visible = false;
                    }
                    else
                    {
                        CH2_LnkBtn.Text = dt.Rows[i]["FileName"].ToString();
                        CH2_LnkBtn.Visible = true;
                        CH2_pnlcerificate.Visible = true;
                    }
                }
                
            }

        }
        else
        {
            // WHEN NO DATA FOUND
            ClearData();
        }


    }

    private void ClearData()
    {
       // P_applicability.SelectedIndex =- 1;
        P_ddlvaccine.SelectedIndex = 0;
        P_rbndose.SelectedIndex = -1;
        P_txtdosedate.Text = "";
        P_txtRemarks.Text = "";
        P_LnkBtn.Text = "";

     //   F_applicability.SelectedIndex = -1;
        F_ddlvaccine.SelectedIndex = 0;
        F_rbndose.SelectedIndex = -1;
        F_txtdosedate.Text = "";
        F_txtRemarks.Text = "";
        F_LnkBtn.Text = "";

     //   M_applicability.SelectedIndex = -1;
        M_ddlvaccine.SelectedIndex = 0;
        M_rbndose.SelectedIndex = -1;
        M_txtdosedate.Text = "";
        M_txtRemarks.Text = "";
        F_LnkBtn.Text = "";

    //    S_applicability.SelectedIndex = -1;
        S_ddlvaccine.SelectedIndex = 0;
        S_rbndose.SelectedIndex = -1;
        S_txtdosedate.Text = "";
        S_txtRemarks.Text = "";
        F_LnkBtn.Text = "";

   //     CH1_applicability.SelectedIndex = -1;
        CH1_ddlvaccine.SelectedIndex = 0;
        CH1_rbndose.SelectedIndex = -1;
        CH1_txtdosedate.Text = "";
        CH1_txtRemarks.Text = "";
        CH1_LnkBtn.Text = "";

   //     CH2_applicability.SelectedIndex = -1;
        CH2_ddlvaccine.SelectedIndex = 0;
        CH2_rbndose.SelectedIndex = -1;
        CH2_txtdosedate.Text = "";
        CH2_txtRemarks.Text = "";
        CH2_LnkBtn.Text = "";


    }

    private void SaveData(string Empcode, int Applicable, string Relation, string Vaccine, int Dose1, string Dose1Date, int Dose2, string Dose2Date, byte[] FilePath,string FileType,string FileName, string Remarks)
    {
        //   string UserCode = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
        try
        {
            if (Applicable == 1)
            {
                if (Dose1 == 1)  // Default File name like TEI-009/FATHER/
                {
                    FileName = Empcode + "/" + Relation.ToUpper() + "/D1." + FileType;
                }
                else
                {
                    FileName = Empcode + "/" + Relation.ToUpper() + "/D2."+FileType;
                }
                
            }
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("sp_vaccinationregistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Empcode", Empcode);
            cmd.Parameters.AddWithValue("@Applicable", Applicable);
            cmd.Parameters.AddWithValue("@Relation", Relation);
            cmd.Parameters.AddWithValue("@Vaccine", Vaccine);
            cmd.Parameters.AddWithValue("@Dose1", Dose1);
            cmd.Parameters.AddWithValue("@Dose1Date", Dose1Date);
            cmd.Parameters.AddWithValue("@Dose2", Dose2);
            cmd.Parameters.AddWithValue("@Dose2Date", Dose2Date);
            cmd.Parameters.AddWithValue("@FileType", FileType);
            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@File", FilePath);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@uid", Session["UserId"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            con.Open();
            //sda.Fill(ds);
            sda.Fill(FGds);
            if (FGds.Tables[0].Rows.Count > 0)
            {
                btnSave.Text = "Submit";

            }
            con.Close();

            // FGds = null;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }

    }

    public void GetEmpHeader(string EmpCode)
    {
        try
        {
            lblTCode.Text = "";
            lblName.Text = "";
            lblDsgntin.Text = "";
            lblDptmt.Text = "";
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("SP_GetEmpDegDept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", EmpCode);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sda.Fill(dt);
            lblTCode.Text = EmpCode;
            lblName.Text = dt.Rows[0]["EmployeeName"].ToString();
            lblDsgntin.Text = dt.Rows[0]["Designation"].ToString();
            lblDptmt.Text = dt.Rows[0]["Department"].ToString();
            con.Close();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }
    void CheckPermission()
    {
        ViewState["AllEmployeeAccess"] = ViewState["AllEmployeeAccess"] == null ? Session["AllEmployeeAccess"] : ViewState["AllEmployeeAccess"];
        ViewState["AllBranchAccess"] = ViewState["AllBranchAccess"] == null ? Session["AllBranchAccess"] : ViewState["AllBranchAccess"];
        if (ViewState["AllEmployeeAccess"] == null || Convert.ToInt32( ViewState["AllEmployeeAccess"]) == 0)
        {
            txtemployee.Text = Session["EmployeeNameCode"].ToString();
            txtemployee.Enabled = false;
        }
    }

    protected void txtemployee_TextChanged(object sender, EventArgs e)
    {
        string EmpCode = UtilityUI.GetEmpCode(txtemployee.Text.Trim());
        if (EmpCode.Length > 0)
        {
            GetEmpHeader(EmpCode);
            GetRecords();
        }
    }

   

    protected void P_LnkBtn_Click(object sender, EventArgs e)
    {
        DownLoad(Convert.ToInt32( P_hdnvalue.Value));   
    }
    private void DownLoad(int id)
    {
        using (SqlConnection con = new SqlConnection(connetionString))
        {
            con.Open();
            // int id = Convert.ToInt32(e.CommandArgument.ToString());
            SqlCommand cmd = new SqlCommand("select [file],filetype,filename from TblVaccineRegistration where id=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = dr["Filetype"].ToString();
                // to open file prompt Box open or Save file    
                Response.AddHeader("content-disposition", "attachment;filename=" + dr["FileName"].ToString());
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite((byte[])dr["file"]);
                Response.End();
            }
        }
    }

    protected void F_LnkBtn_Click(object sender, EventArgs e)
    {
        DownLoad(Convert.ToInt32(F_hdnvalue.Value));
    }

    protected void M_LnkBtn_Click(object sender, EventArgs e)
    {
        DownLoad(Convert.ToInt32(M_hdnvalue.Value));
    }

    protected void S_LnkBtn_Click(object sender, EventArgs e)
    {
        DownLoad(Convert.ToInt32(S_hdnvalue.Value));
    }

    protected void CH1_LnkBtn_Click(object sender, EventArgs e)
    {
        DownLoad(Convert.ToInt32(CH1_hdnvalue.Value));
    }

    protected void CH2_LnkBtn_Click(object sender, EventArgs e)
    {
        DownLoad(Convert.ToInt32(CH2_hdnvalue.Value));
    }

    protected void P_applicability_SelectedIndexChanged(object sender, EventArgs e)
    {
        string P_Applicable = (P_applicability.SelectedValue);

        if (P_Applicable == "0")
        {
            
            P_ddlvaccine.Enabled = false;
            P_rbndose.Enabled = false;
            P_txtdosedate.Enabled = false;
            P_fileupload.Enabled = false;
            P_ddlvaccine.SelectedIndex = 0;
            P_txtdosedate.Text = "";
            P_txtRemarks.Text = "";
            P_LnkBtn.Text = "";

        }
        else
        {
            P_applicability.Enabled = true;
            P_ddlvaccine.Enabled = true;
            P_rbndose.Enabled = true;
            P_txtdosedate.Enabled = true;
            P_txtRemarks.Enabled = true;
            P_fileupload.Enabled = true;
        }
        callJs(PersonalTab);
    }

    protected void F_applicability_SelectedIndexChanged(object sender, EventArgs e)
    {
        string F_Applicable = (F_applicability.SelectedValue);

        if (F_Applicable == "0")
        {
            F_ddlvaccine.Enabled = false;
            F_rbndose.Enabled = false;
            F_txtdosedate.Enabled = false;
            F_fileupload.Enabled = false;
            F_ddlvaccine.SelectedIndex = 0;
            F_rbndose.SelectedIndex = -1;
            F_txtdosedate.Text = "";
            F_txtRemarks.Text = "";
            F_LnkBtn.Text = "";

        }
        else
        {
            F_applicability.Enabled = true;
            F_ddlvaccine.Enabled = true;
            F_rbndose.Enabled = true;
            F_txtdosedate.Enabled = true;
            F_txtRemarks.Enabled = true;
            F_fileupload.Enabled = true;
        }
        callJs(FatherTab);
    }

    protected void M_applicability_SelectedIndexChanged(object sender, EventArgs e)
    {
        string M_Applicable = (M_applicability.SelectedValue);

        if (M_Applicable == "0")
        {

            M_ddlvaccine.Enabled = false;
            M_rbndose.Enabled = false;
            M_txtdosedate.Enabled = false;
            M_fileupload.Enabled = false;
            M_ddlvaccine.SelectedIndex = 0;
            M_rbndose.SelectedIndex = -1;
            M_txtdosedate.Text = "";
            M_txtRemarks.Text = "";
            M_LnkBtn.Text = "";

        }
        else
        {
            M_applicability.Enabled = true;
            M_ddlvaccine.Enabled = true;
            M_rbndose.Enabled = true;
            M_txtdosedate.Enabled = true;
            M_txtRemarks.Enabled = true;
            M_fileupload.Enabled = true;
        }
        callJs(MotherTab);
    }

    protected void S_applicability_SelectedIndexChanged(object sender, EventArgs e)
    {
        string S_Applicable = (S_applicability.SelectedValue);

        if (S_Applicable == "0")
        {

            S_ddlvaccine.Enabled = false;
            S_rbndose.Enabled = false;
            S_txtdosedate.Enabled = false;
            S_fileupload.Enabled = false;
            S_ddlvaccine.SelectedIndex = 0;
            S_rbndose.SelectedIndex = -1;
            S_txtdosedate.Text = "";
            S_txtRemarks.Text = "";
            S_LnkBtn.Text = "";

        }
        else
        {
            S_applicability.Enabled = true;
            S_ddlvaccine.Enabled = true;
            S_rbndose.Enabled = true;
            S_txtdosedate.Enabled = true;
            S_txtRemarks.Enabled = true;
            S_fileupload.Enabled = true;
        }
        callJs(SpouceTab);
    }

    protected void CH1_applicability_SelectedIndexChanged(object sender, EventArgs e)
    {
        string CH1_Applicable = (CH1_applicability.SelectedValue);

        if (CH1_Applicable == "0")
        {

            CH1_ddlvaccine.Enabled = false;
            CH1_rbndose.Enabled = false;
            CH1_txtdosedate.Enabled = false;
            CH1_fileupload.Enabled = false;
            CH1_ddlvaccine.SelectedIndex = 0;
            CH1_rbndose.SelectedIndex = -1;
            CH1_txtdosedate.Text = "";
            CH1_txtRemarks.Text = "";
            CH1_LnkBtn.Text = "";

        }
        else
        {
            CH1_applicability.Enabled = true;
            CH1_ddlvaccine.Enabled = true;
            CH1_rbndose.Enabled = true;
            CH1_txtdosedate.Enabled = true;
            CH1_txtRemarks.Enabled = true;
            CH1_fileupload.Enabled = true;
        }
        callJs(CH1Tab);
    }

    protected void CH2_applicability_SelectedIndexChanged(object sender, EventArgs e)
    {
        string CH2_Applicable = (CH2_applicability.SelectedValue);

        if (CH2_Applicable == "0")
        {

            CH2_ddlvaccine.Enabled = false;
            CH2_rbndose.Enabled = false;
            CH2_txtdosedate.Enabled = false;
            CH2_fileupload.Enabled = false;
            CH2_ddlvaccine.SelectedIndex = 0;
            CH2_rbndose.SelectedIndex = -1;
            CH2_txtdosedate.Text = "";
            CH2_txtRemarks.Text = "";
            CH2_LnkBtn.Text = "";

        }
        else
        {
            CH2_applicability.Enabled = true;
            CH2_ddlvaccine.Enabled = true;
            CH2_rbndose.Enabled = true;
            CH2_txtdosedate.Enabled = true;
            CH2_txtRemarks.Enabled = true;
            CH2_fileupload.Enabled = true;
        }
        callJs(CH2Tab);
    }

    protected void btnref_Click(object sender, EventArgs e)
    {
        Response.Redirect("VaccineRegistration.aspx");
    }
}




        