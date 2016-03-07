using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DescargaFTP
{
    class AccesoFtp
    {
        private String servidor;
        private String usuario;
        private String password;
        private int puerto;

        public AccesoFtp(String servidor, String usuario, String password, int puerto)
        {
            Servidor = servidor;
            Usuario = usuario;
            Password = password;
            Puerto = puerto;
        }
        public AccesoFtp(String servidor, String usuario, String password)
        {
            Servidor = servidor;
            Usuario = usuario;
            Password = password;
            Puerto = 23;
        }


        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
      
        public int Puerto
        {
            get { return puerto; }
            set { puerto = value; }
        }
 
        public String Servidor
        {
            get { return servidor; }
            set { servidor = value; }
        }

        public ArrayList listarFTP(string ruta)
        {
            ArrayList Listado = new ArrayList();

            Tamir.SharpSsh.Sftp  sftp = new Tamir.SharpSsh.Sftp(servidor, usuario, password);
            sftp.Connect();

            Listado=sftp.GetFileList(ruta);

            sftp.Close();
            return Listado;
        }

        public void DescargarArchivo(string archivosOrigen, string archivoDestino)
        {
            ArrayList Listado = new ArrayList();

            Tamir.SharpSsh.Sftp sftp = new Tamir.SharpSsh.Sftp(servidor, usuario, password);
            sftp.Connect();

            sftp.Get(archivosOrigen, archivoDestino);

            sftp.Close();
        }


    }
}
