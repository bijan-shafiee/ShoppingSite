using _98market.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _98market.Componets
{
    [ViewComponent(Name ="showslideruser")]
    public class ShowSliderViewComponent : ViewComponent
    {
        private ISliderService _SliderService;
        public ShowSliderViewComponent(ISliderService SliderService)
        {
            _SliderService = SliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("ShowSliderForUser", _SliderService.ShowSliderForUser()));
        }
    }
}
