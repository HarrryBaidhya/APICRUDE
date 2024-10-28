using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebGrease;
using FoodMandu.Models;
using System.Web.Util;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace FoodMandu.Controllers
{

    public class CompanyController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FoodMandu"].ConnectionString);
         Company company=new Company();

        [HttpGet]
        [Route("api/getallLayout")]
        public HttpResponseMessage getAlllay()
        {
           
                SqlDataAdapter Da = new SqlDataAdapter("sproc_Foodgetalllayout", conn);
                Company loc = new Company();
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                Da.Fill(dt);
                 List<Company> listLo = new List<Company>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Company lc = new Company();
                    lc.Name = dt.Rows[i]["Name"].ToString();
                    lc.LayoutId = Convert.ToInt32(dt.Rows[i]["LayoutId"]);
                    lc.Banner = dt.Rows[i]["Banner"].ToString();
                    lc.Image = dt.Rows[i]["Image"].ToString();
                    listLo.Add(lc);
                }

            }
            if (listLo.Count > 0)
            {
                Company RCP = new Company();
                RCP.Message = "Success";
                RCP.Item =listLo ;
              
                var response = Request.CreateResponse<CommonResponse>(System.Net.HttpStatusCode.OK, RCP);
                return response;
              
            }
            else {
                Company RCP = new Company();
                RCP.Message = "Error";
                RCP.Code = "1";
                var response = Request.CreateResponse<CommonResponse>(System.Net.HttpStatusCode.OK, RCP);
                return response;

            }

           
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/addCompany")]
        public string AddCompanyfood(Company loc)
        {
            string msg = "";
            if (loc != null)
            {
                SqlCommand cmd = new SqlCommand("FoodInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", loc.Name);
                cmd.Parameters.AddWithValue("@Banner", loc.Banner);
                cmd.Parameters.AddWithValue("@Image", loc.Image);
                cmd.Parameters.AddWithValue("@Layout", loc.Layout);
                cmd.Parameters.AddWithValue("@flag", 'I');
                cmd.Parameters.AddWithValue("@LayoutId", loc.LayoutId);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i < 0)
                {
                    msg="Data Save succesfully";
                }
                else
                {
                    msg = "error";
                }

            }
            return msg;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/GetByIDComp")]
        public HttpResponseMessage GetbyId(Company loc)
        {
            SqlDataAdapter Da = new SqlDataAdapter("sproc_companybyid", conn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@LayoutId", loc.LayoutId);
            DataTable dt = new DataTable();
            Da.Fill(dt);
            //var response = Request.CreateResponse<Company>(System.Net.HttpStatusCode.BadRequest, loc);
            List<Company> loclist = new List<Company>();
            if (dt.Rows.Count > 0)
            {

                Company lc = new Company();
                lc.Name = dt.Rows[0]["Name"].ToString();
                lc.LayoutId = Convert.ToInt32(dt.Rows[0]["LayoutId"]);
                lc.Banner = dt.Rows[0]["Banner"].ToString();
               
                lc.Image = dt.Rows[0]["Image"].ToString();
                loclist.Add(lc);
            }

        
            if (loclist != null)
            {
                Company RCP = new Company();
                RCP.Message = "Success";
                RCP.LayoutId = loclist[0].LayoutId;
                RCP.Name = loclist[0].Name;
                RCP.Banner= loclist[0].Banner;
                RCP.Layout = loclist[0].Layout;
                RCP.Image = loclist[0].Image;
                var response = Request.CreateResponse<CommonResponse>(System.Net.HttpStatusCode.OK, RCP);
                return response;


            }
            else {
                Company RCP = new Company();
                RCP.Message = "Error";
                RCP.ReponseCode = 1;
                var response = Request.CreateResponse<CommonResponse>(System.Net.HttpStatusCode.OK, RCP);
                return response;
            }

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/getdata")]
        public List<Company> Get()
        {
            SqlDataAdapter Da = new SqlDataAdapter("sproc_Foodgetalllayout", conn);
           Company loc = new Company();
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            Da.Fill(dt);
            List<Company> listLo = new List<Company>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Company lc = new Company();
                    lc.Name = dt.Rows[i]["Name"].ToString();
                    lc.LayoutId = Convert.ToInt32(dt.Rows[i]["LayoutId"]);
                    lc.Banner = dt.Rows[i]["Banner"].ToString();
                    lc.Image = dt.Rows[i]["Image"].ToString();
                    listLo.Add(lc);
                }

            }
            if (listLo.Count > 0)
            {
                return listLo;
            }
            else { return null; }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Deletedata")]
        public string deletedata(Company loc)
        {
            string msg = "";
            if (loc != null)
            {

                SqlCommand cmd = new SqlCommand("sproc_Deletecompanybyid", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LayoutId", loc.LayoutId);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i < 0)
                {
                    msg = " Deleted Succesfully";
                }
                else
                {
                    msg = "Error";
                }

            }
            return null;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/UpdateCompany")]
        public string UpdateCompanyfood(Company loc)
        {
            string msg = "";
            if (loc != null)
            {
                SqlCommand cmd = new SqlCommand("FoodInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", loc.Name);
                cmd.Parameters.AddWithValue("@Banner", loc.Banner);
                cmd.Parameters.AddWithValue("@Image", loc.Image);
                cmd.Parameters.AddWithValue("@Layout", loc.Layout);
                cmd.Parameters.AddWithValue("@flag", 'U');
                cmd.Parameters.AddWithValue("@LayoutId", loc.LayoutId);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i < 0)
                {
                    msg = "Data UpdatedSuccesfully";
                }
                else
                {
                    msg = "error";
                }

            }
            return msg;
        }

    }
}
