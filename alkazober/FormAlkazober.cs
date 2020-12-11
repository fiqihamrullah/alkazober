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

        private int[] izones;
        private double[] dT;
        
        public FormAlkazober()
        {
            InitializeComponent();           
            loadMasterData();
            izones = new int[6];
            dT = new double[6];
            
              
        }


        private void loadMasterData()
        {
            String sql = "select * from produk";
            DBQuery dbq = new DBQuery();
            dbq.FillTableBySQL(sql);
            dtProduct = dbq.GetTable();
           

          

            cmbproduktt.DataSource = dtProduct;
            cmbproduktt.DisplayMember = "nm_produk";
            cmbproduktt.ValueMember = "nm_produk";
             
            cmbProdukFillingRTWMT.DataSource   = dtProduct;
            cmbProdukFillingRTWMT.DisplayMember = "nm_produk";
            cmbProdukFillingRTWMT.ValueMember = "nm_produk";

            cmbprodukDermagaMLA.DataSource = dtProduct;
            cmbprodukDermagaMLA.DisplayMember = "nm_produk";
            cmbprodukDermagaMLA.ValueMember = "nm_produk";

            cmbprodukReliefValve.DataSource = dtProduct;
            cmbprodukReliefValve.DisplayMember = "nm_produk";
            cmbprodukReliefValve.ValueMember = "nm_produk";

            cmbprodukRumahPompa.DataSource = dtProduct;
            cmbprodukRumahPompa.DisplayMember = "nm_produk";
            cmbprodukRumahPompa.ValueMember = "nm_produk";

            cmbprodukVenting.DataSource = dtProduct;
            cmbprodukVenting.DisplayMember = "nm_produk";
            cmbprodukVenting.ValueMember = "nm_produk";

            sql = "select * from material";
            dbq.FillTableBySQL(sql);
            dtMaterial = dbq.GetTable();
            cmbMaterial.DataSource = dtMaterial;
            cmbMaterial.DisplayMember = "nm_material";
            cmbMaterial.ValueMember = "nm_material";

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

        private void submitTangkiTimbun()
        {

        }

        private void solveTangkiTimbun(int idxProduct)
        {
            double t_produk,T;
            double j_venting, j_dip_hatch, dinding_tangki, tinggi_material, tinggi_dike;


            int iclass;
            int izone;

            bool sump_or_trench;

            iclass = 1;
            izone = 1;

            j_venting = Double.Parse(txtVentingDistance.Text);
            j_dip_hatch = Double.Parse(txtDiphatchDistance.Text);
            dinding_tangki = Double.Parse(txtDindingTangkiDistance.Text);
            tinggi_material = Double.Parse(txtTinggiMaterial.Text);
            tinggi_dike = Double.Parse(txtDikeHeight.Text);



            sump_or_trench = rbtnSumpTrenchTTYes.Checked;



            //------------ Rule


            if ((j_venting < 1.5) || (j_dip_hatch < 1.5))
            {
                izone = 1;
            } else if (((j_venting < 3) || (j_dip_hatch < 3)) || (dinding_tangki < 3))
            {
                if (sump_or_trench)
                {
                    izone = 1;
                } else {
                    izone = 2;
                }
            } else if (tinggi_material < 0.6)
            {
                if (sump_or_trench)
                {
                    izone = 1;
                } else
                {
                    izone = 2;
                }
            } else if (tinggi_material < tinggi_dike)
            {
                izone = 2;
            } else
            {
                izone = -1;
            }



           if (izone != -1)
           {
                        lblDivisionClass.Text = "Class 1 Zone " +  izone.ToString();
           } else
           {
                        lblDivisionClass.Text = "Unclassified";
           }




            t_produk = Double.Parse(dtProduct.Rows[idxProduct]["suhu"].ToString());
            T = t_produk * 0.8;



            izones[0] = izone;
            dT[0] = T; 


              // SolveTClass T, idxrowadd
              // SolveTypeProtectionDesignation izone, idxrowadd

 

        }

        private void submitFillingRTWMT()
        {

        }

        private void solveFillingRTWMT(int idxProduct)
        {
            double t_produk, T;
            double j_mainhole, tinggi_material, tinggi_filling_point_rtw;

            int iclass;
            int izone;

            bool sump_or_trench_rtw;

            double distance_diff, magnitude;
 
            iclass = 1;
            izone = 1;


            j_mainhole = Double.Parse(txtMainholePengisian.Text);
            tinggi_filling_point_rtw = Double.Parse(txtTinggiFillingPointRTW.Text);
            tinggi_material = Double.Parse(txtTinggiMaterial.Text);


            distance_diff = Math.Abs(tinggi_filling_point_rtw - tinggi_material);
            magnitude = Math.Sqrt((distance_diff * distance_diff) + (j_mainhole * j_mainhole));

            sump_or_trench_rtw = rbtnFIllingRTWMTYes.Checked;


            //====== Rule

            if (sump_or_trench_rtw) {
                izone = 1;
            }
            else
            {
                if (magnitude < 1)
                {
                    izone = 1;
                } else if (magnitude <= 4.5)
                {
                    izone = 2;
                }
                else
                {
                    izone = -1;
                }
            }


            if (izone != -1)
            {
                
                lblDivisionClass.Text = "Class 1 Zona " + izone.ToString();
            } else
            {
                lblDivisionClass.Text = "Unclassified";
               
            }





            t_produk = Double.Parse(dtProduct.Rows[idxProduct]["suhu"].ToString());
            T = t_produk * 0.8;


            izones[1] = izone;
            dT[1] = T;
 


           //SolveTClass T, idxrowadd
           //SolveTypeProtectionDesignation izone, idxrowadd

 
        }

        private void submitDermagaLMA()
        {

        }


        private void solveDermagaLMA(int idxProduct)
        {
            double t_produk, T;
            double jarak_darimla, tinggi_dermaga, tinggi_mla;
            int iclass, izone;

            bool sepanjangmla, areabawahdermaga, sumpdermaga, arahdarat;
            double selisih;

            iclass = 1;
            izone = 1;

            jarak_darimla = Double.Parse(txtJarakdariMLA.Text);
            tinggi_dermaga = Double.Parse(txtTinggiDermaga.Text);
            tinggi_mla = Double.Parse(txtTinggiLMA.Text);

            areabawahdermaga = rbtnBawah.Checked;
            sepanjangmla = rbtnSepanjang.Checked;
            arahdarat = rbtnDarat.Checked;


            sumpdermaga = rbtnDermagaMLAYes.Checked;
            selisih = tinggi_dermaga - tinggi_mla;

            //=== Rule

            if (areabawahdermaga)
            {
                izone = 2;
            } else if (sepanjangmla)
            {
                if (selisih < 7.5)
                {
                    if (sumpdermaga)
                    {
                        izone = 1;
                    }
                    else
                    {
                        izone = 2;
                    }
                } else
                {
                    izone = -1;
                }
            } else if (arahdarat)
            {
                if (jarak_darimla < 7.5)
                {
                    if (selisih < 7.5)
                    {
                        if (sumpdermaga)
                        {
                            izone = 1;
                        }
                        else
                        {
                            izone = 2;
                        }
                    }
                    else
                    {
                        izone = -1;
                    }
                } else if (jarak_darimla < 15)
                {
                    if (tinggi_dermaga < 7.5)
                    {
                        if (sumpdermaga)
                        {
                            izone = 1;
                        } else
                        {
                            izone = 2;
                        }
                    } else {
                        izone = -1;
                    }
                } else if (jarak_darimla < 30)
                {
                    if (tinggi_dermaga < 0.6)
                    {
                        if (sumpdermaga)
                        {
                            izone = 1;
                        } else {
                            izone = 2;
                        }
                    } else
                    {
                        izone = -1;
                    }
                } else {
                    izone = -1;
                 }
  
            }


             if (izone != -1)
             {
                
                lblDivisionClass.Text = "Class 1 Zona " + izone.ToString(); 
             } else
             {
                lblDivisionClass.Text = "Unclassified";

             }



            t_produk = Double.Parse(dtProduct.Rows[idxProduct]["suhu"].ToString());
            T = t_produk * 0.8;


            izones[2] = izone;
            dT[2] = T;
 


              // SolveTClass T, idxrowadd
             //  SolveTypeProtectionDesignation izone, idxrowadd

 
        }

        private void submitRumahPompaCompressor()
        {

        }

        private void solveRumahPompaCompressor(int idxProduct)
        {
            double t_produk, T;
            double compr, ventilasi;

            int iclass;
            int izone;

            bool sumptrench,dalam;
            bool bagian_dalam, bagian_luar;

             
            iclass = 1;
            izone = 1;

            dalam = rbtnDalam.Checked;
            sumptrench = rbtnRumahPompaYes.Checked;


            compr = Double.Parse(txtCompressorDistance.Text);
            ventilasi = Double.Parse(txtVentilasiAtapRumahDistance.Text);



            //============== Rule


            if (sumptrench)
            {
                izone = 1;
            } else if (dalam)
            {
                izone = 2;
            } else
            {
                if (compr < 3)
                {
                    izone = 2;
                } else if (ventilasi < 1.5)
                {
                    izone = 2;
                } else
                {
                    izone = -1;
                }
             }

 

            t_produk = Double.Parse(dtProduct.Rows[idxProduct]["suhu"].ToString());
            T = t_produk * 0.8;


            izones[3] = izone;
            dT[3] = T;
 

           //SolveTClass T, idxrowadd
           //SolveTypeProtectionDesignation izone, idxrowadd


    
        }

        private void submitVenting()
        {

        }

        private void solveVenting(int idxProduct)
        {
            double t_produk, T;
            double j_venting;

            int iclass;
            int izone;

 
            iclass = 1;
            izone = 1;

            j_venting = Double.Parse(txtVentingDistance2.Text);

            //==== Rule

            if (j_venting < 1.5)
            {
                izone = 1;
            } else if (j_venting < 3)
            {
                izone = 2;
            } else
            {
                izone = -1;
            }





            if (izone != -1)
            {
                lblDivisionClass.Text = "Class 1 Zona " + izone.ToString();   
            } else
            {
                lblDivisionClass.Text = "Unclassified";
            }



            t_produk = Double.Parse(dtProduct.Rows[idxProduct]["suhu"].ToString());
            T = t_produk * 0.8;


            izones[4] = izone;
            dT[4] = T;
   
           //SolveTClass T, idxrowadd
           //SolveTypeProtectionDesignation izone, idxrowadd

 
        }

        private void submitReliefValve()
        {

        }

        private void solveReliefValve(int idxProduct)
        {
            double t_produk, T;
            double j_relief_valve;

            int iclass;
            int izone;

            iclass = 1;
            izone = 1;


            j_relief_valve = Double.Parse(txtReliefValveDistance.Text);

            //=== Rule

            if (j_relief_valve < 3)
            {
                izone = 2;
            } else
            {
                izone = -1;
            }





            if (izone != -1)
            {
                lblDivisionClass.Text = "Class 1 Zona " + izone.ToString();
             } else
             {
                lblDivisionClass.Text = "Unclassified";
             }



            t_produk = Double.Parse(dtProduct.Rows[idxProduct]["suhu"].ToString());
            T = t_produk * 0.8;


            izones[5] = izone;
            dT[5] = T;
   
           //SolveTClass T, idxrowadd
           //SolveTypeProtectionDesignation izone, idxrowadd
    
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            String dat = dtProduct.Rows[cmbproduktt.SelectedIndex]["suhu"].ToString();
            MessageBox.Show(dat);
        }

     


        private void FormAlkazober_Load(object sender, EventArgs e)
        {

        }

        private void btnResetALL_Click(object sender, EventArgs e)
        {
            resetAll();
        }
    }
}
