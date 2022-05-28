using System.Data;
using System.Data.SqlClient;
using iosClientsAPI.Models;

namespace iosClientsAPI
{
    public class SQLConnection
    {

        const string AZURE_SQL_CONNECTION = "Server=tcp:hectoriosapp.database.windows.net,1433;Initial Catalog=Informacion;Persist Security Info=False;User ID=Hector;Password=Espartanclase3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<Clientes> ListaClientes = new List<Clientes>();
        public List<Clientes> Consulta()
        {

            var dt = new DataTable();
            var connect = new SqlConnection(AZURE_SQL_CONNECTION);
            var cmd = new SqlCommand($"select * from datos", connect);

            try
            {
                ListaClientes = new List<Clientes>();
                connect.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connect.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListaClientes.Add(
                    new Clientes(
                                    int.Parse(dt.Rows[i]["id"].ToString()),
                                    dt.Rows[i]["nombre"].ToString(),
                                    dt.Rows[i]["domicilio"].ToString(),
                                    dt.Rows[i]["correo"].ToString(),
                                    int.Parse(dt.Rows[i]["edad"].ToString()),
                                    double.Parse(dt.Rows[i]["saldo"].ToString()),
                                    dt.Rows[i]["latitud"].ToString(),
                                    dt.Rows[i]["longitud"].ToString(),
                                    dt.Rows[i]["imagen"].ToString(),
                                    dt.Rows[i]["imagenFondo"].ToString()
                                ));
                }

                return ListaClientes;

            }
            catch (System.Exception)
            {
                connect.Close();
                return ListaClientes;
            }

        }
        public SQLHandler Save(Cliente cliente)
        {

            var connect = new SqlConnection(AZURE_SQL_CONNECTION);
            var query = new SqlCommand($"insert into datos values ('{cliente.Nombre}','{cliente.Domicilio}','{cliente.Correo}',{cliente.Edad},{cliente.Saldo},'{cliente.Latitud}','{cliente.Longitud}','{cliente.Imagen}','{cliente.ImagenFondo}')", connect);

            try
            {
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
                return new SQLHandler("Guardado correctamente", true);
            }
            catch (System.Exception ex)
            {
                connect.Close();
                return new SQLHandler(ex.Message, false);
            }
        }
        public SQLHandler Delete(int id)
        {

            var connect = new SqlConnection(AZURE_SQL_CONNECTION);
            var query = new SqlCommand($"delete from datos where id = {id}", connect);

            try
            {
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
                return new SQLHandler("Eliminado correctamente", true);
            }
            catch (System.Exception ex)
            {
                connect.Close();
                return new SQLHandler(ex.Message, false);
            }
        }
        public SQLHandler Update(int id, Cliente cliente)
        {

            var connect = new SqlConnection(AZURE_SQL_CONNECTION);
            var query = new SqlCommand($"update datos set nombre = '{cliente.Nombre}', domicilio = '{cliente.Domicilio}', correo = '{cliente.Correo}',edad = {cliente.Edad}, saldo = {cliente.Saldo}, latitud = '{cliente.Latitud}', longitud ='{cliente.Longitud}',imagen ='{cliente.Imagen}', imagenFondo ='{cliente.ImagenFondo}' where id = {id}", connect);

            try
            {
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
                return new SQLHandler("Editado correctamente", true);
            }
            catch (System.Exception ex)
            {
                connect.Close();
                return new SQLHandler(ex.Message, false);
            }
        }
    }
}
