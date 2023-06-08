using Tareas;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var ListaTareas = new List<Tarea>();
        Tarea t1 = new Tarea();
        t1.Descripcion = "lalala";
        t1.TareaID = 0;
        t1.Duracion = 10;
        ListaTareas.Add(t1);
        foreach (var tarea in ListaTareas)
        {
            MostrarTarea(tarea);
        }
    }
    public static void MostrarTarea(Tarea tarea)
    {
        System.Console.WriteLine("Descripcion: " + tarea.Descripcion);
        System.Console.WriteLine("Duracion: " + tarea.Duracion);
        System.Console.WriteLine("ID:" + tarea.TareaID);
    }
//     public static Tarea CargarTarea(){
//   return 
//     }
}