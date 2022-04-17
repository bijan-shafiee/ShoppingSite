using _98market.Core.Service.Interface;
using _98market.DataLayer.Context;
using _98market.DataLayer.Entities.Entitieproduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _98market.Core.Service
{
    public class BrandService : IBrandService
    {
        private _98marketContext _Context;
        public BrandService(_98marketContext Context)
        {
            _Context = Context;
        }

        public int AddBrand(brand brand)
        {
            try
            {
                _Context.brands.Add(brand);
                _Context.SaveChanges();
                return brand.brandid;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public brand GetBrand(int brandId)
        {
            return _Context.brands.Find(brandId);
        }

        public List<brand> ShowAllBrand()
        {
            return _Context.brands.ToList();
        }

        public int UpdateBrand(brand brand)
        {
            try
            {
                _Context.brands.Update(brand);
                _Context.SaveChanges();
                return brand.brandid;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
