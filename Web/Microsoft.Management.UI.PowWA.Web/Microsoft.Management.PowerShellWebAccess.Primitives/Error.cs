using System;
using System.Web.UI;

namespace Microsoft.Management.PowerShellWebAccess.Primitives
{
	public class Error : Page
	{
		public Error()
		{
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			base.ViewStateUserKey = this.Session.SessionID;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			SessionHelper.TerminateSession(this.Session.SessionID, true, Resources.EventLog_UnknownError);
		}
	}
}