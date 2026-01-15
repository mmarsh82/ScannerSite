using System;
using System.Web.UI;

namespace ScannerSite
{
    public partial class Main : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            actionSignOut.Visible = !string.IsNullOrEmpty(lblName.Text);
            actionProdQuery.Visible = Session["ProductId"] != null;
        }

        public void ChangeState(Actions name, bool state)
        {
            switch (name)
            {
                case Actions.query:
                    actionProdQuery.Visible = state;
                    break;
                case Actions.home:
                    actionHome.Visible = state;
                    break;
            }
        }
    }
}
