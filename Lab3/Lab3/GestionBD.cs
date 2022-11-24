﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Lab3
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Employe> liste ;
        ObservableCollection<Projet> liste1;
        static GestionBD gestionBD = null;

        


        public GestionBD()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info;Database=1939786-mohamed-amine-ben-daya;Uid=1939786;Pwd=1939786;");
            liste = new ObservableCollection<Employe>();
            liste1 = new ObservableCollection<Projet>();
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

        public void ajouter_projet(Projet p)
        {
            string numero = p.Numero;
            DateTime debut = p.Debut;
            int budget = p.Budget;
            string description = p.Description;
            string employe = p.Employe;


            try
            {
                MySqlCommand commande = new MySqlCommand("ajouter_projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@numero", numero);
                commande.Parameters.AddWithValue("@debut", debut);
                commande.Parameters.AddWithValue("@budget", budget);
                commande.Parameters.AddWithValue("@description", description);
                commande.Parameters.AddWithValue("@employe", employe);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
