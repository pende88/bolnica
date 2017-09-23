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
                       
                        k.IDProizvodjac = dr["IDProizvodjac"] == DBNull.Value ? 0 : (int)dr["IDProizvodjac"];
                        k.Proizvodjac = dr["Proizvodjac"].ToString();


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
                    command.Parameters.Add(new SqlParameter("@ProizvodjacID", k.IDProizvodjac));

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
                    command.Parameters.Add(new SqlParameter("@ProizvodjacID", k.IDProizvodjac));

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
                    cmd.Parameters.Add(new SqlParameter("@PacijentKorisnickiRacunID", id));
                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Korisnik k = new Korisnik();

                        k.IDKorisnickiRacun = Convert.ToInt32(dr["PacijentKorisnickiRacunID"]);
                       
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
                        
                        k.IDProizvodjac = Convert.ToInt32(dr["ProizvodjacID"].ToString());
                        


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


        public List<Proizvodjac> GetProizvodjac()
        {
            List<Proizvodjac> lista = new List<Proizvodjac>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetProizvodjac", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Proizvodjac pr = new Proizvodjac();

                        pr.IDProizvodjac = Convert.ToInt32(dr["IDProizvodjac"]);
                        pr.Naziv = dr["Naziv"].ToString();


                        lista.Add(pr);
                    }

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lista;
        }

        public void AddProizvodjac  (Proizvodjac d)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddProizvodjac", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Naziv", d.Naziv));
                    

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateProizvodjac(Proizvodjac p)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdateProizvodjac", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IDProizvodjac", p.IDProizvodjac));
                    command.Parameters.Add(new SqlParameter("@Naziv", p.Naziv));
                   

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void DeleteProizvodjac(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteProizvodjac", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDProizvodjac", id));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        public List<Lijek> GetLijek()
        {
            List<Lijek> lista = new List<Lijek>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetLijek", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Lijek l = new Lijek();

                        l.IDLIjek = Convert.ToInt32(dr["IDLijek"]);
                        l.NazivLijeka = dr["NazivLijeka"].ToString();
                        l.BrojOdobrenja = dr["BrojOdobrenja"].ToString();
                        l.ProizvodjacID = Convert.ToInt32(dr["ProizvodjacID"]);


                        lista.Add(l);
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;


        }

        public void AddLijek(Lijek l)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddLijek", conn);
                    command.CommandType = CommandType.StoredProcedure;

                   
                    command.Parameters.Add(new SqlParameter("@Naziv", l.NazivLijeka));
                    command.Parameters.Add(new SqlParameter("@GodinaOdobrenja", l.BrojOdobrenja));
                    command.Parameters.Add(new SqlParameter("@ProizvodjacID", l.ProizvodjacID));
                    
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateLijek(Lijek l)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdateLijek", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IDLijek", l.IDLIjek));
                    command.Parameters.Add(new SqlParameter("@Naziv", l.NazivLijeka));
                    command.Parameters.Add(new SqlParameter("@BrojOdobrenja", l.BrojOdobrenja));
                    command.Parameters.Add(new SqlParameter("@ProizvodjacID", l.ProizvodjacID));
                    
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteLijek(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteLijek", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDLijek", id));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }





        public List<Bolest> GetBolest()
        {
            List<Bolest> lista = new List<Bolest>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetBolest", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Bolest b = new Bolest();

                        b.IDBolest= Convert.ToInt32(dr["IDBolest"]);
                        b.NazivBolesti= dr["NazivBolesti"].ToString();
                        b.GodinaOtkrica = Convert.ToInt32(dr["GodinaOtkrica"]);
                        b.OpasnostID = Convert.ToInt32(dr["OpasnostID"]);
                        b.Opasnost= dr["Opasnost"].ToString();
                        lista.Add(b);
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;


        }

        public void AddBolest(Bolest b)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddBolest", conn);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@NazivBolest", b.NazivBolesti));
                    command.Parameters.Add(new SqlParameter("@GodinaOtkrica", b.GodinaOtkrica));
                    command.Parameters.Add(new SqlParameter("@OpasnostID", b.OpasnostID));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateBolest(Bolest b)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdateBolest", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IDBolest", b.IDBolest));
                    command.Parameters.Add(new SqlParameter("@NazivBolest", b.NazivBolesti));
                    command.Parameters.Add(new SqlParameter("@GodinaOtkrica", b.GodinaOtkrica));
                    command.Parameters.Add(new SqlParameter("@OpasnostID", b.OpasnostID));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteBolest(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteBolest", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDBolest", id));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

}