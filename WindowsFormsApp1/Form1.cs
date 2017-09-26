using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            form2NewObject();
            Thread frm2 = new Thread(new ThreadStart(StartForm2));
            frm2.Start();
        }
        Form2 form2;

        private void form2NewObject()
        {
            form2 = new Form2();
        }

        private void StartForm2()
        {
            Application.Run(form2);
        }

        public void TransferText(string text)
        {
            // Invoke the method of Form2's textbox1
            if (form2.textBox1.InvokeRequired)
            {
                form2.textBox1.Invoke((MethodInvoker)delegate ()
                {
                    TransferText(text);
                });
            }
            else form2.textBox1.Text = text;

            #region for same form
            //if (form2.textBox1.InvokeRequired)
            //{
            //    this.BeginInvoke(new MethodInvoker(() =>
            //    {
            //        form2.textBox1.Text = text;
            //    }));
            //}
            //else
            //{
            //    form2.textBox1.Text = text;
            //}
            #endregion
        }


        public void close()
        {
            if (form2.textBox1.InvokeRequired)
            {
                form2.textBox1.Invoke((MethodInvoker)delegate ()
                {
                    close();
                });
            }
            else form2.Close();
        }

        public void start()
        {
            if (form2.textBox1.InvokeRequired)
            {
                form2.textBox1.Invoke((MethodInvoker)delegate ()
                {
                    Show();
                });
            }
            else
            {
                form2NewObject();
                form2.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransferText(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            start();
        }
    }
}
