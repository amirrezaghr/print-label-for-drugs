using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Novacode;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;

namespace daronevis
{

    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }
        string temp;
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void btn_ghors_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines("d_ghors.txt");
            listBox1.Items.AddRange(lines);


        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            pic_printer.Visible = true;
            lbl_mode.Text = "در حال پرینت";
            lbl_mode.ForeColor = Color.Green;


            var doc_code = Guid.NewGuid();
            DocX doc = DocX.Load("printTemp.docx");
            doc.ReplaceText("$replace", listBox1.SelectedItem.ToString());
            doc.SaveAs("printTemp-" + doc_code.ToString() + ".docx");


            //--------------------bakhshe print ba kelase Process

            System.Diagnostics.Process print = new System.Diagnostics.Process();

            print.StartInfo.FileName = "printTemp-" + doc_code.ToString() + ".docx";

            print.StartInfo.Verb = "Print";

            print.StartInfo.UseShellExecute = true;

            print.StartInfo.CreateNoWindow = true;

            print.Start();

            //-------------------


            progressBar1.Value = 40;
            progressBar1.Value = 60;
            progressBar1.Value = 100;
            timer1.Enabled = true;
            btn_ghors.Focus();

        }
        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pic_printer.Visible = true;
            lbl_mode.Text = "در حال پرینت";
            lbl_mode.ForeColor = Color.Green;
            progressBar1.Value = 40;
            progressBar1.Value = 60;
            progressBar1.Value = 100;
            timer1.Enabled = true;
            btn_ghors.Focus();



            var doc_code = Guid.NewGuid();
            DocX doc = DocX.Load("printTemp.docx");
            doc.ReplaceText("$replace", textBox1.Text);
            doc.SaveAs("printTemp-" + doc_code.ToString() + ".docx");


            //--------------------bakhshe print ba kelase Process

            System.Diagnostics.Process print = new System.Diagnostics.Process();

            print.StartInfo.FileName = "printTemp-" + doc_code.ToString() + ".docx";

            print.StartInfo.Verb = "Print";

            print.StartInfo.UseShellExecute = true;

            print.StartInfo.CreateNoWindow = true;

            print.Start();

            //-------------------

        }

        private void button15_Click(object sender, EventArgs e)
        {
            txt_pormasraf.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            pic_printer.Visible = true;
            lbl_mode.Text = "در حال پرینت";
            lbl_mode.ForeColor = Color.Green;

            var doc_code = Guid.NewGuid();
            DocX doc = DocX.Load("printTemp.docx");
            doc.ReplaceText("$replace", txt_pormasraf.Text);
            doc.SaveAs("printTemp-" + doc_code.ToString() + ".docx");

            //--------------------bakhshe print ba kelase Process

            System.Diagnostics.Process print = new System.Diagnostics.Process();

            print.StartInfo.FileName = "printTemp-" + doc_code.ToString() + ".docx";

            print.StartInfo.Verb = "Print";

            print.StartInfo.UseShellExecute = true;

            print.StartInfo.CreateNoWindow = true;

            print.Start();

            //-------------------


            progressBar1.Value = 40;
            progressBar1.Value = 60;
            progressBar1.Value = 100;

            txt_pormasraf.Clear();
            timer1.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txt_pormasraf.Text = "هر 12 ساعت";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txt_pormasraf.Text != "")
            {
                temp = txt_pormasraf.Text;
                txt_pormasraf.Text = temp + " " + "یک عدد";
            }
            else
            {
                txt_pormasraf.Text = "یک عدد"; 
                    }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["processorID"].Value.ToString();
                break;
            }

            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }



            //سریال سی پی یو و مک آدرس سیستم خود را با پارامترهای زیر جایگزین کنید



            if (cpuInfo != "BFEBFBFF000506E3" && macAddresses != "18:5E:0F:1E:08:70")
            {
                Application.Exit();
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_pormasraf_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            support sp = new support();
            sp.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            aboutus aboutus = new aboutus();
            aboutus.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt_pormasraf.Text = "هر 6 ساعت";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_pormasraf.Text = "هر 8 ساعت";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_pormasraf.Text != "")
            {
                temp = txt_pormasraf.Text;
                txt_pormasraf.Text = temp + " " + "بعد از غذا";
            }
            else
            {
                txt_pormasraf.Text = "بعد از غذا";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txt_pormasraf.Text != "")
            {
                temp = txt_pormasraf.Text;
                txt_pormasraf.Text = temp + " " + "قبل از غذا";
            }
            else
            {
                txt_pormasraf.Text = "قبل از غذا";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txt_pormasraf.Text != "")
            {
                temp = txt_pormasraf.Text;
                txt_pormasraf.Text = temp + " " + "دو عدد";
            }
            else
            {
                txt_pormasraf.Text = "دو عدد";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txt_pormasraf.Text != "")
            {
                temp = txt_pormasraf.Text;
                txt_pormasraf.Text = temp + " " + "یک قاشق";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (txt_pormasraf.Text != "")
            {
                temp = txt_pormasraf.Text;
                txt_pormasraf.Text = temp + " " + "غذا خوری";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (txt_pormasraf.Text != "")
            {
                temp = txt_pormasraf.Text;
                txt_pormasraf.Text = temp + " " + "چای خوری";
            }
            else
            {
                txt_pormasraf.Text = "چای خوری";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (txt_pormasraf.Text != "")
            {
                temp = txt_pormasraf.Text;
                txt_pormasraf.Text = temp + " " + "جویده شود";
            }
            else
            {
                txt_pormasraf.Text = "جویده شود";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (txt_pormasraf.Text != "")
            {
                temp = txt_pormasraf.Text;
                txt_pormasraf.Text = temp + " " + "شبی یک بار";
            }
            else
            {
                txt_pormasraf.Text = "شبی یک بار";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_mode.Text = "آماده پرینت";
            lbl_mode.ForeColor = Color.Red;
            pic_printer.Visible = false;
            progressBar1.Value = 10;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btn_capsule_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines("d_capsule.txt");
            listBox1.Items.AddRange(lines);
        }

        private void btn_sharbat_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines("d_sharbat.txt");
            listBox1.Items.AddRange(lines);
        }

        private void btn_ampol_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines("d_ampol.txt");
            listBox1.Items.AddRange(lines);
        }

        private void btn_shiaf_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines("d_shiaf.txt");
            listBox1.Items.AddRange(lines);
        }

        private void btn_cream_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines("d_cream.txt");
            listBox1.Items.AddRange(lines);
        }

        private void btn_podr_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines("d_podr.txt");
            listBox1.Items.AddRange(lines);
        }

        private void btn_ghatre_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines("d_ghatre.txt");
            listBox1.Items.AddRange(lines);
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("d_ghors.txt");
        }

        private void EditIcon_Click(object sender, EventArgs e)
        {

                
            


        }

        private void btn_capsuleEdit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("d_capsule.txt");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                btn_ghorsEdit.Visible = true;
                btn_capsuleEdit.Visible = true;
                btn_sharbatEdit.Visible = true;
                btn_ampolEdit.Visible = true;
                btn_shiafEdit.Visible = true;
                btn_creamEdit.Visible = true;
                btn_podrEdit.Visible = true;
                btn_ghatreEdit.Visible = true;
            }
            else
            {
                btn_ghorsEdit.Visible = false;
                btn_capsuleEdit.Visible = false;
                btn_sharbatEdit.Visible = false;
                btn_ampolEdit.Visible = false;
                btn_shiafEdit.Visible = false;
                btn_creamEdit.Visible = false;
                btn_podrEdit.Visible = false;
                btn_ghatreEdit.Visible = false;
            }
        }

        private void btn_sharbatEdit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("d_sharbat.txt");
        }

        private void btn_ampolEdit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("d_ampol.txt");
        }

        private void btn_shiafEdit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("d_shiaf.txt");
        }

        private void btn_creamEdit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("d_cream.txt");
        }

        private void btn_podrEdit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("d_podr.txt");
        }

        private void btn_ghatreEdit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("d_ghatre.txt");
        }

        private void lblCpu_Click(object sender, EventArgs e)
        {
            
        }

        private void analogueClock1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_mode_Click(object sender, EventArgs e)
        {

        }
    }
}
