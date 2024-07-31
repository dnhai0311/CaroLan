using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using General;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client
{
    struct vitri // lưu lại vị trí các quân cờ tại lượt nào
    {
        public int luot;
    }
    
    struct LichSuDau
    {
        public int x, y;
        public int who; // 0 là mình, 1 là đối thủ
    }
    public partial class frmChat : Form
    {
        IRemote obj;
        String userName;
        WrapperTransporterClass wtc;
        //các biến trong cờ caro
        string[] UserNames;// mảng lưu tên User
        int count;//đẽm số User
        vitri[,] ViTriQuanCo = new vitri[21, 21]; // lưu vị trí từng quân cờ
        private Bitmap bmpBanCo = new Bitmap("..//..//caro.jpg");
        public Bitmap bmpX = new Bitmap("..//..//x.jpg");
        public Bitmap bmpO = new Bitmap("..//..//o.jpg");
        public Bitmap bmpXMauVang = new Bitmap("..//..//xvang.jpg");
        public Bitmap bmpOMauVang = new Bitmap("..//..//ovang.jpg");
        int[,] BanCoCaro = new int[19, 19]; // lưu lại bàn cờ caro
        int h, c; // toạ độ quân cờ
        int h1, c1;// toạ độ quân cờ của đối thủ
        int flags; // sẽ vẽ quân cờ nào lên bàn cờ. 1 = X, 2 = O
        int iSWin;// mình có thắng thắng không 1 = thắng , 0 = không, dùng để gởi cho đối thủ
        int doesEnemyWin; // đối thủ có thắng không 1 = thắng , 0 = không, dùng để đối thủ gởi cho mình
        Boolean luot = false;// lượt ai đi False = đối thủ, true = mình
        string DoiThuHienTai;// tên đối thủ hiện tại
        int returnTextTo;//biến dùng quản lý CaroText 1=mở; 0=khóa
        int isAccept;// biến kiểm tra đỗi thủ có chấp nhận đánh caro với mình không 0=0 1=có
        int isX;// quân mình đánh đi là X=1, 0 = O
        int SoTranThang; // số trân thắng của mình
        int SoTranThua;// số trận đối thủ thắng
        int isFirst;// kiểm tra có phải lượt đánh đầu tiên hay không? 0 = là lượt đánh đầu tiên
        int ThoiGianMoiLuot = 30;// Thời gian bắt đầu l hượt đánh
        List<LichSuDau> LSD = new List<LichSuDau>();
        int luotThu = 0;
        public frmChat(IRemote obj, String userName)
        {
            InitializeComponent();
            txtChatDisplay.ScrollBars = ScrollBars.Both;
            AcceptButton = btnSend;
            this.obj = obj;
            this.userName = userName;
            this.Text = userName;
            wtc = new WrapperTransporterClass();
            RegisterMethodToWrapperTransporterClass();
            obj.RegisterWrapperTransporterClass(userName, wtc);
            //Khởi tạo bàn cờ
            for (int i = 0; i < 19; i++)
                for (int j = 0; j < 19; j++)
                    BanCoCaro[i, j] = 0;
            for (int i = 0; i <= 20; i++)
                for (int j = 0; j <= 20; j++)
                    ViTriQuanCo[i, j].luot = 2;
            flags = 2; // Đi quân O đầu tiên
            iSWin = 0;
            doesEnemyWin = 0;
            DoiThuHienTai = "";
            returnTextTo = 0;
            isAccept = 0;
            lbName.Text = this.userName;
            lbWin.Text = SoTranThang.ToString();
            isX = 0; // đánh quân O
            SoTranThang = 0;
            SoTranThua = 0;
            UserNames = new string[100];
            UserNames[0] = "ViTriQuanCo";
            count = 0;
            isFirst = 0;
            TG.Visible = false;
            RunThreadTimePlay();

        } // Kết thúc khởi tạo bàn cờ

        private void RunThreadTimePlay()
        {
            Thread threadTimePlay = new Thread(ThoiGianDaChoi);
            threadTimePlay.Start();
            threadTimePlay.IsBackground = true;
        }
        
        private void ThoiGianDaChoi()
        {
            int timePlay = 0;
            while(true)
            {
                timePlay++;
                this.lbTimePlay.BeginInvoke((MethodInvoker) delegate ()
               {
                   if(timePlay<60)
                   {
                       lbTimePlay.Text = timePlay.ToString() + " giây";
                   }
                   else
                   {
                       lbTimePlay.Text = (timePlay/60).ToString() + " phút, " + (timePlay%60).ToString() + " giây";
                   }
               });
                Thread.Sleep(1000);
            }
        }

        private void DoNothingInCallBack(IAsyncResult Res) {

        }

        private void RegisterMethodToWrapperTransporterClass()
        {
            wtc.SendValuePrivateTransporter += CaroValueReceivedHandler;
        }
        delegate void DelegateSendMessageToServer(String Sender, String MsgCont);// gửi message đến server
        delegate void DelegateSendValuePrivate(String Sender, String Receiver, int type, int x, int y, int who, String Msg); // gửi data đến Server - Sever gởi lại cho Receiver
        //Type: Các loại tin gửi đi
        //0 = Chat
        //1 = Caro
        //2 = Trả lời không tìm thấy người chat
        //3 = Gửi yêu cầu đánh cờ caro
        //4 = Trả lời không tìm thấy người chơi cờ caro
        //5 = Người chơi không chấp nhận đánh cờ
        //6 = Nhận thông tin user từ server
        //7 = Thông tin server gửi tới toàn bộ clients
        //8 = Thông tin đối thủ hết giờ
        //9 = Trả lại thông tin nếu nhận được type == 8
        private void CaroValueReceivedHandler(String Sender, int type, int x, int y, int who, String Msg)
        {
            if (type == 1 && DoiThuHienTai.Equals(Sender))
            {
                draw2(x, y);
                LSD.Add(new LichSuDau() { x = x, y = y, who = 1 });
                luotThu++;
                doesEnemyWin = who;
                luot = true;
                ThoiGianMoiLuot = 30; // Đặt thời gian là 30 giây cho mỗi nước đi
            }
            else if (type == 0)
            {
                AddTextToChatDisplay(Sender + " :" + Msg);
                btnSend.BackColor = System.Drawing.Color.Yellow;// gán BtSend thành màu vàng khi có người gửi `in chat (type==0)
            }
            else if (type == 2)
            {
                MessageBox.Show("Error!!! Không thể chat với :" + Msg);
            }
            else if (type == 3)
            {
                if (MessageBox.Show(Sender + " muốn chơi cờ Caro với bạn ", "Ok", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Chấp nhận đánh
                    DoiThuHienTai = Sender;
                    luot = true;
                    isAccept = 1;
                    isX = 1; //Đánh quân X
                    SoTranThang = 0; SoTranThua = 0;
                    ThoiGianMoiLuot = 30;
                    LSD = new List<LichSuDau>();
                    this.txtChatWith.BeginInvoke((MethodInvoker)delegate ()
                   {
                       txtChatWith.Text = DoiThuHienTai;
                   });
                    
                }
                else
                { 
                    //Từ chối đánh
                    DelegateSendValuePrivate dsmts = new DelegateSendValuePrivate(obj.SendValuePrivate);
                    dsmts.BeginInvoke(userName, Sender, 4, 0, 0, iSWin, null, new AsyncCallback(DoNothingInCallBack), null);
                }
            }
            else if (type == 4)
            {
                MessageBox.Show(Sender + " không chấp nhận chơi !");
                returnTextTo = 1;
            }
            else if (type == 5)
            {
                MessageBox.Show("không thể kết nối với : " + Msg);
                returnTextTo = 1;
            }
            else if (type == 6)
            {
                if (!Msg.Equals(Sender))
                {
                    for (int j = 0; j <= count; j++)
                    {
                        if (Msg.Equals(UserNames[j]))
                        {
                            break;
                        }
                        if (j == count)
                        {
                            UserNames[count] = Msg;
                            count++;
                            break;
                        }
                    }
                }
            }
            else if (type == 7)
            {
                AddTextToChatDisplay(Sender + " đã đánh bại " + Msg);
            }
            else if (type == 8)
            {
                MessageBox.Show("Đã thắng do đối thủ hết giờ. Click để đánh ván khác!");
                doesEnemyWin = who;
                luot = true;
            }
            else if (type == 9)
            {
                MessageBox.Show("Cố lên!");
                isFirst = 0;// trả về lượt đánh đầu tiên
                luot = true;
                ThoiGianMoiLuot = 30;
            }
        } //nhận data từ sever
        /// <summary>
        /// quản lý các button va label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtChatInput.Text != null && txtChatInput.Text.Length > 0)
            {
                AddTextToChatDisplay(userName + ": " + txtChatInput.Text);

                if (txtChatWith.Text.Equals("_SERVER", StringComparison.CurrentCultureIgnoreCase))
                {
                    //obj.SendMessageToServer(userName, txtChatInput.Text);
                }
                else
                {
                    DelegateSendValuePrivate dsmts = new DelegateSendValuePrivate(obj.SendValuePrivate);
                    if(txtChatWith.Text != "")
                    {
                        dsmts.BeginInvoke(userName, txtChatWith.Text, 0, 0, 0, iSWin, txtChatInput.Text, new AsyncCallback(DoNothingInCallBack), null);
                    } 
                    else
                    {
                        for(int i =0; i < count; i++)
                        {
                            dsmts.BeginInvoke(userName, UserNames[i], 0, 0, 0, iSWin, txtChatInput.Text, new AsyncCallback(DoNothingInCallBack), null);
                        }
                    }
                }
                txtChatInput.Clear();
            }
        }
        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                DoiThuHienTai = cbListUser.SelectedItem.ToString();
            }
            catch (Exception)
            {

            }
            TG.Visible = true;
            OK.Visible = false;
            lbEnemyName.Text = DoiThuHienTai;
            lbEnemyWin.Text = SoTranThua.ToString();
            isX = 0;// danh quan O
            reset();
            luot = false;
            DelegateSendValuePrivate dsmts = new DelegateSendValuePrivate(obj.SendValuePrivate);
            dsmts.BeginInvoke(userName, DoiThuHienTai, 3, 0, 0, iSWin, null, new AsyncCallback(DoNothingInCallBack), null);

        }
        private void txtChatInput_TextChanged(object sender, EventArgs e)
        {
            this.btnSend.BackColor = System.Drawing.Color.Ivory; // trả btn về màu trắng
        }
        delegate void AddTextToDisplayDelegate(String Cont);
        private void AddTextToChatDisplay(String Cont)
        {
            if (this.InvokeRequired)
            {
                AddTextToDisplayDelegate d = new AddTextToDisplayDelegate(AddTextToChatDisplay);
                this.Invoke(d, Cont);
            }
            else
            {
                txtChatDisplay.AppendText(Cont + Environment.NewLine);
            }
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            BanCo.Image = bmpBanCo;
        }

        private void banco_OnMouseClick(object sender, MouseEventArgs e)
        {
            if (returnTextTo == 1)
            {
                TG.Visible = false;
                OK.Visible = true;
                returnTextTo = 0;
            }
            if (isAccept == 1)
            {
                OK.Visible = false;
                lbEnemyName.Text = DoiThuHienTai;
                lbEnemyWin.Text = SoTranThua.ToString();
                isAccept = 0;
                reset();
            }
            if (luot)
            {
                if (doesEnemyWin == 0)
                {
                    draw(e.X, e.Y);
                    LSD.Add(new LichSuDau() { x = e.X, y = e.Y, who = 1 });
                    luotThu++;
                    ThoiGianMoiLuot = 30;
                    DelegateSendValuePrivate dsmts = new DelegateSendValuePrivate(obj.SendValuePrivate);
                    dsmts.BeginInvoke(userName, DoiThuHienTai, 1, (e.X), (e.Y), iSWin, null, new AsyncCallback(DoNothingInCallBack), null);
                    if (iSWin == 1)
                    {
                        iSWin = 0;
                    }
                }
                else
                {
                    if (doesEnemyWin == 2)
                    {
                        DelegateSendValuePrivate dsmts = new DelegateSendValuePrivate(obj.SendValuePrivate); // Trả thông tin về cho đối thủ
                        dsmts.BeginInvoke(userName, DoiThuHienTai, 9, 0, 0, iSWin, null, new AsyncCallback(DoNothingInCallBack), null);
                        isX = 0;
                        reset();
                        luot = false;
                        SoTranThang++;
                        lbWin.Text = SoTranThang.ToString();
                        lbEnemyWin.Text = SoTranThua.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã thua! Nhấp OK để chơi lại ván khác!");
                        SoTranThua++;
                        lbWin.Text = SoTranThang.ToString();
                        lbEnemyWin.Text = SoTranThua.ToString();
                        reset();
                        luot = true;
                        isX = 1;
                        isFirst = 0;
                    }
                }
            }
        }

        private void comboBox1_oneClick(object sender, EventArgs e)
        {
            cbListUser.Items.Clear();
            DelegateSendValuePrivate dsmts = new DelegateSendValuePrivate(obj.SendValuePrivate);
            dsmts.BeginInvoke(userName, null, 6, 0, 0, iSWin, null, new AsyncCallback(DoNothingInCallBack), null);
            for (int j = 0; j < count; j++)
                cbListUser.Items.Add(UserNames[j]);
        }
        // kết thúc quản lú các button label
        ///Bắt đầu quản lý bàn cờ
        public void draw2(int x, int y)
        {
            const int KichCo = 32;
            Graphics g = BanCo.CreateGraphics();
            int i = 0, j = 0;
            h = 0; c = 0;
            h1 = 0; c1 = 0;
            while (i < x)
            {
                h++;
                i += KichCo;
            }
            while (j < y)
            {
                c++;
                j += KichCo;
            }
            if (BanCoCaro[h, c] == 0)
            {

                if (flags == 1)
                {
                    g.DrawImage(bmpXMauVang, new Point((h - 1) * KichCo, (c - 1) * KichCo));
                    flags = 2;
                    BanCoCaro[h, c] = 1;
                    ViTriQuanCo[(h + 1), (c + 1)].luot = 1;
                }
                else
                {
                    g.DrawImage(bmpOMauVang, new Point((h - 1) * KichCo, (c - 1) * KichCo));
                    flags = 1;
                    BanCoCaro[h, c] = 2;
                    ViTriQuanCo[(h + 1), (c + 1)].luot = 0;

                }
                h1 = h + 1;
                c1 = c + 1;
                isFirst = 1;
            }
        } // Vẽ quân cờ của đối thủ

        public void reDraw(int x, int y)
        {
            const int KichCo = 32;
            Graphics g = BanCo.CreateGraphics();
            int i = 0, j = 0;
            h = 0; c = 0;
            while (i < x)
            {
                h++;
                i += KichCo;
            }
            while (j < y)
            {
                c++;
                j += KichCo;
            }
            if ((BanCoCaro[h, c] != 0))
            {
                if (flags == 1)
                {
                    g.DrawImage(bmpX, new Point((h - 1) * KichCo, (c - 1) * KichCo));
                    flags = 2;
                }
                else
                {
                    g.DrawImage(bmpO, new Point((h - 1) * KichCo, (c - 1) * KichCo));
                    flags = 1;
                }
            }
        }

        public void draw(int x, int y)
        {
            const int KichCo = 32;
            Graphics g = BanCo.CreateGraphics();
            int i = 0, j = 0;
            h = 0; c = 0;
            while (i < x)
            {
                h++;
                i += KichCo;
            }
            while (j < y)
            {
                c++;
                j += KichCo;
            }
            if (BanCoCaro[h, c] == 0)
            {
                luot = false;
                if (flags == 1)
                {
                    g.DrawImage(bmpX, new Point((h - 1) * KichCo, (c - 1) * KichCo));
                    flags = 2;
                    BanCoCaro[h, c] = 1;
                    ViTriQuanCo[(h + 1), (c + 1)].luot = 1;
                    isEndGame((h + 1), (c + 1));
                }
                else
                {
                    g.DrawImage(bmpO, new Point((h - 1) * KichCo, (c - 1) * KichCo));
                    flags = 1;
                    BanCoCaro[h, c] = 1;
                    ViTriQuanCo[(h + 1), (c + 1)].luot = 0;
                    isEndGame((h + 1), (c + 1));
                }
                if (isFirst != 0)
                {
                    if (ViTriQuanCo[h1, c1].luot == 0)
                    {
                        g.DrawImage(bmpO, new Point((h1 - 2) * KichCo, (c1 - 2) * KichCo));
                    }
                    else
                    {
                        g.DrawImage(bmpX, new Point((h1 - 2) * KichCo, (c1 - 2) * KichCo));
                    }
                }
                else
                {
                    isFirst = 1;
                    ThoiGianMoiLuot = 30;
                    TG.Visible = true;
                }
            }
        } // Vẽ quân cờ mình đánh

        private void Win()
        {
            MessageBox.Show(userName + " thắng");
            DelegateSendMessageToServer dsmts = new DelegateSendMessageToServer(obj.SendMessageToServer);
            dsmts.BeginInvoke(userName, DoiThuHienTai, new AsyncCallback(DoNothingInCallBack), null);
            SoTranThang++;
            isX = 0;
            reset();
            iSWin = 1;
            isFirst = 0;
            luot = false;
            return;
        }

        private void EnemyWin()
        {
            MessageBox.Show(DoiThuHienTai + " thắng");
            SoTranThua++;
            isX = 1;
            reset();
            iSWin = 1;
            isFirst = 0;
            return;
        }

        private void isEndGame(int cot, int hang)
        {
            int CheckLuot = ViTriQuanCo[cot, hang].luot; // kiểm tra lượt vừa rồi là X hay O
            if (KiemTraCheoPhu(cot, hang) || KiemTraCheoChinh(cot, hang) || KiemTraHangDoc(cot, hang) || KiemTraHangNgang(cot, hang))
            {
                if(CheckLuot == isX)
                {
                    Win();
                }
                else
                {
                    EnemyWin();
                }
            }
        }

        private bool KiemTraHangNgang(int cot, int hang)
        {
            int CheckLuot = ViTriQuanCo[cot, hang].luot; // kiểm tra lượt vừa rồi là X hay O
            int countLeft = 0;
            int countRight = 0;
            for(int i = cot; i > 0; i--)
            {
                if(ViTriQuanCo[i, hang].luot == CheckLuot)
                {
                    countLeft++;
                }
                else
                {
                    break;
                }
            }
            for (int i = cot+1; i <= 19; i++)
            {
                if (ViTriQuanCo[i, hang].luot == CheckLuot)
                {
                    countRight++;
                }
                else
                {
                    break;
                }
            }
            return countLeft + countRight >= 5;
        }

        private bool KiemTraHangDoc(int cot, int hang)
        {
            int CheckLuot = ViTriQuanCo[cot, hang].luot; // kiểm tra lượt vừa rồi là X hay O
            int countTop = 0;
            int countBottom = 0;
            for (int i = hang; i > 0; i--)
            {
                if (ViTriQuanCo[cot, i].luot == CheckLuot)
                {
                    countTop++;
                }
                else
                {
                    break;
                }
            }
            for (int i = hang + 1; i <= 19; i++)
            {
                if (ViTriQuanCo[cot, i].luot == CheckLuot)
                {
                    countBottom++;
                }
                else
                {
                    break;
                }
            }
            return countTop + countBottom >= 5;
        }

        private bool KiemTraCheoChinh(int cot, int hang)
        {
            int CheckLuot = ViTriQuanCo[cot, hang].luot; // kiểm tra lượt vừa rồi là X hay O
            int countTop = 0;
            int countBottom = 0;
            for (int i = 0; i <= hang; i++)
            {
                if(cot - i <= 0 || hang - i <= 0)
                {
                    break;
                }
                if (ViTriQuanCo[cot-i, hang-i].luot == CheckLuot)
                {
                    countBottom++;
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; i <= 19 - hang; i++)
            {
                if(cot + i >  19 || hang + i > 19 )
                {
                    break;
                }
                if (ViTriQuanCo[cot + i, hang + i].luot == CheckLuot)
                {
                    countTop++;
                }
                else
                {
                    break;
                }
            }
            return countTop + countBottom >= 5;
        }

        private bool KiemTraCheoPhu(int cot, int hang)
        {
            int CheckLuot = ViTriQuanCo[cot, hang].luot; // kiểm tra lượt vừa rồi là X hay O
            int countTop = 0;
            int countBottom = 0;
            for (int i = 0; i <= hang; i++)
            {
                if (cot + i > 19 || hang - i <= 0)
                {
                    break;
                }
                if (ViTriQuanCo[cot + i, hang - i].luot == CheckLuot)
                {
                    countTop++;
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; i <= 19 - hang; i++)
            {
                if (cot - i <= 0 || hang + i > 19)
                {
                    break;
                }
                if (ViTriQuanCo[cot - i, hang + i].luot == CheckLuot)
                {
                    countTop++;
                }
                else
                {
                    break;
                }
            }
            return countTop + countBottom >= 5;
        }
        private void cbListUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtChatWith.Text = cbListUser.Text;
        }

        private void ChangeTheme(Color MauNen, Color MauChu)
        {
            this.BackColor = MauNen;
            foreach (Control component in this.Controls)
            {
                if (component is Button)
                {
                    component.BackColor = MauNen;
                    component.ForeColor = MauChu;
                }
                else if (component is TextBox)
                {
                    component.BackColor = MauNen;
                    component.ForeColor = MauChu;
                }
                else if (component is Label)
                {
                    component.BackColor = MauNen;
                    component.ForeColor = MauChu;
                }
            }
        }

        bool isMoon = false;

        private void pbMoon_Click(object sender, EventArgs e)
        {
            if(!isMoon)
            {
                isMoon = true;
                pbMoon.Image = Image.FromFile("..//..//fullMoon.jpg");
                ChangeTheme(Color.Black,Color.White);
            }
            else
            {
                isMoon = false;
                pbMoon.Image = Image.FromFile("..//..//notFullMoon.jpg");
                ChangeTheme(Color.White,Color.Black);
            }
            MessageBox.Show("Thay đổi giao diện thành công! Vui lòng tải lại bàn cờ!");
        }

        private void reDrawBanCo()
        {
            int i = 0;
            flags = 1;
            
            for (i = 0; i < LSD.Count; i++)
            {
                reDraw(LSD[i].x, LSD[i].y);
            }
            try
            {
                if (LSD[0].who == 0 && luotThu%2==0)
                {
                    luot = true;
                }
            }
            catch
            {

            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            reDrawBanCo();
        }

        private void btnGiaoDien_Click(object sender, EventArgs e)
        {
            frmGiaoDien frm = new frmGiaoDien();
            frm.Show();
        }

        void reset() // khởi tạo lại bàn cờ
        {
            GC.Collect();
            LSD.Clear();
            LSD = new List<LichSuDau>();
            luotThu = 0;
            for (int i = 0; i <= 20; i++)
                for (int j = 0; j <= 20; j++)
                    ViTriQuanCo[i, j].luot = 2;
            for (int i = 0; i < 19; i++)
                for (int j = 0; j < 19; j++)
                    BanCoCaro[i, j] = 0;
            flags = 1;
            doesEnemyWin = 0;
            lbWin.Text = SoTranThang.ToString();
            lbEnemyWin.Text = SoTranThua.ToString();
            ThoiGianMoiLuot = 30;
            BanCo.Refresh();
        }

        //Đồng hồ đếm giờ
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if(ThoiGianMoiLuot==-1)
            {

            }
            else
            {
                ThoiGianMoiLuot--;
            }
            TG.Text = ThoiGianMoiLuot.ToString();
            if (ThoiGianMoiLuot == 30)
            {
                TG.ForeColor = System.Drawing.Color.Green;
            }
            if (ThoiGianMoiLuot < 15)
            {
                TG.ForeColor = System.Drawing.Color.YellowGreen;
            }
            if (ThoiGianMoiLuot < 5)
            {
                TG.ForeColor = System.Drawing.Color.Red;
            }
            if (ThoiGianMoiLuot == 0 && isFirst != 0)
            {
                if (luot)
                {
                    DelegateSendValuePrivate dsmts = new DelegateSendValuePrivate(obj.SendValuePrivate);
                    dsmts.BeginInvoke(userName, DoiThuHienTai, 8, 0, 0, 2, null, new AsyncCallback(DoNothingInCallBack), null);
                    MessageBox.Show("Hết giờ thua rồi!");
                    SoTranThua++;
                    isX = 1;
                    reset();
                    luot = false;
                }
            }
        }
        //Kết thúc đồng hồ đếm giờ
        ///Kết thúc quản lý bàn cờ caro
    }
}
