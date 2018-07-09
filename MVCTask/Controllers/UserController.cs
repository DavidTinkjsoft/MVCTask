using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTask.ViewModels;
using MVCTask.LinkToSQL;

namespace MVCTask.Controllers
{
    public class UserController : Controller
    {
      private Factory Factory = new Factory();

      // GET: User
      public ActionResult Index() {
         UserViewModel vm = new UserViewModel();
         vm.userList = Factory.GetUserList();

         return View(vm);
      }

      // GET: User/Create
      public ActionResult Create() {
         EditViewModel vm = new EditViewModel();
         vm.DeptDropDownLsit = Factory.GenDeptList();

         return View("Edit", vm);
      }

      // POST: User/Create
      [HttpPost]
      public ActionResult Create(EditViewModel vm) {
         vm.DeptDropDownLsit = Factory.GenDeptList();
         try {
            vm.EditUser.update_date = DateTime.Now;

            DataLayerMessage msg = Factory.CreateUser(vm.EditUser);

            if (msg.Vaild) {
               return RedirectToAction("Index");
            }
            else {
               return View(vm);
            }
         }
         catch {
            return View(vm);
         }
      }

      // GET: User/Edit/5
      public ActionResult Edit(int id) {
         EditViewModel vm = new EditViewModel();
         vm.EditUser = Factory.GetUser(id);
         vm.DeptDropDownLsit = Factory.GenDeptList();

         return View(vm);
      }

      // POST: User/Edit/5
      [HttpPost]
      public ActionResult Edit(EditViewModel vm) {
         vm.DeptDropDownLsit = Factory.GenDeptList();

         try {
            user editEntry = Factory.GetUser(vm.EditUser.user_id);
            editEntry.user_name = vm.EditUser.user_name;
            editEntry.dept_id = vm.EditUser.dept_id;
            editEntry.update_date = DateTime.Now;

            DataLayerMessage msg = Factory.EditUser(editEntry);
            if (msg.Vaild) {
               return RedirectToAction("Index");
            }
            else {
               return View(vm);
            }
         }
         catch {
            return View(vm);
         }
      }

        // GET: User/Delete/5
        public ActionResult Delete(int userid)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
