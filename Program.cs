using Tareas;
using System.Text;
internal class Program
{

    private static void Main(string[] args)
    {
        var ListaPendientes = new List<Tarea>();
        var ListaRealizadas = new List<Tarea>();


        // System.Console.WriteLine("----------LISTA TAREAS----------");
        CargarNTareas(ListaPendientes, 10);
        // ListarTareas(ListaPendientes);
        ControlDeTareas(ListaPendientes, ListaRealizadas);
        System.Console.WriteLine("-----------TAREAS PENDIENTES----------");
        ListarTareas(ListaPendientes);
        System.Console.WriteLine("----------TAREAS REALIZADAS----------");
        ListarTareas(ListaRealizadas);

        //  var numero = ListaPendientes.Count();
        //  var numero2 = ListaPendientes.Count;
        //  System.Console.WriteLine(numero);
        //  System.Console.WriteLine(numero2);

        ///BUSCAR TAREA POR DECRIPCION 

        // System.Console.WriteLine(">>>>>>>>TAREA POR DESCRIPCION>>>>>>>>>>");
        // System.Console.WriteLine("Escriba la descripcion de la tarea buscada");
        // var descripcion = Console.ReadLine();
        // BuscarTarea(ListaPendientes, descripcion);

        // string miArchivo = @"D:\Facultad\Taller I\ArchivoPrueba.txt";
        // string lineaDePrueba = "\n lalalalalaa";

        // string textoArchivo = File.ReadAllText(miArchivo);
        // Console.WriteLine(textoArchivo);

        // StreamWriter sw  = new StreamWriter(miArchivo);
        // sw.WriteLine(lineaDePrueba);
        // sw.Close();
        // System.Console.WriteLine("Horas trabajadas: " + HorasTrabajadas(ListaRealizadas));
        // RegistroHorasTrabajadas("horasTrabajadas.txt", ListaRealizadas);

        //ARCHIVO CSV

        string[] listadoArchivos = ObtenerArregloDeArchivos();
        //NECESITO QUITAR .\ 
        listadoArchivos = QuitarCaracteres(listadoArchivos);
        string path = "index.csv";

        if(!File.Exists(path)){
            CrearArchivoCsv(path);
        }

        for (int i = 0; i < listadoArchivos.Length; i++)
        {
            string[] arregloSplit = listadoArchivos[i].Split(".");
            string cadena = i +";"+arregloSplit[0] + ";" + arregloSplit[1];
            EscribirCsv(path,cadena);
        }
        
        

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
        Random Des = new Random();
        Random rnd2 = new Random();
        Array valores = Enum.GetValues(typeof(Estado));
        Array descr = Enum.GetValues(typeof(Descripciones));


        tarea.Id = indice;
        tarea.Duracion = rnd.Next(1, 100);
        tarea.Descripcion = (Descripciones)descr.GetValue(Des.Next(0, 8));
        tarea.Estado = (Estado)valores.GetValue(rnd2.Next(0, 2));
        return tarea;


    }
    public static void ListarTareas(List<Tarea> ListaPendientes)
    {
        foreach (var tarea in ListaPendientes)
        {
            System.Console.WriteLine("*****************");
            MostrarTarea(tarea);
        }
    }

    public static void CargarNTareas(List<Tarea> ListaPendientes, int N)
    {

        for (int i = 0; i < N; i++)
        {
            ListaPendientes.Add(CargarTarea(i));
        }

    }
    public static void ControlDeTareas(List<Tarea> ListaPendientes, List<Tarea> ListaRealizadas)
    {

        for (int i = 0; i < ListaPendientes.Count(); i++)
        {
            if (ListaPendientes[i].Estado.ToString() == "Realizada")
            {
                Tarea tarea = ListaPendientes[i];
                ListaRealizadas.Add(tarea);
                ListaPendientes.Remove(tarea);
                i--;
                //error era que uso remove y los indices se van actualizando de la lista entonces, siempre que habia dos tareas realizadas continuas se perdia una de ellas.
            }
        }


    }

    public static void BuscarTarea(List<Tarea> ListaPendientes, String descripcion)
    {


        for (int i = 0; i < ListaPendientes.Count; i++)
        {
            if (ListaPendientes[i].Descripcion.ToString().ToLower() == descripcion.ToLower())
            {
                System.Console.WriteLine("--------TAREA BUSCADA-------");
                MostrarTarea(ListaPendientes[i]);
            }
        }



    }

    public static int HorasTrabajadas(List<Tarea> ListaRealizadas)
    {

        int suma = 0;
        foreach (var tarea in ListaRealizadas)
        {
            suma += tarea.Duracion;
        }
        return suma;
    }

    public static void RegistroHorasTrabajadas(string path, List<Tarea> ListaRealizadas)

    {


        // using (FileStream archivo = new FileStream(path, FileMode.Create))
        // {
            using(StreamWriter streamW = new StreamWriter(path, true))
            {
                streamW.WriteLine("Horas trabajadas: " + HorasTrabajadas(ListaRealizadas).ToString());
                streamW.Close();
            }
        // }
    }

    public static string[] ObtenerArregloDeArchivos(){

        string[] listadoArchivos = Directory.GetFiles(".");
        return listadoArchivos;
    }

    public static string[] QuitarCaracteres(string[] listadoArchivos){
        for (int i = 0; i < listadoArchivos.Length; i++)
        {
            listadoArchivos[i] = listadoArchivos[i].Remove(0,2);
        }
        return listadoArchivos;
    }

    public static void CrearArchivoCsv(string path){

        using ( var archivo = new FileStream(path,FileMode.Create))
        {
            
        }
    }

    public static void EscribirCsv(string path,string cadena){
        using (var sw = new StreamWriter(path,true))
        {
            sw.WriteLine(cadena);
        }
    }
}
