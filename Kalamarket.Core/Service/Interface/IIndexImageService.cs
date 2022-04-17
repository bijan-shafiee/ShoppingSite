using _98market.Core.Viewmodel;
using _98market.DataLayer.Entities;
using _98market.DataLayer.Entities.Entitieproduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Service.Interface
{
    public interface IIndexService
    {
        IndexImage GetIndexImage();
        int AddIndexImage(IndexImage indexImage);
        int UpdateIndexImage(IndexImageViewModel indexImage);
        IndexImageViewModel GetIndexImageViewModel();
    }
}
