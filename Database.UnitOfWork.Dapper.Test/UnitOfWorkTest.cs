using Database.UnitOfWork.Contracts.Entities;
using Database.UnitOfWork.Contracts.Services;
using Moq;
using System.Data;

namespace Database.UnitOfWork.Dapper.Test
{
    public class UnitOfWorkTest
    {
        private class UnitOfWorkWithReadonlyRepository : Services.UnitOfWork
        {
            public IReadOnlyRepository<EntityBase> ReadOnlyRepository { get; }

            public UnitOfWorkWithReadonlyRepository(
                IDbConnection connection,
                IReadOnlyRepository<EntityBase> readOnlyRepository)
                : base(connection)
            {
                ReadOnlyRepository = readOnlyRepository;
            }
        }

        private class UnitOfWorkWithRepository : Services.UnitOfWork
        {
            public IRepository<EntityBase> Repository { get; }

            public UnitOfWorkWithRepository(
                IDbConnection connection,
                IRepository<EntityBase> repository)
                : base(connection)
            {
                Repository = repository;
            }
        }

        private class UnitOfWorkWithRepositoryAndReadonlyRepository : Services.UnitOfWork
        {
            public IReadOnlyRepository<EntityBase> ReadOnlyRepository { get; }

            public IRepository<EntityBase> Repository { get; }

            public UnitOfWorkWithRepositoryAndReadonlyRepository(
                IDbConnection connection,
                IReadOnlyRepository<EntityBase> readOnlyRepository,
                IRepository<EntityBase> repository)
                : base(connection)
            {
                ReadOnlyRepository = readOnlyRepository;
                Repository = repository;
            }
        }

        private readonly Mock<IDbConnection> _dbConnectionMock;
        private readonly Mock<IReadOnlyRepository<EntityBase>> _readOnlyRepositoryMock;
        private readonly Mock<IRepository<EntityBase>> _repositoryMock;

        private readonly UnitOfWorkWithReadonlyRepository _unitOfWorkWithReadonlyRepository;
        private readonly UnitOfWorkWithRepository _unitOfWorkWithRepository;
        private readonly UnitOfWorkWithRepositoryAndReadonlyRepository _unitOfWorkWithRepositoryAndReadonlyRepository;

        public UnitOfWorkTest()
        {
            _dbConnectionMock = new();
            _readOnlyRepositoryMock = new();
            _repositoryMock = new();

            _unitOfWorkWithReadonlyRepository = new(_dbConnectionMock.Object, _readOnlyRepositoryMock.Object);
            _unitOfWorkWithRepository = new(_dbConnectionMock.Object, _repositoryMock.Object);
            _unitOfWorkWithRepositoryAndReadonlyRepository = new(_dbConnectionMock.Object, _readOnlyRepositoryMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public void GetRepository_UnitOfWorkContainsRepositoryAndReadOnlyRepository_ReturnsRepositoryFromProperty()
        {
            // Arrange & Act
            var result = _unitOfWorkWithRepositoryAndReadonlyRepository.GetRepository<EntityBase>();

            // Assert
            Assert.That(result).IsSame(_unitOfWorkWithRepositoryAndReadonlyRepository.Repository);
        }

        [Fact]
        public void GetReadOnlyRepository_UnitOfWorkContainsRepositoryAndReadOnlyRepository_ThrowsMoreThanOneRepositoriesUnitOfWorkException()
        {
            // Arrange & Act
            var result = _unitOfWorkWithRepositoryAndReadonlyRepository.GetReadOnlyRepository<EntityBase>();

            // Assert
            Assert.That(result).IsSame(_readOnlyRepositoryMock.Object);
        }
    }
}
