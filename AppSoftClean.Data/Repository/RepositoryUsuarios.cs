using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryUsuarios : IUsuariosRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarUsuario(usuarios user)
        {
            bool res = false;
            
            try
            {
                usuarios userObj = conn.usuarios.Where(c => c.id == user.id).FirstOrDefault<usuarios>();

                userObj.usuario = user.usuario;
                userObj.contrasenia = user.contrasenia;
                userObj.correo = user.correo;
                userObj.idCategoria = user.idCategoria;

                conn.usuarios.Attach(userObj);
                conn.Entry(userObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarUsuario(int id)
        {
            bool res = false;

            try
            {
                usuarios userObj = conn.usuarios.Where(c => c.id == id).FirstOrDefault<usuarios>();
                conn.usuarios.Remove(userObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<usuarios> GetAllUsuarios()
        {
            List<usuarios> userObj = null;
            try
            {
                userObj = conn.usuarios.ToList<usuarios>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return userObj;
        }

        public List<usuarios> GetUsuarioByID(int id)
        {
            List<usuarios> userObj = null;
            try
            {
                userObj = conn.usuarios.Where(c => c.id == id).ToList<usuarios>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return userObj;
        }

        public usuarios GetUsuariosLogin(string usuario, string password)
        {
            usuarios Usuario = null;

            try
            {
                Expression<Func<usuarios, bool>> predicato = p => p.usuario == usuario && p.contrasenia == password;
                Usuario = conn.usuarios.Where(predicato.Compile()).FirstOrDefault<usuarios>();
            }catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return Usuario;
        }

        public bool InsertarUsuario(usuarios user)
        {
            bool res = false;
            try
            {
                conn.usuarios.Add(user);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return res;
        }

    }
}
