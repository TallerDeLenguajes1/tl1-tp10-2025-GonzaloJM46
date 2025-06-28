
using System.Text.Json;
namespace getTarea;
using infoTarea;

public static class peticion
{


  private static readonly HttpClient consulta = new HttpClient();
  

  public static async Task<List<Tarea>> GetTareasAsync()
    {
        var link = "https://jsonplaceholder.typicode.com/todos";

        HttpResponseMessage respuesta = await consulta.GetAsync(link);
        respuesta.EnsureSuccessStatusCode();

        string infoRespuesta = await respuesta.Content.ReadAsStringAsync();
        List<Tarea> listaTarea = JsonSerializer.Deserialize<List<Tarea>>(infoRespuesta);
        
        return listaTarea;
    }
}
