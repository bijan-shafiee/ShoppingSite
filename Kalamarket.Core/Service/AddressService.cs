using _98market.Core.Service.Interface;
using _98market.Core.Viewmodel;
using _98market.DataLayer.Context;
using _98market.DataLayer.Entities.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _98market.Core.Service
{
    public class AddressService : IAddressService
    {
        private _98marketContext _Context;
        public AddressService(_98marketContext Context)
        {
            _Context = Context;
        }
        public int addcity(city city)
        {
            try
            {
                _Context.cities.Add(city);
                _Context.SaveChanges();
                return city.cityid;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int AddProvince(Province province)
        {
            try
            {
                _Context.Add(province);
                _Context.SaveChanges();
                return province.provinceid;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int addusraddress(useraddress useraddress)
        {
            try
            {
                _Context.Add(useraddress);
                _Context.SaveChanges();
                return useraddress.addresid;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public bool deleteaddress(useraddress useraddress)
        {
            try
            {
                useraddress.Isdelete = true;
                _Context.Update(useraddress);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deletecity(city city)
        {
            try
            {
                city.isdelete = true;
                _Context.Update(city);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProvince(Province province)
        {
            try
            {
                province.isDelete = true;
                _Context.Update(province);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Existcity(city city)
        {
            return _Context.cities.Any(c => c.cityid != city.cityid && c.cityname == city.cityname);
        }

        public bool ExistProvince(int provinceid, string provincename)
        {
            return _Context.provinces.Any(p => p.provinceid != provinceid && p.provincename == provincename);
        }

        public ShowAddressForUserViewmodel findaddressforuser(int userid)
        {
            var useraddres = (from ua in _Context.useraddresses
                              join p in _Context.provinces on ua.provinceid equals p.provinceid
                              join c in _Context.cities on p.provinceid equals c.provinceid

                              where (!ua.Isdelete && ua.userid == userid)
                              select new ShowAddressForUserViewmodel
                              {
                                  userid = ua.userid,
                                  addresid = ua.addresid,
                                  cityname = c.cityname,
                                  FullAddress = ua.FullAddress,
                                  Landlinephonenumber = ua.Landlinephonenumber,
                                  phone = ua.phone,
                                  Plaque = ua.Plaque,
                                  postalCode = ua.postalCode,
                                  provincename = p.provincename,
                                  Recipientname = ua.Recipientname,
                                  unit = ua.unit,
                                  provinceid = p.provinceid,
                                  cityid = c.cityid,
                              }).FirstOrDefault();
            return useraddres;
        }

        public city findbuyeidcity(int cityid)
        {
            return _Context.cities.Find(cityid);
        }

        public Province Findprovincebuyeid(int provinceid)
        {
            return _Context.provinces.Find(provinceid);
        }

        public List<city> showallcity()
        {
            return _Context.cities.Where(c => !c.isdelete).ToList();
        }
        public List<city> showallcityForProvince(int provinceid)
        {
            return _Context.cities.Where(c => !c.isdelete && c.provinceid == provinceid).ToList();
        }
        public List<Province> showallProvince()
        {
            return _Context.provinces.Where(p => !p.isDelete).ToList();
        }

        public bool updateaddress(useraddress useraddress)
        {
            try
            {
                _Context.Update(useraddress);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int UpdateAddressInCheckout(ShowAddressForUserViewmodel address)
        {
            useraddress userAddress = _Context.useraddresses.Find(address.addresid);
            userAddress.Recipientname = address.Recipientname;
            userAddress.phone = address.phone;
            userAddress.postalCode = address.postalCode;
            userAddress.FullAddress = address.FullAddress;
            _Context.useraddresses.Update(userAddress);
            _Context.SaveChanges();
            return 1;
        }

        public bool updatecity(city city)
        {
            try
            {
                _Context.Update(city);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProvince(Province province)
        {
            try
            {
                _Context.Update(province);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
