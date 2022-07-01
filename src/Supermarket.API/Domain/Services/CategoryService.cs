using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRespository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRespository categoryRespository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRespository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }
            catch (Exception ex)
            {

                return new SaveCategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}
