﻿using CodeAnalyzeMVC2015.Areas.Demo.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace CodeAnalyzeMVC2015.Areas.Demo.Controllers
{
    public class CodeController : Controller
    {
        //
        // GET: /CodeDemos/

        public ActionResult Articles(string strId)
        {
            string articleId = string.Empty;
            if (RouteData.Values.Count > 0 && RouteData.Values["Id"] != null)
            {
                articleId = RouteData.Values["Id"].ToString();
            }
            else
            {
                articleId = strId;
            }

            if (articleId.Equals("20185"))
            {
                return GetEmployees(0);
            }
             if (articleId.Equals("20186"))
            {
                List<SelectListItem> items = GetItems20186();

                return View("../Code/" + articleId, items);
            }
            else
            {
                return View("../Code/" + articleId);
            }
            //return View(articleId);
        }
        
        #region 20183
        [HttpPost]
        public ActionResult Save()
        {
            //string strEMail = Request.Form["hfUserEMail1"];
            ViewBag.DemoMessage = "Data saved";
            return View("20183");
        }

        [HttpPost]
        public ActionResult Cancel()
        {
            //string strEMail = Request.Form["hfUserEMail1"];
            ViewBag.DemoMessage = "Action cancelled";
            string articleId = ViewBag.ArticleId;
            return View("20183");
        }
        #endregion
        
        
        #region 20184
        [HttpPost]
        public ActionResult DynamicTextBox(string[] txtBoxes)
        {
            string txtBoxValues = "";
            foreach (string textboxValue in txtBoxes)
            {
                txtBoxValues += textboxValue + ", ";
            }
            ViewBag.DemoMessage = txtBoxValues;

            string articleId = string.Empty;
            if (RouteData.Values.Count > 0 && RouteData.Values["Id"] != null)
            {
                articleId = RouteData.Values["Id"].ToString();
            }

            return Articles("20184");
        }
        #endregion
      
        #region 20185
        public const int RecordsPerPage = 5;
        public List<Employee> EmployeeData;


        public ActionResult GetEmployees(int? pageNum)
        {
            pageNum = pageNum ?? 0;
            ViewBag.IsEndOfRecords = false;
            if (Request.IsAjaxRequest())
            {
                var employees = GetRecordsForPage(pageNum.Value);
                ViewBag.IsEndOfRecords = (employees.Any());
                return PartialView("_EmployeeData", employees);
            }
            else
            {
                EmployeeData = GetEmployeeList();

                ViewBag.TotalNumberEmployees = EmployeeData.Count;
                ViewBag.Employees = GetRecordsForPage(pageNum.Value);

                return View("20185");
            }
        }

        public List<Employee> GetRecordsForPage(int pageNum)
        {
            EmployeeData = GetEmployeeList();
            int fromRecords = (pageNum * RecordsPerPage);
            var tempList = (from rec in EmployeeData select rec).Skip(fromRecords).Take(20).ToList<Employee>();
            return tempList;
        }


        public List<Employee> GetEmployeeList()
        {
            //string employeeFile = HostingEnvironment.MapPath("~/App_Data/Employees.txt");
            List<Employee> tempList = new List<Employee>();
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));
            tempList.Add(new Employee("1000", "Employee-1000"));
            tempList.Add(new Employee("1001", "Employee-1001"));
            tempList.Add(new Employee("1002", "Employee-1002"));
            tempList.Add(new Employee("1073", "Employee-1073"));
            tempList.Add(new Employee("1074", "Employee-1074"));


            return tempList;
        }
        #endregion

        #region 20186

        public ActionResult Post20186(FormCollection form)
        {
            string lbEmp = form["lbEmp"];
            ViewBag.Message += lbEmp;
            List<SelectListItem> items = GetItems20186();
            return View("../Code/20186", items);
        }

        private static List<SelectListItem> GetItems20186()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem
            {
                Text = "Microsoft",
                Value = "1"
            });

            items.Add(new SelectListItem
            {
                Text = "Apple",
                Value = "2"
            });

            items.Add(new SelectListItem
            {
                Text = "IBM",
                Value = "3"
            });

            items.Add(new SelectListItem
            {
                Text = "Oracle",
                Value = "4"
            });

            items.Add(new SelectListItem
            {
                Text = "Google",
                Value = "5"
            });
            return items;
        }



        #endregion

        #region 20187
        [HttpPost]
        public ActionResult Charts_ASPNET_MVC(string[] txtBoxes)
        {
            if (Request.Form["BarChart"] != null)
            {
                ViewBag.Message = "Bar";
            }

            if (Request.Form["PieChart"] != null)
            {
                ViewBag.Message = "Pie";
            }

            if (Request.Form["LineChart"] != null)
            {
                ViewBag.Message = "Line";
            }


            return Articles("20187");
        }
        #endregion

        #region 20189
        [HttpPost]
        public ActionResult AlertConfirmation(string hiddenValue)
        {
            if (hiddenValue == "Yes")
            {
                ViewBag.Message = "OK";
            }
            else
            {
                ViewBag.Message = "Cancel";
            }

            return View("20189");
        }
        #endregion

    }



}
