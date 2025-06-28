
using espacioUsuario;
using System.Text.Json;


HttpClient client = new HttpClient();



HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
response.EnsureSuccessStatusCode();

string responseBody = await response.Content.ReadAsStringAsync();

List<Usuario> listaUsuario = JsonSerializer.Deserialize<List<Usuario>>(responseBody);

int contador = 0;

foreach (var usuario in listaUsuario)
{
    Console.WriteLine($"Nombre: {usuario.Name}");
    Console.WriteLine($"Username: {usuario.Username}");
    Console.WriteLine($"Email: {usuario.Email}");
    Console.WriteLine($"Domicilio: {usuario.Address.Street} | {usuario.Address.Suite} | {usuario.Address.City}");


    contador++;
    if (contador >= 5)
        break;
}


string jsonString = JsonSerializer.Serialize<List<Usuario>>(listaUsuario);


File.WriteAllText("usuarios.json", jsonString);
