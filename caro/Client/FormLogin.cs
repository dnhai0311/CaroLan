using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using General;
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Remoting;
using System.Threading;

namespace Client
{
    public partial class FormLogin : Form
    {
        internal IRemote obj;
        private String userName;
        private String IP;
        private WrapperTransporterClass wtc;
        public FormLogin()
        {
            InitializeComponent();
            AcceptButton = btnOk;
            wtc = new WrapperTransporterClass();
        }

        private void MakeConnectionToServer(string IP)
        {
            try
            {
                BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
                BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
                serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

                IDictionary props = new Hashtable();
                props["port"] = 0;
                string s = System.Guid.NewGuid().ToString();
                props["name"] = s;
                props["typeFilterLevel"] = TypeFilterLevel.Full;

                HttpChannel channel = new HttpChannel(props, clientProvider, serverProvider);

                int Port = 6969;
                ChannelServices.RegisterChannel(channel, false);
                obj = (IRemote)Activator.GetObject(typeof(IRemote), "http://" + IP + ":" + Port + "/RemoteObject.soap", WellKnownObjectMode.SingleCall);

            }
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối tới máy chủ");
            }
        }

        private void rdbtnLocalhost_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnLocalhost.Checked == true)
            {
                txtIp.Enabled = false;
            }
            else
            {
                txtIp.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtDesiredName.Text == "")
            {
                MessageBox.Show("Vui nhập nhập tên người chơi!!!");            }
            if (rdbtnLocalhost.Checked)
            {
                IP = "127.0.0.1";
            }
            else
            {
                IP = txtIp.Text;
            }
            userName = txtDesiredName.Text;
            try
            {
                MakeConnectionToServer(IP);

                if (obj.SignIn(userName))
                {
                    (new Thread(new ThreadStart(RunFormChat))).Start();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối tới địa chỉ IP: " + IP);
            }
        }

        private void RunFormChat()
        {
            Application.Run(new frmChat(obj, userName));
        }

        private void rdbtnOtherIp_CheckedChanged(object sender, EventArgs e)
        {
            txtIp.Clear();
        }

        private void btnGiaoDien_Click(object sender, EventArgs e)
        {
            frmGiaoDien giaoDien = new frmGiaoDien();
            giaoDien.Show();
        }
    }
}
