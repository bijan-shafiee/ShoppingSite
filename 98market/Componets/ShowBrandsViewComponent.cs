using _98market.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace _98market.Componets
{
    public class ShowBrandsViewComponent : ViewComponent
    {
        private IBrandService _BrandService;
        public ShowBrandsViewComponent(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult(View("ShowSliderForsepcial", _BrandService.ShowAllBrand()));
        }
    }
}
