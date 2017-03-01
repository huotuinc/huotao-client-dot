using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotTao
{
    public partial class tbLogin : Form
    {

        private Main hotForm { get; set; }

        public tbLogin(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void tbLogin_Load(object sender, EventArgs e)
        {
            Loading();
        }
        private string taobaoLoginUrl = "https://login.taobao.com/member/login.jhtml?style=mini&newMini2=true&css_style=alimama&from=alimama&redirectURL=http://www.alimama.com&full_redirect=true&disableQuickLogin=true";
        public void Loading()
        {
            //webBrowser1.Navigate(taobaoLoginUrl);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string Now_Url = webBrowser1.Url.ToString();
            if (Now_Url.Contains(taobaoLoginUrl))
            {
                System.Threading.Thread.Sleep(2000);
                var usernameElement = webBrowser1.Document.GetElementById("TPL_username_1");
                var passwordElement = webBrowser1.Document.GetElementById("TPL_password_1");
                var d = webBrowser1.Document.GetElementById("J_QRCodeLogin").Style;
                if (isQROpen())
                {
                    var _loginSwitch = webBrowser1.Document.GetElementById(".login-switch");
                    if (_loginSwitch != null)
                        _loginSwitch.InvokeMember("click");

                }
                usernameElement.InnerText = hotForm.taobaoNo;
                passwordElement.SetAttribute("value", hotForm.taobaoPwd);
                var J_SubmitStatic = webBrowser1.Document.GetElementById("J_SubmitStatic");
                //if (J_SubmitStatic != null)
                //J_SubmitStatic.InvokeMember("click");


            }
        }

        private bool isQROpen()
        {
            return webBrowser1.Document.GetElementById("J_LoginBox").GetAttribute("ClassName").Equals("module-quick");
        }








        
        private void button1_Click(object sender, EventArgs e)
        {

           
            //IWebElement usernameElement = driver.FindElement(By.Id("TPL_username_1"));
            //IWebElement passwordElement = driver.FindElement(By.Id("TPL_password_1"));            
            //usernameElement.SendKeys(hotForm.taobaoNo);
            //usernameElement.SendKeys(hotForm.taobaoPwd);

        }

        //public Worker()
        //{
        //    log.Info("start up");
        //    Console.WriteLine("Console Start up");
        //    driver.Navigate().GoToUrl("https://wx.qq.com");
        //}






    }
}
