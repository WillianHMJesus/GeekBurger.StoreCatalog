using GeekBurger.StoreCatalog.Contract;
using GeekBurger.StoreCatalog.Core.Interfaces;
using GeekBurger.StoreCatalog.Infra.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekBurger.StoreCatalog.Core
{
    public class ProductionAreasCore : IProductionAreasCore
    {
        private readonly IRequestApi _requestApi;
        private readonly IRepository<ProductionAreas> _repository;

        public ProductionAreasCore(IRequestApi requestApi, IRepository<ProductionAreas> repository)
        {
            _requestApi = requestApi;
            _repository = repository;
        }

        public void SaveAllProductionArea()
        {
            var responseProductionsAreas = _requestApi.GetProductionAreas().GetAwaiter().GetResult();

            if(responseProductionsAreas.IsSuccessStatusCode)
            {
                var jsonProductionAreas = responseProductionsAreas.Content.ReadAsStringAsync().Result;
                var productionsAreas = JsonConvert.DeserializeObject<List<ProductionAreas>>(jsonProductionAreas);

                foreach(var model in productionsAreas)
                {
                    var listaProductionsAreas = _repository.GetAll();
                    var productionAreas = listaProductionsAreas.FirstOrDefault(x => x.Name == model.Name);

                    if(productionAreas == null)
                    {
                        _repository.Insert(model);
                    }
                    else
                    {
                        model.ProductionAreaId = productionAreas.ProductionAreaId;
                        _repository.Update(model);
                    }
                }
            }
            else
            {
                throw new Exception($"Status code error: {responseProductionsAreas.StatusCode}");
            }
        }
    }
}
