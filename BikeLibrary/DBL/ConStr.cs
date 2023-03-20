using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeClassLibrary.DBL
{
    public class ConStr
    {
        private const string connStr = "Data Source=mssqlstud.fhict.local; Initial Catalog=dbi507644_managestu;User ID=dbi507644_managestu;Password=Otilia_1995";
        public ConStr()
        { 
        }

        public string GetConnectionString()
        {
            return connStr;
        }
    }
}
