using System;
using System.Collections.Generic;

namespace GeekBurger.StoreCatalog.Contract
{
    public class ProductionAreas
    {
        public Guid ProductionAreaId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public IEnumerable<string> Restrictions { get; set; }
    }
}