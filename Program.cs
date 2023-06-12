using Tareas;

internal class Program
{
    private static void Main(string[] args)
    {
        var ListaTareas = new List<Tarea>();
        var ListaRealizadas = new List<Tarea>();

        System.Console.WriteLine("----------LISTA TAREAS----------");
        CargarNTareas(ListaTareas, 10);
        ListarTareas(ListaTareas);
        ControlDeTareas(ListaTareas, ListaRealizadas);
        System.Console.WriteLine("-----------TAREAS PENDIENTES----------");
        ListarTareas(ListaTareas);
        System.Console.WriteLine("----------TAREAS REALIZADAS----------");
         ListarTareas(ListaRealizadas);


    }
    public static void MostrarTarea(Tarea tarea)
    {
        System.Console.WriteLine("ID:" + tarea.Id);
        System.Console.WriteLine("Descripcion: " + tarea.Descripcion);
        System.Console.WriteLine("Duracion: " + tarea.Duracion);
        System.Console.WriteLine("Estado: " + tarea.Estado);

    }
    public static Tarea CargarTarea(int indice)
    {
        Tarea tarea = new Tarea();
        Random rnd = new Random();
        Array valores = Enum.GetValues(typeof(Estado));
        Random rnd2 = new Random();
        tarea.Id = indice;
        tarea.Duracion = rnd.Next(1, 100);
        tarea.Descripcion = "Tarea" + tarea.Id;
        tarea.Estado = (Estado)valores.GetValue(rnd2.Next(valores.Length));
        return tarea;


    }
    public static void ListarTareas(List<Tarea> ListaTareas)
    {
        foreach (var tarea in ListaTareas)
        {
            System.Console.WriteLine("*****************");
            MostrarTarea(tarea);
        }
    }

    public static void CargarNTareas(List<Tarea> ListaTareas, int N)
    {

        for (int i = 0; i < N; i++)
        {
            ListaTareas.Add(CargarTarea(i));
        }

    }
    public static void ControlDeTareas(List<Tarea> ListaTareas, List<Tarea> ListaRealizadas)
    {
   
        for (int i = 0; i < ListaTareas.Count; i++)
        {
            if(ListaTareas[i].Estado == Estado.Realizada){
                ListaRealizadas.Add(ListaTareas[i]);
                ListaTareas.Remove(ListaTareas[i]);
            }
        }

    }
}