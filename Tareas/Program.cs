
﻿using System.Text.Json;
using getTarea;

using infoTarea;
List<Tarea> tareas = await peticion.GetTareasAsync();


tareas.Sort((t1, t2) => t2.Completed.CompareTo(t1.Completed));
foreach (var task in tareas)
{
  Console.WriteLine($"TITULO: {task.Title} - {(task.Completed ? "" : "NO")} COMPLETADA ");
}
string cadenajson = JsonSerializer.Serialize(tareas);

string path = "./tareas.json";
File.WriteAllText(path, cadenajson);
