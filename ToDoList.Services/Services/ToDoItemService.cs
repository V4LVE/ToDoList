using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Entities;
using ToDoList.Repository.Interfaces;
using ToDoList.Services.DataTransferObejcts;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services.Services
{
    public class ToDoItemService : GenericService<ToDoItemDTO, IToDoItemRepository, ToDoItem>, IToDoItemService
    {
        #region backing fields
        private readonly MappingService _mappingService;
        private readonly IToDoItemRepository _toDoItemRepository;
        #endregion

        #region Constructor
        public ToDoItemService(MappingService mappingService, IToDoItemRepository toDoItemRepository) : base(mappingService,toDoItemRepository)
        {
            _mappingService = mappingService;
            _toDoItemRepository = toDoItemRepository;
        }
        #endregion

        public async Task<ObservableCollection<ToDoItemDTO>> GetAllCompletedAsync()
        {
            return _mappingService._mapper.Map<ObservableCollection<ToDoItemDTO>>(await _toDoItemRepository.GetAllCompletedAsync());
        }

        public async Task<ObservableCollection<ToDoItemDTO>> GetAllNotCompletedAsync()
        {
            return _mappingService._mapper.Map<ObservableCollection<ToDoItemDTO>>(await _toDoItemRepository.GetAllNotCompletedAsync());
        }

        public async Task<ToDoItemDTO> GetByIDAsync(Guid id)
        {
            return _mappingService._mapper.Map<ToDoItemDTO>(await _toDoItemRepository.GetByIDAsync(id));
        }

        public async Task<ObservableCollection<ToDoItemDTO>> GetAllNotCompletedByUserIdAsync(int id)
        {
            return _mappingService._mapper.Map<ObservableCollection<ToDoItemDTO>>(await _toDoItemRepository.GetAllNotCompletedByUserIdAsync(id));
        }

        public void SPGetByID(string id)
        {
            _toDoItemRepository.SPGetByID(id);
        }
    }
}
