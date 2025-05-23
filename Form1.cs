using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;




namespace finalproje3
{
    public partial class Form1 : Form
    {

        
        private DateTime referenceStartDate;
        private DateTime referenceEndDate;

        // ---------------------------
        // 1) Constructor’a abone olun
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            // RadioButton’ın CheckedChanged olayına abone ol
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;

            // CheckedListBox’ın SelectedIndexChanged olayına abone ol
            checkedListBox3.SelectedIndexChanged += checkedListBox3_SelectedIndexChanged;

            // Başlangıçta gizli olsun
            checkedListBox3.Visible = false;
        }

        // ---------------------------
        // 2) RadioButton CheckedChanged
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                // İlk defa açılıyorsa lisansı doldur
                if (checkedListBox3.Items.Count == 0)
                {
                    checkedListBox3.Items.AddRange(new object[]
                    {
                "A","A1","A2","M","B","B1","BE",
                "C","C1","CE","C1E","D","D1","DE","D1E","G","F"
                    });
                }
                checkedListBox3.Visible = true;
            }
            else
            {
                checkedListBox3.Visible = false;
            }
        }

        // ---------------------------
        // 3) Lisans seçimi değiştiğinde (isteğe bağlı)
        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen lisans tiplerini al
            var secilenler = checkedListBox3.CheckedItems.Cast<string>();
            // Örneğin bir Label’da göster
            labelSelectedLicenses.Text = "Seçilen Lisanslar: " + string.Join(", ", secilenler);
        }




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog
            {
                Title = "Eğitim Belgesi Seç",
                Filter = "Tüm dosyalar|*.*",
                Multiselect = true
            })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    richTextBox2.Clear();
                    foreach (var file in dlg.FileNames)
                        richTextBox2.AppendText(file + Environment.NewLine);
                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;  // 2: İş Deneyimi ve Referanslar
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
              
                using (var dlg = new OpenFileDialog
                {
                    Title = "Profil Fotoğrafı Seç",
                    Filter = "Resim dosyaları|*.jpg;*.jpeg;*.png;*.bmp"
                })
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                        pictureBox1.Image = Image.FromFile(dlg.FileName);
                }

        }

       

      

        private void button11_Click(object sender, EventArgs e)
        {
            // ProgressBar’ı göster
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            Application.DoEvents();  // UI güncellensin
            Thread.Sleep(5000);       // 5 saniye bekle

            // ProgressBar’ı gizle
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Visible = false;

            // dataGridView1’i temizleyip CV önizlemesini doldur
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Bilgi", "Bilgi");

            // --- Cinsiyet Bilgisi ---
            string cinsiyet = "";
            if (radioErkek.Checked)
                cinsiyet = "Erkek";
            else if (radioKadin.Checked)
                cinsiyet = "Kadın";
            else
                cinsiyet = "Belirtilmedi";

            dataGridView1.Rows.Add("Cinsiyet: " + cinsiyet);

            // Doğum Tarihi
            dataGridView1.Rows.Add("Doğum Tarihi: " + dateTimePicker2.Value.ToShortDateString());
           
            // Eğitim Dosyaları
            foreach (var line in richTextBox2.Lines)
                dataGridView1.Rows.Add("Eğitim Dosyası: " + line);
            
            // Yetenekler
            string diller = string.Join(", ", checkedListBox1.CheckedItems.Cast<string>());
            dataGridView1.Rows.Add("Teknik Yetenekler: " + diller);
            // Yetenek Seviyesi
            dataGridView1.Rows.Add("Yetenek Seviyesi: " + trackBar1.Value);


    

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (var bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height))
            {
                dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                using (var dlg = new SaveFileDialog
                {
                    Title = "CV’yi PNG Olarak Kaydet",
                    Filter = "PNG Dosyası|*.png"
                })
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                        bmp.Save(dlg.FileName, ImageFormat.Png);
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (checkedListBox1.Items.Count == 0)
            {
                checkedListBox1.Items.AddRange(new object[]
                {
            "Java","C#","C++","Python","PHP",
            "JavaScript","TypeScript","Ruby","Go",
            "Swift","Kotlin","Rust","Dart","Scala",
            "Perl","Lua","Haskell","Objective-C",
            "VB.NET","MATLAB"
                });
            }
           
   
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;  // 0: Genel Bilgiler, 1: Eğitim
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;  // 3: Yetenekler
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;  // 4: CV Oluştur
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
                tabControl1.SelectedIndex--;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labelSelectedLicenses_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
                tabControl1.SelectedIndex--;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
                tabControl1.SelectedIndex--;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
                tabControl1.SelectedIndex--;
        }
    }
}
