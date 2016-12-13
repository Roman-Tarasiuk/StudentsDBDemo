using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClient.WindowsForms
{
    public partial class AuthenticationForm : Form
    {
        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        public static extern bool LogonUser(string userName, string domainName, string password, int LogonType, int LogonProvider, ref IntPtr phToken);

        private bool m_EnableClose = false;

        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isValid = IsValidateCredentials(txtLogin.Text, txtPassword.Text, txtDomain.Text);

            if (isValid)
            {
                m_EnableClose = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_EnableClose = true;
            this.Close();
        }

        private static bool IsValidateCredentials(string userName, string password, string domain)
        {
            IntPtr tokenHandler = IntPtr.Zero;
            bool isValid = LogonUser(userName, domain, password, 2, 0, ref tokenHandler);
            return isValid;
        }

        private void AuthenticationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_EnableClose)
            {
                e.Cancel = true;
            }
        }
    }
}
