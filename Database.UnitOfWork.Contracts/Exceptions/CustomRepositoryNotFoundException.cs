namespace Database.UnitOfWork.Contracts.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomRepositoryNotFoundException : Exception
    {
        public Type RepositoryType { get; }

        public Type UnitOfWorkType { get; }

        public CustomRepositoryNotFoundException(Type repositoryType, Type unitOfWorkType)
            : base($"{repositoryType} was not registered in {unitOfWorkType} fields")
        {
            RepositoryType = repositoryType;
            UnitOfWorkType = unitOfWorkType;
        }
    }
}
