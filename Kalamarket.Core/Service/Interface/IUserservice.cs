using _98market.Core.Viewmodel;
using _98market.DataLayer.Entities;
using _98market.DataLayer.Entities.Address;
using _98market.DataLayer.Entities.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Service.Interface
{
    public interface IUserservice
    {
        int AddUser(user user);
        bool updateuser(user user);
        bool deleteuser(user user);
        bool ExistEmail(string email, int id);
        user Finduser(int userid, string Code);
        user FindUserbuyeEmail(string Email);
        user LoginUser(string email, string Password);
        informationAccountViewmodel informationAccount(int userid);
        user findEditUserbuyeid(int userid);
        edituserViewmodel finduserbuyeid(int userid);
        List<showfavoirateViewmodel> showfavoirateUser(int userid);
        List<showorderForUser> showorderForUsers(int userid);
        List<mycommentViewmodel> mycomment(int userid);
        List<ShowDetailorder> showDetailorders(int orderid);
        List<user> GetUsers();
        List<role> GetRolesOfUser(int userId);
        List<permission> GetPermissionsOfUser(int userId);
        List<useraddress> GetAddressesOfUser(int userId);
        int UpdateRolesOfUser(int userId, List<int> roleIds);
        int UpdatePermissionsOfUser(int userId, List<int> permissionIds);
    }
}
