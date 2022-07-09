namespace Database.UnitOfWork.EF.Exceptions
{
    public class MoreThanOneRepositoriesUnitOfWorkException : Exception
    {
        public MoreThanOneRepositoriesUnitOfWorkException(string message) : base(message) { }
    }
}
