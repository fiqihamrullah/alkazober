using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace alkazober
{
    class DBQuery
    {
        private DBConnection dbConn;
        private DataTable dttbl;

        public DBQuery()
        {
            dbConn = new DBConnection();
        }

        public void ExecuteSQL(String sql)
        {
            dbConn.Open();
            OleDbCommand oledbCommand = new OleDbCommand(sql, dbConn.GetConnection());
            oledbCommand.ExecuteNonQuery();
            dbConn.Close();
        }

        public OleDbDataReader ExecuteReader(String sql)
        {
           
            OleDbDataReader oledbDataReader;
            OleDbCommand oledbCommand;
            oledbCommand = new OleDbCommand(sql, dbConn.GetConnection());
            oledbDataReader = oledbCommand.ExecuteReader();
            return oledbDataReader; 

        }

        public void FillTableBySQL(String sql)
        {
            dttbl = new DataTable();
            dbConn.Open();
            OleDbCommand oledbCommand = new OleDbCommand(sql, dbConn.GetConnection());
            OleDbDataAdapter oledbDataAdapter = new OleDbDataAdapter(oledbCommand);
            oledbDataAdapter.Fill(dttbl);
            dbConn.Close();
        }

        public DataTable GetTable()
        {
            return dttbl;
        }

        public DBConnection GetConn()
        {
            return dbConn;
        }

        public void CloseConn()
        {
            dbConn.Close();
        }
             


         
    }
}
