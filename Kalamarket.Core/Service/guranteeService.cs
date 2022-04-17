using _98market.Core.Service.Interface;
using _98market.DataLayer.Context;
using _98market.DataLayer.Entities.Entitieproduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _98market.Core.Service
{
    public class guranteeService : IguranteeService
    {
        private _98marketContext _Context;
        public guranteeService(_98marketContext Context)
        {
            _Context = Context;
        }

        public int AddGurante(ProductGurantee productGurantee)
        {
            try
            {
                _Context.productGurantees.Add(productGurantee);
                _Context.SaveChanges();
                return productGurantee.GuranteeId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool DeleteGurantee(ProductGurantee productGurantee)
        {
            try
            {
                productGurantee.IsDelete = true;
                _Context.productGurantees.Update(productGurantee);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExistGurantee(string guranteename, int guranteeid)
        {
            return _Context.productGurantees.Any(g => g.guranteename == guranteename && g.GuranteeId != guranteeid&&!g.IsDelete);
        }

        public ProductGurantee FindGuranteebuyeid(int guranteeid)
        {
            return _Context.productGurantees.Find(guranteeid);
        }

        public List<ProductGurantee> ShowAllGurantee()
        {
            return _Context.productGurantees.Where(g => !g.IsDelete).ToList();
        }

        public bool updategurantee(ProductGurantee productGurantee)
        {
            try
            {
                _Context.productGurantees.Update(productGurantee);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
