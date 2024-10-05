namespace JSE.Core.DomainObjects.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
