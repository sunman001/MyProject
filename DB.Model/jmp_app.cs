using MyAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model
{
   public  class jmp_app
    {
        public jmp_app ()
            {
             a_showurl = "";
            }
        [Column(PrimaryKey =true,AutoIncrement =true,Name="应用ID")]
        public int a_id { get; set; }
        public int a_user_id { get; set; }
        public string a_name { get; set; }
        public int a_platform_id { get; set; }
        public string  a_paymode_id { get; set; }
        public string a_notifyurl { get; set; }
        public string a_key { get; set; }
        public int a_state { get; set; }
        public int a_auditstate { get; set; }
        public string a_secretkey { get; set; }

        public DateTime a_time { get; set; }
     
        public string a_showurl { get;set ; }

        public string a_auditor { get; set; }
        public int a_rid { get; set; }
        public string a_appurl { get; set; }
        public string a_appsynopsis { get; set; }
    }
}
