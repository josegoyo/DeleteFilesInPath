using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteFilesInPath
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string folderPath = @"C:\Users\jgreg\Documents\Borradores";
            string[] extensionsToDelete = {  ".log", ".bak", ".xlsx" };
            int filesDeleted = 0;

            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] files = Directory.GetFiles(folderPath);

                    foreach (string file in files) {
                        try {
                            string extension = Path.GetExtension(file);

                            //Obtener la extension antes de eliminar.
                            if (Array.IndexOf(extensionsToDelete, extension) != -1) {
                                File.Delete(file);
                                Console.WriteLine($"Archivo Eliminado: {file} con extension {extension}");

                                filesDeleted++;
                            }
                        }
                        catch (Exception ex) { 
                            Console.WriteLine($"No se puedeo eliminar el archivo {file}, por el errror: {ex.ToString()}");
                        }
                    }

                    Console.WriteLine($"{filesDeleted} archivos han sido elimiandos");
                }
                else
                {
                    Console.WriteLine($"La carpeta no existe");
                }
                       
            }catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio un errror: {ex.ToString()}");
            }

            // Para esperar a que el usuario presione enter y se cierra la consola.
            Console.ReadLine();
        }
    }
}
