using _98market.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Service.Interface
{
    public interface ISliderService
    {
        List<MainSlider> ShowAllSlider( int page);
        MainSlider FindSliderById(int SliderId);
        int AddSlider(MainSlider mainSlider);
        bool UpdateSlider(MainSlider mainSlider);
        bool DeleteSlider(MainSlider mainSlider);
        List<MainSlider> ShowSliderForUser();
        int SliderCount();

    }
}
