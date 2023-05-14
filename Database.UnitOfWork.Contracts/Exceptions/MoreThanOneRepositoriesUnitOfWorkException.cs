namespace Database.UnitOfWork.Contracts.Exceptions
{
    /// <summary>
    /// Represents when more than one repository was registered in unit of work type
    /// </summary>
    public class MoreThanOneRepositoriesFoundException : Exception
    {
        public Type RepositoryType { get; }

        public Type UnitOfWorkType { get; }

        public MoreThanOneRepositoriesFoundException(Type repositoryType, Type unitOfWorkType)
            : base($"More than one {repositoryType} was registered in {unitOfWorkType} fields")
        {
            RepositoryType = repositoryType;
            UnitOfWorkType = unitOfWorkType;
        }
    }
}
