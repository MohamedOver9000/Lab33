using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace Lab3
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Employe> liste;

        static GestionBD gestionBD = null;

        


        public GestionBD()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info;Database=1939786-mohamed-amine-ben-daya;Uid=1939786;Pwd=1939786;");
            liste = new ObservableCollection<Employe>(); 
        }


        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }


        public void ajouter_employe(Employe e)
        {
            String matricule = e.Matricule;
            String nom = e.Nom;
            String prenom = e.Prenom;

            try
            {
                MySqlCommand commande = new MySqlCommand("ajouter_employe");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@matricule", matricule);
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch
            {
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        public ObservableCollection<Employe> rechercher_employeN(string name)
        {
            try
            {
                liste.Clear();

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from employe where nom = '" + name + "'";

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {

                    liste.Add(new Employe()
                    {
                        Matricule = r.GetString(0),
                        Nom = r.GetString(1),
                        Prenom = r.GetString(2)

                    });


                }


                r.Close();
                con.Close();
                return liste;

            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                return null;
            }


        }
        public ObservableCollection<Employe> rechercher_employeP(string prename)
        {
            try
            {
                liste.Clear();

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from employe where prenom = '" + prename + "'";

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {

                    liste.Add(new Employe()
                    {
                        Matricule = r.GetString(0),
                        Nom = r.GetString(1),
                        Prenom = r.GetString(2)

                    });


                }


                r.Close();
                con.Close();
                return liste;

            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                return null;
            }


        }

    }
}
