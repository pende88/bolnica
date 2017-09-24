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
                       
                        k.DrzavaID = dr["IDDrzava"] == DBNull.Value ? 0 : (int)dr["IDDrzava"];
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
                    command.Parameters.Add(new SqlParameter("@DrzavaID", k.DrzavaID));

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
                    command.Parameters.Add(new SqlParameter("@IDDrzava", k.DrzavaID));

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
                        
                        k.DrzavaID = Convert.ToInt32(dr["DrzavaID"].ToString());
                        


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

                    command.Parameters.Add(new SqlParameter("@NazivProizvodjac", d.Naziv));
                    

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

        public void AddDrzava(Drzava d)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddDrzava", conn);
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

        public void UpdateDrzava(Drzava d)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdateDrzava", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IDDrzava", d.IDDrzava));
                    command.Parameters.Add(new SqlParameter("@Naziv", d.Naziv));


                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void DeleteDrzava(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteDrzava", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDDrzava", id));
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

                        l.IDLijek = Convert.ToInt32(dr["IDLijek"]);
                        l.NazivLijeka = dr["NazivLijeka"].ToString();
                        l.BrojOdobrenja = dr["BrojOdobrenja"].ToString();
                        l.ProizvodjacID = Convert.ToInt32(dr["ProizvodjacID"]);
                        l.ProizvodjacNaziv = dr["NazivProizvodjaca"].ToString();


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

        public void UpdateLijek(Lijek l)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdateLijek", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IDLijek", l.IDLijek));
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
                        b.OpasnostID = Convert.ToInt32(dr["OpasnostBolestiID"]);
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


                    command.Parameters.Add(new SqlParameter("@Naziv", b.NazivBolesti));
                    command.Parameters.Add(new SqlParameter("@GodinaOtkrica", b.GodinaOtkrica));
                    command.Parameters.Add(new SqlParameter("@OpasnostBolestiID", b.OpasnostID));

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
                    command.Parameters.Add(new SqlParameter("@Naziv", b.NazivBolesti));
                    command.Parameters.Add(new SqlParameter("@GodinaOtkrica", b.GodinaOtkrica));
                    command.Parameters.Add(new SqlParameter("@OpasnostBolestiID", b.OpasnostID));

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

        public List<OpasnostBolesti> GetOpasnostBolesti()
        {
            List<OpasnostBolesti> lista = new List<OpasnostBolesti>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetOpasnost", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OpasnostBolesti ob = new OpasnostBolesti();

                       ob.IDOPasnost = Convert.ToInt32(dr["IDOpasnostBolesti"]);
                        ob.Opasnost = dr["Naziv"].ToString();
                       
                        lista.Add(ob);
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;


        }




        public List<Terapija> GetTerapija()
        {
            List<Terapija> lista = new List<Terapija>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetTerapija", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Terapija t = new Terapija();

                        t.IDTerapija= Convert.ToInt32(dr["IDTerapija"]);
                        t.Naziv= dr["Naziv"].ToString();
                        t.BolestID= Convert.ToInt32(dr["BolestID"]);
                        t.NazivBolesti = dr["NazivBolesti"].ToString();
                        t.DaniTrajanja= Convert.ToInt32(dr["DaniTrajanja"]);


                        lista.Add(t);
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;


        }

        public void AddTerapija(Terapija t)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddTerapija", conn);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@BolestID", t.BolestID));
                    command.Parameters.Add(new SqlParameter("@Naziv", t.Naziv));
                    command.Parameters.Add(new SqlParameter("@DaniTrajanja", t.DaniTrajanja));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateTerapija(Terapija t)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdateTerapija", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IDTerapija", t.IDTerapija));
                    command.Parameters.Add(new SqlParameter("@BolestID", t.BolestID));
                    command.Parameters.Add(new SqlParameter("@Naziv", t.Naziv));
                    command.Parameters.Add(new SqlParameter("@DaniTrajanja", t.DaniTrajanja));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteTerapija(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteTerapija", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDTerapija", id));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Bolest> GetBolestiDDL()
        {
            List<Bolest> lista = new List<Bolest>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetBolestiDDL", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Bolest b = new Bolest();

                       b.IDBolest= Convert.ToInt32(dr["IDBolest"]);
                        b.NazivBolesti= dr["Naziv"].ToString();


                        lista.Add(b);
                    }

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lista;
        }

        public List<Lijek> GetLijekDDL()
        {
            List<Lijek> lista = new List<Lijek>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetLijekDDL", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Lijek l = new Lijek();

                        l.IDLijek = Convert.ToInt32(dr["IDLijek"]);
                        l.NazivLijeka = dr["Naziv"].ToString();


                        lista.Add(l);
                    }

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lista;
        }



        public List<TerapijaLijek> GetLijekByTerapija(int id)
        {
            List<TerapijaLijek> lista = new List<TerapijaLijek>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetLijekByTerapija", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDTerapija", id));

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TerapijaLijek tl = new TerapijaLijek();

                        tl.IDTerapijaLijek = Convert.ToInt32(dr["IDTerapijaLijekVeza"]);
                        tl.TerapijaID = Convert.ToInt32(dr["TerapijaID"]);
                        tl.LijekID= Convert.ToInt32(dr["LijekID"]);
                        tl.NazivLijeka = dr["NazivLijeka"].ToString();


                        lista.Add(tl);
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;


        }

        public void AddTerapijaLijek(TerapijaLijek tl)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddTerapijaLijekVeza", conn);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@TerapijaID", tl.TerapijaID));
                    
                    command.Parameters.Add(new SqlParameter("@LijekID", tl.LijekID));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateTerapijaLijek(TerapijaLijek tl)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdateTerapijaLijeVeza", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IDTerapijaLijekVeza", tl.IDTerapijaLijek));
                    command.Parameters.Add(new SqlParameter("@TerapijaID", tl.TerapijaID));
                    command.Parameters.Add(new SqlParameter("@LijekID", tl.LijekID));


                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteTerapijaLijek(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteTerijapijaLijekVeza", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDTerapijaLijekVeza", id));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public List<PlanTerapije> GetPlanTerapije(int id)
        {
            List<PlanTerapije> lista = new List<PlanTerapije>();

            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetPlanTerapije", Sqlcon);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Pacijent", id));

                    Sqlcon.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        PlanTerapije pt = new PlanTerapije();

                        pt.IDPlantTerapije= Convert.ToInt32(dr["IDPlantTerapije"]);
                        pt.DoktorID = Convert.ToInt32(dr["DoktorID"]);
                        pt.PacijentID= Convert.ToInt32(dr["PacijentID"]);
                        pt.TerapijaID= Convert.ToInt32(dr["TerapijaID"]);

                        pt.NazivTerapije = dr["Naziv"].ToString();
                        pt.DatumPocetka = Convert.ToDateTime(dr["DatumPocetka"]);
                        pt.DatumZavrsetka= Convert.ToDateTime(dr["DatumPocetka"]);
                                                                         

                        lista.Add(pt);
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;


        }

        public void AddPlanTerapije(PlanTerapije pt)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddPlanTerapije", conn);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@DoktorID", pt.DoktorID));
                    command.Parameters.Add(new SqlParameter("@PacijentID", pt.PacijentID));
                    command.Parameters.Add(new SqlParameter("@TerapijaID", pt.TerapijaID));
                    command.Parameters.Add(new SqlParameter("@DatumPocetka", pt.DatumPocetka));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdatePlanTerapije(PlanTerapije pt)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdatePlanTerapije", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IDPlanTerapije", pt.IDPlantTerapije));
                    command.Parameters.Add(new SqlParameter("@DoktorID", pt.DoktorID));
                    command.Parameters.Add(new SqlParameter("@PacijentID", pt.PacijentID));
                    command.Parameters.Add(new SqlParameter("@TerapijaID", pt.TerapijaID));
                    command.Parameters.Add(new SqlParameter("@DatumPocetka", pt.DatumPocetka));


                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletePlanTerapije(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeletePlanTerapije", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDPlanTerapije", id));
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