using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUAltaUsuario : ICUAlta<Usuario>{

        public IRepositorioUsuarios Repo { get; set; }
        public CUAltaUsuario(IRepositorioUsuarios repo) {
            Repo = repo;
        }
        public void Alta(Usuario obj) {
            obj.ContraseniaEncriptada = EncryptionUtility.EncryptString(obj.Contraseña);
            Repo.Create(obj);
        }
    }

    public class EncryptionUtility {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("your_secret_key_here");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("your_initialization_vector_here");

        public static string EncryptString(string plainText) {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var msEncrypt = new MemoryStream();
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                using (var swEncrypt = new StreamWriter(csEncrypt)) {
                    swEncrypt.Write(plainText);
                }
            }
            return Convert.ToBase64String(msEncrypt.ToArray());
        }
    }
}
