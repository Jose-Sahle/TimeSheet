using SHL.Utils;
using SHL.TokenSecurity;
using System;
using System.Windows.Forms;

namespace TokenSecurityTest
{
    public partial class frmPrincipal : Form
    {
        #region "Eventos"
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void cmdGerarHash_Click(object sender, EventArgs e)
        {
            GetHash();
        }

        private void cmdSolicitarToken_Click(object sender, EventArgs e)
        {
            GetTokenSecurity();
        }

        private void cmdValidar_Click(object sender, EventArgs e)
        {
            Validar();
        }
        #endregion

        #region "Metodos Privados"
        private void GetHash()
        {
            txtHash.Text = String.Empty;
            txtToken.Text = String.Empty;

            try
            {
                if (txtCredencial.Text == String.Empty)
                    new Exception("Informe a 'Credencial'");

                if (txtURL.Text == String.Empty)
                    new Exception("Informa a URL");

                txtHash.Text = TokenKey.GetCryptMessage(txtCredencial.Text.Trim(), txtURL.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetTokenSecurity()
        {
            try
            {
                txtHash.Text = String.Empty;
                txtToken.Text = String.Empty;
                txtValidar.Text = String.Empty;
                txtKey.Text = String.Empty;
                lblAccess.Text = String.Empty;

                if (txtURITokenSecurity.Text == String.Empty)
                    new Exception("Informe a 'URI Token Security'");

                if (txtCredencial.Text == String.Empty)
                    new Exception("Informe a 'Credencial'");

                if (txtURL.Text == String.Empty)
                    new Exception("Informa a URL");

                txtHash.Text = TokenKey.GetCryptMessage(txtCredencial.Text.Trim(), txtURL.Text.Trim());

                if (!txtURITokenSecurity.Text.EndsWith("/"))
                    txtURITokenSecurity.Text += "/";

                if(txtHash.Text != String.Empty)
                {
                    txtToken.Text = (String)Util.ControllerSelectEx<String>(String.Format("{0}api/",txtURITokenSecurity.Text), "TokenSecurity", "GetTokenSecurity", "key", txtHash.Text.Trim());

                    txtKey.Text = TokenKey.GetCryptMessage(String.Format("{0}|{1}", txtCredencial.Text.Trim(), txtToken.Text.Trim()), txtURL.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Validar()
        {
            try
            {
                if (!txtURITokenSecurity.Text.EndsWith("/"))
                    txtURITokenSecurity.Text += "/";

                if (txtKey.Text != String.Empty)
                {
                    txtValidar.Text = (String)Util.ControllerSelectEx<String>(String.Format("{0}api/", txtURITokenSecurity.Text), "TokenSecurity", "GetTestAccess", "key", txtKey.Text);

                    lblAccess.Text = ((Boolean)Util.ControllerSelectEx<Boolean>(String.Format("{0}api/", txtURITokenSecurity.Text), "TokenSecurity", "GetAccess", "key", txtKey.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
