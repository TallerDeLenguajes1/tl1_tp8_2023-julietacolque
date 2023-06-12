namespace Tareas
{
   public class Tarea
    {
        private int id;
        private string descripcion;
        private int duracion;
        private Estado estado;

        

       
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }
        public int Id { get => id; set => id = value; }
        public Estado Estado { get => estado; set => estado = value; }
    }
    public enum Estado
    {
        Realizada,
        EnCurso,
        Pendiente
    }
}