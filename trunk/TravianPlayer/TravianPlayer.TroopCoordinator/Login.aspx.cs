﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace TravianPlayer.TroopCoordinator
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
            FormsAuthentication.RedirectFromLoginPage("jeza", true);
        }

        protected void LinkButtonRegister_Click(object sender, EventArgs e)
        {

        }
	}
}