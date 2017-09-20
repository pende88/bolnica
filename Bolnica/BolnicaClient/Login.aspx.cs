using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;

using System.Web.Security;
using System.Data.SqlClient;

namespace BolnicaClient
{
    public partial class Login : System.Web.UI.Page
    {


        BolnicaService.IService1 proxy;


        protected void Page_Load(object sender, EventArgs e)
        {


            if (!this.IsPostBack)
            {
                if (this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void ValidateUser(object sender, EventArgs e)
        {

            int UserId = 0;
            string roles = String.Empty;
            try
            {
                proxy = new BolnicaService.Service1Client();
                BolnicaService.Korisnik korisnik = new BolnicaService.Korisnik();
            }
            catch(Exception ex)
            {
                throw ex;
            } 

            var kor = proxy.LoginKorisnikProvjera(Login1.UserName, Login1.Password);

            foreach(var k in kor)// tu je problem ne dobiva vrijednost
            {
                UserId = k.IDKorisnickiRacun;
                roles = k.Grupa;
                
            }

            this.Session["TrenutniKorisnik"] = UserId;


            switch (UserId)
                {
                    case -1:
                        Login1.FailureText = "Username and/or password is incorrect.";
                        break;

                    default:
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now, DateTime.Now.AddMinutes(2880), Login1.RememberMeSet, roles, FormsAuthentication.FormsCookiePath);
                        string hash = FormsAuthentication.Encrypt(ticket);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                        if (ticket.IsPersistent)
                        {
                            cookie.Expires = ticket.Expiration;
                        }
                        Response.Cookies.Add(cookie);
                        Response.Redirect(FormsAuthentication.GetRedirectUrl(Login1.UserName, Login1.RememberMeSet));
                        break;
                }
            }
        }
    
}

