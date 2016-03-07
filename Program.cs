using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DescargaFTP
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadParameters leer = new ReadParameters();
            string servidor = leer.readParameter("/FuentesDeInformacion/FTP/EncuestasIVR/servidor");
            string usuario = leer.readParameter("/FuentesDeInformacion/FTP/EncuestasIVR/usuario");
            string password = leer.readParameter("/FuentesDeInformacion/FTP/EncuestasIVR/password");
            int puerto = Convert.ToInt32(leer.readParameter("/FuentesDeInformacion/FTP/EncuestasIVR/puerto"));
            string rutaorigen = leer.readParameter("/FuentesDeInformacion/ParametrosAplicacion/SincronizacionFTPEncuestas/RutaOrigen");
            string rutadestino = leer.readParameter("/FuentesDeInformacion/ParametrosAplicacion/SincronizacionFTPEncuestas/RutaDestino");

            SincronizacionDirectorios(servidor, usuario, password, puerto, rutaorigen, rutadestino);

            //Finaliza con exito
            Environment.Exit(0);
        }

        private static void SincronizacionDirectorios(string servidor, string usuario, string password, int puerto, string rutaorigen, string rutadestino)
        {
            string rutaFtp = rutaorigen;
            string rutaDestino = @rutadestino;
            int contador = 0;

            AccesoFtp acceso = new AccesoFtp(servidor, usuario, password, puerto);
            ArrayList AL = new ArrayList();
            AL = acceso.listarFTP(rutaFtp);


            foreach (string archivo in AL)
            {
                //Console.WriteLine("{0}", obj);
                if (!File.Exists(rutaDestino + archivo))
                {
                    try
                    {
                        Console.WriteLine("Copiando " + contador.ToString() + " de " + AL.Count.ToString() + " " + archivo + " ..........");
                        acceso.DescargarArchivo(rutaFtp + archivo, rutaDestino);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error copiando: " + archivo);
                    }


                }
                else
                {
                    Console.WriteLine("Archivo sincronizado previamente " + archivo);
                }


                contador++;
            }


            
        }



    }
}
