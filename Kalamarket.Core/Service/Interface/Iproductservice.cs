using _98market.Core.Viewmodel;
using _98market.DataLayer.Entities.Entitieproduct;
using _98market.DataLayer.Entities.Entitieproduct.FaQ;
using System;
using System.Collections.Generic;
using System.Text;
using _98market.DataLayer.Entities;

namespace _98market.Core.Service.Interface
{
    public interface Iproductservice
    {
        #region ProductColor
        List<productColor> showallColor();

        int AddColor(productColor productColor);
        bool updateColor(productColor productColor);
        bool DeleteColor(productColor productColor);
        productColor findcolorbuyeid(int colorid);
        bool ExistColor(string namecolor, string codecolors, int colorid);

        #endregion

        #region Propertyname
        List<PropertyName> ShowAllProperty();
        int AddPropertyname(PropertyName propertyName);
        void ActiveFelter(int id);
        void DeActiveFelter(int id);
        bool ExistPropertyname(string name, int id);
        bool AddPropertyForCategory(List<Propertyname_Category> categories);
        List<UpdatePropertynameViewmodel> ShowpropertynameForUpdate(int propertynameid);
        bool UpdatePropertyname(PropertyName propertyName);
        bool DeleteProperyForCategory(int propid);
        PropertyName findpropbuyeid(int id);
        #endregion

        #region Product
        List<product> ShowallProduct();
        int AddProduct(product product);
        void DeleteProduct(int productid);
        product findproductbuyeid(int productid);
        bool UpdateProduct(product product);
        int FindCategoryForProduct(int product);
        List<PropertyName> showallpropertyforcategory(int categoryid);
        bool AddOrUpdatePropertynameForProduct(List<PropertyValue> propertyValues, int productid);
        bool DeletePropertyvalueForProduct(int productid);
        List<PropertyValue> showpropertyvalueforproduct(int productid);
        List<showPriceForProductViewmodel> ShowAllPriceForProduct(int Productid);
        int AddPriceForProduct(ProductPrice productPrice);
        void ActivePrice(int id);
        void DeActivePrice(int id);
        List<sepcialProductViewmoddel> ShowAllSepcialproduct();
        Tuple<string, List<SliderForCategoryViewmodel>> showproductForCategory(Category category);
        List<ShowDetailsProductViewmodel> ShowDetailsProduct(int productid);
        List<ValueViewmodel> showValueForProduct(int productid);
        List<ValueViewmodel> ShowAllPropertyForProduct(int productid);
        List<ShowCommentForProductViewmodel> ShowAllCommentForProduct(int productid);
        List<comapreviewmodel> Showcompareproduct(List<int?> productid);
        List<Propertyproductcompare> ShowPropertyCompare(int categoryid);
        List<GetProductForCompare> GetProductForCompare(int ctagoryid, List<int?> productid);
        List<product> search(string text, List<int> categoryid, List<int> propertyValues,
            List<int> brandid, int minprice = 0, int maxprice = 0, int sort = 1);
        List<RandomProductViewmodel> RandomProduct();
        List<productpricevm> GetProductprice(int productid);
        DetailProductViewmodel DetailProduct(int productid);
        List<PropertyName> GetPropertyNamesOfCategory(int categoryId);
        void AddProductSell(int cartId);
        void DecreaseProductCount(int cartId);
        #endregion

        #region review
        Review findreviewbuyeid(int productid);
        bool AddOrupdatereview(Review review);
        bool Deletereview(int productid);

        #endregion

        #region Faq
        List<ShowfaqViewmodel> ShowAllFaq(int productid);
        int AddAnswer(Answer answer);
        int AddQustion(question question);
        List<question> GetInactiveQuestions();
        int ActiveQuestion(int questionId);
        int DeActiveQuestion(int questionId);
        //int SetAnswers(int AnswersId);
        //List<question> GetInactiveAnswer();
        //int ActiveAnswer(int questionId);
        //int DeActiveAnswer(int questionId);
        #endregion

        #region Comment
        int AddComment(comment comment);
        int LikeComment(int userId, int commentId);
        int DislikeComment(int userId, int commentId);
        int ActiveComment(int commentId);
        int DeActiveComment(int commentId);
        List<comment> GetInactiveComments();
        CommentScalesViewModel GetAverageOfCommentScales(int productId);
        #endregion

        #region Faviorate
        bool removefaviorate(Faviorate faviorate);
        bool AddFaiorate(Faviorate faviorate);
        Faviorate findfavioratebuyeuserid(int userid, int productid);
        #endregion

        #region Reating
        List<ReatingViewmodel> GetreatingForProduct(int productid);
        #endregion

        #region View
        void AddProductView(int userId, int productId);
        bool HasUserViewedProduct(int userId, int productId);
        #endregion

        #region Rate
        List<Rate> GetRatesOfProduct(int productId);
        void AddRate(int userId, int productId, int star);
        bool HasUserRated(int userId, int productId);
        int GetAverageOfRates(int productId);
        #endregion

        #region Gallery
        List<ProductGallery> showgalleryforproduct(int productid);
        ProductGallery GetGallery(int id);
        void AddGallery(ProductGallery gallery);
        void EditGallery(ProductGallery gallery);
        int DeleteGallery(int id);
        #endregion

        Cart GetAmountBy(int cartId);
        string PaymentSucceeded(int cartId, string refId);
    }
}
