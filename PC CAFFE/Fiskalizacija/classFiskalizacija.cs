﻿using Raverus.FiskalizacijaDEV;
using Raverus.FiskalizacijaDEV.PopratneFunkcije;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PCPOS.Fiskalizacija
{
    internal class classFiskalizacija
    {
        private static DataTable DTfis = classSQL.select_settings("SELECT * FROM fiskalizacija", "fiskalizacija").Tables[0];
        private static DataTable DTpostavke = classSQL.select_settings("SELECT * FROM postavke", "postavke").Tables[0];

        public static string xml = "";
        public static double osnovica_sve = 0;
        public static string sifra_prodajnog_mjesta = "";

        public static string[] Fiskalizacija(string oib,
            string oib_operatera,
            DataTable DTartikli,
            DateTime datum_racuna,
            bool sustavPDV,
            int broj_rac,
            string prodajnoMJ,
            int broj_kase,
            DataTable DTpdv,
            string[] porez_na_potrosnju,
            DataTable DTostali_porezi,
            string iznososlobpdv,
            string iznos_marza,
            DataTable DTnaknade,
            decimal ukupno,
            string nacin_placanja,
            bool naknadno_poslano,
            double osnovica)
        {
            sifra_prodajnog_mjesta = prodajnoMJ;

            DataTable DTdd = classSQL.select("SELECT ime_ducana FROM ducan WHERE id_ducan='" + prodajnoMJ + "'", "ducan").Tables[0];
            if (DTdd.Rows.Count > 0)
            {
                prodajnoMJ = DTdd.Rows[0][0].ToString();
            }

            string ZkiGotov = "";
            string[] za_vratiti = new string[3];
            try
            {
                Raverus.FiskalizacijaDEV.Schema.ZaglavljeType zaglavlje = new Raverus.FiskalizacijaDEV.Schema.ZaglavljeType()
                {
                    DatumVrijeme = Razno.DohvatiFormatiranoTrenutnoDatumVrijeme(),
                    IdPoruke = Guid.NewGuid().ToString()
                };

                osnovica_sve = osnovica;

                X509Certificate2 certifikat;
                if (File.Exists(DTpostavke.Rows[0]["putanja_certifikat"].ToString()))
                {
                    certifikat = Raverus.FiskalizacijaDEV.PopratneFunkcije.Potpisivanje.DohvatiCertifikat(DTpostavke.Rows[0]["putanja_certifikat"].ToString(), DTpostavke.Rows[0]["certifikat_zaporka"].ToString());
                }
                else
                {
                    certifikat = Raverus.FiskalizacijaDEV.PopratneFunkcije.Potpisivanje.DohvatiCertifikat(DTfis.Rows[0]["naziv_certifikata"].ToString());
                }

                if (certifikat == null)
                {
                    MessageBox.Show("Nije pravilno instalirani certifikat.", "Greška");
                    return za_vratiti;
                }

                string datum_vrijeme = DateTime.Now.ToString("dd.MM.yyyyTHH:mm:ss");
                ZkiGotov = ZKI(certifikat,
                    oib,
                    datum_vrijeme,
                    broj_rac.ToString(),
                    prodajnoMJ,
                    broj_kase.ToString(),
                    ukupno.ToString("#0.00").Replace(",", "."));

                xml = @"<?xml version=""1.0"" encoding=""utf-8""?>" +
                        @"<tns:RacunZahtjev xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" Id=""signXmlId"" xmlns:tns=""http://www.apis-it.hr/fin/2012/types/f73"">" +
                                    @"<tns:Zaglavlje>" +
                                    @"<tns:IdPoruke>" + zaglavlje.IdPoruke + "</tns:IdPoruke>" +
                                    @"<tns:DatumVrijeme>" + datum_vrijeme + "</tns:DatumVrijeme>" +
                                    @"</tns:Zaglavlje>" +

                                    @"<tns:Racun>" +

                                    @"<tns:Oib>" + oib + "</tns:Oib>" +
                                    @"<tns:USustPdv>" + sustavPDV.ToString().ToLower() + "</tns:USustPdv>" +
                                    @"<tns:DatVrijeme>" + datum_racuna.ToString("dd.MM.yyyyTHH:mm:ss") + "</tns:DatVrijeme>" +
                                    @"<tns:OznSlijed>" + DTfis.Rows[0]["oznaka_slijednosti"].ToString() + "</tns:OznSlijed>" +

                                    @"<tns:BrRac>" +
                                    @"<tns:BrOznRac>" + broj_rac + "</tns:BrOznRac>" +
                                    @"<tns:OznPosPr>" + prodajnoMJ + "</tns:OznPosPr>" +
                                    @"<tns:OznNapUr>" + broj_kase + "</tns:OznNapUr>" +
                                    @"</tns:BrRac>" +

                                    PDVreturn(DTpdv, sustavPDV.ToString().ToLower()) +

                                    PorezNaPotrosnju(porez_na_potrosnju) +

                                    OstaliPorezi(DTostali_porezi) +
                                    IznosOslobPdv(iznososlobpdv) +
                                    IznosMarza(iznos_marza) +
                                    Naknade(DTnaknade) +

                                    @"<tns:IznosUkupno>" + ukupno.ToString("#0.00").Replace(",", ".") + "</tns:IznosUkupno>" +
                                    @"<tns:NacinPlac>" + nacin_placanja + "</tns:NacinPlac>" +
                                    @"<tns:OibOper>" + oib_operatera + "</tns:OibOper>" +
                                    @"<tns:ZastKod>" + ZkiGotov + "</tns:ZastKod>" +
                                    @"<tns:NakDost>" + naknadno_poslano.ToString().ToLower() + "</tns:NakDost>" +

                                    @"</tns:Racun>" +
                                    @"</tns:RacunZahtjev>";

                XmlDocument dokument = new XmlDocument();
                dokument.LoadXml(xml);

                try
                {
                    string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (!Directory.Exists(path + "/FiskalniXML"))
                        Directory.CreateDirectory(path + "/FiskalniXML");

                    dokument.Save(path + "/FiskalniXML/" + Util.Korisno.GodinaKojaSeKoristiUbazi + "-" + broj_rac + "-" + prodajnoMJ + "-" + broj_kase + ".xml");
                }
                catch { }

                Raverus.FiskalizacijaDEV.CentralniInformacijskiSustav cis = new CentralniInformacijskiSustav();
                if (Class.Postavke.TEST_FISKALIZACIJA)
                {
                    cis.CisUrl = "https://cistest.apis-it.hr:8449/FiskalizacijaServiceTest";
                }
                else
                {
                    cis.CisUrl = "https://cis.porezna-uprava.hr:8449/FiskalizacijaService";
                }
                Raverus.FiskalizacijaDEV.PopratneFunkcije.Potpisivanje.PotpisiXmlDokument(dokument, certifikat);
                Raverus.FiskalizacijaDEV.PopratneFunkcije.XmlDokumenti.DodajSoapEnvelope(ref dokument);

                try
                {
                    cis.TimeOut = 8000;

                    XmlDocument odgovor = null;

                    try
                    {
                        odgovor = cis.PosaljiSoapPoruku(dokument);
                    }
                    catch
                    {
                    }

                    if (odgovor != null)
                    {
                        string jir = Raverus.FiskalizacijaDEV.PopratneFunkcije.XmlDokumenti.DohvatiJir(odgovor);
                        za_vratiti[0] = jir;
                        za_vratiti[1] = ZkiGotov;
                        za_vratiti[2] = zaglavlje.IdPoruke;
                        return za_vratiti;
                    }
                    else
                    {
                        za_vratiti[0] = "";
                        za_vratiti[1] = ZkiGotov;
                        za_vratiti[2] = zaglavlje.IdPoruke;
                        string gr = cis.OdgovorGreska == null ? "" : cis.OdgovorGreska.ToString();
                        InsertNeuspjelaFis(broj_rac.ToString(), gr, sifra_prodajnog_mjesta, broj_kase.ToString(), oib_operatera, ukupno.ToString("#0.00").Replace(",", "."));
                        return za_vratiti;
                    }
                }
                catch (Exception ex)
                {
                    za_vratiti[0] = "";
                    za_vratiti[1] = ZkiGotov;
                    za_vratiti[2] = zaglavlje.IdPoruke;

                    string greska;
                    if (cis.OdgovorGreska != null)
                    {
                        greska = cis.OdgovorGreska.InnerXml.Replace("\'", "");

                        InsertNeuspjelaFis(broj_rac.ToString(), greska.Replace("\"", ""), sifra_prodajnog_mjesta, broj_kase.ToString(), oib_operatera, ukupno.ToString("#0.00").Replace(",", "."));
                        MessageBox.Show("Greška kod fiskalizacije\r\n\r\n\r\n" + greska.Replace("\"", "") + "\r\n\r\n\r\n\r\n\r\n", "Greška od strane FINE");
                    }
                    else
                    {
                        greska = ex.ToString().Replace("\'", "");
                        InsertNeuspjelaFis(broj_rac.ToString(), greska, sifra_prodajnog_mjesta, broj_kase.ToString(), oib_operatera, ukupno.ToString("#0.00").Replace(",", "."));
                        MessageBox.Show("Greška kod fiskalizacije\r\n\r\n\r\n" + greska.Replace("\"", ""));
                    }

                    za_vratiti[1] = ZkiGotov;
                    return za_vratiti;
                }
            }
            catch
            {
                za_vratiti[0] = "";
                za_vratiti[1] = ZkiGotov;
                za_vratiti[2] = "";
                return za_vratiti;
            }
        }

        private static void InsertNeuspjelaFis(string br_rac, string greska, string id_ducan, string id_kasa, string blagajnik, string iznos)
        {
            string sql = "INSERT INTO neuspjela_fiskalizacija (broj_racuna,xml,greska,id_ducan,id_kasa,blagajnik,iznos,date) VALUES (" +
                "'" + br_rac + "'," +
                "'" + xml + "'," +
                "'" + greska + "'," +
                "'" + DTpostavke.Rows[0]["default_ducan"].ToString() + "'," +
                "'" + DTpostavke.Rows[0]["default_blagajna"].ToString() + "'," +
                "'" + blagajnik + "'," +
                "'" + iznos + "'," +
                "'" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "'" +
                ")";
            provjera_sql(classSQL.insert(sql));
        }

        private static void provjera_sql(string str)
        {
            if (str != "")
            {
                MessageBox.Show(str);
            }
        }

        private static string PDVreturn(DataTable DTpdv, string sustavPDV)
        {
            if (sustavPDV == "false")
                return "";
            string pdv = "";

            if (DTpdv.Rows.Count > 0) { pdv = "<tns:Pdv>"; }
            foreach (DataRow row in DTpdv.Rows)
            {
                pdv = pdv + @"<tns:Porez>" +
                      @"<tns:Stopa>" + decimal.Parse(row["stopa"].ToString()).ToString("#0.00").Replace(",", ".") + "</tns:Stopa>" +
                      @"<tns:Osnovica>" + decimal.Parse(row["osnovica"].ToString()).ToString("#0.00").Replace(",", ".") + "</tns:Osnovica>" +
                      @"<tns:Iznos>" + decimal.Parse(row["iznos"].ToString()).ToString("#0.00").Replace(",", ".") + "</tns:Iznos>" +
                      @"</tns:Porez>";
            }
            if (DTpdv.Rows.Count > 0) { pdv += "</tns:Pdv>"; }
            return pdv;
        }

        private static string PorezNaPotrosnju(string[] porez)
        {
            string pnp = "";
            if (porez[2] != "0")
            {
                pnp = pnp + @"<tns:Pnp>" +
                            @"<tns:Porez>" +
                            @"<tns:Stopa>" + decimal.Parse(porez[0].ToString()).ToString("#0.00").Replace(",", ".") + "</tns:Stopa>" +
                            @"<tns:Osnovica>" + decimal.Parse(porez[1].ToString()).ToString("#0.00").Replace(",", ".") + "</tns:Osnovica>" +
                            @"<tns:Iznos>" + decimal.Parse(porez[2].ToString()).ToString("#0.00").Replace(",", ".") + "</tns:Iznos>" +
                            @"</tns:Porez>" +
                            @"</tns:Pnp>";
            }
            return pnp;
        }

        private static string OstaliPorezi(DataTable DTostali_porez)
        {
            string OstaliPor = "";
            foreach (DataRow row in DTostali_porez.Rows)
            {
                OstaliPor = OstaliPor + @"<tns:OstaliPor>" +
                                @"<tns:Porez>" +
                                @"<tns:Naziv>" + row["naziv"].ToString() + "</tns:Naziv>" +
                                @"<tns:Stopa>" + decimal.Parse(row["stopa"].ToString()).ToString("#0.00").Replace(",", ".") + "</tns:Stopa>" +
                                @"<tns:Osnovica>" + decimal.Parse(row["osnovica"].ToString()).ToString("#0.00").Replace(",", ".") + "</tns:Osnovica>" +
                                @"<tns:Iznos>" + decimal.Parse(row["iznos"].ToString()).ToString("#0.00").Replace(",", ".") + "</tns:Iznos>" +
                                @"</tns:Porez>" +
                                @"</tns:OstaliPor>";
            }
            return OstaliPor;
        }

        private static string Naknade(DataTable DTnaknade)
        {
            string naknade = "";
            foreach (DataRow row in DTnaknade.Rows)
            {
                naknade = naknade + @"<tns:Naknade>" +
                                @"<tns:Naknada>" +
                                @"<tns:NazivN>" + row["naziv"].ToString() + "</tns:NazivN>" +
                                @"<tns:IznosN>" + decimal.Parse(row["iznos"].ToString()).ToString("#0.00").Replace(",", ".") + "</tns:IznosN>" +
                                @"</tns:Naknada>" +
                                @"</tns:Naknade>";
            }
            return naknade;
        }

        private static string IznosOslobPdv(string iznos_oslob_pdv)
        {
            string OstaliPor = "";
            if (iznos_oslob_pdv != "")
            {
                OstaliPor = "<tns:IznosOslobPdv>" + decimal.Parse(iznos_oslob_pdv.ToString()).ToString("#0.00").Replace(",", ".") + "</tns:IznosOslobPdv>";
            }
            return OstaliPor;
        }

        private static string IznosMarza(string iznos_marza)
        {
            string neka_marza = "";
            if (iznos_marza != "")
            {
                neka_marza = "<tns:IznosMarza>" + decimal.Parse(iznos_marza.ToString()).ToString("#0.00").Replace(",", ".") + "</tns:IznosMarza>";
            }
            return neka_marza;
        }

        public static string ComputeHash(byte[] objectAsBytes)
        {
            //MD5 md5 =  new MD5CryptoServiceProvider();
            MD5 md5 = MD5.Create();
            try
            {
                byte[] result = md5.ComputeHash(objectAsBytes);

                // Build the final string by converting each byte
                // into hex and appending it to a StringBuilder
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    sb.Append(result[i].ToString("x2"));
                }

                // And return it
                return sb.ToString();
            }
            catch
            {
                //If something occurred during serialization,
                //this method is called with a null argument.
                MessageBox.Show("Hash has not been generated.");
                return null;
            }
        }

        private static string ZKI(X509Certificate2 certifikat, string oibObveznika, string datumVrijemeIzdavanjaRacuna, string brojcanaOznakaRacuna, string oznakaPoslovnogProstora, string oznakaNaplatnogUredaja, string ukupniIznosRacuna)
        {
            string zastitniKod;

            StringBuilder sb = new StringBuilder();
            sb.Append(oibObveznika);
            sb.Append(datumVrijemeIzdavanjaRacuna);
            sb.Append(brojcanaOznakaRacuna);
            sb.Append(oznakaPoslovnogProstora);
            sb.Append(oznakaNaplatnogUredaja);
            sb.Append(ukupniIznosRacuna.Replace(',', '.'));

            byte[] by = Potpisivanje.PotpisiTekst(sb.ToString(), certifikat);

            if (by != null)
                zastitniKod = ComputeHash(by);
            else
                zastitniKod = "";

            return zastitniKod;
        }
    }
}