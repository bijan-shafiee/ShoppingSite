using _98market.Core.Service.Interface;
using _98market.DataLayer.Context;
using _98market.DataLayer.Entities;
using _98market.DataLayer.Entities.Entitieproduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _98market.Core.Viewmodel;
using _98market.Core.ExtentionMethod;

namespace _98market.Core.Service
{
    public class IndexService : IIndexService
    {
        private _98marketContext _Context;
        public IndexService(_98marketContext Context)
        {
            _Context = Context;
        }

        public int AddIndexImage(IndexImage indexImage)
        {
            try
            {
                _Context.IndexImages.Add(indexImage);
                _Context.SaveChanges();
                return indexImage.IndexImageId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IndexImage GetIndexImage()
        {
            return _Context.IndexImages.SingleOrDefault();
        }

        public int UpdateIndexImage(IndexImageViewModel indexImage)
        {
            IndexImage IndexImage = GetIndexImage();
            try
            {
                // image 1
                if (indexImage.Image1 != null)
                {
                    string imgname1 = UploadImgadplacement.CreateImage(indexImage.Image1);
                    IndexImage.Image1 = imgname1;
                }
                // image 2
                if (indexImage.Image2 != null)
                {
                    string imgname2 = UploadImgadplacement.CreateImage(indexImage.Image2);
                    IndexImage.Image2 = imgname2;
                }
                // image 3
                if (indexImage.Image3 != null)
                {
                    string imgname3 = UploadImgadplacement.CreateImage(indexImage.Image3);
                    IndexImage.Image3 = imgname3;
                }
                // image 4
                if (indexImage.Image4 != null)
                {
                    string imgname4 = UploadImgadplacement.CreateImage(indexImage.Image4);
                    IndexImage.Image4 = imgname4;
                }
                // image 5
                if (indexImage.Image5 != null)
                {
                    string imgname5 = UploadImgadplacement.CreateImage(indexImage.Image5);
                    IndexImage.Image5 = imgname5;
                }
                // image 6
                if (indexImage.Image6 != null)
                {
                    string imgname6 = UploadImgadplacement.CreateImage(indexImage.Image6);
                    IndexImage.Image6 = imgname6;
                }
                // image 7
                if (indexImage.Image7 != null)
                {
                    string imgname7 = UploadImgadplacement.CreateImage(indexImage.Image7);
                    IndexImage.Image7 = imgname7;
                }
                // image 8
                if (indexImage.Image8 != null)
                {
                    string imgname8 = UploadImgadplacement.CreateImage(indexImage.Image8);
                    IndexImage.Image8 = imgname8;
                }
                // image 9
                if (indexImage.Image9 != null)
                {
                    string imgname9 = UploadImgadplacement.CreateImage(indexImage.Image9);
                    IndexImage.Image9 = imgname9;
                }
                // image 10
                if (indexImage.Image10 != null)
                {
                    string imgname10 = UploadImgadplacement.CreateImage(indexImage.Image10);
                    IndexImage.Image10 = imgname10;
                }
                // image 11
                if (indexImage.Image11 != null)
                {
                    string imgname11 = UploadImgadplacement.CreateImage(indexImage.Image11);
                    IndexImage.Image11 = imgname11;
                }
                // image 12
                if (indexImage.Image12 != null)
                {
                    string imgname12 = UploadImgadplacement.CreateImage(indexImage.Image12);
                    IndexImage.Image12 = imgname12;
                }
                // links
                IndexImage.Link1 = indexImage.Link1;
                IndexImage.Link2 = indexImage.Link2;
                IndexImage.Link3 = indexImage.Link3;
                IndexImage.Link4 = indexImage.Link4;
                IndexImage.Link5 = indexImage.Link5;
                IndexImage.Link6 = indexImage.Link6;
                IndexImage.Link7 = indexImage.Link7;
                IndexImage.Link8 = indexImage.Link8;
                IndexImage.Link9 = indexImage.Link9;
                IndexImage.Link10 = indexImage.Link10;
                IndexImage.Link11 = indexImage.Link11;
                IndexImage.Link12 = indexImage.Link12;
                _Context.Update(IndexImage);
                _Context.SaveChanges();
                return IndexImage.IndexImageId;
            }
            catch
            {
                return 0;
            }
        }

        public IndexImageViewModel GetIndexImageViewModel()
        {
            IndexImage indexImage = GetIndexImage();
            IndexImageViewModel model = new IndexImageViewModel()
            {
                Link1 = indexImage.Link1,
                Link2 = indexImage.Link2,
                Link3 = indexImage.Link3,
                Link4 = indexImage.Link4,
                Link5 = indexImage.Link5,
                Link6 = indexImage.Link6,
                Link7 = indexImage.Link7,
                Link8 = indexImage.Link8,
                Link9 = indexImage.Link9,
                Link10 = indexImage.Link10,
                Link11 = indexImage.Link11,
                Link12 = indexImage.Link12
            };
            return model;
        }

    }
}
