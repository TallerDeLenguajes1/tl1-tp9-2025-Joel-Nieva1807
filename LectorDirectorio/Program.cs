// See https://aka.ms/new-console-template for more information
using System;
using System.Formats.Asn1;
using System.IO;
using System.Threading.Tasks.Dataflow;

string path;

Console.WriteLine("Ingrese un Path:");
path = Console.ReadLine();
int bandera=0;


do
{
    if (Directory.Exists(path))
    {
        Console.WriteLine("El directorio existe!");
        bandera = 1;
        string[] subDirectorios = Directory.GetDirectories(path);
        string[] archivos = Directory.GetFiles(path);

        Console.WriteLine("Nombres de las carpetas que se encuentran en el directorio:");
        foreach (string sub in subDirectorios)
        {
            string nombreCarpeta = Path.GetFileName(sub);
            Console.WriteLine(nombreCarpeta);

        }
        Console.WriteLine("-------------------------------------------");

        Console.WriteLine("Nombres de los archivos que se encuentran en el directorio con su tamnio:");

        foreach (string archiv in archivos)
        {
            string nombreArchivos = Path.GetFileName(archiv);
            FileInfo info = new FileInfo(archiv);
            Console.WriteLine($"Nombre del archivo: {info.Name}, peso: {(info.Length / 1024) + 1} KB");

        }

        string rutaDeArchivoNuevo = $"{path}\\reporte_archivos.csv";
        

        using (StreamWriter writer = new StreamWriter(rutaDeArchivoNuevo)) //cierre de ciclo
        {
            writer.WriteLine("Nombre, Tamaño, Ultima modificacion");
            foreach (string archivo in archivos)
            {
                FileInfo info = new FileInfo(archivo);
                string nombre = info.Name;
                long tamanio = info.Length;
                DateTime fechaDeCreacion = info.LastWriteTime;

                writer.WriteLine($"{nombre}, {tamanio} bytes, {fechaDeCreacion}");
                
            }
        }



    }
    else
    {
        Console.WriteLine("El directorio no existe. Ingrese nuevamente");
        path = Console.ReadLine();

    }
    
} while (bandera == 0);

