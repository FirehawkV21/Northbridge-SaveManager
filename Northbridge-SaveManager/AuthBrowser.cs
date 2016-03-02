using System;
using System.Windows.Forms;

namespace NorthbridgeSubSystem
{
    public partial class AuthBrowser : Form
    {
        private string AccessToken
        {
            get { return _accessToken; }
            set { _accessToken = value; }
        }
        private string _accessToken = string.Empty;

        private const string Scope = "wl.skydrive_update";

        // Remember to change this to your ClientID, this one will be
        // invalid by the time this is published
        private const string ClientId = "0000000000000000";

        private const string SignInUrl = @"https://login.live.com/
         oauth20_authorize.srf?client_id={0}&redirect_uri=
         https://login.live.com/oauth20_desktop.srf&response_type=
         token&scope={1}";
        private Timer _closeTimer;
        public AuthBrowser()
        {
            InitializeComponent();
            StartAuthenticationProcess();
        }
        private void StartAuthenticationProcess()
        {
            webBrowser1.DocumentCompleted +=
               AuthenticationBrowserDocumentCompleted;
            webBrowser1.Navigate(string.Format
               (SignInUrl, ClientId, Scope));
        }

        private void AuthenticationBrowserDocumentCompleted(object sender,
           WebBrowserDocumentCompletedEventArgs e)
        {
            if (!e.Url.AbsoluteUri.Contains("#access_token=")) return;
            var x = e.Url.AbsoluteUri.Split(new[]
            { "#access_token" }, StringSplitOptions.None);
            AccessToken = x[1].Split(new[] { '&' })[0];
            _closeTimer = new Timer { Interval = 500 };
            _closeTimer.Tick += CloseTimerTick;
            _closeTimer.Enabled = true;
        }

        private void CloseTimerTick(object sender, EventArgs e)
        {
            _closeTimer.Enabled = false;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void AuthBrowser_Load(object sender, EventArgs e)
        {

        }
    }
}
