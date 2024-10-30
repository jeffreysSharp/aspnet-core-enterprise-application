namespace JSE.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
