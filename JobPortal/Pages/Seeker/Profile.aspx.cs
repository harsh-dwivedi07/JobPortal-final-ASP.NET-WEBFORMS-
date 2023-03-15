using JobPortal.Models;
using JobPortal.Repository.Implementation;
using JobPortal.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace JobPortal.Pages.Seeker
{
    public partial class Profile : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            // Guid userID = (Guid)Session["UserID"];
            //  string val = GetSeekerDetail();
            if (!Page.IsPostBack )
                await GetSeekerDetail();
           
        }

        protected  void Button1_Click(object sender, EventArgs e)
        {
            Guid userId = (Guid)Session["UserID"];
            JobSeekerModel seek = new JobSeekerModel()
            {
                UserId= userId,
                firstName = FirstName.Text,
                lastName = LastName.Text,
                email = Email.Text,
                Mobile = Mobile.Text,
                DOB = DOB.Text.AsDateTime(),
                CurrentLocation = Location.Text,
                About = about.Text,
                Experience = int.Parse(Experience.Text),
                UpdatedAt = DateTime.Now,
                CreatedAt= DateTime.Now,
            };
            
            IJobSeeker _jobseeker = new JobSeeker();
            _jobseeker.UpdateJobSeekerDetails(userId, seek);

        }
        protected async Task GetSeekerDetail()
        {
            
            Guid userId = (Guid)Session["UserID"];
            SqlConnection con = new SqlConnection(); ;
            SqlCommand cmd;
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con.Open();
            string query = $"Select * from JobSeeker where UserId='{userId}'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Retrieve data from the current row
                //int id = (int)reader["ID"];
                //string name = (string)reader["Name"];
                FirstName.Text = (reader["firstName"] == DBNull.Value) ? "": (string)reader["firstName"];
                LastName.Text = (reader["lastName"] == DBNull.Value) ? "": (string)reader["lastName"];
                Email.Text= (reader["email"] == DBNull.Value) ? "": (string)reader["email"];
                DOB.Text = (reader["DOB"] == DBNull.Value)?"Empty": reader["DOB"].ToString();
                Mobile.Text= (reader["Mobile"] == DBNull.Value) ? "" : (string)reader["Mobile"];
                Location.Text= (reader["CurrentLocation"]==DBNull.Value)?"": (string)reader["CurrentLocation"];
                about.Text= (reader["About"] == DBNull.Value) ? "" : (string)reader["About"];
                Experience.Text = (reader["Experience"] == DBNull.Value) ? "" : reader["Experience"].ToString();
            }
            
            cmd.Dispose();
            con.Dispose();
        }
    }
}