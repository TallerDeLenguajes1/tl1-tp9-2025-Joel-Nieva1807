// See https://aka.ms/new-console-template for more information
using EspacioId3v1Tag;

Console.WriteLine("Ingrese la ruta de su cancion");

string ruta = Console.ReadLine();
Id3v1Tag cancion = new Id3v1Tag();

using (FileStream archivoStream = new FileStream(ruta, FileMode.Open, FileAccess.Read))
{
    archivoStream.Seek(-128, SeekOrigin.End);
    byte[] buffer = new byte[128];
    archivoStream.Read(buffer, 0, 128);

    //mostrar los primeros 3 caracteres

    string header = System.Text.Encoding.ASCII.GetString(buffer, 0, 3).TrimEnd('\0'); // el trimEnd es útil porque los campos pueden venir con ceros (\0) al final si no están completos.
    cancion.Titulo = System.Text.Encoding.Default.GetString(buffer, 3, 30).TrimEnd('\0');
    cancion.Artista = System.Text.Encoding.Default.GetString(buffer, 30, 30).TrimEnd('\0');
    cancion.Album = System.Text.Encoding.Default.GetString(buffer, 63, 30).TrimEnd('\0');
    cancion.Anio = System.Text.Encoding.Default.GetString(buffer, 93, 4).TrimEnd('\0');
    Console.WriteLine("Header (debería ser 'TAG'): " + header);
    Console.WriteLine("Titulo: " + cancion.Titulo);
    Console.WriteLine("Artista: " + cancion.Artista);
    Console.WriteLine("Album: " + cancion.Album);
    Console.WriteLine("anio: " + cancion.Anio);
    

}
