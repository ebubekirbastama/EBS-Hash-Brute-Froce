using EbubekirBastamatxtokuma;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Md5Craker
{
    public partial class sah1 : Form
    {
        public sah1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        Thread th;OpenFileDialog op;
        private void button1_Click(object sender, EventArgs e)
        {
            op = new OpenFileDialog();

            if (DialogResult.OK == op.ShowDialog()) //EBS Coding...
            {
                th = new Thread(bsli); th.Start();
            }
        }
        private void başlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            th = new Thread(bsli);th.Start();
        }

        private void bsli()
        {
            try
            {
                string[] vrr = File.ReadAllLines(op.FileName, Encoding.GetEncoding("iso-8859-9"));
                Parallel.For(0, vrr.Length, (i,ls) => {
                    //label3.Text = i.ToString(); 

                    if (kmtmrkz.Sha1(vrr[i].ToString()) == textBox1.Text) //EBS Coding...
                    {
                        richTextBox1.AppendText("Bulunan index yeri: "+i);
                        richTextBox1.AppendText("Veri Kırıldı: " + textBox1.Text + ":" + vrr[i].ToString());
                        ls.Stop();
                    }
                    else if (vrr.Length == Convert.ToInt64(i))
                    {
                        richTextBox1.AppendText("Veri Kırılamadı.");
                    }
                });
                MessageBox.Show("Tarama Bitti.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EBS Securty");
            }
        }
    }
}
