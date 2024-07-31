using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class WrapperTransporterClass : MarshalByRefObject
    {

        public delegate void DelegateSendValuePrivateTransporter(String sender, int type, int x, int y, int who, String msg);

        public DelegateSendValuePrivateTransporter SendValuePrivateTransporter;

        public void RunDelegateSendValuePrivateTransporter(String sender, int type, int x, int y, int who, String msg)
        {
            SendValuePrivateTransporter(sender, type, x, y, who, msg);
        }

    }
}
