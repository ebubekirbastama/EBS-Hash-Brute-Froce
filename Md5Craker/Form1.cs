using EbubekirBastamatxtokuma;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Md5Craker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        OpenFileDialog op;Thread th;
        private void button1_Click(object sender, EventArgs e)
        {

            op = new OpenFileDialog();

            if (DialogResult.OK == op.ShowDialog()) //EBS Coding...
            {
                th = new Thread(vraktr);th.Start();
            }
        }
        private void vraktr()
        {
            BekraTxtOkuma.Txtİmport(op.FileName,listBox1,false);
        }
        private void başlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            th = new Thread(bsll);th.Start();
        }
        private void bsll()
        {
            try
            {

                Parallel.For(0, listBox1.Items.Count, i =>
                {
                    if (kmtmrkz.MD5Sifrele(listBox1.Items[i].ToString()) == textBox1.Text) //EBS Coding...
                    {
                        richTextBox1.AppendText("Md5 :" + kmtmrkz.MD5Sifrele(listBox1.Items[i].ToString()) + "Kırılmış hali :" + listBox1.Items[i].ToString());
                    }
                    else
                    {
                        listBox2.Items.Add("Bu Değer Eşleşmiyor :" + kmtmrkz. MD5Sifrele(listBox1.Items[i].ToString()));
                    }
                });
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "EBS Securty");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }
    }
}
