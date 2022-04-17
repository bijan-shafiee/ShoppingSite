using _98market.Core.Service.Interface;
using _98market.DataLayer.Entities.Entitieproduct;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace _98market.Componets
{
    public class sliderForCategoryViewComponent : ViewComponent
    {
        private Iproductservice _Productservice;
        public sliderForCategoryViewComponent(Iproductservice Productservice)
        {
            _Productservice = Productservice;
        }

        public async Task<IViewComponentResult> InvokeAsync(Category category)
        {
            return await Task.FromResult(View("ShowSliderForsepcial", _Productservice.showproductForCategory(category)));
        }
    }
}
