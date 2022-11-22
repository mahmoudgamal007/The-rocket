using TheRocket.Dtos.ProductDtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IProductSizeRepo
    {
        public Task<SharedResponse<ProductSizeDto>> AssignSizesToProdcut(ProductSizeDto model);
        public Task<SharedResponse<ProductSizeDto>> UnAssignSizesToProdcut(ProductSizeDto model);
        public Task<SharedResponse<List<SizeDto>>> GetSizesByProductId(int PoductID);

    }
}