using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTask.LinkToSQL;

namespace MVCTask.ViewModels
{
   public class EditViewModel
   {
      public user EditUser { set; get; }

      public List<SelectListItem> DeptDropDownLsit { get; set; }
   }
}