using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASLibrary
{
    static class DB
    {
        private static DBConnection db;

        static DB()
        {
            db = DBConnection.Instance;
        }
    }
}
