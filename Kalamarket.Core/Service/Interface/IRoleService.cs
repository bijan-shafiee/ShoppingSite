using _98market.DataLayer.Entities.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Service.Interface
{
    public interface IRoleService
    {
        bool CheckPermission(int userid, int permissionid);
        List<role> GetRoles();
        int AddRole(role role);
        int UpdateRole(role role);
        int DeleteRole(int roleId);
        int AddPermission(permission permission, List<int> roleIds);
        int UpdatePermission(permission permission, List<int> roleIds);
        int DeletePermission(int permissionId);
        List<permission> GetPermissions();
        role GetRole(int roleId);
        permission GetPermission(int permissionId);
        List<role> GetRolesAndPermissions();
        List<role> GetRolesOfPermission(int permissionId);
    }
}
