using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebCrudNotas.Models
{
    public class AlumnoDAO
    {
        string conex = "database=bdAlumno; pwd=castro; uid=sa;server=(local)";

        public List<Alumno> lisAlumno()
        {
            List<Alumno> lista = new List<Alumno>();
            string sql = "select * from alumno";
            SqlConnection cn = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader(); 
            while (dr.Read())
            {
                Alumno a = new Alumno();
                a.codigo = dr.GetInt32(0);
                a.nombres = dr.GetString(1);
                a.nota1 = dr.GetInt32(2);
                a.nota2 = dr.GetInt32(3);
                lista.Add(a);
            }
            cn.Close();
            return lista;
        }

        public int Agregar(Alumno a)
        {
            int res = 0;
            SqlConnection cn = new SqlConnection(conex);
            string sql = "insert into alumno values(@nom,@nota1,@nota2)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@nom", a.nombres);
            cmd.Parameters.AddWithValue("@nota1", a.nota1);
            cmd.Parameters.AddWithValue("@nota2", a.nota2);
            cn.Open();
            res = cmd.ExecuteNonQuery();
            cn.Close();
            return res;
        }

        public Alumno ObtenerPorId(int codigo)
        {
            Alumno a = null;
            string sql = "select * from alumno where codigo = @code";
            SqlConnection cn = new SqlConnection(conex);
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@code" , codigo);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                a = new Alumno();
                a.codigo = dr.GetInt32(0);
                a.nombres = dr.GetString(1);
                a.nota1 = dr.GetInt32(2);
                a.nota2 = dr.GetInt32(3);
            }
            cn.Close();
            return a;
        }

        public int Modificar(Alumno a)
        {
            int res = 0;
            SqlConnection cn = new SqlConnection(conex);
            string sql = "update alumno set nombres = @nom, nota1 = @nota1, nota2 = @nota2 where codigo = @code";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@nom", a.nombres);
            cmd.Parameters.AddWithValue("@nota1", a.nota1);
            cmd.Parameters.AddWithValue("@nota2", a.nota2);
            cmd.Parameters.AddWithValue("@code", a.codigo);
            cn.Open();
            res = cmd.ExecuteNonQuery();
            cn.Close();
            return res;
        }

        public int Eliminar(int codigo)
        {
            int res = 0;
            SqlConnection cn = new SqlConnection(conex);
            string sql = "delete from alumno where codigo = @code";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@code", codigo);
            cn.Open();
            res = cmd.ExecuteNonQuery();
            cn.Close();
            return res;
        }


    }
}