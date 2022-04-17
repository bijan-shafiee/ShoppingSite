using _98market.Core.Service.Interface;
using _98market.DataLayer.Context;
using _98market.DataLayer.Entities.Role;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _98market.Core.Service
{
    public class RoleService : IRoleService
    {
        private _98marketContext _Context;
        public RoleService(_98marketContext Context)
        {
            _Context = Context;
        }

        public int AddPermission(permission permission, List<int> roleIds)
        {
            try
            {
                _Context.permissions.Add(permission);
                _Context.SaveChanges();
                foreach (int roleId in roleIds)
                {
                    RolePermission rolePermission = new RolePermission()
                    {
                        Permissionid = permission.permissionid,
                        Roleid = roleId
                    };
                    _Context.RolePermissions.Add(rolePermission);
                }
                _Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int AddRole(role role)
        {
            try
            {
                _Context.roles.Add(role);
                _Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public bool CheckPermission(int userid, int permissionid)
        {
            var Rolid = _Context.UserRoles.Where(c => c.userid == userid)
                .Select(c => c.Roleid).ToList();

            if (!Rolid.Any())
                return false;


            List<int> RolPermission = _Context.RolePermissions
                .Where(p => p.Permissionid == permissionid).Select(p => p.Roleid).ToList();


            return RolPermission.Any(c => Rolid.Contains(c));

        }

        public int DeletePermission(int permissionId)
        {
            try
            {
                permission permission = _Context.permissions.Find(permissionId);
                _Context.permissions.Remove(permission);
                _Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteRole(int roleId)
        {
            try
            {
                role role = _Context.roles.Find(roleId);
                _Context.roles.Add(role);
                _Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public permission GetPermission(int permissionId)
        {
            return _Context.permissions.Find(permissionId);
        }

        public List<permission> GetPermissions()
        {
            return _Context.permissions.ToList();
        }

        public role GetRole(int roleId)
        {
            return _Context.roles.Find(roleId);
        }

        public List<role> GetRoles()
        {
            return _Context.roles.ToList();
        }

        public List<role> GetRolesAndPermissions()
        {
            return _Context.roles.Include(r => r.rolePermissions).ThenInclude(rp => rp.permission).ToList();
        }

        public List<role> GetRolesOfPermission(int permissionId)
        {
            var roleIds = _Context.RolePermissions.Where(rp => rp.Permissionid == permissionId).Select(rp => rp.Roleid);
            return _Context.roles.Where(r => roleIds.Contains(r.roleid)).ToList();
        }

        public int UpdatePermission(permission permission, List<int> roleIds)
        {
            try
            {
                _Context.permissions.Update(permission);
                // first remove all role permissions
                var rolePermissions = _Context.RolePermissions.Where(rp => rp.Permissionid == permission.permissionid);
                _Context.RemoveRange(rolePermissions);
                _Context.SaveChanges();
                // then add new role permissions
                foreach (int roleId in roleIds)
                {
                    RolePermission rolePermission = new RolePermission()
                    {
                        Permissionid = permission.permissionid,
                        Roleid = roleId
                    };
                    _Context.RolePermissions.Add(rolePermission);
                }
                _Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateRole(role role)
        {
            try
            {
                _Context.roles.Update(role);
                _Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
