using DockerSqlServer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Mvc;


namespace DockerSqlServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HrmsController
    {
        private readonly AppDbContext _db;
        SqlConnection con;

        public HrmsController(AppDbContext db)
        {
            _db = db;
            con = new SqlConnection(_db.Database.GetDbConnection().ConnectionString);
        }

     

        [HttpPost]
        [Route("LoyaltyCustomersUpdate")]
        public async Task<ActionResult<bool>> LoyaltyCustomersUpdate (LyCustomersModel Ly)
        {

            SqlCommand command = new SqlCommand("[dbo].[Ly_Customers_Update]", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@v_Cd", Ly.Cd);
            command.Parameters.AddWithValue("@v_Des", Ly.Des);
            command.Parameters.AddWithValue("@v_FName", Ly.FName);
            command.Parameters.AddWithValue("@v_LName", Ly.LName);
            command.Parameters.AddWithValue("@v_MName", Ly.MName);
            command.Parameters.AddWithValue("@v_CoCd", Ly.CoCd);
            command.Parameters.AddWithValue("@v_Gender", Ly.Gender);
            command.Parameters.AddWithValue("@v_BirthDt", Ly.BirthDt);
            command.Parameters.AddWithValue("@v_Addr1", Ly.Addr1);
            command.Parameters.AddWithValue("@v_Addr2", Ly.Addr2);
            command.Parameters.AddWithValue("@v_Addr3", Ly.Addr3);
            command.Parameters.AddWithValue("@v_CustCoCd", Ly.CustCoCd);
            command.Parameters.AddWithValue("@v_AreaCd", Ly.AreaCd);
            command.Parameters.AddWithValue("@v_Religion", Ly.Religion);
            command.Parameters.AddWithValue("@v_Profession", Ly.Profession);
            command.Parameters.AddWithValue("@v_Phone", Ly.Phone);
            command.Parameters.AddWithValue("@v_Fax", Ly.Fax);
            command.Parameters.AddWithValue("@v_Mobile", Ly.Mobile);
            command.Parameters.AddWithValue("@v_Email", Ly.Email);
            command.Parameters.AddWithValue("@v_UID", Ly.UID);
            command.Parameters.AddWithValue("@v_IDType", Ly.IDType);
            command.Parameters.AddWithValue("@v_Curr", Ly.Curr);
            command.Parameters.AddWithValue("@v_Country",Ly.Country);
            command.Parameters.AddWithValue("@v_Region", Ly.Region);
            command.Parameters.AddWithValue("@v_CustGrp", Ly.CustGrp);
            command.Parameters.AddWithValue("@v_CardType",Ly.CardType);
            command.Parameters.AddWithValue("@v_Active", Ly.Active);
            command.Parameters.AddWithValue("@v_BlackListed", Ly.BlackListed);
            command.Parameters.AddWithValue("@v_CardIssued", Ly.CardIssued);
            command.Parameters.AddWithValue("@v_Remarks",Ly.Remarks);
            command.Parameters.AddWithValue("@v_EntryBy", Ly.EntryBy);
            command.Parameters.AddWithValue("@v_EditBy", Ly.EditBy);

            // Open the connection
            con.Open();

            // Execute the command and get the number of rows affected
            int rowsAffected = await command.ExecuteNonQueryAsync();

            // Close the connection
            con.Close();

            if (rowsAffected > 0) {
                return true;
            }
            return false;

        }



        [HttpGet]
        [Route("userValidat")]
        public async Task<ActionResult<bool>> userValidat(String userCd,String password)
        {
            string StoredProc = "select * from [hr].[user] where userCd = '" + userCd + "' and password = '" + password + "'";

            var t = await _db.users.FromSqlRaw(StoredProc).ToListAsync();


            if (t.Count > 0)
            {
                return true;
            }
            return false;

        }

        [HttpGet]
        [Route("getDocDetails")]
        public async Task<ActionResult<List<docScreenDetails>>> getDocDetails()
        {
            string StoredProc = "select docd.id,(ISNULL(narration + ' - ','')+ emp.name )narration,doct.description docType,dueDate,renewedDate,\n  (select name from hr.[user] where  id = docd.editBy)editBy,editdt,(select name from hr.[user] where  id = docd.creatBy)creatBy,creatDt \n  from [hr].[documentDetails] docd\n  left join hr.documentType doct on doct.id = docd.docid\n  left join hr.empMaster emp on emp.id = docd.empCode ";

            var t = await _db.docScreenDetails.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }


        [HttpPost]
        [Route("saveSalary")]
        public async Task<ActionResult<bool>> saveSalary(Salary salary)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //salary.EditBy = 1; // Set the user ID for the editBy column
            //salary.EditDt = DateTime.Now; // Set the current date and time for the editDt column
            //salary.CreatBy = 1; // Set the user ID for the creatBy column
            //salary.CreatDt = DateTime.Now; // Set the current date and time for the creatDt column

            _db.Salary.Add(salary);
           var rowsAffected = await _db.SaveChangesAsync();

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("saveLeaveSalary")]
        public async Task<ActionResult<bool>> saveLeaveSalary(LeaveSalary leaveSalary)
        {
            _db.LeaveSalary.Add(leaveSalary);
            var rowsAffected = await _db.SaveChangesAsync();

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("saveSalaryMaster")]
        public async Task<ActionResult<bool>> saveSalaryMaster(SalaryMaster SalaryMaster)
        {
            _db.SalaryMaster.Add(SalaryMaster);
            var rowsAffected = await _db.SaveChangesAsync();

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
