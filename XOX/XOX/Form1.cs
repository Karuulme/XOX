using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool Users1 = true;
        public bool Users2 = false;
        public string[] konumlar = new string[9];
        public Button[] butonlar = new Button[9];

        public  int[,] UserX = new int[3, 3];
        public  int[,] UserO = new int[3, 3];

        public void Buton_olusturma()
        {
          
            label3.ForeColor = Color.Green;
            label4.ForeColor = Color.Red;
            for (int i = 0; i < 9; i++)
            {

                butonlar[i] = new Button();
                butonlar[i].Width = 90;
                butonlar[i].Height = 90;
                butonlar[i].Font = new Font(butonlar[i].Font.FontFamily, 30);
                butonlar[i].Text = " ";
                butonlar[i].Name = "K" + i.ToString();
                konumlar[i] = "K" + i.ToString();
                flowLayoutPanel1.Controls.Add(butonlar[i]);
                butonlar[i].Click += new EventHandler(KClick);
                butonlar[i] = butonlar[i];
            }


        }
        private void Form1_Load(object sender, EventArgs e)
        {
             Buton_olusturma();
        }
        void KClick(object sender, EventArgs e)
        {


            Button btn = (Button)sender;

            for (int i = 0; i < 9; i++)
            {



                if (btn.Name.ToString() == konumlar[i])
                {
                    btn.Enabled = false;
                    int satir = i / 3;
                    int sutun = i % 3;

                    if (Users1 == true)
                    {
                        btn.Text = "X";


                        Users1 = false;
                        Users2 = true;
                        label3.ForeColor = Color.Red;
                        label4.ForeColor = Color.Green;

                        UserX[satir, sutun] = 1;
                        DiziKontrol(UserX, 1);

                    }
                    else
                    {
                        btn.Text = "O";
                        label3.ForeColor = Color.Green;
                        label4.ForeColor = Color.Red;
                        Users1 = true;
                        Users2 = false;
                        UserO[satir, sutun] = 1;
                        DiziKontrol(UserO, 2);

                    }


                }


            }

        }
        public void ButtonClose()
        {
            foreach (var i in butonlar)
            {
                i.Enabled = false;


            }


        }
        public void DiziKontrol(int[,] Konumlar, int PlayerNo)
        {

            for (int i = 0; i < 3; i++)
            {
                int toplam = 0;
                for (int j = 0; j < 3; j++)
                {

                    toplam += Konumlar[i, j];
                    if (toplam == 3)
                    {
                        MessageBox.Show("Oyunu Kazanan " + PlayerNo + ". Oyuncu");
                        ButtonClose();

                    }

                }



            }
            for (int i = 0; i < 3; i++)
            {
                int toplam = 0;
                for (int j = 0; j < 3; j++)
                {

                    toplam += Konumlar[j, i];
                    if (toplam == 3)
                    {
                        MessageBox.Show("Oyunu Kazanan " + PlayerNo + ". Oyuncu");
                        ButtonClose();
                    }

                }



            }
            for (int i = 0; i < 3; i++)
            {
                int toplam = 0;

                toplam += Konumlar[i, i];
                if (toplam == 3)
                {
                    MessageBox.Show("Oyunu Kazanan " + PlayerNo + ". Oyuncu");
                    ButtonClose();
                }


            }
            int toplam2 = Konumlar[0, 2] + Konumlar[1, 1] + Konumlar[2, 0];
            if (toplam2 == 3)
            {


                MessageBox.Show("Oyunu Kazanan " + PlayerNo + ". Oyuncu");
                ButtonClose();
            }










        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void DizileriSil(int[,] Diziler)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Diziler[i, j] = 0;

                }


            }


        }

      private  void btnRestart_Click(object sender, EventArgs e)
        {
            Users1 = true;
            Users2 = false;


            DizileriSil(UserO);
            DizileriSil(UserX);
            flowLayoutPanel1.Controls.Clear();
            Buton_olusturma();

        }
    }
}
