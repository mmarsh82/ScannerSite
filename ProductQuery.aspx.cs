using M2kClient;
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace ScannerSite
{
    public partial class ProductQuery : Page
    {
        /// <summary>
        /// Page Constructor
        /// </summary>
        /// <param name="sender">sending page</param>
        /// <param name="e">passed page arguements</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
                ((Main)Master).lblNameHeader.Text = "Name:";
                ((Main)Master).lblName.Text = HttpContext.Current.User.Identity.Name;
                ((Main)Master).lblSite.Text = "Site: Wahpeton (01)";
            }
            if (Session["ProductNumber"] != null)
            {
                lblPartNumberData.Text = Session["ProductNumber"].ToString();
                lblReturnId.Text = Session["ProductId"].ToString();
                lblReturnType.Text = Session["ProductType"].ToString() == "PN" ? "nLot" : "Lot";
                using (DataTable _dt = SQLCommand.GetProductTable(lblPartNumberData.Text, lblReturnType.Text))
                {
                    if (_dt == null || _dt.Rows.Count == 0)
                    {
                        //TODO: add in error handling
                    }
                    else
                    {
                        gvProduct.DataSource = _dt;
                        gvProduct.DataBind();
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Default.aspx");
        }
    }
}
