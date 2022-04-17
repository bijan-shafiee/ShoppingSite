using _98market.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _98market.Componets
{
    [ViewComponent(Name = "ShowMenuResponseViewComponent")]
    public class ShowMenuResponseViewComponent :  ViewComponent
    {
        private ICategoryService _Categoryservice;
        public ShowMenuResponseViewComponent(ICategoryService Categoryservice)
        {
            _Categoryservice = Categoryservice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("ShowMenuReponse", _Categoryservice.GetAllCategoryForMenu()));
        }
    }
}
