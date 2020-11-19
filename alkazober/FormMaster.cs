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
    public partial class FormMaster : Form
    {
        public FormMaster()
        {
            InitializeComponent();
        }

        private void saveUser(String username,String password)
        {
            String sql = "insert into user (username,password)values('" + username + "','" + password + "')";
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void updateUser(String username, String password,String id)
        {
            String sql = "update user set username ='" + username + "',password='" + password + "' where user_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void deleteUser(String id)
        {
            String sql = "delete from user where user_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void saveProduct(String nmproduk, String suhu)
        {
            String sql = "insert into produk (nm_produk,suhu)values('" + nmproduk + "'," + suhu + ")";
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void updateProduct(String nmproduk, String suhu, String id)
        {
            String sql = "update produk set nm_produk ='" + nmproduk + "',suhu='" + suhu + "' where produk_id=" + id ;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void deleteProduct(String id)
        {
            String sql = "delete from produk where produk_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void saveMaterial(String nmmaterial, String deskripsi)
        {
            String sql = "insert into material (nm_material,deskripsi)values('" + nmmaterial + "'," + deskripsi + ")";
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void updateMaterial(String nmmaterial, String deskripsi, String id)
        {
            String sql = "update material set nm_material ='" + nmmaterial + "',deskripsi='" + deskripsi + "' where material_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void deleteMaterial(String id)
        {
            String sql = "delete from material where material_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }



        private void saveTempStandard(String tempc, String tempf,String tempclass)
        {
            String sql = "insert into tempstandard (temp_c,temp_f,temp_class)values(" + tempc + "," + tempf + ",'" + tempclass + "')";
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void updateTempStandard(String tempc, String tempf, String tempclass,String id)
        {
            String sql = "update tempstandard set temp_c =" + tempc + ",temp_f=" + tempf + ",temp_class='" +  tempclass + "' where tempstandard_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void deleteTempStandard(String id)
        {
            String sql = "delete from tempstandard where tempstandard_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }


        private void saveTypeOfProtection(String designation, String technique, String zone)
        {
            String sql = "insert into typeofprotection (designation,technique,zone)values('" + designation + "','" + technique + "'," + zone + ")";
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void updateTypeOfProtection(String designation, String technique, String zone, String id)
        {
            String sql = "update typeofprotection set designation =" + designation + ",technique=" + technique + ",zone=" + zone + " where topd_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void deleteTypeofProtection(String id)
        {
            String sql = "delete from typeofprotection where topd_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSimpanUser_Click(object sender, EventArgs e)
        {

        }
    }
}
