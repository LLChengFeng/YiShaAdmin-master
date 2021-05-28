using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using YiSha.Entity.CheckingInModel;
using YiSha.Entity.OrganizationManage;
using YiSha.Entity.SystemManage;
using YiSha.Model.Param.AttendanceManagement;
using YiSha.Model.Param.ToolManage;
using YiSha.Service.AttendanceManagement;
using YiSha.Service.OrganizationManage;
using YiSha.Service.SystemManage;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;

namespace YiSha.Business.AttendanceManagement
{
    public class EmployeePositionRelationshipBLL
    {
        private EmployeePositionRelationshipService employeePositionRelationshipService = new EmployeePositionRelationshipService();

        #region 查询
        public async Task<TData<EmployeePositionRelationshipEntity>> GetEntity(long id)
        {
            TData<EmployeePositionRelationshipEntity> obj = new TData<EmployeePositionRelationshipEntity>();
            obj.Data = await employeePositionRelationshipService.GetEntity(id);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<EmployeePositionRelationshipEntity>>> GetEmployeePositionRelationshipList(EmployeePositionRelationshipParam param, Pagination pagination)
        {
            var obj = new TData<List<EmployeePositionRelationshipEntity>>();
            var list = await employeePositionRelationshipService.GetPageList(param, pagination);
            obj.Data = list;
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<EmployeePositionRelationshipEntity>>> GetEmployeePositionRelationshipBySql(EmployeePositionRelationshipParam param, Pagination pagination)
        {
            var obj = new TData<List<EmployeePositionRelationshipEntity>>();
            var list = await employeePositionRelationshipService.GetPageListSql(param, pagination);
            obj.Data = list;
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(EmployeePositionRelationshipEntity entity)
        {
            TData<string> obj = new TData<string>();
            await employeePositionRelationshipService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await employeePositionRelationshipService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion
    }
}
