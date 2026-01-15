using M2kClient;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace ScannerSite
{
    public partial class Container : Page
    {
        #region Properties

        private int ContainerId { get; set; }

        #endregion


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
                ((Main)Master).ChangeState(Actions.home, true);
                tbLocationData.Visible = false;
                lblLocationHeader.Visible = false;
                if (Session["ProductId"] != null)
                {
                    Session["ContainerId"] = Session["ProductId"];
                    Session["ProductId"] = null;
                    ContainerId = int.TryParse(Session["ContainerId"].ToString(), out int i) ? i : 1;
                }
            }
        }

        #region Page Interaction Event Code

        /// <summary>
        /// View event for the container page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) || string.IsNullOrEmpty(((Main)Master).lblName.Text))
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                
            }
        }

        /// <summary>
        /// Add product event for the container page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) || string.IsNullOrEmpty(((Main)Master).lblName.Text))
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {

            }
        }

        /// <summary>
        /// Remove product event for the container page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) || string.IsNullOrEmpty(((Main)Master).lblName.Text))
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {

            }
        }

        /// <summary>
        /// Move container event for the container page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) || string.IsNullOrEmpty(((Main)Master).lblName.Text))
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {

            }
        }

        #endregion
    }
}
