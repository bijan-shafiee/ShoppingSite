using _98market.DataLayer.Entities.Entitieproduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Service.Interface
{
    public interface IBrandService
    {
        List<brand> ShowAllBrand();
        int AddBrand(brand brand);
        brand GetBrand(int brandId);
        int UpdateBrand(brand brand);
    }
}
