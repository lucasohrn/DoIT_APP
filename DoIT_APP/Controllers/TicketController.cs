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
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TicketController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select * from
                dbo.Ticket
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

        [HttpPost]
        public JsonResult Post(Ticket tic)
        {
            string query = @"
                insert into dbo.Ticket
                (TicketName, Description, AssignedTo, Status, DueDate, Created)
                values (@TicketName, @Description, @AssignedTo, @Status, @DueDate, @Created)
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TicketName", tic.TicketName);
                    myCommand.Parameters.AddWithValue("@Description", tic.Description);
                    myCommand.Parameters.AddWithValue("@AssignedTo", tic.AssignedTo);
                    myCommand.Parameters.AddWithValue("@Status", tic.Status);
                    myCommand.Parameters.AddWithValue("@DueDate", tic.DueDate);
                    myCommand.Parameters.AddWithValue("@Created", tic.Created);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");

        }

        [HttpPut]
        public JsonResult Put(Ticket tic)
        {
            string query = @"
                update dbo.Ticket
                set TicketName = @TicketName,
                    Description=@Description,
                    AssignedTo=@AssignedTo,
                    Status=@Status,
                    DueDate=@DueDate,
                    Created=@Created
                where TicketId = @TicketId
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TicketId", tic.TicketId);
                    myCommand.Parameters.AddWithValue("@TicketName", tic.TicketName);
                    myCommand.Parameters.AddWithValue("@Description", tic.Description);
                    myCommand.Parameters.AddWithValue("@AssignedTo", tic.AssignedTo);
                    myCommand.Parameters.AddWithValue("@Status", tic.Status);
                    myCommand.Parameters.AddWithValue("@DueDate", tic.DueDate);
                    myCommand.Parameters.AddWithValue("@Created", tic.Created);
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
                delete from dbo.Ticket
                where TicketId = @TicketId
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TicketId", id);
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
