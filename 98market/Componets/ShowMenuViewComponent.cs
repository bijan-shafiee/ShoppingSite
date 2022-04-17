using _98market.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _98market.Componets
{
    [ViewComponent(Name = "ShowMenuViewComponent")]
    public class ShowMenuViewComponent : ViewComponent
    {
        private ICategoryService _Categoryservice;
        public ShowMenuViewComponent(ICategoryService Categoryservice)
        {
            _Categoryservice = Categoryservice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("ShowMenu", _Categoryservice.GetAllCategoryForMenu()));
        }

    }
}
