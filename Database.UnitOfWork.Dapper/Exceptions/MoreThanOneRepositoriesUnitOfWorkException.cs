namespace Database.UnitOfWork.Dapper.Exceptions
{
    public class MoreThanOneRepositoriesUnitOfWorkException : Exception
    {
        public MoreThanOneRepositoriesUnitOfWorkException(string message) : base(message) { }
    }
}
