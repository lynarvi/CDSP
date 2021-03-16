using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDSP.Class
{
    class SqlConnection
    {
        public String connection()
        {
            String conString = "datasource=localhost;port=3306;username=root;password=;database=cdsp";
            return conString;
        }
    }
}
