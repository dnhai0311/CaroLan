﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting;
using System.Collections;
using System.Net;
using General;

namespace Server
{
    public partial class ServerForm : Form
    {
        private int Port = 6969;
        private Hashtable OnlineUserList;
        public int indexUser = 0;
        public string[] UserNames = new string[100];
        public ServerForm()
        {
            InitializeComponent();
            String hostName = Dns.GetHostName();
            BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            IDictionary props = new Hashtable();
            props["port"] = Port;
            props["typeFilterLevel"] = TypeFilterLevel.Full;

            HttpChannel chan = new HttpChannel(props, clientProvider, serverProvider);
            ChannelServices.RegisterChannel(chan, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "RemoteObject.soap", WellKnownObjectMode.SingleCall);

            AddTextToDisplay("Đang mở Port  " + Port + "..." + hostName);
            OnlineUserList = new Hashtable();
        }

        delegate void AddTextToDisplayDelegate(String Info);
        public void AddTextToDisplay(String Info)
        {
            if (this.InvokeRequired)
            {
                AddTextToDisplayDelegate d = new AddTextToDisplayDelegate(AddTextToDisplay);
                this.Invoke(d, Info);
            }
            else
            {
                this.txtDisplay.AppendText(Environment.NewLine + "#" + Info);
            }

        }

        internal void AddUserToOnlineUserList(String userName, WrapperTransporterClass wtc)
        {
            OnlineUserList.Add(userName, wtc);
        }

        internal void ModifyUserOnlineListWrapper(String userName, WrapperTransporterClass wtc)
        {
            OnlineUserList[userName] = wtc;
        }

        internal WrapperTransporterClass GetConnectionTo(String userName)
        {
            return (WrapperTransporterClass)OnlineUserList[userName];
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void SetUserName(string name)
        {
            UserNames[indexUser] = name;
            indexUser++;
        }
        public string GetUserName(int i)
        {
            return UserNames[i];
        }
    }
}
