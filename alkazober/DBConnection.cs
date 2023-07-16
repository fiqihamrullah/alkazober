using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alkazober
{
    class DBConnection
    {
        OleDbConnection oledbConn;

        public DBConnection()
        {
          
            oledbConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/alkazober.accdb"   );
        }


        public void Open()
        {
            oledbConn.Open();
        }

        public void Close()
        {
            oledbConn.Close();
        }

        public OleDbConnection GetConnection()
        {
            return oledbConn;
        }


    }
}
