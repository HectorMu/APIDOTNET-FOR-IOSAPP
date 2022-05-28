namespace iosClientsAPI.Models
{
 
    public class Cliente
    {
        public string Nombre { get; set; } = "";
        public string Domicilio { get; set; } = "";
        public string Correo { get; set; } = "";
        public int Edad { get; set; } = 0;
        public double Saldo { get; set; } = 0;
        public string Latitud { get; set; } = "";
        public string Longitud { get; set; } = "";
        public string Imagen { get; set; } = "";
        public string ImagenFondo { get; set; } = "";

        public Cliente(string nombre, string domicilio, string correo, int edad, 
            double saldo, string latitud, string longitud, string imagen, string imagenFondo)
        {
            Nombre = nombre;
            Domicilio = domicilio;
            Correo = correo;
            Edad = edad;
            Saldo = saldo;
            Latitud = latitud;
            Longitud = longitud;
            Imagen = imagen;
            ImagenFondo = imagenFondo;  
           
        }
    }
}
