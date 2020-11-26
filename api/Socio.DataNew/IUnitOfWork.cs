namespace Socio.DataNew
{
    public interface IUnitOfWork
    {
        Repository<T> Repository<T>() where T : class;

        void SaveChanges();
    }

}
