using Moq;
using Database.UnitOfWork.Contracts.Entities;

namespace Database.UnitOfWork.Contracts.Test
{
    public class UnitOfWorkTest
    {
        private class UnitOfWork : UnitOfWorkBase
        {
            public override void SaveChanges() => throw new NotImplementedException();

            public override Task SaveChangesAsync() => throw new NotImplementedException();

            public override void RejectAllChanges() => throw new NotImplementedException();

            public override void RejectChanges<TEntity>() => throw new NotImplementedException();

            public override void Dispose() => throw new NotImplementedException();

            protected override IReadOnlyRepository<TEntity> CreateReadOnlyRepository<TEntity>() => throw new NotImplementedException();

            protected override IRepository<TEntity> CreateRepository<TEntity>() => throw new NotImplementedException();
        }

        private class UnitOfWorkWithReadonlyRepository : UnitOfWork
        {
            public IReadOnlyRepository<EntityBase> ReadOnlyRepository { get; }

            public UnitOfWorkWithReadonlyRepository(IReadOnlyRepository<EntityBase> readOnlyRepository)
            {
                ReadOnlyRepository = readOnlyRepository;
            }
        }

        private class UnitOfWorkWithRepository : UnitOfWork
        {
            public IRepository<EntityBase> Repository { get; }

            public UnitOfWorkWithRepository(IRepository<EntityBase> repository)
            {
                Repository = repository;
            }
        }

        private class UnitOfWorkWithRepositoryAndReadonlyRepository : UnitOfWork
        {
            public IReadOnlyRepository<EntityBase> ReadOnlyRepository { get; }

            public IRepository<EntityBase> Repository { get; }

            public UnitOfWorkWithRepositoryAndReadonlyRepository(
                IReadOnlyRepository<EntityBase> readOnlyRepository,
                IRepository<EntityBase> repository)
            {
                ReadOnlyRepository = readOnlyRepository;
                Repository = repository;
            }
        }

        private class UnitOfWorkWithCustomRepository : UnitOfWork
        {
            public IRepository Repository { get; }

            public UnitOfWorkWithCustomRepository(IRepository repository)
            {
                Repository = repository;
            }
        }

        private class UnitOfWorkWithCreateReadOnlyRepositoryImplementation : UnitOfWork
        {
            protected override IReadOnlyRepository<TEntity> CreateReadOnlyRepository<TEntity>()
            {
                return new Mock<IReadOnlyRepository<TEntity>>().Object;
            }
        }

        private class UnitOfWorkWithCreateRepositoryImplementation : UnitOfWork
        {
            protected override IRepository<TEntity> CreateRepository<TEntity>()
            {
                return new Mock<IRepository<TEntity>>().Object;
            }
        }
        
        private readonly Mock<IReadOnlyRepository<EntityBase>> _readOnlyRepositoryMock;
        private readonly Mock<IRepository<EntityBase>> _repositoryMock;
        private readonly Mock<IRepository> _customRepositoryMock;

        private readonly UnitOfWorkWithRepositoryAndReadonlyRepository _unitOfWorkWithRepositoryAndReadonlyRepository;
        private readonly UnitOfWorkWithCustomRepository _unitOfWorkWithCustomRepository;

        public UnitOfWorkTest()
        {
            _readOnlyRepositoryMock = new();
            _repositoryMock = new();
            _customRepositoryMock = new();

            _unitOfWorkWithRepositoryAndReadonlyRepository = new(_readOnlyRepositoryMock.Object, _repositoryMock.Object);
            _unitOfWorkWithCustomRepository = new(_customRepositoryMock.Object);
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
        public void GetReadOnlyRepository_UnitOfWorkContainsRepositoryAndReadOnlyRepository_ReturnsReadonlyRepositoryFromProperty()
        {
            // Arrange & Act
            var result = _unitOfWorkWithRepositoryAndReadonlyRepository.GetReadOnlyRepository<EntityBase>();

            // Assert
            Assert.That(result).IsSame(_unitOfWorkWithRepositoryAndReadonlyRepository.ReadOnlyRepository);
        }

        [Fact]
        public void GetCustomRepository_UnitOfWorkContainsCustomRepository_ReturnsCustomRepositoryFromProperty()
        {
            // Arrange & Act
            var result = _unitOfWorkWithCustomRepository.GetCustomRepository<IRepository>();

            // Assert
            Assert.That(result).IsSame(_unitOfWorkWithCustomRepository.Repository);
        }

        [Fact]
        public void GetReadOnlyRepository_UnitOfWorkDoesNotContainsRepositoryAndCalledSeveralTimes_ReturnsSameCreatedRepository()
        {
            // Arrange
            var unitOfWork = new UnitOfWorkWithCreateReadOnlyRepositoryImplementation();
            var repository = unitOfWork.GetReadOnlyRepository<EntityBase>();

            // Act
            var result = unitOfWork.GetReadOnlyRepository<EntityBase>();

            // Assert
            Assert.That(result).IsSame(repository);
        }

        [Fact]
        public void GetRepository_UnitOfWorkDoesNotContainsRepositoryAndCalledSeveralTimes_ReturnsSameCreatedRepository()
        {
            // Arrange
            var unitOfWork = new UnitOfWorkWithCreateRepositoryImplementation();
            var repository = unitOfWork.GetRepository<EntityBase>();

            // Act
            var result = unitOfWork.GetRepository<EntityBase>();

            // Assert
            Assert.That(result).IsSame(repository);
        }
    }
}
