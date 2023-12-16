using Business.Dtos.Requests;
using Business.Dtos.Responses;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        // Task<IPaginate<GetListCategoryResponse>> GetListAsync();
        Task<CreatedCategoryResponse> Add(CreateCategoryRequest creatCategoryRequest);
    }
}
