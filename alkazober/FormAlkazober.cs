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
    public partial class FormAlkazober : Form
    {
        private DataTable dtMaterial, dtProduct, dtTempStandard, dtToP;
        public FormAlkazober()
        {
            InitializeComponent();
        }


        private void loadMasterData()
        {
            String sql = "select * from produk";
            DBQuery dbq = new DBQuery();
            dbq.FillTableBySQL(sql);
            dtProduct = dbq.GetTable();

            sql = "select * from material";
            dbq.FillTableBySQL(sql);
            dtMaterial = dbq.GetTable();

            sql = "select * from tempstandard";
            dbq.FillTableBySQL(sql);
            dtTempStandard = dbq.GetTable();

            sql = "select * from typeofprotection";
            dbq.FillTableBySQL(sql);
            dtToP = dbq.GetTable();




        }

       
        private void resetTangkiTimbun()
        {
            txtDindingTangkiDistance.Text = "0";
            txtDikeHeight.Text = "0";
            txtVentingDistance.Text = "0";
            txtDiphatchDistance.Text = "0";
            txtTinggiMaterial.Text = "0";
            rbtnSumpTrenchTTNo.Checked = false;
            rbtnSumpTrenchTTYes.Checked = false;


        }

        private void resetFillingRTWMT()
        {
            txtMainholePengisian.Text = "0";
            txtTinggiFillingPointRTW.Text = "0";
            txtTinggiMaterialRTWMT.Text = "0";
            rbtnFIllingRTWMTYes.Checked = false;
            rbtnFIllingRTWMTNo.Checked = false;

        }

        private void resetDermagaMLA()
        {
            rbtnBawah.Checked = false;
            rbtnSepanjang.Checked = false;
            rbtnDarat.Checked = false;

            txtJarakdariMLA.Text = "0";
            txtTinggiDermaga.Text = "0";
            txtTinggiLMA.Text = "0";

            rbtnDermagaMLANo.Checked = false;
            rbtnDermagaMLAYes.Checked = false; 


        }

        private void resetpumpCompressor()
        {
            rbtnDalam.Checked = false;
            rbtnLuar.Checked = false;

            txtCompressorDistance.Text = "0";
            txtVentilasiAtapRumahDistance.Text = "0";

            rbtnRumahPompaNo.Checked = false;
            rbtnRumahPompaYes.Checked = false;

        }

        private void resetVenting()
        {
            txtVentingDistance2.Text = "0";

        }

        private void resetReliefValve()
        {
            txtReliefValveDistance.Text = "0";

        }

        public void resetAll()
        {
            resetTangkiTimbun();
            resetFillingRTWMT();
            resetDermagaMLA();
            resetpumpCompressor();
            resetVenting();
            resetReliefValve();

            chkTangkiTimbun.Checked = false;
            chkFillingRTWMT.Checked = false;
            chkDermagaMLA.Checked = false;
            chkRumahPompa.Checked = false;
            chkVenting.Checked = false;
            chkReliefValve.Checked = false;

        }



        private void FormAlkazober_Load(object sender, EventArgs e)
        {

        }

        private void btnResetALL_Click(object sender, EventArgs e)
        {

        }
    }
}
