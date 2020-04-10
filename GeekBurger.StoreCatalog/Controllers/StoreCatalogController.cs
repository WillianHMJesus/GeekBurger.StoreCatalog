using System;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.StoreCatalog.Contract;

namespace GeekBurger.StoreCatalog.Controllers
{
    /// <summary>
    /// Store Catalog endpoints
    /// </summary>
    public class StoreCatalogController : Controller
    {
        /// <summary>
        /// Return store catalog by Guid identifier
        /// </summary>
        /// <param name="storeid">Guid of store catalog</param>
        /// <returns></returns>
        [HttpGet("store/{storeid:Guid}")]
        public IActionResult GetStore(Guid storeid)
        {
            var result = new OperationResult<bool>();

            try
            {
                // verifica se os outros serviços estão ok

                // retorna se está on line

                result.Data = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return StatusCode(503, result);
            }
        }
    }
}