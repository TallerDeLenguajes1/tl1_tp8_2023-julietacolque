namespace Tareas
{
    public class Tarea
    {
        private int id;
        private Descripciones descripcion;
        private int duracion;
        private Estado estado;




        
        public int Duracion { get => duracion; set => duracion = value; }
        public int Id { get => id; set => id = value; }
        public Estado Estado { get => estado; set => estado = value; }
        public Descripciones Descripcion { get => descripcion; set => descripcion = value; }
    }
    public enum Estado
    {
        Realizada,
        EnCurso,
        Pendiente
    }
    public enum Descripciones
    {
        Visitarcliente,
        CobrarCliente ,
        Agregarproductos,
        QuitarProductos,
        Revisarstock,
        Reponerstock,
        Consultarprecios,
        Modificarprecios
    }
}