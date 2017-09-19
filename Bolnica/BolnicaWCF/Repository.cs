using BolnicaWCF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BolnicaWCF
{
    public class Repository
    {
        private static string _cs = System.Configuration.ConfigurationManager.ConnectionStrings["BolnicaCS"].ConnectionString;

        public List<Korisnik> LoginKorisnikProvjera(string Username, string Password)
        {

            List<Korisnik> lista = new List<Korisnik>();
            

            using (SqlConnection Sqlcon = new SqlConnection(_cs))
            {
                SqlCommand cmd = new SqlCommand("dbo.LoginKorisnik", Sqlcon);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", Username);
                cmd.Parameters.AddWithValue("@Password", Password);

                //cmd.Parameters.Add("@IsValid", SqlDbType.Int);
                //cmd.Parameters["@IsValid"].Direction = ParameterDirection.Output;

               

                Sqlcon.Open();
                
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Korisnik k = new Korisnik();
                    k.IDKorisnickiRacun = Convert.ToInt32(dr["IDKorisnickiRacun"]);
                    

                    
                    if (k.IDKorisnickiRacun != -1)
                    {
                        k.KorisnickaGrupaNaziv = dr["Naziv"].ToString();

                    }

                    lista.Add(k);
                }
                return lista;

            };


        }       
    }
}