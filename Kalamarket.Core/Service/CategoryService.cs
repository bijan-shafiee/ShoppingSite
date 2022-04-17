using _98market.Core.Service.Interface;
using _98market.DataLayer.Context;
using _98market.DataLayer.Entities.Entitieproduct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _98market.Core.Service
{
    public class CategoryService : ICategoryService
    {
        private _98marketContext _Context;
        public CategoryService(_98marketContext Context)
        {
            _Context = Context;
        }

        public int AddCategory(Category category)
        {
            try
            {
                if (category.Slider != 0)
                {
                    Category sliderCategory = _Context.categories.SingleOrDefault(c => c.Slider == category.Slider);
                    if (sliderCategory != null)
                    {
                        sliderCategory.Slider = 0;
                        _Context.categories.Update(sliderCategory);
                    }
                }
                _Context.categories.Add(category);
                _Context.SaveChanges();
                return category.Categoryid;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                _Context.categories.Update(category);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category findcategorybuyeid(int categoryid)
        {
            return _Context.categories.Find(categoryid);
        }

        public List<Category> ShowAllCategory()
        {
            return _Context.categories.Where(c => !c.IsDelete && c.SubCategory == null).ToList();
        }

        public List<Category> showAllSubCategory(int categoryid)
        {
            return _Context.categories.Where(c => !c.IsDelete && c.SubCategory == categoryid).ToList();
        }

        public bool updatecategory(Category category)
        {
            try
            {
                if (category.Slider != 0)
                {
                    Category sliderCategory = _Context.categories.SingleOrDefault(c => c.Slider == category.Slider);
                    if (sliderCategory != null)
                    {
                        sliderCategory.Slider = 0;
                        _Context.categories.Update(sliderCategory);
                    }
                }
                _Context.categories.Update(category);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExistCategory(string fatitle, string entitle, int cateid)
        {
            return _Context.categories.Any(c => c.CategoryFaTitle == fatitle && c.CategoryEnTitle == entitle && c.Categoryid != cateid);
        }

        public List<Category> Showsubcategory()
        {
            return _Context.categories.Where(c => c.SubCategory != null).ToList();
        }

        public List<Category> GetAllCategoryForMenu()
        {
            return _Context.categories.Where(c => !c.IsDelete).ToList();
        }

        public List<Category> GetSliderCategories()
        {
            return _Context.categories
                .Where(c => c.Slider != 0).ToList();
        }
    }
}
