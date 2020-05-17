using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FakultetZadatak.Models
{
    public class IspitDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Fakultetconn"].ToString();
            con = new SqlConnection(constring);
        }

        
        public bool DodajIspit(Ispit ispit)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DodajIspit", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@bi", ispit.bi);
            cmd.Parameters.AddWithValue("@predmet_id", ispit.predmet_id);
            cmd.Parameters.AddWithValue("@ocena", ispit.ocena);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        
        public List<Ispit> VratiIspite()
        {
            connection();
            List<Ispit> ispiti = new List<Ispit>();

            SqlCommand cmd = new SqlCommand("VratiIspite", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ispiti.Add(
                    new Ispit
                    {
                        id = Convert.ToInt32(dr["id"]),
                        bi = Convert.ToInt32(dr["bi"]),
                        predmet_id = Convert.ToInt32(dr["predmet_id"]),
                        ocena = Convert.ToInt32(dr["ocena"])
                    });
            }
            return ispiti;
        }

        
        public bool UpdateIspita(Ispit ispit)
        {
            connection();
            SqlCommand cmd = new SqlCommand("IzmenaIspita", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", ispit.id);
            cmd.Parameters.AddWithValue("@bi", ispit.bi);
            cmd.Parameters.AddWithValue("@predmet_id", ispit.predmet_id);
            cmd.Parameters.AddWithValue("@ocena", ispit.ocena);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        
        public bool DeleteIspita(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("BrisanjeIspita", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}