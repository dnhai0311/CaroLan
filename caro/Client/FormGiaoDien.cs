using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Client
{
    public partial class frmGiaoDien : Form
    {
        public frmGiaoDien()
        {
            InitializeComponent();
        }
        string targetFile;
        private void btnMo_Click(object sender, EventArgs e)
        {
            Thread t = new Thread((ThreadStart)(() =>
            {
                OpenFileDialog fileImage = new OpenFileDialog();
                if (fileImage.ShowDialog() == DialogResult.OK)
                {
                    pbGiaoDien.Image = new Bitmap(fileImage.FileName);
                    this.txtDiaChi.BeginInvoke((MethodInvoker)delegate ()
                    {
                        txtDiaChi.Text = fileImage.FileName;
                    });
                    targetFile = Path.Combine("..//..//saves//user//", Path.GetFileName(fileImage.FileName));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Copy(fileImage.FileName, targetFile);
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        private void change(string strPath)
        {
            string path = Path.Combine("..//..//", System.IO.Path.GetFileName(strPath));
            if (File.Exists(path)) File.Delete(path);
            File.Copy(targetFile, path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            change("..//..//caro.jpg");
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            change("..//..//x.jpg");
        }

        private void btnXVang_Click(object sender, EventArgs e)
        {
            change("..//..//xvang.jpg");
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            change("..//..//o.jpg");
        }

        private void btnOVang_Click(object sender, EventArgs e)
        {
            change("..//..//ovang.jpg");
        }
    }
}
