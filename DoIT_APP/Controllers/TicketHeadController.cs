using DoIT_APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DoIT_APP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketHeadController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TicketHeadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetLatestTicketHeadId()
        {
            string query = @"
                SELECT TOP 1 TicketHeadId FROM TicketHead Order by TicketHeadId desc
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select * from
                dbo.TicketHead
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult GetByProject(int id)
        {
            string query = @"
                select * from
                dbo.TicketHead
                where ProjectId = @ProjectId
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ProjectId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult GetByEmployee(int id)
        {
            string query = @"
                select TicketHeadId from
                dbo.TicketHead
                where TicketHeadId = @TicketHeadId
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TicketHeadId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(TicketHead tic)
        {
            string query = @"
                insert into dbo.TicketHead
                (TicketHeadName, Description, Status, DueDate, Created, ProjectId)
                values (@TicketHeadName, @Description, @Status, @DueDate, @Created, @ProjectId)
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TicketHeadName", tic.TicketHeadName);
                    myCommand.Parameters.AddWithValue("@Description", tic.Description);
                    myCommand.Parameters.AddWithValue("@Status", tic.Status);
                    myCommand.Parameters.AddWithValue("@DueDate", tic.DueDate);
                    myCommand.Parameters.AddWithValue("@Created", tic.Created);
                    myCommand.Parameters.AddWithValue("@ProjectId", tic.ProjectId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(TicketHead tic)
        {
            string query = @"
                update dbo.TicketHead
                set TicketHeadName = @TicketHeadName,
                    Description=@Description,
                    Status=@Status,
                    DueDate=@DueDate,
                    Created=@Created,
                    ProjectId=@ProjectId
                where TicketHeadId = @TicketHeadId
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TicketHeadId", tic.TicketHeadId);
                    myCommand.Parameters.AddWithValue("@TicketHeadName", tic.TicketHeadName);
                    myCommand.Parameters.AddWithValue("@Description", tic.Description);
                    myCommand.Parameters.AddWithValue("@Status", tic.Status);
                    myCommand.Parameters.AddWithValue("@DueDate", tic.DueDate);
                    myCommand.Parameters.AddWithValue("@Created", tic.Created);
                    myCommand.Parameters.AddWithValue("@ProjectId", tic.ProjectId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from dbo.TicketHead
                where TicketHeadId = @TicketHeadId
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TicketHeadId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
