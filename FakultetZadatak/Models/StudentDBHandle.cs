using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FakultetZadatak.Models
{
    public class StudentDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Fakultetconn"].ToString();
            con = new SqlConnection(constring);
        }

     
        public bool DodajStudenta(Student student)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DodajStudenta", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@godina_studija",student.godina_studija);
            cmd.Parameters.AddWithValue("@grupa_id", student.grupa_id);
            cmd.Parameters.AddWithValue("@Ime_i_prezime", student.Ime_i_prezime);
            cmd.Parameters.AddWithValue("@datum_rodjenja",student.datum_rodjenja);
            cmd.Parameters.AddWithValue("@Grad", student.Grad);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        
        public List<Student> VratiStudente()
        {
            connection();
            List<Student> listaStudenata = new List<Student>();

            SqlCommand cmd = new SqlCommand("VratiStudente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                listaStudenata.Add(
                    new Student
                    {
                        bi = Convert.ToInt32(dr["bi"]),
                        godina_studija = Convert.ToInt32(dr["godina_studija"]),
                        grupa_id = Convert.ToInt32(dr["grupa_id"]),
                        Ime_i_prezime = Convert.ToString(dr["Ime_i_prezime"]),
                        datum_rodjenja = Convert.ToDateTime(dr["datum_rodjenja"]),
                        Grad = Convert.ToString(dr["Grad"])
                    });
            }
            return listaStudenata;
        }

        
        public bool UpdateStudenta(Student student)
        {
            connection();
            SqlCommand cmd = new SqlCommand("IzmenaStudenta", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bi", student.bi);
            cmd.Parameters.AddWithValue("@godina_studija", student.godina_studija);
            cmd.Parameters.AddWithValue("@grupa_id", student.grupa_id);
            cmd.Parameters.AddWithValue("@Ime_i_prezime", student.Ime_i_prezime);
            cmd.Parameters.AddWithValue("@datum_rodjenja", student.datum_rodjenja);
            cmd.Parameters.AddWithValue("@Grad",student.Grad);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        
        public bool BrisanjeStudenta(int bi)
        {
            connection();
            SqlCommand cmd = new SqlCommand("BrisanjeStudenta", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@bi", bi);

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