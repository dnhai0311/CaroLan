using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using General;

namespace Server
{


    class RemoteObject : MarshalByRefObject, IRemote
    {

        #region IRemote Members

        public bool SignIn(string userName)
        {
            if (userName != null && userName.Length > 0)
            {
                try
                {
                    ServerStartup.frmServer.AddUserToOnlineUserList(userName, null);
                }
                catch (Exception)
                {
                    MessageBox.Show("Thử lại với tên khác ^_^!");
                    return false;
                }
                if (ServerStartup.frmServer.indexUser < 100)
                {
                    if (ServerStartup.frmServer.indexUser == 0) ServerStartup.frmServer.AddTextToDisplay("Tạo phòng thành công!");
                    ServerStartup.frmServer.AddTextToDisplay(userName + " đã vào phòng!");
                    ServerStartup.frmServer.UserNames[ServerStartup.frmServer.indexUser] = userName;
                    ServerStartup.frmServer.indexUser++;
                    return true;
                }
                else
                {
                    MessageBox.Show("Server đầy....!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void SendMessageToServer(string sender, string MsgCont)
        {
            for (int j = 0; j < ServerStartup.frmServer.indexUser; j++)
            {

                ((WrapperTransporterClass)(ServerStartup.frmServer.GetConnectionTo(ServerStartup.frmServer.UserNames[j]))).RunDelegateSendValuePrivateTransporter(sender, 7, 0, 0, 0, MsgCont);
            }
        } // Gửi date tới server

        public void RegisterWrapperTransporterClass(string sender, WrapperTransporterClass wtc)
        {
            ServerStartup.frmServer.ModifyUserOnlineListWrapper(sender, wtc);
        } // Tạo thread


        public void SendValuePrivate(string sender, string Receiver, int type, int x, int y, int who, String Msg)
        {
            if (type == 6)
            {

                for (int j = 0; j < ServerStartup.frmServer.indexUser; j++)
                {

                    ((WrapperTransporterClass)(ServerStartup.frmServer.GetConnectionTo(sender))).RunDelegateSendValuePrivateTransporter(sender, 6, x, y, who, ServerStartup.frmServer.UserNames[j]);
                }
            }
            else
            {

                try
                {
                    ((WrapperTransporterClass)(ServerStartup.frmServer.GetConnectionTo(Receiver))).RunDelegateSendValuePrivateTransporter(sender, type, x, y, who, Msg);
                }
                catch (Exception)
                {
                    try
                    {
                        if (type == 0)
                            ((WrapperTransporterClass)(ServerStartup.frmServer.GetConnectionTo(sender))).RunDelegateSendValuePrivateTransporter(null, 2, x, y, who, Receiver);
                        else
                            ((WrapperTransporterClass)(ServerStartup.frmServer.GetConnectionTo(sender))).RunDelegateSendValuePrivateTransporter(null, 5, x, y, who, Receiver);
                    }
                    catch (Exception) { }

                }
            }
        }// Gửi Data đến Receiver

        #endregion

    }
}
