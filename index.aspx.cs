using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using SparDbConnect;
using sparsecurity;
using AssemblyServiceReporting;


    public partial class index : System.Web.UI.Page
    {
        protected DataAccess sdba = new DataAccess();
        protected SecCls ssec = new SecCls();
        protected DropDownList ddlbprod = new DropDownList();
        
        protected DataSet dsProdList = new ProdList();
        
        protected string[] v_prompt = new string[30];
        protected string[] v_error_msg = new string[20];
        
        protected string langid, userid, usertype, username, appname;
        protected string dbconnstr;

        public string[] arr_activityId = new string[50];
        public string[] arr_activityDescription = new string[50];
        public string addSku_flag="";

        protected void Page_PreRender(object sender, EventArgs e)
        {
                        
            if (!IsPostBack)
            {
                ViewState["startDt"] = Master.SDate.ToString();
            }
            lblDtMask.Text = Master.v_sys_rule[0].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
             //Response.Write(sdba.DbConnectString(langid) );     
           // Response.Write("<b><font color='red'>Connected to US Production DB</font></b>");   

            // Response.Write(Request.Form);

            //  from CallForm application        

            try
            {
                if (MainFrm.ActiveViewIndex == -1)
                {
                    MainFrm.ActiveViewIndex = 0;
                }

                if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_chain_no"]) == false)
                {
                   
                    MainFrm.ActiveViewIndex = 0;
                    reLoadforCF();                                        
                    Master.LangId = langid;
                    Master.UserId = userid;
                    Master.UserType = usertype;
                    Master.AppName = appname;
                    dbconnstr = sdba.DbConnectString(langid);                    
                    Prompt_Inti();
                    Prompt_Err_Msg();
                    LoadBusinessType();
                    if (!LoadJWT())
                    {
                        // return;
                    }
                    if (MainFrm.ActiveViewIndex < MainFrm.Views.Count - 1)
                    {
                        MainFrm.ActiveViewIndex++;
                    }
                    DisplayControls();                    
                }


                if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_chain_no"]) == true)
                {
                    
                    if (IsPostBack)
                    {
                       
                        if (ViewState["dsProdList"] != null)
                        {
                            dsProdList = (DataSet)ViewState["dsProdList"];
                        }
                        userid = ViewState["User Id"].ToString();
                        usertype = ViewState["UserType"].ToString();
                        langid = ViewState["Lang Id"].ToString();
                        appname = ViewState["App Name"].ToString();
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["sysmode"].ToString() == "T")
                        {
                            userid = ConfigurationManager.AppSettings["testuser"].ToString();
                            usertype = "S";
                        }
                        else
                        {
                           
                            if (string.IsNullOrEmpty(Request.Form["merch_no"]))
                            {                                
                                userid = ssec.getUserId().ToString();
                                userid = userid.Replace("%3A", ":");
                                usertype = "S";                               
                                
                            }
                            else
                            {

                                userid = Request.Form["merch_no"].ToString();
                                //userid = "236";
                                usertype = "M";
                                txtMSNo.Text = userid;
                                txtMSNo.ReadOnly = true;
                            }
                        }
                        appname = ConfigurationManager.AppSettings["appname"].ToString();
                        if (userid != "-1")
                        {
                            langid = ssec.getLangId();
                        }
                        else
                        {
                            Response.Redirect("error.htm");
                        }
                        ViewState["User Id"] = userid;
                        ViewState["UserType"] = usertype;
                        ViewState["Lang Id"] = langid;
                        ViewState["App Name"] = appname;
                        ViewState["ChainNo"] = "0";
                        ViewState["StoreNo"] = "0";
                        ViewState["JobNo"] = "0";
                        ViewState["WaveNo"] = "0";
                        ViewState["TaskNo"] = "0";
                        ViewState["VisitDt"] = "";
                        ViewState["MerchNo"] = "";
                    }

               

                    
                    Master.LangId = langid;
                    Master.UserId = userid;
                    Master.UserType = usertype;
                    Master.AppName = appname;
                    dbconnstr = sdba.DbConnectString(langid);				
                    Prompt_Inti();
                    Prompt_Err_Msg();
                    if (!IsPostBack)
                    {
                        LoadBusinessType();
                    }
                    DisplayControls();
                } // cf true

            }
            catch (Exception ex)
            {
                showMsg(ex.Message);
            }


                //Response.Write("check_gvRowNewOrEdit");
                //if (IsPostBack)
                //{
                //     ClientScript.RegisterClientScriptBlock(GetType(), "se", "check_gvRowNewOrEdit1()", true);
                //}
                //else
                //{
                   ////  ClientScript.RegisterStartupScript(GetType(), "", "check_gvRowNewOrEdit()", true);
               // }

            

        }
       
        public void reLoadforCF()
        {

            //Response.Write(Request.Form["merch_no"].ToString());
            if (ConfigurationManager.AppSettings["sysmode"].ToString() == "T")
            {
                userid = ConfigurationManager.AppSettings["testuser"].ToString();
                usertype = "S";
            }
            else
            {

                if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_merch_no"]))
                {                   
                    userid = ssec.getUserId().ToString();
                    userid = userid.Replace("%3A", ":");
                    usertype = "S";                    
                }
                else
                {
                    userid = Request.Form["ctl00$ContentPlaceHolder1$uparm_merch_no"].ToString();                 
                    usertype = "M";
                    txtMSNo.Text = userid;
                    txtMSNo.ReadOnly = true;
                   
                }
            }
            appname = ConfigurationManager.AppSettings["appname"].ToString();
            
            
            if (userid != "-1")
            {
               
                langid = ssec.getLangId();
                
            }
            else
            {
                Response.Redirect("error.htm");
            }
        
            ViewState["User Id"] = userid;
            ViewState["UserType"] = usertype;
            ViewState["Lang Id"] = langid;
            ViewState["App Name"] = appname;
            ViewState["ChainNo"] = "0";
            ViewState["StoreNo"] = "0";
            ViewState["JobNo"] = "0";
            ViewState["WaveNo"] = "0";
            ViewState["TaskNo"] = "0";
            ViewState["VisitDt"] = "";
            ViewState["MerchNo"] = "";
        }


        public void Prompt_Inti()
        {
            v_prompt[0] = ConfigurationManager.AppSettings["appname"].ToString();
            v_prompt[1] = "MS No.";
            v_prompt[2] = "Chain No.";
            v_prompt[3] = "Store No.";
            v_prompt[4] = "Visit Date:";
            v_prompt[5] = "Activity";
            v_prompt[6] = "Next >>";
            v_prompt[7] = "<< Back";
            v_prompt[8] = "Save";
            v_prompt[9] = "Call Form";
            v_prompt[10] = "Next Store";
            langid = sdba.LangId(langid);

            if (langid.ToString() == "1" || langid.ToString() == "13")
            {
                v_prompt[11] = "Contract/Job No";                
            }
            else
            {
                v_prompt[11] = "Job No";    
            }
            v_prompt[12] = "Wave No";
            v_prompt[13] = "Task No";
            if (langid.ToString() == "1" || langid.ToString() == "13")
            {
                v_prompt[14] = "Contract/Job Desc";
            }
            else
            {
                v_prompt[14] = "Job Desc";
            }
            
            v_prompt[15] = "Task Desc";
            v_prompt[16] = "Start Date";
            v_prompt[17] = "End Date";
            v_prompt[18] = "----- Select an Activity -----";
            v_prompt[19] = "Add";
            v_prompt[20] = "Add SKU";
            v_prompt[21] = "Remarks";
            v_prompt[22] = "Revisit Date";
            v_prompt[23] = "Input Responses";

            v_prompt = sdba.GetPrompt(langid, appname, v_prompt);

            btnNext.Text = v_prompt[6]; // Next>>
            btnBack.Text = v_prompt[7]; // <<Back
            lblChainNo.Text = v_prompt[2];  // Chain No.
            lblStoreNo.Text = v_prompt[3];  // Store No.
            lblMSNo.Text = v_prompt[1]; // MS No.
            lblVdt.Text = v_prompt[4];  // Visit Date:
            lblCrChainNo.Text = v_prompt[2];
            lblCrStoreNo.Text = v_prompt[3];
            lblCrDVdt.Text = v_prompt[4];
            lblCrMSNo.Text = v_prompt[1];

            lblSkuLookup.Text = v_prompt[20];    // Add SKU
            btnAddProd.Text = v_prompt[19]; // Add

        }
        protected void Prompt_Err_Msg()
        {
            v_error_msg[0] = "Invalid Chain/Store";
            v_error_msg[1] = "Invalid Visit Date";
            v_error_msg[2] = "No job is open for the given Visit Date.";
            v_error_msg[3] = "Please input all the data";
            v_error_msg[4] = "Select a Job to report the work.";
            v_error_msg[5] = "Visit Date cannot be a future date.";
            v_error_msg[6] = "No open job to report the work.";
            v_error_msg[7] = "No product list available for reporting";
            v_error_msg[8] = "Invalid Merch No.";
            v_error_msg[9] = "No Product Status list available.";
            v_error_msg[10] = "SKU not found or not Authorized.";
            v_error_msg[11] = "SKU already exists in the list.";
            v_error_msg[12] = "Input valid SKU.";
            v_error_msg[13] = "There may be some items not/and or incorrectly reported, see the error description and correct them before Save them.";
            v_error_msg[14] = "Error:  Data not saved.";
            v_error_msg[15] = "No data available to save.";
            v_error_msg[16] = "You have already reported assembly data today.  You can only report assembly data once per day.";
            v_error_msg[17] = "Please indicate in the Remarks field, the date you placed the order, the expected delivery date, and the confirmation number from the order placed.";

            v_error_msg = sdba.GetPrompt(langid, appname, v_error_msg);
        }
        protected void DisplayCriteria()
        {
            lblCrDJobNo.Visible = false;
            lblCrJobNo.Visible = false;
            lblCrDJobNo.Text = "";
            lblCrJobNo.Text = "";

            lblCrDWaveNo.Visible = false;
            lblCrWaveNo.Visible = false;
            lblCrDWaveNo.Text = "";
            lblCrWaveNo.Text = "";

            lblCrDTaskNo.Visible = false;
            lblCrTaskNo.Visible = false;
            lblCrDTaskNo.Text = "";
            lblCrTaskNo.Text = "";

            if (ViewState["StoreNo"] != null)
            {
                lblCrDStoreNo.Text = ViewState["StoreNo"].ToString();
            }
            if (ViewState["ChainNo"] != null)
            {
                lblCrDChainNo.Text = ViewState["ChainNo"].ToString();
            }
            if (ViewState["StoreName"] != null)
            {
                lblCrDStoreDtl.Text = ViewState["StoreName"].ToString() + ",  " + ViewState["StoreAddr"].ToString() + ", " + ViewState["StoreCity"].ToString() + ", " + ViewState["StoreState"].ToString() + "  " + ViewState["StoreZip"].ToString();
            }
            if (ViewState["VisitDt"] != null)
            {
                lblCrDVdt.Text = ViewState["VisitDt"].ToString();
            }
            if (ViewState["MerchName"] != null)
            {
                lblCrDMsNo.Text = ViewState["MerchNo"].ToString()+" - "+ ViewState["MerchName"].ToString();
            }
            if (MainFrm.ActiveViewIndex >= 2)
            {
                if (ViewState["JobNo"].ToString() != "0")
                {
                    lblCrDJobNo.Visible = true;
                    lblCrJobNo.Visible = true;

                    lblCrDJobNo.Text = "&nbsp;" + ViewState["JobNo"].ToString() + " - " + ViewState["JobDesc"].ToString() + "   ";
                    lblCrJobNo.Text = v_prompt[11];
                }
                if (ViewState["WaveNo"].ToString() != "0")
                {
                    lblCrDWaveNo.Visible = true;
                    lblCrWaveNo.Visible = true;

                    lblCrDWaveNo.Text = "&nbsp;" + ViewState["WaveNo"].ToString() + "   ";
                    lblCrWaveNo.Text = v_prompt[12];
                }
                if (ViewState["TaskNo"].ToString() != "0")
                {
                    lblCrDTaskNo.Visible = true;
                    lblCrTaskNo.Visible = true;

                    lblCrDTaskNo.Text = "&nbsp;" + ViewState["TaskNo"].ToString() + " - " + ViewState["TaskDesc"].ToString();
                    lblCrTaskNo.Text = v_prompt[13];
                }
            }
            pnlCriteria.Visible = true;
        }
        protected void DisplayChainStoreDetail_FromCF()
        {            
            if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_chain_no"]) == false)
            {
                lblCrDChainNo.Text  = Request.Form["ctl00$ContentPlaceHolder1$uparm_chain_no"];
            }
            if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_store_no"]) == false)
            {
                lblCrDStoreNo.Text = Request.Form["ctl00$ContentPlaceHolder1$uparm_store_no"];
            }
            if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_visit_dt"]) == false)
            {
                lblCrDVdt.Text=Request.Form["ctl00$ContentPlaceHolder1$uparm_visit_dt"];
            }
            if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_merch_no"]) == false)
            {
                lblCrDMsNo.Text=Request.Form["ctl00$ContentPlaceHolder1$uparm_merch_no"];
            }
        }
        protected void DisplayControls()
        {
            string pageindex;
            
            pageindex = MainFrm.ActiveViewIndex.ToString();
           
            btnNext.Visible = false;
            btnBack.Visible = false;
            btnCallform.Visible = false;
            btnSave.Visible = false;
            btnStore.Visible = false;
            
            if (pageindex == "0")
            {
                btnNext.Visible = true;
                pnlCriteria.Visible = false;
            }
            if (pageindex == "1")
            {
                btnBack.Visible = true;
                btnNext.Visible = true;
                DisplayCriteria();
                DisplayChainStoreDetail_FromCF();
            }
            if (pageindex == "2")
            {
                btnBack.Visible = true;
                btnSave.Visible = true;
                DisplayCriteria();
            }
            if (pageindex == "3")
            {
                if (ViewState["BusinessTypeId"].ToString() == "16")
                {
                    btnCallform.Visible = true;
                }
                else
                {
                    btnStore.Visible = true;
                }                
                DisplayCriteria();
            }
        }
        protected void showMsg(string msg)
        {
            tblMsg.Visible = true;
            lblErrMsg.Visible = true;
            lblErrMsg.Text = msg;
        }
        protected void LoadBusinessType() {
            string sqlstr;
            ListItem lstitm = new ListItem();

            sqlstr = "usp_fa_pdcs_business_type";

            try
            {
                sdba.dbConnect(dbconnstr);
               // Response.Write(dbconnstr);
                sdba.sqlCommand.Connection = sdba.sqlConnection;
                sdba.sqlCommand.CommandType = CommandType.StoredProcedure;
                sdba.sqlCommand.CommandText = sqlstr;

                sdba.sqlReader = sdba.sqlCommand.ExecuteReader();

                ddlbBtype.DataSource = sdba.sqlReader;
                ddlbBtype.DataValueField = "business_type_id";
                ddlbBtype.DataTextField = "business_type_desc";

                ddlbBtype.DataBind();
                lstitm.Value = "";
                lstitm.Text = v_prompt[18];
                ddlbBtype.Items.Insert(0, lstitm);

            }
            catch (Exception ex)
            {
                showMsg("#101" + ex.Message);
            }
            finally
            {
                sdba.dbDisconnect();
            }
        }        
        protected void btnNext_Click(object sender, EventArgs e)
        {
            //Response.Write("<br> MainFrm.ActiveViewIndex:  " + MainFrm.ActiveViewIndex + " <Br>");
            txtSkuLookup.Text = "";
            lblProdMsg.Text = "";
            lblProdMsg.Visible = false;
            if (MainFrm.ActiveViewIndex == 0)
            {
                if (!LoadJWT())
                {
                    return;
                }
            }
            if (MainFrm.ActiveViewIndex == 1)
            {
                if (!LoadProducts())
                {
                    return;
                }
            }
            if (MainFrm.ActiveViewIndex == 2)
            {
                if (!ProductListValidate())
                {
                    return;
                }
            }
            if (MainFrm.ActiveViewIndex < MainFrm.Views.Count - 1)
            {
                MainFrm.ActiveViewIndex++;
            }
            DisplayControls();
            
        }
        protected bool ProductListValidate()
        {
            gvToDs();
            if (dsProdList.Tables["Products"].Rows.Count < 1)
            {
                showMsg(v_error_msg[15]);  // "No data available to save."
                return false;
            }
            if (! ProdStatCheck())
            {
                showMsg(v_error_msg[13]); //"There may be some items not/and or incorrectly reported, see the error description and correct them before Save them."
                Bind_gvProdList();                
                return false;
            }
            if (SaveDataToDB())
            {
                ViewState["startDt"] = Master.SDate.ToString();
                return true;
            }
            else { return false; }
        }
        protected bool LoadProducts()
        {
            int jwtindex, i;
            string sqlstr, jobno, waveno, taskno, chainno, storeno, visitdt, businesstypeid;
            string pjno, pwno, ptno, pcno, psno, pbtype;
            DataSet dsProd = new DataSet();

            pjno = pwno = ptno = pcno = psno = pbtype = "0";

            if (ViewState["JobNo"] != null)
            {
                pjno = ViewState["JobNo"].ToString().Trim();
            }
            if (ViewState["WaveNo"] != null)
            {
                pwno = ViewState["WaveNo"].ToString().Trim();
            }
            if (ViewState["TaskNo"] != null)
            {
                ptno = ViewState["TaskNo"].ToString().Trim();
            }

            if (ViewState["ChainNo"] != null)
            {
                pcno = ViewState["ChainNo"].ToString().Trim();
            }
            if (ViewState["storeNo"] != null)
            {
                psno = ViewState["StoreNo"].ToString().Trim();
            }
            if (ViewState["BusinessTypeId"] != null)
            {
                pbtype = ViewState["BusinessTypeId"].ToString().Trim();
            }

            if (string.IsNullOrEmpty(Request.Form["selectJWT"]))
            {
                showMsg(v_error_msg[4]);    //Select a Job to report the work.
                return false;
            }
            else
            {
                jwtindex = Convert.ToInt16(Request.Form["selectJWT"].ToString());
                ViewState["jwtindex"] = jwtindex;
                for (i = 0; i <= gvJWT.HeaderRow.Cells.Count - 1; i++)
                {

                    switch (gvJWT.HeaderRow.Cells[i].Text)
                    {                           
                        case "Job No": ViewState["JobNo"] = gvJWT.Rows[jwtindex].Cells[i].Text; break;
                        case "Contract/Job No": ViewState["JobNo"] = gvJWT.Rows[jwtindex].Cells[i].Text; break;
                        case "Job Desc": ViewState["JobDesc"] = gvJWT.Rows[jwtindex].Cells[i].Text; break;
                        case "Contract/Job Desc": ViewState["JobDesc"] = gvJWT.Rows[jwtindex].Cells[i].Text; break;                            
                        case "Wave No": ViewState["WaveNo"] = gvJWT.Rows[jwtindex].Cells[i].Text; break;
                        case "Task No": ViewState["TaskNo"] = gvJWT.Rows[jwtindex].Cells[i].Text; break;
                        case "Task Desc": ViewState["TaskDesc"] = gvJWT.Rows[jwtindex].Cells[i].Text; break;
                    }
                }
            }
            foreach (TemplateField tf in gvProdList.Columns)
            {
                if (tf.HeaderText == "Error Description")
                {
                    tf.Visible = false;
                }
            }
            sqlstr = "usp_fa_pdcs_productlist_new";//_new usp_fa_pdcs_productlist_new [org]
            jobno = ViewState["JobNo"].ToString();
            waveno = ViewState["WaveNo"].ToString();
            taskno = ViewState["TaskNo"].ToString();
            chainno = ViewState["ChainNo"].ToString();
            storeno = ViewState["StoreNo"].ToString();
            visitdt = ViewState["VisitDt"].ToString();
            businesstypeid = ViewState["BusinessTypeId"].ToString();
            hd_business_type_id.Value = businesstypeid.ToString();
            
            if (pjno == jobno && pwno == waveno && ptno == taskno && pcno == chainno && psno == storeno && pbtype == businesstypeid)
            {
                return true;
            }
            else
            {
                dsProdList.Clear();
            }
            try
            {
                sdba.dbConnect(dbconnstr);
                sdba.sqlDataAdapter.SelectCommand.Connection = sdba.sqlConnection;
                sdba.sqlDataAdapter.SelectCommand.CommandText = sqlstr;
                sdba.sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdba.sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@business_type_id", businesstypeid);
                sdba.sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@chain_no", chainno);
                sdba.sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@store_no", storeno);
                sdba.sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@visit_dt", visitdt);
                sdba.sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@job_no", jobno);
                sdba.sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@wave_no", waveno);
                sdba.sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@task_no", taskno);

                sdba.sqlDataAdapter.TableMappings.Add("Table", "Products");
                sdba.sqlDataAdapter.TableMappings.Add("Table1", "Activity");

                sdba.sqlDataAdapter.Fill(dsProdList);
                  //Response.Write("Load Product :: usp_fa_pdcs_productlist_new_030414_1 " + businesstypeid + "," + chainno + "," + storeno + ",'" + visitdt + "'," + jobno + "," + waveno + "," + taskno);
                //if (dsProdList.Tables["Products"].Rows.Count < 1 && (businesstypeid == "13"))
                //{
                //    showMsg(v_error_msg[7]);    // No product list available for reporting.
                //    ViewState["JobNo"] = "0";
                //    return false;
                //}
                if (dsProdList.Tables["Activity"].Rows.Count < 1)
                {
                    showMsg(v_error_msg[9]);   // No Product Status list available.
                    return false;
                }
                else
                {
                    for (int i2 = 1; i2 < dsProdList.Tables[1].Rows.Count ; i2++)
                    {
                        arr_activityId[i2 - 1] = dsProdList.Tables[1].Rows[i2][0].ToString();
                        arr_activityDescription[i2 - 1] = dsProdList.Tables[1].Rows[i2][1].ToString();
                        
                    }
                }
                Bind_gvProdList();
            }
            catch (Exception ex)
            {
                showMsg(ex.Message);
            }
            finally
            {
                sdba.dbDisconnect();
            }
            return true;
        }
        protected bool ChainStoreValidation(string chainno, string storeno, string businesstypeid, string visitdt, string merchno)
        {
        string sqlstr;

        sqlstr = "usp_fa_pdcs_validation";

        try
        {
            sdba.dbConnect(dbconnstr);
            sdba.sqlCommand.Connection = sdba.sqlConnection;
            sdba.sqlCommand.CommandText = sqlstr;
            sdba.sqlCommand.CommandType = CommandType.StoredProcedure;
            sdba.sqlCommand.Parameters.AddWithValue("@chain_no", chainno);
            sdba.sqlCommand.Parameters.AddWithValue("@store_no", storeno);
            sdba.sqlCommand.Parameters.AddWithValue("@business_type_id", businesstypeid);
            sdba.sqlCommand.Parameters.AddWithValue("@visit_dt", visitdt);
            sdba.sqlCommand.Parameters.AddWithValue("@merch_no", merchno);

            sdba.sqlReader = sdba.sqlCommand.ExecuteReader();

            sdba.sqlReader.Read();
            if (sdba.sqlReader[0].ToString() == "-1")
            {
                switch (sdba.sqlReader[1].ToString())
                {
                    case "Invalid Store": showMsg(v_error_msg[0]); break;   //Invalid Chain/Store
                    case "Invalid Date": showMsg(v_error_msg[1]); break;    //Invalid Visit Date
                    case "No open job": showMsg(v_error_msg[2]); break;  //No job is open for the given Visit Date.
                    case "Future Date": showMsg(v_error_msg[5]); break; // Visit cannot be a future date.
                    case "Invalid Merch No": showMsg(v_error_msg[8]); break;    //Invalid Merch No.
                    case "Visit reported": showMsg(v_error_msg[16]); break; //You have already reported assembly data today.  You can only report assembly data once per day.
                }
                return false;
            }
            
            ViewState["VisitDt"] = visitdt;
            ViewState["MerchNo"] = sdba.sqlReader["merch_no"].ToString();
            ViewState["StoreName"] = sdba.sqlReader["store_name"].ToString();
            ViewState["StoreAddr"] = sdba.sqlReader["street_addr"].ToString();
            ViewState["StoreCity"] = sdba.sqlReader["city"].ToString();
            ViewState["StoreState"] = sdba.sqlReader["state"].ToString();
            ViewState["StoreZip"] = sdba.sqlReader["zip"].ToString();
            ViewState["MerchName"] = sdba.sqlReader["merch_name"].ToString();

            sdba.dbDisconnect();
        }
        catch (Exception ex)
        {
            showMsg("#2" + ex.Message);
            return false;
        }
        finally
        {
            sdba.sqlCommand.Parameters.Clear();
            sdba.dbDisconnect();
        }
        return true;
        }

        protected void loadValuesfromCF()
        {


            if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_chain_no"]) == false)
            {
                txtChainNo.Text = Convert.ToString(Request.Form["ctl00$ContentPlaceHolder1$uparm_chain_no"]);                
            }
            if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_store_no"]) == false)
            {
                txtStoreNo.Text = Convert.ToString(Request.Form["ctl00$ContentPlaceHolder1$uparm_store_no"]);
            }
            if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_visit_dt"]) == false)
            {
                txtVdt.Text = Convert.ToString(Request.Form["ctl00$ContentPlaceHolder1$uparm_visit_dt"]);
            }
            if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_merch_no"]) == false)
            {
                txtMSNo.Text = Convert.ToString(Request.Form["ctl00$ContentPlaceHolder1$uparm_merch_no"]);
            }
            if (string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$uparm_business_type_id"]) == false)
            {
                ddlbBtype.SelectedValue = Convert.ToString(Request.Form["ctl00$ContentPlaceHolder1$uparm_business_type_id"]);
                //ddlbBtype.SelectedValue = "16";
            }
            

        }

        protected bool LoadJWT()
        {
            string sqlstr;
            int i;
            loadValuesfromCF(); // load form variables from Internet Call Form 
            //Response.Write("$$" + ddlbBtype.SelectedValue.ToString());
            string chainno, storeno, visitdt, businesstypeid, merchno;
          //  Response.Write("###" + Convert.ToString(Request.Form["txtChainNo"])); 
            chainno = txtChainNo.Text.ToString().Trim();
            storeno = txtStoreNo.Text.ToString().Trim();
            visitdt = txtVdt.Text.ToString().Trim();
            businesstypeid =  ddlbBtype.SelectedValue.ToString().Trim();
            merchno = txtMSNo.Text.ToString().Trim();
            //Response.Write(chainno + "-" + storeno + "-" + visitdt + "-" + businesstypeid + "-" + merchno);
            if ( string.IsNullOrEmpty(chainno) || string.IsNullOrEmpty(storeno) || string.IsNullOrEmpty(visitdt)|| string.IsNullOrEmpty(businesstypeid) || string.IsNullOrEmpty(merchno))
            {
                showMsg(v_error_msg[3]);
                return false;
            }
            
            if (!ChainStoreValidation(chainno, storeno, businesstypeid, visitdt, merchno))
            {
                return false;
            }

            sqlstr = "usp_fa_pdcs_jwt";
        //   Response.Write("<br>" + dbconnstr.ToString());
            try
            {
                sdba.dbConnect(dbconnstr);
                sdba.sqlCommand.Connection = sdba.sqlConnection;
                sdba.sqlCommand.CommandText = sqlstr;
                sdba.sqlCommand.CommandType = CommandType.StoredProcedure;
                sdba.sqlCommand.Parameters.AddWithValue("@chain_no", chainno);
                sdba.sqlCommand.Parameters.AddWithValue("@store_no", storeno);
                sdba.sqlCommand.Parameters.AddWithValue("@business_type_id", businesstypeid);
                sdba.sqlCommand.Parameters.AddWithValue("@visit_dt", visitdt);
                
                sdba.sqlReader = sdba.sqlCommand.ExecuteReader();
                
                if (! sdba.sqlReader.HasRows)
                {
                    showMsg(v_error_msg[6]);    // No open job to report the work.
                    return false;
                }
                gvJWT.DataSource = sdba.sqlReader;
                gvJWT.DataBind();

                //Response.Write("%%" + gvJWT.Rows.Count.ToString() + "%%");
                for (i = 0; i <= gvJWT.HeaderRow.Cells.Count - 1; i++ )
                {
                    switch (gvJWT.HeaderRow.Cells[i].Text.ToString().Trim())
                    {
                        case "job_no": gvJWT.HeaderRow.Cells[i].Text = v_prompt[11]; break; // Job No
                        case "wave_no": gvJWT.HeaderRow.Cells[i].Text = v_prompt[12]; break; // Wave No
                        case "task_no": gvJWT.HeaderRow.Cells[i].Text = v_prompt[13]; break; // Task No
                        case "job_desc": gvJWT.HeaderRow.Cells[i].Text = v_prompt[14]; break; // Job Desc
                        case "task_desc": gvJWT.HeaderRow.Cells[i].Text = v_prompt[15]; break; // Task Desc
                        case "start_dt": gvJWT.HeaderRow.Cells[i].Text = v_prompt[16]; break; // Start Date
                        case "end_dt": gvJWT.HeaderRow.Cells[i].Text = v_prompt[17]; break; // End Date
                    }
                }
                ViewState["ChainNo"] = chainno;
                ViewState["StoreNo"] = storeno;
                ViewState["BusinessTypeId"] = businesstypeid;
            }
            catch (Exception ex)
            {
                showMsg(ex.Message);
                return false;
            }
            finally
            {
                sdba.dbDisconnect();
            }
            return true;
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (MainFrm.ActiveViewIndex > 0)
            {
                MainFrm.ActiveViewIndex--;
            }
            DisplayControls();
        }
        protected void gvJWT_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal output = (Literal)e.Row.FindControl("rbtnLiteral");
                
                output.Text = string.Format(@"<input type='radio' name='selectJWT' " + @"id='rbtnJWT{0}' value='{0}' runat='server' />", e.Row.RowIndex);
            }
        }
        protected void IbtnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar.Visible)
            {
                Calendar.Visible = false;
            }
            else
            {
                Calendar.Visible = true;
            }
        }
        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txtVdt.Text = Calendar.SelectedDate.ToString(Master.v_sys_rule[0].Replace("mm", "MM"));
            Calendar.EnableViewState = false;
            Calendar.Visible = false;
        }
        protected void btnStore_Click(object sender, EventArgs e)
        {
            ViewState["ChainNo"] = "0";
            ViewState["StoreNo"] = "0";
            ViewState["JobNo"] = "0";
            ViewState["WaveNo"] = "0";
            ViewState["TaskNo"] = "0";
            ViewState["VisitDt"] = "";
            txtChainNo.Text = "";
            txtStoreNo.Text = "";
            txtSkuLookup.Text = "";
            txtVdt.Text = "";
            MainFrm.ActiveViewIndex = 0;
            DisplayControls();
        }
        protected void gvProdList_DataBound(object sender, EventArgs e)
         {
             string currentstatus, businesstypeid, strjscript, infotype, lblactmsgclientid, schainno;
            DropDownList gvddlb = new DropDownList();
            HiddenField hf = new HiddenField();
            TextBox tbx = new TextBox();
            DataTable dt = new DataTable();
            Label lbl = new Label();
            Label lbl_sta = new Label();
            Label lbl_rem = new Label();

            Button buttUpdateStatus = new Button();
            
            dt = dsProdList.Tables["Activity"];
            //lbl = (Label)gvProdList.FindControl("sku");
            schainno = ViewState["ChainNo"].ToString();

            lbActivity.DataSource = dt;
            lbActivity.DataValueField = dt.Columns["activity_id"].ToString();
            lbActivity.DataTextField = dt.Columns["info_type"].ToString();
            lbActivity.DataBind();
            
            businesstypeid = ViewState["BusinessTypeId"].ToString().Trim();

            hf = (HiddenField)ProdFrm.FindControl("lblActMsg");
            hf.Value = v_error_msg[17];
            lblactmsgclientid = hf.ClientID;

            foreach (GridViewRow gvRow in gvProdList.Rows)
            {
                buttUpdateStatus = (Button)ProdFrm.FindControl("buttUpdateStatus");
                gvddlb = (DropDownList)gvRow.FindControl("ddlbActivity");
                lbl = (Label)gvRow.FindControl("current_status");
                lbl_sta = (Label)gvRow.FindControl("last_status");
                lbl_rem = (Label)gvRow.FindControl("lblRemarks");                
                currentstatus = lbl.Text.ToString().Trim();

              // hiddenValue = ((TextBox)gvRow.FindControl("hd_gvProdList_Row")).Text.ToString().Trim();
                
               
                if (currentstatus == null)
                {
                    currentstatus = "";
                }
              //  gvddlb.DataSource = dt;
                gvddlb.Visible = false;
                

                if (businesstypeid == "16" && lbl_sta.Text.StartsWith("DPO") )
                {
                   // gvddlb.DataSource = dt.Select("activity_id in ('','AD','DPO','IR')");
				    gvddlb.DataSource = dt.Select("activity_id in ('','DPO','IR')");
                }
                else if (businesstypeid == "16" )
                {
                    gvddlb.DataSource = dt.Select("activity_id not in ('AM','AD')");
                }
                else
                {
                     gvddlb.DataSource = dt.Select("activity_id not in ('DD')");
                    //gvddlb.DataSource = dt;
                }
                gvddlb.DataValueField = dt.Columns["activity_id"].ToString();
                gvddlb.DataTextField = dt.Columns["activity_desc"].ToString();
                gvddlb.DataBind();
                gvddlb.SelectedValue = currentstatus;
                 

                //buttUpdateStatus.Attributes.Add("onclientclick", "javascript:return test_()");
                

                tbx = (TextBox)gvRow.FindControl("itm_response_text");
                strjscript = "javascript:activity_changed(this, " + lbActivity.ClientID.ToString() + ", " + tbx.ClientID.ToString();
                tbx = (TextBox)gvRow.FindControl("itm_response_dt");
                strjscript = strjscript +", " + tbx.ClientID.ToString();
				tbx = (TextBox)gvRow.FindControl("itm_qty");
				strjscript = strjscript +", " + tbx.ClientID.ToString();
                hf = (HiddenField)gvRow.FindControl("itm_no_of_builds");
                strjscript = strjscript + ", " + hf.ClientID.ToString();
                strjscript = strjscript + ", " + schainno;
                strjscript = strjscript + ", " + lbl_rem.ClientID.ToString();                
                strjscript = strjscript + ", " + lblactmsgclientid + ")";				
                gvddlb.Attributes.Add("onchange", strjscript);
                lbl.Visible=false;
                hf = (HiddenField)gvRow.FindControl("itm_build_status");
                //gvRow.Cells[2].ToolTip = "Model: " + dsProdList.Tables["Products"].Rows[gvRow.RowIndex]["model"].ToString() + "   Prior Status: " + dsProdList.Tables["Products"].Rows[gvRow.RowIndex]["last_status"].ToString();
                if (hf.Value.ToString().Trim().IndexOf("Y") >= 0)
                {
                    gvRow.Cells[2].BackColor = Color.Pink;                  
                    
                    if (gvddlb.Items.FindByValue("AM") != null)
                    {
                        gvddlb.Items.RemoveAt(gvddlb.Items.IndexOf(gvddlb.Items.FindByValue("AM")));
                    }

                    if (businesstypeid == "13")
                    {
                        if (gvddlb.Items.FindByValue("X") != null && gvddlb.SelectedValue == "")
                        {
                            gvddlb.SelectedValue = "X";
                        }
                    }
                }
                if (hf.Value.ToString().Trim().IndexOf("N") >= 0)
                {
                    if (gvddlb.Items.FindByValue("AD") != null)
                    {
                        gvddlb.Items.RemoveAt(gvddlb.Items.IndexOf(gvddlb.Items.FindByValue("AD")));
                    }
                }
                if (hf.Value.ToString().Trim().IndexOf("C") >= 0)   // Do not allow AD for chair items(chair_flag = 'Y' in furn_item_mst).
                {
                    if (gvddlb.Items.FindByValue("AD") != null)
                    {
                        gvddlb.Items.RemoveAt(gvddlb.Items.IndexOf(gvddlb.Items.FindByValue("AD")));
                    }
                }
                hf = (HiddenField)gvRow.FindControl("itm_no_of_builds");
                if (hf.Value.ToString().Trim() == "1")
                {
                    tbx = (TextBox)gvRow.FindControl("itm_qty");
                    tbx.Enabled = false;
                }
                hf = (HiddenField)gvRow.FindControl("itm_status_flag");
                if (hf.Value.ToString().Trim().IndexOf("D") >= 0)
                {
                    if (gvddlb.Items.FindByValue("AM") != null)
                    {
                        gvddlb.Items.RemoveAt(gvddlb.Items.IndexOf(gvddlb.Items.FindByValue("AM")));
                    }
                    if (gvddlb.Items.FindByValue("AD") != null)
                    {
                        gvddlb.Items.RemoveAt(gvddlb.Items.IndexOf(gvddlb.Items.FindByValue("AD")));
                    }

                }

                lbActivity.SelectedValue = gvddlb.SelectedValue;
                infotype = lbActivity.Items[lbActivity.SelectedIndex].Text;
                tbx = (TextBox)gvRow.FindControl("itm_response_text");

                if (infotype.IndexOf("T") >= 0)
                {
                    tbx.Enabled = true;
                    tbx.BackColor = Color.White;
                }
                if (infotype == "RA" && lbActivity.SelectedValue == "DD" && schainno == "306")
                {
                    tbx.Enabled = true;
                    tbx.BackColor = Color.White;
                    lbl_rem.Text = "RA Number";
                }


                tbx = (TextBox)gvRow.FindControl("itm_response_dt");
                if (infotype.IndexOf("D") >= 0)
                {
                    tbx.Enabled = true;
                    tbx.BackColor = Color.White;
                }

               
                //added enabling qty for DD,AD,AM
                tbx = (TextBox)gvRow.FindControl("itm_qty");
                if ((schainno == "306") && (lbActivity.SelectedValue == "AM" || lbActivity.SelectedValue == "DD" || lbActivity.SelectedValue == "AM"))
                {
                    tbx.Enabled = true;
                }

                
   
            }
         }
        protected void Bind_gvProdList()
        {
            gvProdList.DataSource = dsProdList.Tables["Products"];
            gvProdList.DataBind();

            ViewState["dsProdList"] = dsProdList;
        }
        protected bool Item_Retrieve()
        {
            
            string sqlstr, chainno, storeno, businesstypeid, visitdt, jobno, waveno, taskno, skulist, skulookup;
            string merchno;

            skulookup = txtSkuLookup.Text.Trim();

            if (skulookup == "" || skulookup == null)
            {
                showMsg(v_error_msg[12]);   // Input valid SKU.
                return false;
            }

            skulist = SKU_List();
            lblProdMsg.Visible = false; ;
            if (skulist.IndexOf(skulookup + "~") >= 0)
            {
                lblProdMsg.Visible = true;
                lblProdMsg.Text = v_error_msg[11];  // SKU already exists in the list.
                return false;
            }

            sqlstr = "usp_fa_pdcs_productlookup_new"; // "usp_fa_pdcs_productlookup_new";

            chainno = ViewState["ChainNo"].ToString();
            storeno = ViewState["StoreNo"].ToString();
            businesstypeid = ViewState["BusinessTypeId"].ToString();
            visitdt = ViewState["VisitDt"].ToString();
            jobno = ViewState["JobNo"].ToString();
            waveno = ViewState["WaveNo"].ToString();
            taskno = ViewState["TaskNo"].ToString();
            merchno = ViewState["MerchNo"].ToString();
            // Response.Write("usp_fa_pdcs_productlookup_new  : " + jobno + " W: " + waveno + " T : " + taskno + "C : " + chainno + " S : " + storeno + " M : " + merchno + " D : " + visitdt + " BUSS : " + businesstypeid + " skulookup : " + skulookup);
            try
            {
                sdba.dbConnect(dbconnstr);
                sdba.sqlCommand.Connection = sdba.sqlConnection;
                sdba.sqlCommand.CommandText = sqlstr;
                sdba.sqlCommand.CommandType = CommandType.StoredProcedure;
                sdba.sqlCommand.Parameters.AddWithValue("@chain_no", chainno);
                sdba.sqlCommand.Parameters.AddWithValue("@store_no", storeno);
                sdba.sqlCommand.Parameters.AddWithValue("@business_type_id", businesstypeid);
                sdba.sqlCommand.Parameters.AddWithValue("@visit_dt", visitdt);
                sdba.sqlCommand.Parameters.AddWithValue("@job_no", jobno);
                sdba.sqlCommand.Parameters.AddWithValue("@wave_no", waveno);
                sdba.sqlCommand.Parameters.AddWithValue("@task_no", taskno);
//                sdba.sqlCommand.Parameters.AddWithValue("@skulist", skulist);
                sdba.sqlCommand.Parameters.AddWithValue("@lookuptext", skulookup);
                 sdba.sqlCommand.Parameters.AddWithValue("@merch_no", merchno);

                sdba.sqlReader = sdba.sqlCommand.ExecuteReader();

                lblProdMsg.Visible = false;
                if (! sdba.sqlReader.HasRows)
                {
                    lblProdMsg.Visible = true;

                        lblProdMsg.Text = v_error_msg[10];  // SKU not found or not Authorized.
                    
                    return false;
                }
                gvAddRow(sdba.sqlReader);
            }
            catch (Exception ex)
            {
                showMsg(ex.Message);
                return false;
            }
            finally
            {
                sdba.dbDisconnect();
            }
            return true;
        }        
        protected string SKU_List()
        {
            Label lbl = new Label();

            string sku, output;

            output = "";
            foreach (GridViewRow gvRow in gvProdList.Rows)
            {
                sku = ((Label)gvRow.FindControl("sku")).Text.ToString().Trim();
                
                if (sku == null)
                {
                    sku = "";
                }   
                output +=  sku + "~" ;
            }
            return output;
        }
        protected void btnAddProd_Click(object sender, EventArgs e)
        {
            lblProdMsg.Text = "";
            lblProdMsg.Visible = false;
            gvToDs();
            if (Item_Retrieve())
            {
                Bind_gvProdList();
                addSku_flag = "true";
                if (gvProdList.Rows.Count > 0)
                {
                    gvProdList.Rows[gvProdList.Rows.Count - 1].Focus();
                }
                txtSkuLookup.Text = "";
            }
           
            
             DataSet ds=new DataSet ();
            ds = (DataSet)ViewState["dsProdList"];             
            for (int i2 = 1; i2 < dsProdList.Tables[1].Rows.Count; i2++)
            {
                arr_activityId[i2 - 1] = dsProdList.Tables[1].Rows[i2][0].ToString();
                arr_activityDescription[i2 - 1] = dsProdList.Tables[1].Rows[i2][1].ToString();
            }
            //hd_CurrentEntries.Value = ""; 
          //   ClientScript.RegisterStartupScript(GetType(), "", "check_gvRowNewOrEdit()", true);
            //ClientScript.RegisterStartupScript(GetType(), "", "assignPopupValues()", true);
            

        }
        protected void gvAddRow(System.Data.SqlClient.SqlDataReader sdr)
        {
            DataRow dr;
            string skulist;
            skulist = SKU_List();
            while (sdr.Read())
            {
                
                if (skulist.IndexOf(sdr["sku"].ToString() + "~") < 0)
                {
                dr = dsProdList.Tables["Products"].NewRow();

                dr["job_no"] = sdr["job_no"].ToString();
                dr["wave_no"]=sdr["wave_no"].ToString();
                dr["task_no"] = sdr["task_no"].ToString();
                dr["sku"] = sdr["sku"].ToString();
                dr["item_desc"] = sdr["item_desc"].ToString();
                dr["no_of_builds"] = sdr["no_of_builds"].ToString();
                dr["last_status"] = sdr["last_status"].ToString();
                dr["item_link"] = sdr["item_link"].ToString();
                dr["build_status"] = sdr["build_status"].ToString();
                dr["model"] = sdr["model"].ToString();
                dr["qty"] = sdr["qty"].ToString();

                dr["status_flag"] = sdr["status_flag"].ToString();
                     dsProdList.Tables[0].Rows.Add(dr); 
                 }
                  
            }
        }
        protected bool ProdStatCheck()
        {
            return true; // jks
            DataRow[] drs, drslink, drsactivity, activityrw;
            bool rtnstatus;
            string infotype, schainno, sinfotype;           
            rtnstatus = true;
            int iqtyval = 0;
            
            /*
            drs = dsProdList.Tables["Products"].Select("current_status= ''");
            if (drs.Length > 0)
            {
                rtnstatus = false;
                for (int i = 0; i < drs.Length; i++)
                {
                    drs[i]["err_desc"] = "Select a status.";
                }
            }
              */
            schainno = ViewState["ChainNo"].ToString();
            infotype = "";
            drs = dsProdList.Tables["Products"].Select();
            if (drs.Length > 0)
            {
                for (int i = 0; i < drs.Length; i++)
                {
                    
                    if (drs[i]["current_status"].ToString().Trim() == "")
                    {
                        drs[i]["err_desc"] = "Select a status.";
                        rtnstatus = false;
                    }
                    else
                    {
                        drsactivity = dsProdList.Tables["Activity"].Select("activity_id = '" + drs[i]["current_status"] + "'");                       
                        if ((drs[i]["current_status"].ToString().Trim() == "AM") || (drs[i]["current_status"].ToString().Trim() == "AD"))
                        {
                            if (Convert.ToInt32(drs[i]["qty"].ToString()) <=0)
                            {
                                drs[i]["qty"] = "1";
                               // rtnstatus = false;
                            }
                        }        
                        if (drsactivity.Length > 0)
                        {
                            infotype = drsactivity[0]["info_type"].ToString().Trim();
                        }
                        
                        if (infotype.IndexOf("T") >= 0)
                        {
                            if (drs[i]["response_text"].ToString().Trim() == ""){
                                drs[i]["err_desc"] = "Input Remarks.";
                                rtnstatus = false;
                            }
                        }

                        if (infotype.IndexOf("RA") >= 0)
                        {
                            if (drs[i]["response_text"].ToString().Trim() == "")
                            {
                                drs[i]["err_desc"] = "Input RA Number.";
                                rtnstatus = false;
                            }
                        }

                        if (infotype.IndexOf("D") >= 0)
                        {
                            if (drs[i]["response_dt"].ToString().Trim() == "")
                            {
                                drs[i]["err_desc"] = "Input Revisit Date.";
                                rtnstatus = false;
                            }
                        }
                    }                                    
                }
            }
            drs = dsProdList.Tables["Products"].Select("no_of_builds < qty");
            if (drs.Length > 0)
            {                
                for (int i = 0; i < drs.Length; i++)
                {                 

                    if ((schainno != "306") && (drs[i]["current_status"].ToString().Trim() != "DD") && (drs[i]["current_status"].ToString().Trim() != "AD") && (drs[i]["current_status"].ToString().Trim() != "AM"))
                    {                       
                        rtnstatus = false;
                        drs[i]["err_desc"] = "Qty is above the limit - " + drs[i]["no_of_builds"].ToString();
                    }
                    //end
                }
            }
            drs = dsProdList.Tables["Products"].Select("item_link <> ''");
            if (drs.Length > 0)
            {
                for (int i = 0; i < drs.Length; i++)
                {
                    drslink = dsProdList.Tables["Products"].Select("item_link='" + drs[i]["item_link"].ToString() + "'");
                    if (drslink.Length > 0)
                    {
                        for (int j = 0; j < drslink.Length; j++)
                        {
                            if (drslink[j]["current_status"].ToString() != drs[i]["current_status"].ToString())
                            {
                                drs[i]["err_desc"] = "Status shoulbe be same as Link item - "+drslink[j]["sku"].ToString();
                                rtnstatus = false;
                            }
                        }
                    }
                }
            }
            drs = dsProdList.Tables["Products"].Select("response_dt <> ''");
            if (drs.Length > 0)
            {
                for (int i = 0; i < drs.Length; i++)
                {
                    if (! isDate(drs[i]["response_dt"].ToString(), Master.v_sys_rule[0].ToString())){
                    drs[i]["err_desc"] = "Invalid Date.";                       
                    rtnstatus = false;
                    }
                }
            }
            
                foreach (TemplateField tf in gvProdList.Columns)
                {
                    if (tf.HeaderText == "Error Description")
                    {
                        if (!rtnstatus)
                        {
                            tf.Visible = true;
                        }
                        else
                        {
                            tf.Visible = false;
                        }
                    }
                }
               
               

            return rtnstatus;
        }
        protected bool isDate(string dtStr, string dtFmt)
        {
            DateTime outDT;
            string[] aryDtStr, aryDtFmt;
            string dateString;

            dateString = "MM/DD/YY";
            aryDtStr = dtStr.Split(new Char[] {'/'});
            aryDtFmt = dtFmt.ToUpper().Split(new Char[] {'/'});

            if (aryDtFmt.Length != aryDtStr.Length)
            {
                return false;
            }

            for (int i = 0; i < aryDtFmt.Length; i++ )
            {
                switch (aryDtFmt[i])
                {
                    case "DD":  dateString = dateString.Replace("DD", aryDtStr[i].ToString()); break;
                    case "MM": dateString = dateString.Replace("MM", aryDtStr[i].ToString()); break;
                    case "YYYY": dateString = dateString.Replace("YY", aryDtStr[i].ToString()); break;
                    case "YY": dateString = dateString.Replace("YY", aryDtStr[i].ToString()); break;
                    default: break;
                }
            }
            if (DateTime.TryParse(dateString, out outDT))
            {
                if (outDT != DateTime.Parse("01/01/01") && outDT < DateTime.Now.Date)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        protected void gvToDs()
        {
            string sku, currentstatus, qty, remark, revisitdt, hiddenValue_current, hiddenValue_previous;
            DataRow[] drs;           
            //DataTable dt = (DataTable)gvProdList.DataSource;

            foreach (GridViewRow gvrow in gvProdList.Rows){

                sku = ((Label)gvrow.FindControl("sku")).Text;                
                currentstatus = ((DropDownList)gvrow.FindControl("ddlbActivity")).SelectedValue.ToString();               
                qty = ((TextBox)gvrow.FindControl("itm_qty")).Text.ToString().Trim();
                remark = ((TextBox)gvrow.FindControl("itm_response_text")).Text.ToString().Trim();
                revisitdt = ((TextBox)gvrow.FindControl("itm_response_dt")).Text.ToString().Trim();


                hiddenValue_current = ((HiddenField)gvrow.FindControl("hd_gvProdList_Row")).Value.ToString().Trim();//org
                // hiddenValue_current = ((TextBox)gvrow.FindControl("hd_gvPreviousStatus")).Text.ToString().Trim(); 


                
                drs = dsProdList.Tables["Products"].Select("sku = '" + sku + "'");
               
                for (int i = 0; i < drs.Length; i++)
                {                    
                    drs[i]["current_status"] = currentstatus;
                    drs[i]["qty"] = qty;
                    drs[i]["err_desc"] = "";
                    drs[i]["response_text"] = remark;
                    drs[i]["response_dt"] = revisitdt;

                    //drs[i]["PreviousStatus"] = hiddenValue_previous;
                    drs[i]["CurrentStatus"] = hiddenValue_current; //org

                }
            }
        }
        protected bool SaveDataToDB()
        {
            string sqlstr, jobno, waveno, taskno, chainno, storeno, visitdt, businesstypeid, userid, merchno, startdt;

            sqlstr = "usp_fa_pdcs_save";

            jobno = ViewState["JobNo"].ToString().Trim();
            waveno = ViewState["WaveNo"].ToString().Trim();
            taskno = ViewState["TaskNo"].ToString().Trim();
            chainno = ViewState["ChainNo"].ToString().Trim();
            storeno = ViewState["StoreNo"].ToString().Trim();
            visitdt = ViewState["VisitDt"].ToString().Trim();
            businesstypeid = ViewState["BusinessTypeId"].ToString().Trim();
            userid = ViewState["User Id"].ToString().Trim();
            merchno = ViewState["MerchNo"].ToString().Trim();
            startdt = ViewState["startDt"].ToString().Trim();

            try
            {
             //  Response.Write("J : " + jobno + " W: " + waveno + " T : " + taskno + "C : " + chainno + " S : " + storeno + " M : " + merchno + " D : " + visitdt + " BUSS : " + businesstypeid + " S DATE : " + startdt);
               // Response.Write(dsProdList.Tables["Products"].DataSet.GetXml());
            //    Response.End();
                sdba.dbConnect(dbconnstr);
                sdba.sqlCommand.Connection = sdba.sqlConnection;
                sdba.sqlCommand.CommandText = sqlstr;
                sdba.sqlCommand.CommandType = CommandType.StoredProcedure;
                dsProdList.Namespace = "";
                sdba.sqlCommand.Parameters.AddWithValue("@job_no", jobno);
                sdba.sqlCommand.Parameters.AddWithValue("@wave_no", waveno);
                sdba.sqlCommand.Parameters.AddWithValue("@task_no", taskno);
                sdba.sqlCommand.Parameters.AddWithValue("@chain_no", chainno);
                sdba.sqlCommand.Parameters.AddWithValue("@store_no", storeno);
                sdba.sqlCommand.Parameters.AddWithValue("@merch_no", merchno);
                sdba.sqlCommand.Parameters.AddWithValue("@visit_dt", visitdt);
                sdba.sqlCommand.Parameters.AddWithValue("@business_type_id", businesstypeid);
                sdba.sqlCommand.Parameters.AddWithValue("@user_id", userid);
                sdba.sqlCommand.Parameters.AddWithValue("@proddata", dsProdList.Tables["Products"].DataSet.GetXml());
                sdba.sqlCommand.Parameters.AddWithValue("@startdt", startdt);

                sdba.sqlReader = sdba.sqlCommand.ExecuteReader();
                sdba.sqlReader.Read();
                if (sdba.sqlReader[0].ToString() == "-1")
                {
                    //showMsg(sdba.sqlReader[1].ToString());
                    showMsg(v_error_msg[14]);  //Error:  Data not saved.
                    sdba.dbDisconnect();
                    return false;
                }
                lblConfNo.Text = sdba.sqlReader[1].ToString();
            }
            catch (Exception ex)
            {
                showMsg(ex.Message);
                return false;
            }
            finally
            {
                sdba.dbDisconnect();
            }
            return true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            btnNext_Click(sender, e);
        }        
        protected string GetMerchDistrictNum()
        {
            string merchno_val = "";
            string merch_districtno="";
            string sqlstr = "";
            merchno_val = ViewState["MerchNo"].ToString().Trim();
            sqlstr = "usp_get_merchdistrict_no";

            try
            {
                sdba.dbConnect(dbconnstr);
                sdba.sqlCommand.Connection = sdba.sqlConnection;
                sdba.sqlCommand.CommandType = CommandType.StoredProcedure;
                sdba.sqlCommand.CommandText = sqlstr;

                sdba.sqlCommand.Parameters.AddWithValue("@merch_no", merchno_val);

                sdba.sqlReader = sdba.sqlCommand.ExecuteReader();
                sdba.sqlReader.Read();
                if (sdba.sqlReader.HasRows)
                {
                    merch_districtno= sdba.sqlReader[0].ToString();                    
                }
            }
            catch (Exception ex)
            {
                showMsg(ex.Message);
            }
            finally
            {
                sdba.dbDisconnect();
            }
            return merch_districtno;
        }        
        protected void SetCallFormVariables()
        {
            string callformUrl;
            string merchno_val, merch_districtno;
            string callformlink;
            string domain_val, str1Dom,domLink;
            int getDomPos, getDom2Pos;
            merch_districtno = "";
            domain_val = Request.Url.Host;
            getDomPos = domain_val.LastIndexOf(".");
            str1Dom = domain_val.Remove(getDomPos);
            getDom2Pos = str1Dom.IndexOf(".");

            domLink = str1Dom.Substring(getDom2Pos + 1);
            callformlink = ConfigurationManager.AppSettings["Callform"].ToString();
            callformlink = "http://miweb22." + domLink + ".com/callformdpq/CFJWTValidateSV.aspx";           
            

            merchno_val = ViewState["MerchNo"].ToString().Trim();
            langid = sdba.LangId(langid);
            if (langid.ToString() == "1")
            {
               merch_districtno = GetMerchDistrictNum();
            }
            callformUrl = "<html><script type='text/javascript' language='javascript'>function goto_callform() {document.frmCallform.submit(); return true;  }</script>";
            callformUrl += "<body onload='goto_callform()'>";
            if (langid.ToString() == "1")
            {
              //  if (merchno_val == "108118" || merchno_val == "59899" || merchno_val == "8104" || merchno_val == "68974" || merchno_val == "143238" || merchno_val == "143626" || merchno_val == "132116" || merchno_val == "61941" || merchno_val == "79559" || merchno_val == "25049" || merchno_val == "61138" || merchno_val == "28432" || merchno_val == "50755" || merchno_val == "116623" || merchno_val == "127305" || merchno_val == "144192" || merchno_val == "107155" || merchno_val == "146444" || merchno_val == "147493" || merchno_val == "147582" || merchno_val == "113802" || merchno_val == "116691" || merchno_val == "116721" || merchno_val == "116794" || merchno_val == "116836" || merchno_val == "26653" || merchno_val == "30942" || merchno_val == "59802" || merchno_val == "66323" || merchno_val == "115819" || merch_districtno == "157" || merch_districtno == "1012" || merch_districtno == "1730")
              //  {
                    callformlink = "http://miweb22." + domLink + ".com/CallFormMultiVisit/CFJWTValidateSV.aspx";
                    callformUrl += "<form id='frmCallform' name='frmCallform' action='" + callformlink + "' method='post'>";
             //   }
              //  else
             //   {
             //       callformUrl += "<form id='frmCallform' name='frmCallform' action='" + callformlink + "' method='post'>";
             //   }
            }
            else
            {
                callformUrl += "<form id='frmCallform' name='frmCallform' action='" + callformlink + "' method='post'>";
            }
            callformUrl += "<input type=hidden name='txt_jobno' value='" + ViewState["JobNo"].ToString()+"'>";
            callformUrl += "<input type=hidden name='txt_waveno' value='" + ViewState["WaveNo"].ToString() + "'>";
            callformUrl += "<input type=hidden name='txt_taskno' value='" + ViewState["TaskNo"].ToString() + "'>";
            callformUrl += "<input type=hidden name='txt_chainno' value='" + ViewState["ChainNo"].ToString() + "'>";
            callformUrl += "<input type=hidden name='txt_storeno' value='" + ViewState["StoreNo"].ToString() + "'>";
            callformUrl += "<input type=hidden name='visit_dt' value='" + ViewState["VisitDt"].ToString() + "'>";
            callformUrl += "<input type=hidden name='merch_no' value='" + ViewState["MerchNo"].ToString() + "'>";
            callformUrl += "<input type=hidden name='txt_usrid' value='" + ViewState["User Id"].ToString() + "'>";
            callformUrl += "<input type=hidden name='txt_langid' value='" + ViewState["Lang Id"].ToString() + "'>";
            callformUrl += "</form></body></html>";

            Response.Write(callformUrl);
            Response.Flush();
        }
        protected void btnCallform_Click(object sender, EventArgs e)
        {
            SetCallFormVariables();
        }
    }
