using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryUsuarios : IUsuariosRepository
    {
        private string key = "mikey";
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

        public string EncryptarContrasena(String contrasena)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(contrasena);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,
            0, ArrayResultado.Length);
        }

        public string Desencriptar(string textoEncriptado)
        {
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar =
            Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
            tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(Array_a_Descifrar,
            0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
            
        }


    }
}
