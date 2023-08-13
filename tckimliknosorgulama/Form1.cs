using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tckimliknosorgulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strTcNo;
        int[] intTcNo;
        bool sonuc;
        int ilkOnRakamToplami;
        int TekRakamlarToplami;
        int CiftRakamlarToplami;

        private void button1_Click(object sender, EventArgs e)
        {
            sonuc = true;
            strTcNo = maskedTextBox1.Text;
            if (strTcNo.Length != 11)

                MessageBox.Show("Eksik Giriş Yaptınız..", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                intTcNo = new int[11];
                for (int i = 0; i < 11; i++)
                {
                    intTcNo[i] = strTcNo[i] - 48;
                }
                if (!BirinciKural())
                {
                    sonuc = false;
                }
                else if (!İkinciKural())
                {
                    sonuc = false;
                }
                else if (!UcuncuKural())
                {
                    sonuc = false;
                }
                if (sonuc)
                {
                    MessageBox.Show("TC Kimlik Numarası Doğrulandı.", "Kimlik Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                else
                {
                    MessageBox.Show("TC Kimlik Numarası Doğrulanamadı !!!", "Kimlik Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }

            maskedTextBox1.Text = "";

        }





        private bool BirinciKural()
        {
            ilkOnRakamToplami = 0;
            for (int i = 0; i < 10; i++)
                ilkOnRakamToplami += intTcNo[i];
            if ((ilkOnRakamToplami % 10) == intTcNo[10]) //10. indis 11. rakama denk gelir..
                return true;
            else
                return false;
        }

        private bool İkinciKural()
        {
            TekRakamlarToplami = 0;
            for (int i = 0; i < 9; i += 2)
                TekRakamlarToplami += intTcNo[i];

            CiftRakamlarToplami = 0;
            for (int i = 1; i < 8; i += 2)
                CiftRakamlarToplami += intTcNo[i];

            int Toplam = (TekRakamlarToplami * 7) + (CiftRakamlarToplami * 9);

            if ((Toplam % 10) == intTcNo[9]) //9. indis 10. rakama denk gelir..
                return true;
            else
                return false;
        }
        private bool UcuncuKural()
        {
            if ((TekRakamlarToplami * 8) % 10 == intTcNo[10])
                return true;
            else
                return false;

        }
    }
}
