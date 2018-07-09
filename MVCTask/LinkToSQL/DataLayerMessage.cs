using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTask.LinkToSQL
{
   public class DataLayerMessage
   {
      public bool Vaild { get; set; }
      public string ErrorMessage { get; set; }
      public int Rows { get; set; }
   }
}