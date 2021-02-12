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

        public bool ActualizarUsuario(Usuarios user)
        {
            bool res = false;
            
            try
            {
                Usuarios userObj = conn.Usuarios.Where(c => c.id == user.id).FirstOrDefault<Usuarios>();

                userObj.usuario = user.usuario;
                userObj.contrasenia = user.contrasenia;
                userObj.correo = user.correo;
                userObj.idCategoria = user.idCategoria;

                conn.Usuarios.Attach(userObj);
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
                Usuarios userObj = conn.Usuarios.Where(c => c.id == id).FirstOrDefault<Usuarios>();
                conn.Usuarios.Remove(userObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<Usuarios> GetAllUsuarios()
        {
            List<Usuarios> userObj = null;
            try
            {
                userObj = conn.Usuarios.ToList<Usuarios>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return userObj;
        }

        public List<Usuarios> GetUsuarioByID(int id)
        {
            List<Usuarios> userObj = null;
            try
            {
                userObj = conn.Usuarios.Where(c => c.id == id).ToList<Usuarios>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return userObj;
        }

        public Usuarios GetUsuariosLogin(string usuario, string password)
        {
            Usuarios Usuario = null;

            try
            {
                Expression<Func<Usuarios, bool>> predicato = p => p.usuario == usuario && p.contrasenia == password;
                Usuario = conn.Usuarios.Where(predicato.Compile()).FirstOrDefault<Usuarios>();
            }catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return Usuario;
        }

        public bool InsertarUsuario(Usuarios user)
        {
            bool res = false;
            try
            {
                conn.Usuarios.Add(user);
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
