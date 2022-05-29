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

            return _Context.brands.Where(c => c.IsActive != false).ToList() ;
        }
        public List<brand> ShowAllBrandforadmin()
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
        public void ActiveBrand(int id)
        {
            var Active = _Context.brands.Find(id);
            if (Active == null) return;
            Active.Active();
            _Context.SaveChanges();
        }
        public void DeActiveBrand(int id)
        {
            var DeActive = _Context.brands.Find(id);
            if (DeActive == null) return;
            DeActive.DeActive();
            _Context.SaveChanges();
        }
    }
}
