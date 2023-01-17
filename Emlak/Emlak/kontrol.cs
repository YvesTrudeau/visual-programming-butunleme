using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Emlak
{
    internal class kontrol
    {
        string con = "Server=localhost;Database=emlaks;Uid=root;Pwd='';";

        public int giris(string ka, string sf)
        {
            int sonuc = 0;

            using (var baglan = new MySqlConnection(con))
            {
                using (var komut = new MySqlCommand($"SELECT ka,sf FROM ygiris WHERE ka='{ka}' AND sf='{sf}'", baglan))
                {

                    try
                    {
                        komut.Connection.Open();
                        MySqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            string k = dr["ka"].ToString();
                            string s = dr["sf"].ToString();
                            if (k == ka && s == sf)
                            {
                                sonuc = 1;
                            }
                            else
                            {
                                sonuc = 0;
                            }
                        }
                    }
                    catch (System.Exception)
                    {
                        sonuc = 0;
                    }
                    komut.Connection.Close();
                }

                if (sonuc == 0)
                {
                    using (var komut1 = new MySqlCommand($"SELECT ka,sf FROM musteri WHERE ka='{ka}' AND sf='{sf}'", baglan))
                    {
                        try
                        {
                            komut1.Connection.Open();
                            MySqlDataReader dr = komut1.ExecuteReader();
                            if (dr.Read())
                            {
                                string k = dr["ka"].ToString();
                                string s = dr["sf"].ToString();
                                if (k == ka && s == sf)
                                {
                                    sonuc = 2;
                                }
                                else
                                {
                                    sonuc = 0;
                                }
                            }
                        }
                        catch (System.Exception)
                        {
                            sonuc = 0;
                        }
                        komut1.Connection.Close();

                    }
                }
                return sonuc;
            }
        }
    }
}
