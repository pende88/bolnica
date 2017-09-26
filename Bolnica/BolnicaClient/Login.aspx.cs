﻿using System;
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

            //ovdje ubaciti logiku provjere cookia



            int UserId=0;
            string roles= String.Empty;
            string prezime= String.Empty;



            
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

            foreach(var k in kor)
            {
                UserId = k.IDKorisnickiRacun;
                roles = k.Grupa;
                prezime = k.Prezime;
                
            }

            this.Session["TrenutniKorisnik"] = UserId;
            this.Session["Prezime"] = prezime;


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


                    //HttpCookie podaciKorisnika = new HttpCookie("userInfo");
                    //podaciKorisnika["UserId"] = UserId;
                    //podaciKorisnika["prezime"] = prezime;
                    //podaciKorisnika["username"] = userName;
                    //podaciKorisnika["password"] = paswword;

                    Response.Cookies.Add(cookie);
                    // ovdje eventualno možemo odrediti gdje želimo da role ode nakon login-a
                        Response.Redirect(FormsAuthentication.GetRedirectUrl(Login1.UserName, Login1.RememberMeSet));
                        break;
                }
            }
        }
    
}

