using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProgramlamaProje_Deneme1.Models;

namespace WebProgramlamaProje_Deneme1.Controllers
{
    public class UserController : Controller
    {
        INewService newService = new NewsManager(new EfNewsDal());
        IBranchService branchService = new BranchManager(new EfBranchDal());
        IUserService userService = new UserManager(new EfUserDal(), new EfBasketDal());
        IAdminService adminService = new AdminManager(new EfAdminDal());
        // GET: UserController
        public ActionResult Index()
        {

            indexData d = new indexData
            {
                News = newService.GetAll().Data,
                Branches = branchService.GetAll().Data
            };

            return View(d);
        }

        public ActionResult Giris(string Email, string Password)
        {
            if (userService.GetByMail(Email).Success)
            {
                if (userService.GetByMail(Email).Data.Password == Password)
                {
                    HttpContext.Session.SetInt32("IsAdmin", 0);
                    HttpContext.Session.SetString("Mail", Email);
                    return RedirectToAction("Index");
                }
            }
            
            if(adminService.GetByMail(Email).Success)
            {
                if (adminService.GetByMail(Email).Data.Password == Password)
                {
                    HttpContext.Session.SetInt32("IsAdmin", 1);
                    HttpContext.Session.SetString("Mail", Email);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult KayitOl()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KayitOlRes(string Name, string Email, string PhoneNumber, string Password, string P2)
        {
            userService.Add(new User {Name = Name, Email = Email, Password = Password, PhoneNumber = PhoneNumber, Basket = new Basket() });
            HttpContext.Session.SetInt32("IsAdmin", 0);
            HttpContext.Session.SetString("Mail", Email);
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Haber(int id)
        {
            if (newService.GetById(id).Success)
            {
                return View(newService.GetById(id).Data);
            }
            return RedirectToAction("Index");
        }

        public ActionResult CarList()
        {
            return View();
        }

        public ActionResult ContUs()
        {
            return View();
        }

        /*
        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
