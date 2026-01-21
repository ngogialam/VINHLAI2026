using System;
using System.Web;
using System.Web.Security;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Session.RemoveAll();

        HttpCookie aCookie;
        string cookieName;
        int limit = Request.Cookies.Count;
        for (int i = 0; i < limit; i++)
        {
            cookieName = Request.Cookies[i].Name;
            aCookie = new HttpCookie(cookieName);
            aCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(aCookie);
        }
        Response.Redirect("Login.aspx");
    }
}