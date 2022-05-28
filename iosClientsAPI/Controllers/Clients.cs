using Microsoft.AspNetCore.Mvc;
using iosClientsAPI.Models;

namespace iosClientsAPI
{
    [ApiController]
    [Route("[controller]")]
    public class Clients : Controller
    {

        [HttpGet("get")]
        public JsonResult Consultar()
        {

            var db = new SQLConnection();
            var ClientsList = db.Consulta();
            return Json(ClientsList);
        }

        [HttpPost("save")]
        [ActionName("save")]
        [Consumes("application/json")]
        public JsonResult Save([FromBody] Cliente cliente)
        {

            var Cliente = new Cliente(cliente.Nombre, cliente.Domicilio, cliente.Correo,
                cliente.Edad, cliente.Saldo, cliente.Latitud, cliente.Longitud, cliente.Imagen, 
                cliente.ImagenFondo);

            var bd = new SQLConnection();

            try
            {
                SQLHandler sqlResult = bd.Save(Cliente);
                if (!sqlResult.Status)
                {
                    return Json(new HttpJsonResponse(sqlResult.Message, sqlResult.Status));
                }
                else
                {
                    return Json(new HttpJsonResponse(sqlResult.Message, sqlResult.Status));
                }
            }
            catch (System.Exception ex)
            {

                return Json(new HttpJsonResponse(ex.Message, false));
            }
        }

        [HttpDelete("delete")]
        [ActionName("delete")]
        public JsonResult Eliminar(int id)
        {
            var bd = new SQLConnection();

            try
            {
                SQLHandler sqlResult = bd.Delete(id);
                if (!sqlResult.Status)
                {
                    return Json(new HttpJsonResponse(sqlResult.Message, sqlResult.Status));
                }
                else
                {
                    return Json(new HttpJsonResponse(sqlResult.Message, sqlResult.Status));
                }
            }
            catch (System.Exception ex)
            {

                return Json(new HttpJsonResponse(ex.Message, false));
            }
        }

        [HttpPut("update")]
        [ActionName("delete")]
        public JsonResult Update([FromBody] Cliente cliente,
           [FromQuery] int id)
        {
            var updatedClient = new Cliente(cliente.Nombre, cliente.Domicilio, cliente.Correo,
                           cliente.Edad, cliente.Saldo, cliente.Latitud, cliente.Longitud, cliente.Imagen,
                           cliente.ImagenFondo);

            var bd = new SQLConnection();

            try
            {
                SQLHandler sqlResult = bd.Update(id, updatedClient);
                if (!sqlResult.Status)
                {
                    return Json(new HttpJsonResponse(sqlResult.Message, sqlResult.Status));
                }
                else
                {
                    return Json(new HttpJsonResponse(sqlResult.Message, sqlResult.Status));
                }
            }
            catch (System.Exception ex)
            {

                return Json(new HttpJsonResponse(ex.Message, false));
            }
        }
    }
}
