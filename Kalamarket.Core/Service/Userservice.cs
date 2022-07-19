using _98market.Core.ExtentionMethod;
using _98market.Core.Security;
using _98market.Core.Sender;
using _98market.Core.Service.Interface;
using _98market.Core.Viewmodel;
using _98market.DataLayer.Context;
using _98market.DataLayer.Entities;
using _98market.DataLayer.Entities.Address;
using _98market.DataLayer.Entities.Role;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _98market.Core.Service
{
    public class Userservice : IUserservice
    {
        private _98marketContext _Context;
        public Userservice(_98marketContext Context)
        {
            _Context = Context;
        }
        public bool ActiveCodeTrue(ActiveCodeViewModel model)
        {
            return _Context.users.Any(u => u.phone == model.Mobile && u.ActiveCode == model.ActiveCode);
        }

        public user ActiveUser(ActiveCodeViewModel model)
        {
            user user = _Context.users.SingleOrDefault(u => u.phone == model.Mobile);           
            user.isActive = true;
            user.ActiveCode = CodeGenerators.ActiveCode();//بعد از فعالسازی کد تغییر می کند
            _Context.users.Update(user);
            _Context.SaveChanges();
            return user;
           
           
        }

        public bool ExistMobile(string mobile)
        {
            bool user = _Context.users.Any(u => u.phone == mobile);
            return user;
        }



        public void RegisterUser(RegisteMobilerViewModel model)
        {
            user user = new user()
            {
                ActiveCode = CodeGenerators.ActiveCode(),
                phone = model.Mobile,
                userAccount = model.UserName,
                password = model.Password,
                isActive = false,
                CreateAccount = DateTime.Now
            };

            _Context.users.Add(user);
            _Context.SaveChanges();
            //SmsSender.VerifySend(model.Mobile, user.ActiveCode);//جهت ارسال پیامک

            string to = model.Mobile;
            string text = "کد فعالسازی شما  : " + user.ActiveCode ;
            string url = "https://RayganSMS.com/SendMessageWithUrl.ashx?UserName=bijan98shafiee&Password=Shafiee98&PhoneNumber=50002210003000&MessageBody=" + text + "&RecNumber=" + to + "&Smsclass=1";
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] result = wc.DownloadData(url);
            string response = System.Text.Encoding.ASCII.GetString(result);
            if (response == "0")
            {
                // ok
            }
            else
            {
                // sms not sent - or error sms (maybe user mobile number of username-password are not correct)
            }

        }

        public void SendSMSForLogin(LoginMobileViewModel model)
        {
            user user = _Context.users.SingleOrDefault(u => u.phone == model.Mobile);
            //SmsSender.VerifySend(model.Mobile, user.ActiveCode);//جهت ارسال پیامک
            //_98market.Program x = new _98market.Program();

            string to = model.Mobile;
            string text = "کد فعالسازی شما  : " + user.ActiveCode ;
            string url = "https://RayganSMS.com/SendMessageWithUrl.ashx?UserName=bijan98shafiee&Password=Shafiee98&PhoneNumber=50002200889117&MessageBody=" + text + "&RecNumber=" + to + "&Smsclass=1";
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] result = wc.DownloadData(url);
            string response = System.Text.Encoding.ASCII.GetString(result);
            if (response == "0")
            {
                // ok
            }
            else
            {
                // sms not sent - or error sms (maybe user mobile number of username-password are not correct)
            }

        }
        ///















        public int AddUser(user user)
        {
            try
            {
                _Context.users.Add(user);
                _Context.SaveChanges();
                return user.userid;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool deleteuser(user user)
        {
            try
            {
                user.IsDelete = true;
                _Context.users.Update(user);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExistEmail(string email, int id)
        {
            return _Context.users.Any(u => u.email == email && u.userid != id);
        }
        public bool ExistPhone(string phone)
        {
            return _Context.users.Any(u => u.phone == phone);
        }

        public bool updateuser(user user)
        {
            try
            {
                _Context.users.Update(user);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public user Finduser(int userid, string Code)
        {
            return _Context.users.Where(u => u.userid == userid && u.ActiveCode == Code).FirstOrDefault();
        }

        public user FindUserbuyeEmail(string Email)
        {
            return _Context.users.Where(u => u.email == Email).FirstOrDefault();
        }


        public user LoginUser(string email, string Password)
        {
            return _Context.users.Where(u => u.password == Password && u.email == email).SingleOrDefault();
        }

        public informationAccountViewmodel informationAccount(int userid)
        {
            return _Context.users.Where(x => x.userid == userid).Select(x => new informationAccountViewmodel
            {

                DateTime = x.CreateAccount,
                email = x.email,
                userid = x.userid,
                phone = x.phone,
                userfamily = x.userfamily,
                username = x.username,

            }).FirstOrDefault();
        }

        public edituserViewmodel finduserbuyeid(int userid)
        {
            return _Context.users.Where(x => x.userid == userid)
                .Select(x => new edituserViewmodel
                {
                    email = x.email,
                    phone = x.phone,
                    userfamily = x.userfamily,
                    username = x.username

                }).FirstOrDefault();
        }
        public user findEditUserbuyeid(int userid)
        {
            return _Context.users.Find(userid);

        }

        public List<showfavoirateViewmodel> showfavoirateUser(int userid)
        {
            return (from f in _Context.Faviorates
                    join u in _Context.users on f.userid equals u.userid
                    join p in _Context.products on f.productid equals p.productid
                    where (f.userid == userid)
                    select new showfavoirateViewmodel
                    {
                        productfatitle = p.productFaTitle,
                        productid = p.productid,
                        productimage = p.Productimage,
                        productstar = p.producStart,

                        productprice = _Context.ProductPrices.Where(x => x.count > 0
                          && x.productid == p.productid)
                        .OrderBy(x => x.mainprice).Select(x => x.mainprice).FirstOrDefault(),

                    }).ToList();

        }

        public List<showorderForUser> showorderForUsers(int userid)
        {
            return _Context.cart.Where(x => x.userid == userid).Select(x => new showorderForUser
            {
                cartid = x.cartid,
                createdate = x.CreateDate.MilatiToShamsi(),
                ispaye = x.ispay,
                totalprice = x.TotalPrice,

            }).ToList();

        }


        public List<mycommentViewmodel> mycomment(int userid)
        {
            return (from c in _Context.comments
                    join p in _Context.products on c.productid equals p.productid
                    where (c.userid == userid)
                    select new mycommentViewmodel
                    {
                        commenttitle = c.commentTitle,
                        isactive = c.IsActive,
                        productFaTitle = p.productFaTitle,
                        productid = p.productid,
                        productstar = p.producStart,
                        productimage = p.Productimage,
                    }).ToList();


        }

        public List<ShowDetailorder> showDetailorders(int orderid)
        {
            var b = (from cd in _Context.CartDetail
                     join c in _Context.cart on cd.Cartid equals c.cartid
                     join p in _Context.ProductPrices on cd.productid equals p.Productpriceid
                     where (cd.Cartid == orderid)
                     select new ShowDetailorder
                     {
                         productid = p.productid,
                         cartid = c.cartid,
                         price = cd.price,
                         productFaTitle = p.product.productFaTitle,
                         Totalprice = c.TotalPrice,
                         Status = c.Status,
                         TrackingCode = c.TrackingCode
                     }).ToList();
            return b;
        }

        public List<user> GetUsers()
        {
            return _Context.users.OrderByDescending(u => u.CreateAccount).ToList();
        }

        public List<role> GetRolesOfUser(int userId)
        {
            var roleIds = _Context.UserRoles.Where(ur => ur.userid == userId).Select(ur => ur.Roleid);
            return _Context.roles.Include(r => r.rolePermissions).ThenInclude(rp => rp.permission)
                .Where(r => roleIds.Contains(r.roleid)).ToList();
        }

        public List<permission> GetPermissionsOfUser(int userId)
        {
            var roleIds = _Context.UserRoles.Where(ur => ur.userid == userId).Select(ur => ur.Roleid);
            var permissionIds = _Context.RolePermissions.Where(rp => roleIds.Contains(rp.RolPermissionid)).Select(rp => rp.Permissionid);
            return _Context.permissions.Include(p => p.rolePermissions).ThenInclude(rp => rp.role)
                .Where(p => permissionIds.Contains(p.permissionid)).ToList();
        }

        public List<useraddress> GetAddressesOfUser(int userId)
        {
            return _Context.useraddresses.Include(ua => ua.city).Include(ua => ua.province)
                .Where(ua => ua.userid == userId).ToList();
        }

        public int UpdateRolesOfUser(int userId, List<int> roleIds)
        {
            try
            {
                user user = _Context.users.Find(userId);
                // first remove all roles
                var userRoles = _Context.UserRoles.Where(ur => ur.userid == userId);
                _Context.UserRoles.RemoveRange(userRoles);
                _Context.SaveChanges();
                // then add new roles
                foreach (int roleId in roleIds)
                {
                    UserRole userRole = new UserRole()
                    {
                        userid = userId,
                        Roleid = roleId
                    };
                    _Context.UserRoles.Add(userRole);
                }
                _Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int UpdatePermissionsOfUser(int userId, List<int> permissionIds)
        {
            throw new NotImplementedException();
        }



        public (string name, string mobile) GetUserBy(int id)
        {
            var user = _Context.users.Find(id);
            return (user.userfamily, user.phone);
        }

      
    }
}
