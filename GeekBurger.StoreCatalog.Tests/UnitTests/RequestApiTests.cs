using GeekBurger.StoreCatalog.Infra.Services;
using GeekBurger.StoreCatalog.Infra.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeekBurger.StoreCatalog.Tests.UnitTests
{
    [TestClass]
    public class RequestApiTests
    {
        private IRequestApi _requestApi;

        [TestInitialize]
        public void Inicialize()
        {
            _requestApi = new RequestApi();
        }

        [TestMethod]
        public void Check_If_Endpoint_GetProducts_Is_Avaliable()
        {
            var result = _requestApi.GetProducts(string.Empty).GetAwaiter().GetResult();

            Assert.IsTrue(result.IsSuccessStatusCode);
        }
    }
}
