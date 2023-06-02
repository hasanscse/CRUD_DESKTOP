using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.BIZ.MODEL.BRAND
{
    public class BRAND
    {
        public int BRAND_ID { get; set; } 
        public string BRAND_NAME { get; set; }
        public int COMPANY_ID { get; set; }
        public int BRANCH_ID { get; set; }
        public int ACTIVE_STATUS { get; set; }
        public string STATUS { get; set; }
    }
}
