﻿using System;
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
        private BindingSource bsProduct, bsMaterial, bsTempStandard, bsToP, bsUser;
        private const int MODE_SIMPAN = 0;
        private const int MODE_UPDATE = 1;
        private int mode;


        public FormMaster()
        {
            InitializeComponent();

            bsUser = new BindingSource();
            bsProduct = new BindingSource();
            bsMaterial = new BindingSource();
            bsTempStandard = new BindingSource();
            bsToP = new BindingSource();

            cmbZone.SelectedIndex = 0;


            loadUser();
            loadProduct();
            loadMaterial();
            loadTempStandard();
            loadToP();
            mode = MODE_SIMPAN;
        }

        private void clearProduct()
        {
            txtNmProduk.Text = "";
            txtSuhu.Text = "";
            mode = MODE_SIMPAN;
        }

        private void clearMaterial()
        {
            txtMaterial.Text = "";
            txtDeskripsi.Text = "";
            mode = MODE_SIMPAN;
        }

        private void clearTempStandard()
        {
            txtTemp_C.Text = "";
            txtTemp_F.Text = "";
            txtTemp_Class.Text = "";
            mode = MODE_SIMPAN;
        }

        private void clearTypeOfProtection()
        {
            txtDesignation.Text = "";
            txtTechnique.Text = "";
            mode = MODE_SIMPAN;

        }

        private void clearUser()
        {
            txtNmAdmin.Text = "";
            txtKataSandi.Text = "";
            mode = MODE_SIMPAN;
        }

        private void loadUser()
        {
            DBQuery dbq = new DBQuery();
            dbq.FillTableBySQL("select * from `user`");
            bsUser.DataSource = dbq.GetTable();
            dgvUser.DataSource = bsUser;
        }

        private void loadProduct()
        {
            DBQuery dbq = new DBQuery();
            dbq.FillTableBySQL("select * from produk");
            bsProduct.DataSource = dbq.GetTable();
            dgvProduk.DataSource = bsProduct;
        }

        private void loadMaterial()
        {
            DBQuery dbq = new DBQuery();
            dbq.FillTableBySQL("select * from material");
            bsMaterial.DataSource = dbq.GetTable();
            dgvMaterial.DataSource = bsMaterial;
        }

        private void loadTempStandard()
        {
            DBQuery dbq = new DBQuery();
            dbq.FillTableBySQL("select * from tempstandard");
            bsTempStandard.DataSource = dbq.GetTable();
            dgvTempStandard.DataSource = bsTempStandard;
        }


        private void loadToP()
        {
            DBQuery dbq = new DBQuery();
            dbq.FillTableBySQL("select * from typeofprotection");
            bsToP.DataSource = dbq.GetTable();
            dgvToPD.DataSource = bsToP;
        }





        private void saveUser(String username,String password)
        {
            String sql = "insert into `user` (`username`,`password`)values('" + username + "','" + password + "')";
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void updateUser(String username, String password,String id)
        {
            String sql = "update `user` set `username` ='" + username + "',`password`='" + password + "' where user_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void deleteUser(String id)
        {
            String sql = "delete from `user` where user_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void saveProduct(String nmproduk, String suhu)
        {
            String sql = "insert into produk (nm_produk,suhu)values('" + nmproduk + "','" + suhu + "')";
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
            String sql = "insert into material (nm_material,deskripsi)values('" + nmmaterial + "','" + deskripsi + "')";
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
            String sql = "insert into typeofprotection (designation,technique,`zone`)values('" + designation + "','" + technique + "','" + zone + "')";
           // MessageBox.Show(sql);
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void updateTypeOfProtection(String designation, String technique, String zone, String id)
        {
            String sql = "update typeofprotection set designation ='" + designation + "',technique='" + technique + "',`zone`='" + zone + "' where topd_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void deleteTypeofProtection(String id)
        {
            String sql = "delete from typeofprotection where topd_id=" + id;
            DBQuery dbQ = new DBQuery();
            dbQ.ExecuteSQL(sql);
        }

        private void btnSimpanProduk_Click(object sender, EventArgs e)
        {
            String nmproduk = txtNmProduk.Text;
            String suhu = txtSuhu.Text;
            if (nmproduk != "" && suhu != "")
            {
                if (mode == MODE_SIMPAN)
                {
                    saveProduct(nmproduk, suhu);
                }else
                {
                    updateProduct(nmproduk, suhu, dgvProduk.CurrentRow.Cells[0].Value.ToString());
                }

                MessageBox.Show("Data Produk disimpan!!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearProduct();
                loadProduct();
            }else
            {
                MessageBox.Show("Lengkapi Terlebih dahulu!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnSimpanMaterial_Click(object sender, EventArgs e)
        {
            String nmmaterial = txtMaterial.Text;
            String deskripsi = txtDeskripsi.Text;
            if (nmmaterial != "" && deskripsi != "")
            {
                if (mode == MODE_SIMPAN)
                {
                    saveMaterial(nmmaterial, deskripsi);
                }
                else
                {
                    updateMaterial(nmmaterial, deskripsi, dgvMaterial.CurrentRow.Cells[0].Value.ToString());
                }

                MessageBox.Show("Data Material disimpan!!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearMaterial();
                loadMaterial();
            }else
            {
                MessageBox.Show("Lengkapi Terlebih dahulu!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnHapusMaterial_Click(object sender, EventArgs e)
        {
            DialogResult res;

            res = MessageBox.Show("Apakah Anda yakin akan menghapus data tersebut?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                deleteMaterial(dgvMaterial.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Data Berhasil Dihapus!!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadMaterial();
            }
        }

        private void btnSimpanTempStandard_Click(object sender, EventArgs e)
        {
            String tempc = txtTemp_C.Text;
            String tempf = txtTemp_F.Text;
            String tempClass = txtTemp_Class.Text;

            if (tempc != "" && tempf != "" && tempClass != "")
            {
                if (mode == MODE_SIMPAN)
                {
                    saveTempStandard(tempc, tempf, tempClass);
                }
                else
                {
                    updateTempStandard(tempc, tempf, tempClass,dgvTempStandard.CurrentRow.Cells[0].Value.ToString());
                }

                MessageBox.Show("Data Temperatur Standard disimpan!!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearTempStandard();
                loadTempStandard();
            }else
            {
                MessageBox.Show("Lengkapi Terlebih dahulu!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnHapusTempStandard_Click(object sender, EventArgs e)
        {
            DialogResult res;

            res = MessageBox.Show("Apakah Anda yakin akan menghapus data tersebut?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                deleteTempStandard(dgvTempStandard.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Data Berhasil Dihapus!!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTempStandard();
            }
        }

        private void btnSimpanToPD_Click(object sender, EventArgs e)
        {
            String designation = txtDesignation.Text;
            String technique = txtTechnique.Text;
            String zone = cmbZone.SelectedItem.ToString();

            if (designation != "" && technique != "")
            {
                if (mode == MODE_SIMPAN)
                {
                    saveTypeOfProtection(designation, technique, zone);
                }else
                {
                    updateTypeOfProtection(designation, technique, zone, dgvToPD.CurrentRow.Cells[0].Value.ToString());
                }

                MessageBox.Show("Data Type of Protection disimpan!!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearTypeOfProtection();
                loadToP();
            }else
            {
                MessageBox.Show("Lengkapi Terlebih dahulu!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHapusUser_Click(object sender, EventArgs e)
        {
            DialogResult res;

            res = MessageBox.Show("Apakah Anda yakin akan menghapus data tersebut?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                deleteUser(dgvUser.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Data Berhasil Dihapus!!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadUser();
            }
        }

        private void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNmProduk.Text = dgvProduk.CurrentRow.Cells[1].Value.ToString();
            txtSuhu.Text = dgvProduk.CurrentRow.Cells[2].Value.ToString();
            mode = MODE_UPDATE;
        }

        private void dgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaterial.Text = dgvMaterial.CurrentRow.Cells[1].Value.ToString();
            txtDeskripsi.Text = dgvMaterial.CurrentRow.Cells[2].Value.ToString();
            mode = MODE_UPDATE;
        }

        private void dgvTempStandard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTemp_C.Text  = dgvTempStandard.CurrentRow.Cells[1].Value.ToString();
            txtTemp_F.Text = dgvTempStandard.CurrentRow.Cells[2].Value.ToString();
            txtTemp_Class.Text = dgvTempStandard.CurrentRow.Cells[3].Value.ToString();
            mode = MODE_UPDATE;

        }

        private void dgvToPD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDesignation.Text = dgvToPD.CurrentRow.Cells[1].Value.ToString();
            txtTechnique.Text = dgvToPD.CurrentRow.Cells[2].Value.ToString();
            cmbZone.Text = dgvToPD.CurrentRow.Cells[3].Value.ToString();
            mode = MODE_UPDATE;

        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNmAdmin.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
            txtKataSandi.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();
            mode = MODE_UPDATE;
        }

        private void btnResetProduk_Click(object sender, EventArgs e)
        {
            clearProduct();
        }

        private void btnResetMaterial_Click(object sender, EventArgs e)
        {
            clearMaterial();
        }

        private void btnResetTempStandard_Click(object sender, EventArgs e)
        {
            clearTempStandard();
        }

        private void btnResetToP_Click(object sender, EventArgs e)
        {
            clearTypeOfProtection();
        }

        private void btnResetPengguna_Click(object sender, EventArgs e)
        {
            clearUser();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSimpanUser_Click(object sender, EventArgs e)
        {
            String username = txtNmAdmin.Text;
            String password = txtKataSandi.Text;
            if (username != "" && password != "")
            {
                if (mode == MODE_SIMPAN)
                {
                    saveUser(username, password);
                }else
                {
                    updateUser(username, password, dgvUser.CurrentRow.Cells[0].Value.ToString());
                }
                MessageBox.Show("Data User disimpan!!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadUser();
                clearUser();
            }else
            {
                MessageBox.Show("Lengkapi Terlebih dahulu!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHapusProduk_Click(object sender, EventArgs e)
        {
            DialogResult res;

            res = MessageBox.Show("Apakah Anda yakin akan menghapus data tersebut?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                deleteProduct(dgvProduk.CurrentRow.Cells[0].Value.ToString()); 
                MessageBox.Show("Data Berhasil Dihapus!!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadProduct(); 
            }
        }

        private void btnHapusToPD_Click(object sender, EventArgs e)
        {
            DialogResult res;

            res = MessageBox.Show("Apakah Anda yakin akan menghapus data tersebut?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                deleteTypeofProtection(dgvToPD.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Data Berhasil Dihapus!!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadToP();
            }
        }
    }
}
