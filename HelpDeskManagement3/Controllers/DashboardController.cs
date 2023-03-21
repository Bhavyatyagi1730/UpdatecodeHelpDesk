using Model;
using Service.Class;
using Service.Entities;
using Service.Interface;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace HelpDeskManagement3.Controllers
{
    public class DashboardController : Controller
    {
        ICreateUser _CreateUser = null;
        public DashboardController()
        {
            _CreateUser = new CreateUser();
        }
        // GET: Dashboard
        HelpdeskEntities admin = new HelpdeskEntities();

        public ActionResult ShowAdminDashboard()
        {
            return View();
        }

        public ActionResult Showticketstable()
        {
            var data = admin.TicketTables.ToList();
            return View(data);
        }

        public ActionResult EditTickets(int id)
        {
            ViewBag.dptdata = admin.Departments.ToList();
            var ticketdata = admin.TicketTables.Where(model => model.Ticket_Id == id).FirstOrDefault();
            return View(ticketdata);
        }

        [HttpPost]

        public ActionResult EditTickets(TicketTable t)
        {
            int deptId = Convert.ToInt32(t.Dept_List);
            var department = admin.Departments.Where(m => m.Dep_ID==deptId).FirstOrDefault();

            t.Dept_List = department.Dept_Desc;
            t.Dep_ID = department.Dep_ID;

            admin.TicketTables.Add(t);
            admin.Entry(t).State = EntityState.Modified;
            int a = admin.SaveChanges();
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Updated !!)</script>";
                return RedirectToAction("Showticketstable");
            }
            else if(a <= 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Not Updated !!)</script>";
            }
            return View();
        }

        public ActionResult ShowUser()
        {
            string message = TempData["AdminUpdate"] as string;
            ViewBag.Message = message;

            var data = admin.UserTables.ToList();
            return View(data);
            //var people = _CreateUser.GetAllUser();
            //return View(people);
        }
        public ActionResult Create()
        {
            ViewBag.dpt = admin.Departments.ToList();
            ViewBag.role = admin.RoleTypes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserTable newUser)
        {

            if (ModelState.IsValid == true)
            {
                //_CreateUser.AddUser(newUser);
                //var roleType = admin.RoleTypes.Where(m => m.RoleTypeID == newUser.RoleTypeID).FirstOrDefault();

                //newUser.Roletype = roleType.RoleType_Disc;

                admin.UserTables.Add(newUser);
                int a = admin.SaveChanges();
                if (a > 0)
                {
                    Session["InsertMessage"] = "<script>alert('Inserted !!)</script>";
                    //ViewBag.Message = "Action submitted successfully!";
                    return RedirectToAction("ShowAdminDashboard");
                }
                else
                {
                    Session["InsertMessage"] = "<script>alert('not inserted !!)</script>";

                }

            }



            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.role = admin.RoleTypes.ToList();
            var row = admin.UserTables.Where(model => model.Id == id).FirstOrDefault();
            //var row = _CreateUser.GetUserById(id);

            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(UserTable newUser)
        {
            if (ModelState.IsValid == true)
            {
                //_CreateUser.UpdateUser(newUser);
                //var roleType = admin.RoleTypes.Where(m => m.RoleTypeID == newUser.RoleTypeID).FirstOrDefault();

                //newUser.Roletype = roleType.RoleType_Disc;

                //admin.UserTables.Add(newUser);
                admin.Entry(newUser).State = EntityState.Modified;
                int a = admin.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Updated !!)</script>";
                    return RedirectToAction("ShowUser");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Not Updated !!)</script>";
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var Deleterow = admin.UserTables.Where(model => model.Id == id).FirstOrDefault();

            return View(Deleterow);
        }
        [HttpPost]
        public ActionResult Delete(UserTable deleteUser)
        {
            admin.Entry(deleteUser).State = EntityState.Deleted;
            int a = admin.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Data is Deleted !!)</script>";
                return RedirectToAction("ShowUser");
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Not Deleted !!)</script>";
            }


            return View();
        }




        public ActionResult TicketDelete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TicketDelete(int id)
        {
            var product = admin.TicketTables.Find(id);

            admin.TicketTables.Remove(product);
            int a = admin.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Data is Deleted !!)</script>";
                return RedirectToAction("Showticketstable");
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Not Deleted !!)</script>";
            }


            return View();
        }

     
    }
}