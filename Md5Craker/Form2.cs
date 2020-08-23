using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Md5Craker
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        Thread th;ArrayList ary = new ArrayList();
        private string dff;

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Başlama Zamanı: " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();

            if (radioButton1.Checked==true) //EBS Coding...
            {
                th = new Thread(bslsayi); th.Start();
            }
            if (radioButton2.Checked == true) //EBS Coding...
            {
                th = new Thread(bslharf); th.Start();
            }
            //
        }
        private void bslharf()
        {
            try
            {
                int intt = 0;
                for (int i = 0; i < int.Parse(textBox2.Text); i++)
                {
                    for (int j = 0; j < ary.Count; j++)
                    {

                        if (i==0) //EBS Coding...
                        {
                            string fv = ary[j].ToString();
                            if (kmtmrkz.MD5Sifrele(fv) == textBox1.Text) //EBS Coding...
                            {
                                richTextBox1.Text = "Şifreli Hali : " + kmtmrkz.MD5Sifrele(i.ToString()) + "Kırılmış Hali : " + fv;
                                textBox2.Text = "0";
                                break;
                            }
                        }
                        else
                        {

                            dff = ary[intt].ToString();
                            for (int b = 0; b < ary.Count; b++)
                            {
                                string fgg = dff + ary[b].ToString();
                                if (kmtmrkz.MD5Sifrele(fgg) == textBox1.Text) //EBS Coding...
                                {
                                    richTextBox1.Text = "Şifreli Hali : " + kmtmrkz.MD5Sifrele(fgg + ary[b].ToString()) + "Kırılmış Hali : " + fgg;
                                    textBox2.Text = "0";
                                    break;
                                }

                            }
                            intt++;

                        }

                    }
                    dff = "";
                    dff+= ary[i].ToString();
                }
                label4.Text = "Bitiş Zamanı: " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "EBS Securty");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; label3.Text = "";label4.Text = "";
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                alfabe();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "EBS Securty");
            }
        }
        void alfabe()
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                ary.Add(c.ToString());
            }
        }
        void bslsayi()
        {
            try
            {

                Parallel.For(0, int.Parse(textBox2.Text), i =>
                {
                    //label3.Text = i.ToString();
                    if (kmtmrkz.MD5Sifrele(i.ToString()) == textBox1.Text) //EBS Coding...
                    {
                        richTextBox1.Text = "Şifreli Hali : " + kmtmrkz.MD5Sifrele(i.ToString()) + "Kırılmış Hali : " + i;

                    }
                    else
                    {
                        // listBox2.Items.Add("Bu değer değil : " + i + " MD5 : " + Form1.MD5Sifrele(i.ToString()));
                    }
                });
                label4.Text = "Bitiş Zamanı: " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "EBS Securty");
            }
        }
    }
}
