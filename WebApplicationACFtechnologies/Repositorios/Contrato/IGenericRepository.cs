namespace WebApplicationACFtechnologies.Repositorios.Contrato
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> Lista();
        Task<bool> Guardar(T Modelo);
        Task<bool> Editar(T Modelo);
        Task<bool> Eliminar(int identificacion);    

    }
}
