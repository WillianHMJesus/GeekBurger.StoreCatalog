using System;
using System.Linq;
using System.Collections.Generic;
using GeekBurger.StoreCatalog.Contract;
using GeekBurger.StoreCatalog.Core.Interfaces;
using GeekBurger.StoreCatalog.Infra.Interfaces;

namespace GeekBurger.StoreCatalog.Core
{
    public class ProductCore : IProductCore
    {
        private readonly IRequestApi _requestApi;
        private readonly IRepository<ProductionAreasCore> _repository;

        public ProductCore(IRequestApi requestApi, IRepository<ProductionAreasCore> repository)
        {
            _requestApi = requestApi;
            _repository = repository;
        }

        public IEnumerable<Product> GetProductsFromUser(User user)
        {
            var restrictions = String.Join(",", user.Restrictions);
            var responseProducts = _requestApi.GetProducts(restrictions).GetAwaiter().GetResult();

            if(responseProducts.IsSuccessStatusCode)
            {
                var products = Product.GetProducts(responseProducts.Content.ReadAsStringAsync().Result);
                var productionAreas = _repository.GetAll();
                //var result = productionAreas.Where(x => user.Restrictions.ToList().Contains(x.Restrictions)).ToList();

                return products;
            }
            else
            {
                throw new Exception($"Status code error: {responseProducts.StatusCode}");
            }
        }
    }
}
