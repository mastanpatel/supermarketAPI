using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRespository _categoryRepository;

        public CategoryService(ICategoryRespository categoryRespository)
        {
            _categoryRepository = categoryRespository;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }
    }
}
