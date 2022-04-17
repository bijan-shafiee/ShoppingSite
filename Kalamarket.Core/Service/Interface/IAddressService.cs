using _98market.Core.Viewmodel;
using _98market.DataLayer.Entities.Address;
using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Service.Interface
{
    public interface IAddressService
    {
        #region Province

        List<Province> showallProvince();
        int AddProvince(Province province);
        bool UpdateProvince(Province province);
        bool DeleteProvince(Province province);

        bool ExistProvince(int provinceid, string provincename);
        Province Findprovincebuyeid(int provinceid);
        #endregion

        #region city

        List<city> showallcity();

        int addcity(city city);
        bool updatecity(city city);
        bool deletecity(city city);
        bool Existcity(city city);
        city findbuyeidcity(int cityid);
        List<city> showallcityForProvince(int provinceid);
        #endregion

        #region Address

        ShowAddressForUserViewmodel findaddressforuser(int userid);

        int addusraddress(useraddress useraddress);

        bool updateaddress(useraddress useraddress);
        bool deleteaddress(useraddress useraddress);

        int UpdateAddressInCheckout(ShowAddressForUserViewmodel address);

        #endregion
    }
}
