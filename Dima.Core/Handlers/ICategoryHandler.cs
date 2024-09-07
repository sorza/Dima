﻿using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Core.Handlers
{
    public interface ICategoryHandler
    {
        Task<Response<Category>> CreateGetAsync(CreateCategoryRequest request);
        Task<Response<Category>> UpdateGetAsync(UpdateCategoryRequest request);
        Task<Response<Category>> DeleteGetAsync(DeleteCategoryRequest request);
        Task<Response<Category>> GetByIdAsync(GetCategoryByIdRequest request);
        Task<Response<List<Category>>> GetAllAsync(GetAllCategoriesRequest request);
    }
}
