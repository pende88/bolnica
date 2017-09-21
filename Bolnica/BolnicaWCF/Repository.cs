﻿using BolnicaWCF.Model;
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

            try
            {
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
                            k.Grupa = dr["Naziv"].ToString();

                        }

                        lista.Add(k);
                    }

                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return lista;


        }

        public List<Korisnik> GetKorisnik()
        {
            List<Korisnik> lista = new List<Korisnik>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetKorisnik", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;
          
                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Korisnik k = new Korisnik();

                        k.IDKorisnickiRacun = Convert.ToInt32(dr["IDKorisnickiRacun"]);
                        k.IDKorisnickaGrupa = Convert.ToInt32(dr["IDKorisnickaGrupa"]);
                        k.Grupa = dr["Grupa"].ToString();
                        k.Username = dr["Username"].ToString();
                        k.Password = dr["Password"].ToString();
                        k.Ime = dr["Ime"].ToString();
                        k.Prezime = dr["Prezime"].ToString();
                        k.OIB = dr["OIB"].ToString();
                        k.Telefon = dr["Telefon"].ToString();
                        k.Email = dr["Email"].ToString();
                        k.Adresa = dr["Adresa"].ToString();
                        k.PTTBroj = dr["PTTBroj"].ToString();
                        k.Grad = dr["Grad"].ToString();
                       
                        k.IDDrzava = dr["IDDrzava"] == DBNull.Value ? 0 : (int)dr["IDDrzava"];
                        k.Drzava = dr["Drzava"].ToString();


                        lista.Add(k);
                    }

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lista;
        }

        public void AddKorisnik(Korisnik k)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddKorisnik", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Username", k.Username));
                    command.Parameters.Add(new SqlParameter("@Password", k.Password));
                    command.Parameters.Add(new SqlParameter("@KorisnickaGrupaID", k.IDKorisnickaGrupa));
                    command.Parameters.Add(new SqlParameter("@Ime", k.Ime));
                    command.Parameters.Add(new SqlParameter("@Prezime", k.Prezime));
                    command.Parameters.Add(new SqlParameter("@OIB", k.OIB));
                    command.Parameters.Add(new SqlParameter("@Telefon", k.Telefon));
                    command.Parameters.Add(new SqlParameter("@Email", k.Email));
                    command.Parameters.Add(new SqlParameter("@Adresa", k.Adresa));
                    command.Parameters.Add(new SqlParameter("@Grad", k.Grad));
                    command.Parameters.Add(new SqlParameter("@PTTbroj", k.PTTBroj));
                    command.Parameters.Add(new SqlParameter("@DrzavaID", k.IDDrzava));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateKorisnik(Korisnik k)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdateKorisnik", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IDKorisnickiRacun", k.IDKorisnickiRacun));
                    command.Parameters.Add(new SqlParameter("@Username", k.Username));
                    command.Parameters.Add(new SqlParameter("@Password", k.Password));
                    command.Parameters.Add(new SqlParameter("@KorisnickaGrupaID", k.IDKorisnickaGrupa));
                    command.Parameters.Add(new SqlParameter("@Ime", k.Ime));
                    command.Parameters.Add(new SqlParameter("@Prezime", k.Prezime));
                    command.Parameters.Add(new SqlParameter("@OIB", k.OIB));
                    command.Parameters.Add(new SqlParameter("@Telefon", k.Telefon));
                    command.Parameters.Add(new SqlParameter("@Email", k.Email));
                    command.Parameters.Add(new SqlParameter("@Adresa", k.Adresa));
                    command.Parameters.Add(new SqlParameter("@Grad", k.Grad));
                    command.Parameters.Add(new SqlParameter("@PTTbroj", k.PTTBroj));
                    command.Parameters.Add(new SqlParameter("@DrzavaID", k.IDDrzava));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    
        public void DeleteKorisnik(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteKorisnik", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDKorisnickiRacun", id));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public List<Grupa> GetGrupa()
        {
            List<Grupa> lista = new List<Grupa>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetGrupa", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Grupa g = new Grupa();

                        g.IDKorisnickaGrupa = Convert.ToInt32(dr["IDKorisnickaGrupa"]);
                        g.KorisnickaGrupaNaziv = dr["Naziv"].ToString();


                        lista.Add(g);
                    }

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lista;
        }

        public List<Drzava> GetDrzava()
        {
            List<Drzava> lista = new List<Drzava>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetDrzava", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Drzava d = new Drzava();

                        d.IDDrzava = Convert.ToInt32(dr["IDDrzava"]);
                        d.Naziv = dr["Naziv"].ToString();


                        lista.Add(d);
                    }

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lista;
        }




        public List<PacijentDoktor> GetPacijentByDoktorID(int IDDoktor)
        {
            List<PacijentDoktor> lista = new List<PacijentDoktor>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetPacijentByDoktorID", Sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDDoktor", IDDoktor));
                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        PacijentDoktor pd = new PacijentDoktor();

                        pd.IDPacijentDoktorVeza = Convert.ToInt32(dr["IDPacijentDoktorVeza"]);
                        pd.DoktorKorisnickiRacunID = Convert.ToInt32(dr["DoktorKorisnickiRacunID"]);
                        pd.PacijentKorisnickiRacunID = Convert.ToInt32(dr["IDPacijenta"]);
                        pd.NazivPacijenta = dr["NazivPacijenta"].ToString();


                        lista.Add(pd);
                    }

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lista;
        }

        public void AddPacijentDoktorVeza(PacijentDoktor pd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddPacijentDoktorVeza", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@DoktorKorisnickiRacunID", pd.DoktorKorisnickiRacunID));
                    command.Parameters.Add(new SqlParameter("@PacijentKorisnickiRacunID", pd.PacijentKorisnickiRacunID));
               
                    

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdatePacijentKorisnikVeza(PacijentDoktor pd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdatePacijentKorisnikVeza", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IDPacijentDoktorVeza", pd.IDPacijentDoktorVeza));
                    command.Parameters.Add(new SqlParameter("@DoktorKorisnickiRacunID", pd.DoktorKorisnickiRacunID));
                    command.Parameters.Add(new SqlParameter("@PacijentKorisnickiRacunID", pd.PacijentKorisnickiRacunID));
                    

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletePacijentDoktorVeza(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeletePacijentDoktorVeza", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDPacijentDoktorVeza", id));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public List<Doktor> GetDoktor()
        {
            List<Doktor> lista = new List<Doktor>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetDoktor", Sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                   

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Doktor d = new Doktor();

                        d.IDKOrisnickiRacun = Convert.ToInt32(dr["IDKOrisnickiRacun"]);
                        d.NazivDoktora = dr["NazivDoktora"].ToString();
                        
                        lista.Add(d);
                    }

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lista;
        }

        public List<Pacijent> GetPacijent()
        {
            List<Pacijent> lista = new List<Pacijent>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetPacijent", Sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;


                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Pacijent p = new Pacijent();

                        p.IDKOrisnickiRacun = Convert.ToInt32(dr["IDKOrisnickiRacun"]);
                        p.NazivPacijenta = dr["NazivPacijenta"].ToString();

                        lista.Add(p);
                    }

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lista;
        }

        public List<Korisnik> GetPacijentByVeza(int id)
        {
            List<Korisnik> lista = new List<Korisnik>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetPacijentByVeza", Sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDPacijentDoktorVeza", id));
                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Korisnik k = new Korisnik();

                        k.IDKorisnickiRacun = Convert.ToInt32(dr["IDKorisnickiRacun"]);
                       
                        k.Username = dr["Username"].ToString();
                        k.Password = dr["Password"].ToString();
                        k.Ime = dr["Ime"].ToString();
                        k.Prezime = dr["Prezime"].ToString();
                        k.OIB = dr["OIB"].ToString();
                        k.Telefon = dr["Telefon"].ToString();
                        k.Email = dr["Email"].ToString();
                        k.Adresa = dr["Adresa"].ToString();
                        k.PTTBroj = dr["PTTBroj"].ToString();
                        k.Grad = dr["Grad"].ToString();

                        k.IDDrzava = dr["IDDrzava"] == DBNull.Value ? 0 : (int)dr["IDDrzava"];
                        k.Drzava = dr["Drzava"].ToString();


                        lista.Add(k);
                    }

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lista;
        }

    }

}