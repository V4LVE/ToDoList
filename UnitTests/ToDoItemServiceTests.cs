namespace UnitTests
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Moq;
    using Xunit;
    using AutoMapper;
    using ToDoList.Repository.Entities;
    using ToDoList.Repository.Interfaces;
    using ToDoList.Services.DataTransferObejcts;
    using ToDoList.Services.Services;

    public class ToDoItemServiceTests
    {
        private readonly Mock<IToDoItemRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly MappingService _mappingService;
        private readonly ToDoItemService _service;

        public ToDoItemServiceTests()
        {
            _repoMock = new Mock<IToDoItemRepository>();
            _mapperMock = new Mock<IMapper>();
            _mappingService = new MappingService();
            typeof(MappingService)
                .GetField("_mapper", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                .SetValue(_mappingService, _mapperMock.Object);
            _service = new ToDoItemService(_mappingService, _repoMock.Object);
        }

        [Fact]
        public async Task GetAllCompletedAsync_ReturnsMappedCollection()
        {
            // Arrange
            var entities = new ObservableCollection<ToDoItem> { new ToDoItem { ID = Guid.NewGuid() } };
            var dtos = new ObservableCollection<ToDoItemDTO> { new ToDoItemDTO { ID = entities[0].ID } };

            _repoMock.Setup(r => r.GetAllCompletedAsync()).ReturnsAsync(entities);
            _mapperMock.Setup(m => m.Map<ObservableCollection<ToDoItemDTO>>(entities)).Returns(dtos);

            // Act
            var result = await _service.GetAllCompletedAsync();

            // Assert
            Assert.Equal(dtos, result);
            _repoMock.Verify(r => r.GetAllCompletedAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<ObservableCollection<ToDoItemDTO>>(entities), Times.Once);
        }

        [Fact]
        public async Task GetAllNotCompletedAsync_ReturnsMappedCollection()
        {
            var entities = new ObservableCollection<ToDoItem> { new ToDoItem { ID = Guid.NewGuid() } };
            var dtos = new ObservableCollection<ToDoItemDTO> { new ToDoItemDTO { ID = entities[0].ID } };

            _repoMock.Setup(r => r.GetAllNotCompletedAsync()).ReturnsAsync(entities);
            _mapperMock.Setup(m => m.Map<ObservableCollection<ToDoItemDTO>>(entities)).Returns(dtos);

            var result = await _service.GetAllNotCompletedAsync();

            Assert.Equal(dtos, result);
            _repoMock.Verify(r => r.GetAllNotCompletedAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<ObservableCollection<ToDoItemDTO>>(entities), Times.Once);
        }

        [Fact]
        public async Task GetByIDAsync_ReturnsMappedDto()
        {
            var id = Guid.NewGuid();
            var entity = new ToDoItem { ID = id };
            var dto = new ToDoItemDTO { ID = id };

            _repoMock.Setup(r => r.GetByIDAsync(id)).ReturnsAsync(entity);
            _mapperMock.Setup(m => m.Map<ToDoItemDTO>(entity)).Returns(dto);

            var result = await _service.GetByIDAsync(id);

            Assert.Equal(dto, result);
            _repoMock.Verify(r => r.GetByIDAsync(id), Times.Once);
            _mapperMock.Verify(m => m.Map<ToDoItemDTO>(entity), Times.Once);
        }

        [Fact]
        public void SPGetByID_CallsRepositoryMethod()
        {
            var id = "test-id";
            _service.SPGetByID(id);
            _repoMock.Verify(r => r.SPGetByID(id), Times.Once);
        }

    }
}
