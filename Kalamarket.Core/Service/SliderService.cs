using _98market.Core.Service.Interface;
using _98market.DataLayer.Context;
using _98market.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _98market.Core.Service
{
    public class SliderService : ISliderService
    {
        private _98marketContext _Context;
        public SliderService(_98marketContext Context)
        {
            _Context = Context;
        }
        public int AddSlider(MainSlider mainSlider)
        {
            try
            {
                _Context.mainSliders.Add(mainSlider);
                _Context.SaveChanges();
                return mainSlider.Sliderid;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public bool DeleteSlider(MainSlider mainSlider)
        {
            try
            {
                _Context.mainSliders.Remove(mainSlider);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public MainSlider FindSliderById(int Sliderid)
        {
            return _Context.mainSliders.Find(Sliderid);
        }

        public List<MainSlider> ShowAllSlider(int page)
        {
            int skip=(page-1)*2;
            return _Context.mainSliders.OrderBy(s=>s.SliderSort).Skip(skip).Take(2).ToList();
        }

        public bool UpdateSlider(MainSlider mainSlider)
        {
            try
            {
                _Context.mainSliders.Update(mainSlider);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SliderCount()
        {
            int SliderCount = _Context.mainSliders.Count();
            if (SliderCount % 2 != 0)
                SliderCount++;
            SliderCount = SliderCount / 2;
            return SliderCount;

        }

        public List<MainSlider> ShowSliderForUser()
        {
            return _Context.mainSliders.Where(c => c.IsActive).ToList();
        }
    }
       
}
