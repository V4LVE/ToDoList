using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Interfaces;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services.Services
{
    public abstract class GenericService<DTO, IRepository, Entity> : IGenericService<DTO> where DTO : class where IRepository : IGenericRepository<Entity> where Entity : class
    {
        #region backing fields
        private readonly IRepository _genericRepository;
        private readonly MappingService _mappingService;
        #endregion

        #region Constructor
        protected GenericService(MappingService mappingService, IRepository genericRepository)
        {
            _mappingService = mappingService;
            _genericRepository = genericRepository;
        }
        #endregion

        public async Task CreateAsync(DTO entity)
        {
            await _genericRepository.CreateAsync(_mappingService._mapper.Map<Entity>(entity));
        }

        public async Task DeleteAsync(DTO entity)
        {
            await _genericRepository.DeleteAsync(_mappingService._mapper.Map<Entity>(entity));
        }

        public async Task<ObservableCollection<DTO>> GetAllAsync()
        {
            return _mappingService._mapper.Map<ObservableCollection<DTO>>(await _genericRepository.GetAllAsync());
        }

        public async Task UpdateAsync(DTO entity)
        {
            await _genericRepository.UpdateAsync(_mappingService._mapper.Map<Entity>(entity));
        }
    }
}
