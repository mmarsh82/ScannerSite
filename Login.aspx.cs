using System;
using System.DirectoryServices.AccountManagement;
using System.Web.Security;
using System.Web.UI;

namespace ScannerSite
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            ((Main)Master).lblName.Text = "";
            ((Main)Master).lblSite.Text = "";
            Session["ProductType"] = null;
            Session["ProductNumber"] = null;
            Session["ProductId"] = null;
            txtUser.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!txtUser.Text.Contains("_FA"))
            {
                try
                {
                    try
                    {
                        var _test = Membership.ValidateUser($"{txtUser.Text}@contiwan.com", txtPassword.Text);
                    }
                    catch (Exception ex)
                    {
                        lblLoginFailure.Visible = true;
                        lblLoginFailure.Text = ex.Message;
                        lblLoginFailure.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (Membership.ValidateUser($"{txtUser.Text}@contiwan.com", txtPassword.Text))
                    {
                        var _displayName = string.Empty;
                        using (var _pc = new PrincipalContext(ContextType.Domain))
                        {
                            using (var _prin = UserPrincipal.FindByIdentity(_pc, $"{txtUser.Text}@contiwan.com"))
                            {
                                _displayName = $"{_prin.Surname}, {_prin.GivenName}";
                            }
                        }
                        if (!string.IsNullOrEmpty(_displayName))
                        {
                            FormsAuthentication.SetAuthCookie(_displayName, true);
                            FormsAuthentication.RedirectFromLoginPage(_displayName, true);
                        }
                        else
                        {
                            lblLoginFailure.Visible = true;
                            lblLoginFailure.Text = "Account not found.";
                            lblLoginFailure.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        var _user = Membership.GetUser($"{txtUser.Text}@contiwan.com");
                        if (_user == null)
                        {
                            lblLoginFailure.Visible = true;
                            lblLoginFailure.Text = "Invalid Account.";
                            lblLoginFailure.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (_user.IsLockedOut)
                        {
                            lblLoginFailure.Visible = true;
                            lblLoginFailure.Text = "Account is Locked.";
                            lblLoginFailure.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (_user.IsApproved == false)
                        {
                            lblLoginFailure.Visible = true;
                            lblLoginFailure.Text = "Account is disabled.";
                            lblLoginFailure.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            txtPassword.Text = "";
                            lblLoginFailure.Visible = true;
                            lblLoginFailure.Text = "Invalid credentials.";
                            lblLoginFailure.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                catch (Exception)
                {
                    lblLoginFailure.Visible = true;
                    lblLoginFailure.Text = "Account does not exist.";
                    lblLoginFailure.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
