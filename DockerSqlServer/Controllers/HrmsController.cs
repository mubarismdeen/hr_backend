using DockerSqlServer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using System.Xml.Linq;
using System.Linq;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using DockerSqlServer.DTO;

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
        public async Task<ActionResult<bool>> LoyaltyCustomersUpdate(LyCustomersModel Ly)
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
            command.Parameters.AddWithValue("@v_Country", Ly.Country);
            command.Parameters.AddWithValue("@v_Region", Ly.Region);
            command.Parameters.AddWithValue("@v_CustGrp", Ly.CustGrp);
            command.Parameters.AddWithValue("@v_CardType", Ly.CardType);
            command.Parameters.AddWithValue("@v_Active", Ly.Active);
            command.Parameters.AddWithValue("@v_BlackListed", Ly.BlackListed);
            command.Parameters.AddWithValue("@v_CardIssued", Ly.CardIssued);
            command.Parameters.AddWithValue("@v_Remarks", Ly.Remarks);
            command.Parameters.AddWithValue("@v_EntryBy", Ly.EntryBy);
            command.Parameters.AddWithValue("@v_EditBy", Ly.EditBy);

            // Open the connection
            con.Open();

            // Execute the command and get the number of rows affected
            int rowsAffected = await command.ExecuteNonQueryAsync();

            // Close the connection
            con.Close();

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }



        [HttpGet]
        [Route("userValidat")]
        public async Task<ActionResult<bool>> userValidat(String userCd, String password)
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
        [Route("authorizeUser")]
        public async Task<ActionResult<List<UserScreens>>> authorizeUser(String userName, String password)
        {
            string StoredProc = "select scr.* from [hr].[user] u inner join [hr].[userScreens] scr on u.userCd = scr.userId where u.name = '" + userName + "' and u.password = '" + password + "'";

            var t = await _db.UserScreens.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getPrivilegesForUser")]
        public async Task<ActionResult<List<UserPrivileges>>> getPrivilegesForUser(String userName, String privilege)
        {
            string StoredProc = "select priv.* from [hr].[user] u inner join [hr].[userPrivileges] priv on u.userCd = priv.userId where u.name = '" + userName + "' and priv.privilegeName = '" + privilege + "'";

            var t = await _db.UserPrivileges.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getDocDetails")]
        public async Task<ActionResult<List<docScreenDetails>>> getDocDetails()
        {
            string StoredProc = "select docd.id,ISNULL(narration,'Nil') narration,emp.name,doct.description docType,dueDate,renewedDate," +
                "(select name from hr.[user] where  id = docd.editBy)editBy,editdt,(select name from hr.[user] where  id = docd.creatBy)creatBy,creatDt " +
                " from [hr].[documentDetails] docd left join hr.documentType doct on doct.id = docd.docid " +
                "inner join hr.empMaster emp on emp.id = docd.empCode and emp.statusId = 1 where docd.Status != 2 order by dueDate";

            var t = await _db.docScreenDetails.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpPost]
        [Route("saveDocDetails")]
        public async Task<ActionResult<bool>> saveDocDetails(DocumentDetails docDetails)
        {
            //_db.DocumentDetails.Add(docDetails);
            //var rowsAffected = await _db.SaveChangesAsync();

            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //return false;


            try
            {

                int rowsAffected = 0;


                var existingEntity = await _db.DocumentDetails.FindAsync(docDetails.Id);

                if (existingEntity == null)
                {
                    docDetails.EditDt = DateTime.Now;
                    docDetails.creatDt = DateTime.Now;


                    _db.DocumentDetails.Add(docDetails);
                    rowsAffected = await _db.SaveChangesAsync();

                }
                else
                {

                    existingEntity.empCode = docDetails.empCode;
                    existingEntity.narration = docDetails.narration;
                    existingEntity.renewedDate = docDetails.renewedDate;
                    existingEntity.docid = docDetails.docid;
                    existingEntity.dueDate = docDetails.dueDate;
                    existingEntity.EditDt = docDetails.EditDt;
                    existingEntity.EditBy = docDetails.EditBy;
                    existingEntity.Status = docDetails.Status;


                    _db.DocumentDetails.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("DeleteDocDetails")]
        public async Task<ActionResult<bool>> DeleteDocDetails(int id)
        {

            try
            {

                int rowsAffected = 0;


                var existingEntity = await _db.DocumentDetails.FindAsync(id);

                if (existingEntity == null)
                {
                    return false;

                }
                else
                {

                    existingEntity.Status = 2;


                    _db.DocumentDetails.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("getDocType")]
        public async Task<ActionResult<List<DocType>>> getDocType()
        {
            string StoredProc = "select * from hr.documentType ";

            var t = await _db.DocType.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }


        [HttpPost]
        [Route("saveSalary")]
        public async Task<ActionResult<bool>> saveSalary(Salary salary)
        {

            //_db.Salary.Add(salary);
            //var rowsAffected = await _db.SaveChangesAsync();

            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //return false;

            try
            {

                int rowsAffected = 0;


                var existingEntity = await _db.Salary.FindAsync(salary.Id);

                if (existingEntity == null)
                {
                    salary.EditDt = DateTime.Now;
                    salary.CreatDt = DateTime.Now;


                    _db.Salary.Add(salary);
                    rowsAffected = await _db.SaveChangesAsync();

                }
                else
                {

                    existingEntity.EmpCode = salary.EmpCode;
                    existingEntity.attendance = salary.attendance;
                    existingEntity.Anchorage = salary.Anchorage;
                    existingEntity.molId = salary.molId;
                    existingEntity.Novt = salary.Novt;
                    existingEntity.OffDays = salary.OffDays;
                    existingEntity.Overseas = salary.Overseas;
                    existingEntity.salary = salary.salary;
                    existingEntity.Sovt = salary.Sovt;
                    existingEntity.EditDt = salary.EditDt;
                    existingEntity.EditBy = salary.EditBy;


                    _db.Salary.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("saveLeaveSalary")]
        public async Task<ActionResult<bool>> saveLeaveSalary(List<Attendance> attendanceList)
        {
            try
            {

                int rowsAffected = 0;
                LeaveSalary leaveSalary = new LeaveSalary();

                foreach (var attendance in attendanceList)
                {
                    var existingEntity = await _db.LeaveSalary.Where(e => e.EmpCode == attendance.EmpCode & e.Year == attendance.date.Substring(0, 4)).FirstOrDefaultAsync();
                    var salaryMaster = await _db.SalaryMaster.Where(e => e.EmpCode == attendance.EmpCode).FirstOrDefaultAsync();


                    if (existingEntity == null)
                    {
                        leaveSalary.EmpCode = attendance.EmpCode;
                        leaveSalary.Attendance = attendance.attendance;
                        leaveSalary.SickLeave = attendance.OffDays - attendance.Lop;
                        leaveSalary.Salary = salaryMaster.Salary;
                        leaveSalary.PayAmt = (leaveSalary.SickLeave + attendance.attendance) * (salaryMaster.Salary / 335);
                        leaveSalary.Id = 0;
                        leaveSalary.PaidAmt = 0;
                        leaveSalary.Year = attendance.date.Substring(0, 4);
                        leaveSalary.PendingAmt = leaveSalary.PayAmt;
                        leaveSalary.EditBy = attendance.EditBy;
                        leaveSalary.EditDate = attendance.EditDate;
                        leaveSalary.CreatBy = attendance.CreateBy;
                        leaveSalary.CreatDate = attendance.CreateDate;

                        _db.LeaveSalary.Add(leaveSalary);
                        rowsAffected = await _db.SaveChangesAsync();

                    }
                    else
                    {

                        existingEntity.EmpCode = attendance.EmpCode;
                        existingEntity.Attendance = attendance.attendance;
                        existingEntity.SickLeave = attendance.Lop;
                        existingEntity.Salary = salaryMaster.Salary;
                        existingEntity.PayAmt = (existingEntity.SickLeave + attendance.attendance) * (salaryMaster.Salary / 335);
                        existingEntity.PendingAmt = existingEntity.PayAmt - existingEntity.PaidAmt;
                        existingEntity.Year = attendance.date.Substring(0, 4);
                        existingEntity.EditBy = attendance.EditBy;
                        existingEntity.EditDate = attendance.EditDate;

                        _db.LeaveSalary.Update(existingEntity);
                        rowsAffected = await _db.SaveChangesAsync();
                    }
                }
                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                var m = e;
            }
            return true;

        }

        [HttpPost]
        [Route("saveSalaryMaster")]
        public async Task<ActionResult<bool>> saveSalaryMaster(SalaryMaster salaryMaster)
        {
            //_db.SalaryMaster.Add(SalaryMaster);
            //var rowsAffected = await _db.SaveChangesAsync();

            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //return false;

            try
            {

                int rowsAffected = 0;
                salaryMaster.EditDt = DateTime.Now;


                var existingEntity = await _db.SalaryMaster.FindAsync(salaryMaster.Id);

                if (existingEntity == null)
                {
                    salaryMaster.CreatDt = DateTime.Now;


                    _db.SalaryMaster.Add(salaryMaster);
                    rowsAffected = await _db.SaveChangesAsync();

                }
                else
                {

                    existingEntity.EmpCode = salaryMaster.EmpCode;
                    existingEntity.Overseas = salaryMaster.Overseas;
                    existingEntity.Anchorage = salaryMaster.Anchorage;
                    existingEntity.NOtr = salaryMaster.NOtr;
                    existingEntity.SOtr = salaryMaster.SOtr;
                    existingEntity.Overseas = salaryMaster.Overseas;
                    existingEntity.Salary = salaryMaster.Salary;
                    existingEntity.EditDt = salaryMaster.EditDt;
                    existingEntity.EditBy = salaryMaster.EditBy;
                    existingEntity.Status = salaryMaster.Status;

                    _db.SalaryMaster.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("saveAttendance")]
        public async Task<ActionResult<bool>> saveAttendance(List<Attendance> attendanceList)
        {
            //DateTime myDateTime = DateTime.Now;
            //string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            try
            {

                int rowsAffected = 0;
                foreach (var attendance in attendanceList)
                {
                    attendance.EditDate = DateTime.Now;
                    attendance.CreateDate = DateTime.Now;

                    var existingEntity = await _db.Attendance.FindAsync(attendance.Id);

                    if (existingEntity == null)
                    {

                        _db.Attendance.Add(attendance);
                        rowsAffected = await _db.SaveChangesAsync();

                    }
                    else
                    {

                        existingEntity.Anchorage = attendance.Anchorage;
                        existingEntity.attendance = attendance.attendance;
                        existingEntity.Lop = attendance.Lop;
                        existingEntity.Novt = attendance.Novt;
                        existingEntity.OffDays = attendance.OffDays;
                        existingEntity.Overseas = attendance.Overseas;
                        existingEntity.Sovt = attendance.Sovt;
                        existingEntity.EditDate = attendance.EditDate;
                        existingEntity.EditBy = attendance.EditBy;


                        _db.Attendance.Update(existingEntity);
                        rowsAffected = await _db.SaveChangesAsync();
                    }
                }
                if (rowsAffected > 0)
                {
                    await updateMonthlySalary(attendanceList);
                    await saveLeaveSalary(attendanceList);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        [HttpGet]
        [Route("getEmpDetails")]
        public async Task<ActionResult<List<EmpMaster>>> getEmpDetails()
        {
            string StoredProc = "select * from hr.empMaster where statusId = 1 and status != 2 ";

            var t = await _db.EmpMaster.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getAttendance")]
        public async Task<List<AttendanceDto>> getAttendance(String date)
        {
            string StoredProc = "select att.id,att.empCode,emp.name,attendance,offdays,lop,novt,sovt,overseas,anchorage,date," +
                                "(select name from[hr].[user] where userCd = att.editBy) editBy,editDt," +
                                "(select name from[hr].[user] where userCd = att.creatBy) creatBy,creatDt " +
                                "from hr.attendance att inner join hr.empMaster emp on att.empcode = emp.empcode " +
                                "where date = '" + date + "'";

            var t = await _db.AttendanceDto.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        public async Task<Boolean> updateMonthlySalary(List<Attendance> attendanceList)
        {
            //----------------------------------daysInMonth-----------------------------------------------//
            DateTime sdate = DateTime.ParseExact(attendanceList[0].date, "yyyy-MM", CultureInfo.InvariantCulture);
            int year = sdate.Year;
            int month = sdate.Month;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            //----------------------------------daysInMonth----------------------------------------------//

            int rowsAffected = 0;
            SalaryPayable salaryPayable = new SalaryPayable();

            //List<EmpMaster> empList = await _db.empMaster.Where(e => e.StatusId == 1).ToListAsync();
            //var existingEntity = await _db.SalaryPaid.Where(e => e.EmpCode == emp.EmpCode & e.date == date).FirstOrDefaultAsync();


            var existingEntity = await _db.SalaryPayable.Where(e => e.Date == attendanceList[0].date).FirstOrDefaultAsync();

            try
            {
                if (existingEntity != null)
                {
                    _db.SalaryPayable.Remove(existingEntity);
                    _db.SaveChanges();
                }

                foreach (var attendance in attendanceList)
                {
                    //Attendance attendance = await _db.Attendance.Where(e => e.EmpCode == emp.EmpCode & e.date == date).FirstOrDefaultAsync();

                    SalaryMaster salaryMaster = await _db.SalaryMaster.Where(e => e.EmpCode == attendance.EmpCode).FirstOrDefaultAsync();

                    SalaryPaid salarypaid = await _db.SalaryPaid.Where(e => e.EmpCode == attendance.EmpCode).FirstOrDefaultAsync();

                    salaryPayable.Id = 0;
                    salaryPayable.EmpCode = attendance.EmpCode;
                    salaryPayable.Anchorage = attendance.Anchorage * salaryMaster.Anchorage;
                    salaryPayable.Attendance = attendance.attendance * (salaryMaster.Salary / daysInMonth);
                    salaryPayable.Basic = salaryMaster.Salary;
                    salaryPayable.Novt = attendance.Novt * salaryMaster.NOtr;
                    salaryPayable.Sovt = attendance.Sovt * salaryMaster.SOtr;
                    salaryPayable.Overseas = attendance.Overseas * salaryMaster.Overseas;
                    salaryPayable.due = salarypaid != null ? salarypaid.Due ?? 0 : 0;
                    decimal[] numbers = { salaryPayable.due, salaryPayable.Overseas, salaryPayable.Sovt, salaryPayable.Novt,
                                         salaryPayable.Basic , salaryPayable.Attendance, salaryPayable.Anchorage };
                    salaryPayable.Total = numbers.Sum();
                    salaryPayable.EditDt = DateTime.Now;
                    salaryPayable.CreatDt = DateTime.Now;
                    salaryPayable.Date = attendance.date;

                    _db.SalaryPayable.Add(salaryPayable);
                    rowsAffected = await _db.SaveChangesAsync();
                }
                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                var d = e.Message;
            }
            return false;
        }

        [HttpGet]
        [Route("getSalaryPay")]
        public async Task<List<SalaryPay>> getSalaryPay(String date)
        {

            string StoredProc = "select sa.id,sa.date,sa.empcode,name,basic,attendance,novt,sovt,overseas,anchorage,sa.due,total, " +
                                "sa.editDt,sa.creatDt from hr.salaryPayable sa " +
                                "inner join hr.empMaster emp on emp.empCode = sa.empcode " +
                                "where sa.date = '" + date + "'";

            var t = await _db.SalaryPay.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getLeaveSalary")]
        public async Task<List<LeaveSalaryPay>> getLeaveSalary(String year)
        {

            string StoredProc = "select sa.id,sa.empcode,name,salary,attendance,sickLeave,paidAmt,payAmt,sa.pendingAmt, " +
                                "(select name from[hr].[user] where userCd = sa.editBy) editBy,sa.editDate, " +
                                "(select name from[hr].[user] where userCd = ISNULL(sa.creatby,1)) " +
                                "creatBy,sa.creatDate from hr.leavesalary sa " +
                                "inner join hr.empMaster emp on emp.empCode = sa.empcode " +
                                "where sa.year = '" + year + "'";

            var t = await _db.leaveSalaryPay.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getSalary")]
        public async Task<List<SalaryMasterDto>> getSalary()
        {
            string StoredProc = "select sm.id,sm.empCode,name,salary,nOtr,sOtr,overseas,anchorage,sm.editDt,sm.creatDt, " +
                                "(select name from[hr].[user] where userCd = sm.editBy) editBy, " +
                                "(select name from[hr].[user] where userCd = sm.creatby) creatBy " +
                                "from hr.salaryMaster sm " +
                                "INNER join hr.empMaster em on em.empCode = sm.empCode " +
                                "where em.statusId = 1 and sm.Status != 2";

            var t = await _db.SalaryMasterDto.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }


        [HttpGet]
        [Route("DeleteSalaryMaster")]
        public async Task<ActionResult<bool>> DeleteSalaryMaster(int id)
        {

            try
            {

                int rowsAffected = 0;


                var existingEntity = await _db.SalaryMaster.FindAsync(id);

                if (existingEntity == null)
                {
                    return false;

                }
                else
                {

                    existingEntity.Status = 2;


                    _db.SalaryMaster.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("saveSalaryPaid")]
        public async Task<ActionResult<bool>> saveSalaryPaid(SalaryPaid salaryPaid)
        {
            try
            {
                int rowsAffected = 0;

                salaryPaid.EditDt = DateTime.Now;
                salaryPaid.CreatDt = DateTime.Now;

                //    var existingEntity = await _db.SalaryPaid.Where(e => e.Date == salaryPaid.Date & e.EmpCode == salaryPaid.EmpCode & e.Type == salaryPaid.Type).FirstOrDefaultAsync();

                //if (existingEntity == null)
                //    {

                _db.SalaryPaid.Add(salaryPaid);
                rowsAffected = await _db.SaveChangesAsync();

                //}
                //else
                //{

                //    existingEntity.EmpCode = salaryPaid.EmpCode;
                //    existingEntity.Payable = salaryPaid.Payable;
                //    existingEntity.Type = salaryPaid.Type;
                //    existingEntity.Totalpaid += salaryPaid.Totalpaid;
                //    existingEntity.PaidDt = salaryPaid.PaidDt;
                //    existingEntity.Due = salaryPaid.Due;
                //    existingEntity.Date = salaryPaid.Date;
                //    existingEntity.PaidBy = salaryPaid.PaidBy;
                //    existingEntity.Paid = salaryPaid.Paid;
                //    existingEntity.EditBy = salaryPaid.EditBy;

                //    _db.SalaryPaid.Update(existingEntity);
                //    rowsAffected = await _db.SaveChangesAsync();
                //}

                if (salaryPaid.Type == 1)
                {

                    var existingSalaryPayable = await _db.SalaryPayable.Where(e => e.Date == salaryPaid.Date & e.EmpCode == salaryPaid.EmpCode).FirstOrDefaultAsync();
                    existingSalaryPayable.due = salaryPaid.Payable - salaryPaid.Totalpaid;
                    _db.SalaryPayable.Update(existingSalaryPayable);
                    rowsAffected = await _db.SaveChangesAsync();

                }
                else if (salaryPaid.Type == 2)
                {

                    var existingLeaveSalary = await _db.LeaveSalary.Where(e => e.Year == salaryPaid.Date.Substring(0, 4) & e.EmpCode == salaryPaid.EmpCode).FirstOrDefaultAsync();
                    existingLeaveSalary.PaidAmt += salaryPaid.Totalpaid;
                    existingLeaveSalary.PendingAmt = salaryPaid.Payable - salaryPaid.Totalpaid;
                    _db.LeaveSalary.Update(existingLeaveSalary);
                    rowsAffected = await _db.SaveChangesAsync();

                }
                else
                {

                    var existingGratuity = await _db.Gratuity.Where(e => e.EmpCode == salaryPaid.EmpCode).FirstOrDefaultAsync();
                    existingGratuity.Paid = true;
                    _db.Gratuity.Update(existingGratuity);
                    rowsAffected = await _db.SaveChangesAsync();

                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("saveQuotation")]
        public async Task<ActionResult<bool>> saveQuotation(QuotationDetail quotationDetail)
        {

            try
            {

                int rowsAffected = 0;


                var existingEntity = await _db.QuotationDetail.FindAsync(quotationDetail.Id);

                if (existingEntity == null)
                {
                    quotationDetail.EditDt = DateTime.Now;
                    quotationDetail.CreatDt = DateTime.Now;


                    _db.QuotationDetail.Add(quotationDetail);
                    rowsAffected = await _db.SaveChangesAsync();

                }
                else
                {

                    existingEntity.ClientId = quotationDetail.ClientId;
                    existingEntity.Narration = quotationDetail.Narration;
                    existingEntity.Name = quotationDetail.Name;
                    existingEntity.Date = quotationDetail.Date;
                    existingEntity.DueDate = quotationDetail.DueDate;
                    existingEntity.PoStatus = quotationDetail.PoStatus;
                    existingEntity.Type = quotationDetail.Type;
                    existingEntity.InvStatus = quotationDetail.InvStatus;
                    existingEntity.InvoiceNo = quotationDetail.InvoiceNo;
                    existingEntity.InvoiceAmt = quotationDetail.InvoiceAmt;
                    existingEntity.ReportNo = quotationDetail.ReportNo;
                    existingEntity.PoNo = quotationDetail.PoNo;
                    existingEntity.PoRefNo = quotationDetail.PoRefNo;
                    existingEntity.EditDt = quotationDetail.EditDt;
                    existingEntity.EditBy = quotationDetail.EditBy;
                    existingEntity.Status = quotationDetail.Status;


                    _db.QuotationDetail.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("DeleteQuotationDetails")]
        public async Task<ActionResult<bool>> DeleteQuotationDetails(int id)
        {

            try
            {

                int rowsAffected = 0;


                var existingEntity = await _db.QuotationDetail.FindAsync(id);

                if (existingEntity == null)
                {
                    return false;

                }
                else
                {

                    existingEntity.Status = 2;


                    _db.QuotationDetail.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        [HttpGet]
        [Route("getQuotationDetails")]
        public async Task<List<QuotationDetailDto>> getQuotationDetails(String clientName, String name, String poStatus, String invStatus, String type)
        {

            string StoredProc = "select quo.id,cld.name ClientName,narration,quo.name,date,invoiceNo,poNo,poRefNo,reportNo,invoiceAmt," +
                                "pos.[description] poStatus,ins.[description] invStatus,qut.[description] type,dueDate,quo.editDt,quo.creatDt," +
                                "(select name from[hr].[user] where userCd = quo.editBy) editBy," +
                                "(select name from[hr].[user] where userCd = ISNULL(quo.creatby, 1)) creatBy from hr.quotationDetails quo " +
                                "INNER JOIN  hr.poStatus pos on pos.id = quo.poStatus " +
                                "INNER JOIN hr.clientDetails cld on cld.id = quo.clientId " +
                                "INNER JOIN  hr.invStatus ins on ins.id = quo.invStatus " +
                                "INNER JOIN hr.quotationType qut on qut.id = quo.[type] " +
                                "where cld.name Like '%" + clientName + "%' and quo.name Like '%" + name + "%' and quo.Status != 2" +
                                "and poStatus Like '%" + poStatus + "%' and invStatus Like '%" + invStatus + "%' and type Like '%" + type + "%'";

            var t = await _db.QuotationDetailDto.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getEmployeeDetails")]
        public async Task<List<EmployeeDetailsDto>> getEmployeeDetails()
        {

            string StoredProc = "SELECT emp.id, emp.empCode, emp.name, emp.mobile1, emp.mobile2, dep.[description] department, " +
                                "stat.[description] status, nat.[description] nationality, emp.birthDt, emp.joinDt, " +
                                "editEmp.[name] editBy, emp.[editDate] editDt, createEmp.[name] createBy, emp.[creatDate] createDt " +
                                "FROM hr.empMaster emp INNER JOIN hr.departmentMaster dep on dep.id = emp.depId " +
                                "INNER JOIN hr.statusMaster stat on stat.id = emp.statusId " +
                                "INNER JOIN hr.nationalityMaster nat on nat.id = emp.natianalityId " +
                                "INNER JOIN hr.empMaster editEmp on editEmp.id = emp.editBy " +
                                "INNER JOIN hr.empMaster createEmp on createEmp.id = emp.creatBy " +
                                "WHERE emp.status != 2";

            var t = await _db.EmployeeDetailsDto.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpPost]
        [Route("saveJobDetail")]
        public async Task<ActionResult<bool>> saveJobDetail(JobDetail jobDetail)
        {

            try
            {

                int rowsAffected = 0;


                var existingEntity = await _db.jobDetail.FindAsync(jobDetail.Id);

                if (existingEntity == null)
                {
                    jobDetail.EditDt = DateTime.Now;
                    jobDetail.CreatDt = DateTime.Now;


                    _db.jobDetail.Add(jobDetail);
                    rowsAffected = await _db.SaveChangesAsync();

                }
                else
                {

                    existingEntity.Job = jobDetail.Job;
                    existingEntity.JobStatus = jobDetail.JobStatus;
                    existingEntity.AssignedDate = jobDetail.AssignedDate;
                    existingEntity.AssignedTo = jobDetail.AssignedTo;
                    existingEntity.DueDate = jobDetail.DueDate;
                    existingEntity.Narration = jobDetail.Narration;
                    existingEntity.EditDt = jobDetail.EditDt;
                    existingEntity.EditBy = jobDetail.EditBy;


                    _db.jobDetail.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("getJobDetails")]
        public async Task<List<JobDetailDto>> getJobDetails(String JobStatus, String AssignedTo, String DueDate)
        {

            string StoredProc = "select jod.id,Job,narration,assignedDate,dueDate,stm.[description] jobStatus,editDt,creatDt ," +
                                "(select name from[hr].[empMaster] where empCode = jod.assignedTo) assignedTo," +
                                "(select name from[hr].[user] where userCd = jod.editBy) editBy," +
                                "(select name from[hr].[user] where userCd = ISNULL(jod.creatby,1)) creatBy " +
                                "from hr.jobDetails jod " +
                                "INNER JOIN hr.statusMaster stm on stm.id = jod.jobStatus " +
                                "where JobStatus Like '%" + JobStatus + "%' and AssignedTo Like '%" + AssignedTo + "%' " +
                                "and DueDate Like '%" + DueDate + "' and Status != 2";

            var t = await _db.jobDetailDto.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }


        [HttpGet]
        [Route("DeleteJobDetails")]
        public async Task<ActionResult<bool>> DeleteJobDetails(int id)
        {

            try
            {

                int rowsAffected = 0;


                var existingEntity = await _db.jobDetail.FindAsync(id);

                if (existingEntity == null)
                {
                    return false;

                }
                else
                {

                    existingEntity.Status = 2;


                    _db.jobDetail.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("getjobStatus")]
        public async Task<ActionResult<List<DocType>>> getjobStatus()
        {
            string StoredProc = "select * from hr.statusMaster";

            var t = await _db.DocType.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }


        [HttpGet]
        [Route("getpoStatus")]
        public async Task<ActionResult<List<DocType>>> getpoStatus()
        {
            string StoredProc = "select * from hr.poStatus";

            var t = await _db.DocType.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }


        [HttpGet]
        [Route("getQuotationType")]
        public async Task<ActionResult<List<DocType>>> getQuotationType()
        {
            string StoredProc = "select * from hr.quotationType";

            var t = await _db.DocType.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getinvStatus")]
        public async Task<ActionResult<List<DocType>>> getinvStatus()
        {
            string StoredProc = "select * from hr.invStatus";

            var t = await _db.DocType.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getDeparments")]
        public async Task<ActionResult<List<DocType>>> getDeparments()
        {
            string StoredProc = "select * from hr.departmentMaster";

            var t = await _db.DocType.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getEmployeeStatuses")]
        public async Task<ActionResult<List<DocType>>> getEmployeeStatuses()
        {
            string StoredProc = "select * from hr.statusMaster";

            var t = await _db.DocType.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getEmployeeNationalities")]
        public async Task<ActionResult<List<DocType>>> getEmployeeNationalities()
        {
            string StoredProc = "select * from hr.nationalityMaster";

            var t = await _db.DocType.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpGet]
        [Route("getGratuityType")]
        public async Task<ActionResult<List<DocType>>> getGratuityType()
        {
            string StoredProc = "select * from hr.gratuityType";

            var t = await _db.DocType.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpPost]
        [Route("saveEmployeeDetails")]
        public async Task<ActionResult<bool>> saveEmployeeDetails(EmpMaster empMaster)
        {

            try
            {

                int rowsAffected = 0;
                empMaster.EditDate = DateTime.Now;


                var existingEntity = await _db.EmpMaster.FindAsync(empMaster.Id);

                if (existingEntity == null)
                {
                    empMaster.CreatDate = DateTime.Now;


                    _db.EmpMaster.Add(empMaster);
                    rowsAffected = await _db.SaveChangesAsync();

                }
                else
                {

                    existingEntity.EmpCode = empMaster.EmpCode;
                    existingEntity.Name = empMaster.Name;
                    existingEntity.Mobile1 = empMaster.Mobile1;
                    existingEntity.Mobile2 = empMaster.Mobile2;
                    existingEntity.DepId = empMaster.DepId;
                    existingEntity.NatianalityId = empMaster.NatianalityId;
                    existingEntity.StatusId = empMaster.StatusId;
                    existingEntity.JoinDt = empMaster.JoinDt;
                    existingEntity.BirthDt = empMaster.BirthDt;
                    existingEntity.EditBy = empMaster.EditBy;
                    existingEntity.EditDate = empMaster.EditDate;
                    existingEntity.Status = empMaster.Status;


                    _db.EmpMaster.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("DeleteEmployeeDetails")]
        public async Task<ActionResult<bool>> DeleteEmployeeDetails(int id)
        {

            try
            {

                int rowsAffected = 0;


                var existingEntity = await _db.EmpMaster.FindAsync(id);

                if (existingEntity == null)
                {
                    return false;

                }
                else
                {

                    existingEntity.Status = 2;


                    _db.EmpMaster.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("getClientDetails")]
        public async Task<ActionResult<List<ClientDetails>>> getClientDetails()
        {
            string StoredProc = "select * from hr.clientDetails where status != 2";

            var t = await _db.ClientDetails.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }

        [HttpPost]
        [Route("saveClientDetails")]
        public async Task<ActionResult<bool>> saveClientDetails(ClientDetails clientDetails)
        {

            try
            {
                int rowsAffected = 0;
                var existingEntity = await _db.ClientDetails.FindAsync(clientDetails.Id);
                if (existingEntity == null)
                {
                    clientDetails.EditDt = DateTime.Now;
                    clientDetails.CreatDt = DateTime.Now;
                    _db.ClientDetails.Add(clientDetails);
                    rowsAffected = await _db.SaveChangesAsync();

                }
                else
                {
                    existingEntity.Name = clientDetails.Name;
                    existingEntity.Address = clientDetails.Address;
                    existingEntity.Mobile1 = clientDetails.Mobile1;
                    existingEntity.Mobile2 = clientDetails.Mobile2;
                    existingEntity.EditBy = clientDetails.EditBy;
                    existingEntity.EditDt = clientDetails.EditDt;
                    existingEntity.Status = clientDetails.Status;
                    _db.ClientDetails.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }
                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("DeleteClientDetails")]
        public async Task<ActionResult<bool>> DeleteClientDetails(int id)
        {

            try
            {

                int rowsAffected = 0;


                var existingEntity = await _db.ClientDetails.FindAsync(id);

                if (existingEntity == null)
                {
                    return false;

                }
                else
                {

                    existingEntity.Status = 2;


                    _db.ClientDetails.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("SaveGratuity")]
        public async Task<ActionResult<bool>> SaveGratuity(short empCode, byte type, short editBy)
        {

            Gratuity gratuity = new();

            try
            {
                int rowsAffected = 0;

                string StoredProc = "select sum(attendance + offdays) ServedDays from hr.attendance where empCode = '" + empCode + "'";

                var salaryMaster = await _db.SalaryMaster.Where(e => e.EmpCode == empCode).FirstOrDefaultAsync();

                var ServedDays = await _db.ServedDaysDto.FromSqlRaw(StoredProc).ToListAsync();

                gratuity.EmpCode = empCode;
                gratuity.ServedYears = ServedDays[0].ServedDays / 360;
                gratuity.Type = type;
                gratuity.EditBy = editBy;
                gratuity.CreatBy = editBy;
                gratuity.EditDate = DateTime.Now;
                gratuity.CreatDate = DateTime.Now;
                gratuity.Paid = false;

                //decimal DaySalary = salaryMaster.Salary / 21;
                decimal dailySalary = salaryMaster.Salary / ServedDays[0].ServedDays;
                decimal twentyOneDaySalary = dailySalary * 21;

                if (type == 1)
                {
                    if (gratuity.ServedYears > 1 & gratuity.ServedYears < 5)
                    {

                        gratuity.GratuityAmt = twentyOneDaySalary * gratuity.ServedYears;

                    }
                    else if (gratuity.ServedYears > 5)
                    {

                        gratuity.GratuityAmt = twentyOneDaySalary * 2;

                        gratuity.GratuityAmt = gratuity.GratuityAmt + ((dailySalary * 30) * gratuity.ServedYears - 5);

                    }
                }
                else if (type == 2)
                {
                    if (gratuity.ServedYears > 1 & gratuity.ServedYears < 5)
                    {

                        gratuity.GratuityAmt = twentyOneDaySalary * gratuity.ServedYears;

                    }
                    else if (gratuity.ServedYears > 5)
                    {

                        gratuity.GratuityAmt = twentyOneDaySalary * 2;

                        gratuity.GratuityAmt = gratuity.GratuityAmt + ((dailySalary * 30) * gratuity.ServedYears - 5);

                    }
                }
                else if (type == 3)
                {
                    if (gratuity.ServedYears > 1 & gratuity.ServedYears < 3)
                    {

                        gratuity.GratuityAmt = twentyOneDaySalary / 3;

                    }
                    else if (gratuity.ServedYears > 3 & gratuity.ServedYears < 5)
                    {

                        gratuity.GratuityAmt = twentyOneDaySalary * (2 / 3);

                    }
                    else if (gratuity.ServedYears > 5)
                    {
                        gratuity.GratuityAmt = twentyOneDaySalary;

                    }

                }

                var existingEntity = await _db.Gratuity.Where(e => e.EmpCode == empCode).FirstOrDefaultAsync();

                if (existingEntity != null)
                {

                    existingEntity.EditDate = DateTime.Now;
                    existingEntity.EditBy = editBy;
                    existingEntity.Type = type;
                    existingEntity.GratuityAmt = gratuity.GratuityAmt;
                    existingEntity.ServedYears = gratuity.ServedYears;
                    _db.Gratuity.Update(existingEntity);
                    rowsAffected = await _db.SaveChangesAsync();
                }
                else
                {
                    _db.Gratuity.Add(gratuity);
                    rowsAffected = await _db.SaveChangesAsync();
                }


                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        [HttpGet]
        [Route("getGratuityDetails")]
        public async Task<List<GratuityDetailsDto>> getGratuityDetails()
        {

            string StoredProc = "select grt.id,grt.empCode,emp.name,servedYears,gtp.description type,gratuityAmt,grt.editDate,Paid," +
                                "grt.creatDate,(select name from [hr].[user] where userCd = grt.editBy) editBy," +
                                "(select name from [hr].[user] where userCd = grt.creatby) creatBy from [hr].[gratuity] grt  " +
                                "inner join hr.empMaster emp on emp.empCode = grt.empcode " +
                                "inner join hr.gratuityType gtp on gtp.id = grt.type";

            var t = await _db.GratuityDetailsDto.FromSqlRaw(StoredProc).ToListAsync();

            return t;

        }



    }
}
