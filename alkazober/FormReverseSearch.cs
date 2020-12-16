using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alkazober
{
    public partial class FormReverseSearch : Form
    {
        private DataTable dtTempStandard, dtToP;
        public FormReverseSearch()
        {
            InitializeComponent();
             

        }

        private String getZone(String designation)
        {
            String result = "-";
            String sql = "";
            DBQuery dbq = new DBQuery();

            sql = "select * from typeofprotection where designation='" + designation + "'";
            dbq.GetConn().Open();
            System.Data.OleDb.OleDbDataReader dtreader =  dbq.ExecuteReader(sql);
            if (dtreader.Read())
            {
                
                result = dtreader.GetString(3);
            }
                    
           
            dbq.CloseConn();
            return result;

        }

        private String getTemp(String class_temp)
        {
            String result = "-";
            String sql = "";
            DBQuery dbq = new DBQuery();

            sql = "select * from tempstandard where temp_class='" + class_temp + "'";
            dbq.GetConn().Open();
            System.Data.OleDb.OleDbDataReader dtreader = dbq.ExecuteReader(sql);
            if (dtreader.Read())
            {

                result = dtreader.GetInt16(1).ToString();
            }


            dbq.CloseConn();
            return result;

        }



        private void btnCekToP_Click(object sender, EventArgs e)
        {
            lblZone.Text = getZone(txtDesignation.Text);
        }

        private void btnCekTempStandard_Click(object sender, EventArgs e)
        {
            lblTemp.Text = getTemp(txtClassTemp.Text);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
