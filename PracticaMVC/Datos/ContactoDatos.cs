using PracticaMVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace PracticaMVC.Datos
{
    public class ContactoDatos
    {
        public List<ContactosModel> Listar()
        {
            var oLista=new List<ContactosModel>();
            var cn=new Conexion();

            using(var conexion=new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactosModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Direccion = dr["Direccion"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public ContactosModel Obtener(int Id)
        {
            var oContacto=new ContactosModel();
            var cn=new Conexion();

            using(var conexion=new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType=CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.Id = Convert.ToInt32(dr["Id"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Apellido = dr["Apellido"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Direccion = dr["Direccion"].ToString();
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(ContactosModel oContacto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using(var conexion=new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oContacto.Apellido);
                    cmd.Parameters.AddWithValue("Telefono",oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Direccion",oContacto.Direccion);
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta= false;
            }
            return rpta;
        }

        public bool Editar(ContactosModel oContacto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using(var conexion=new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Id",oContacto.Id);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oContacto.Apellido);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Direccion", oContacto.Direccion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta= true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta= false;
            }
            return rpta;
        }

        public bool Eliminar(int Id)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Id",Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error= ex.Message;
                rpta= false;
            }
            return rpta;
        }
    }
}
