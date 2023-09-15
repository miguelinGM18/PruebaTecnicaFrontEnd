using ApiUsers.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Usuarios.DataAccess.DataAccess;

namespace Usuarios.Business
{
    public class UsuarioBusiness
    {
        public GeneralResponse<Object> PostUsuario(UsuarioDto request)
        {
            GeneralResponse<Object> response = new GeneralResponse<Object>();
            try
            {
                using (var context = new TestingAliFullstackContext())
                {
                    UsersTestMiguelEmanuelSanchezRamo usuario = new UsersTestMiguelEmanuelSanchezRamo()
                    {                        
                        Email = request.Email,
                        Nombre = request.Nombre,
                        SegundoNombre= request.SegundoNombre,
                        ApellidoPaterno= request.ApellidoPaterno,
                        ApellidoMaterno= request.ApellidoMaterno,
                        Telefono= request.Telefono,
                        FechaNacimiento = request.FechaNacimiento,
                        FechaRegistro = DateTime.Now,
                    };
                    context.UsersTestMiguelEmanuelSanchezRamos.Add(usuario);
                    context.SaveChanges();

                    response.Success = true;
                    response.Message = "El usuario se creo exitosamente.";
                    response.Code = (int)HttpStatusCode.Created;
                }
            }
            catch (Exception ex)
            {
                response.Code = 500;
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
