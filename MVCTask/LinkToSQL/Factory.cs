using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTask.ViewModels;

namespace MVCTask.LinkToSQL
{
   public class Factory {
      private MVCEntities mvcDB = new MVCEntities();

      public List<user> GetUserList() {
         return mvcDB.users.ToList();
      }

      public user GetUser(int id) {
         return mvcDB.users.Where(u => u.user_id == id).SingleOrDefault();
      }

      public dept GetDept(int id) {
         return mvcDB.depts.Where(u => u.dept_id == id).SingleOrDefault();
      }

      public DataLayerMessage EditUser(user userEntry) {
         DataLayerMessage msg = new DataLayerMessage();
         msg.Vaild = false;

         try {
            user userEntity = mvcDB.users.Where(u => u.user_id == userEntry.user_id).SingleOrDefault();
            userEntity = userEntry;

            msg.Rows = mvcDB.SaveChanges();

            if (msg.Rows == 1) {
               msg.Vaild = true;
            }
         }
         catch (Exception ex) {
            msg.ErrorMessage = ex.Message;
         }

         return msg;
      }

      public List<SelectListItem> GenDeptList() {
         List<SelectListItem> deptList = mvcDB.depts.Select(u => new SelectListItem() {
            Text = u.dept_name,
            Value = u.dept_id.ToString()
         }).ToList();

         return deptList;
      } 
   }
}