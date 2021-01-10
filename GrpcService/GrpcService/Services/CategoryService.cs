using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcService.Context;
using GrpcService.Protos;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class CategoryService : Category.CategoryBase
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly DataContext _context;

        public CategoryService(ILogger<CategoryService> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<CategoryInfo> GetCategory(FindCategory request, ServerCallContext context)
        {
            var data = _context.Categories.Find(request.Id);
            var ctg = new CategoryInfo()
            {
                Id = data.Id,
                Name = data.Name

            };
            return Task.FromResult(ctg);
        }

        public override Task<ProductInfo> GetProduct(FindProduct request, ServerCallContext context)
        {
            var data = _context.Products.Find(request.Id);
            var ctg = new ProductInfo()
            {
                Id = data.Id,
                Name = data.Name,
                Price = data.Price,
                Categoryid = data.CategoryId

            };
            return Task.FromResult(ctg);
        }

        public override Task<Empty> InsertCategory(CategoryInfo request, ServerCallContext context)
        {
            _context.Categories.Add(new Models.Category()
            {
                Id = request.Id,
                Name = request.Name
            });
            _context.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> InsertProduct(ProductInfo request, ServerCallContext context)
        {
            _context.Products.Add(new Models.Product()
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.Categoryid

            });
            _context.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateCategory(CategoryInfo request, ServerCallContext context)
        {
            _context.Categories.Update(new Models.Category()
            {
                Id = request.Id,
                Name = request.Name
            });
            _context.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateProduct(ProductInfo request, ServerCallContext context)
        {
            _context.Products.Update(new Models.Product()
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.Categoryid

            });
            _context.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteCategory(FindCategory request, ServerCallContext context)
        {
            var data = _context.Categories.Find(request.Id);
            _context.Categories.Remove(new Models.Category()
            {
                Id = data.Id,
                Name = data.Name
            });
            _context.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteProduct(FindProduct request, ServerCallContext context)
        {
            var data = _context.Products.Find(request.Id);
            _context.Products.Remove(new Models.Product()
            {
                Id = data.Id,
                Name = data.Name,
                Price = data.Price,
                CategoryId = data.CategoryId
            });
            _context.SaveChanges();
            return Task.FromResult(new Empty());
        }
    }
}
