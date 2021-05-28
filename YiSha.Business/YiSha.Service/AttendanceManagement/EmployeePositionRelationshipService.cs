using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YiSha.Data.Repository;
using YiSha.Entity.CheckingInModel;
using YiSha.Model.Param.ToolManage;
using YiSha.Model.Param;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Util;
using System.Linq;
using System.Data.Common;
using YiSha.Model.Param.AttendanceManagement;
using YiSha.Entity.SystemManage;
using YiSha.Model.Param.SystemManage;
using System.Reflection.Metadata;
using YiSha.Data;

namespace YiSha.Service.AttendanceManagement
{
    public class EmployeePositionRelationshipService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<EmployeePositionRelationshipEntity>> GetList(EmployeePositionRelationshipParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<EmployeePositionRelationshipEntity>> GetPageList(EmployeePositionRelationshipParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }


        public async Task<List<EmployeePositionRelationshipEntity>> GetPageListSql(EmployeePositionRelationshipParam param, Pagination pagination)
        {
            var dbParam = new List<DbParameter>();
            var sql =new StringBuilder( @"SELECT
                    em.Id,
                    em.JobNumber,
                    em.`Name`,
                    (SELECT DictValue from SysDataDictDetail WHERE id=em.DepartmentID) as DepartmentName,
                    (SELECT DictValue from SysDataDictDetail WHERE id=em.AdministrativeOfficeID) as AdministrativeOfficeName,
                    (SELECT DictValue from SysDataDictDetail WHERE id=em.TeamOrGroupID) as TeamOrGroupName,
                    em.BaseIsDelete,
                    em.BaseCreateTime,
                    em.BaseCreatorId,
                    em.BaseModifyTime,
                    em.BaseModifierId,
                    em.BaseVersion
                    FROM
                    EmployeePositionRelationship AS em
                    WHERE 1=1");
            if (param.JobNumber.ParseToInt()>0)
            {
                sql.Append(" AND em.JobNumber=@JobNumber ");
                dbParam.Add(DbParameterExtension.CreateDbParameter("@JobNumber", param.JobNumber));
            }
            if (!string.IsNullOrEmpty(param.Name))
            {
                sql.Append(" AND em.`Name` LIKE '@Name%' ");
                dbParam.Add(DbParameterExtension.CreateDbParameter("@Name", param.Name));
            }
            var list = await this.BaseRepository().FindList<EmployeePositionRelationshipEntity>(sql.ToString(), dbParam.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<EmployeePositionRelationshipEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<EmployeePositionRelationshipEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(EmployeePositionRelationshipEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                await entity.Modify();
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task<TData> SaveFormList(ImportParam param, List<EmployeePositionRelationshipEntity> list)
        {
            TData obj = new TData();
            var db = await this.BaseRepository().BeginTrans();
            try
            {
                foreach (var item in list)
                {
                    var para= new EmployeePositionRelationshipParam() { JobNumber = item.JobNumber };
                    var check = await GetIsHadByDictValue(para);
                    if (check != null)
                    {
                        list.Remove(item);
                    }
                }
                if (list.Any())
                {
                    foreach (EmployeePositionRelationshipEntity entity in list)
                    {
                        await entity.Create();
                    }
                    await this.BaseRepository().Insert<EmployeePositionRelationshipEntity>(list);
                    obj.Tag = 1;
                    await db.CommitTrans();
                }
                else
                {
                    obj.Message = " 未找到导入的数据";
                }
            }
            catch
            {
                await db.RollbackTrans();
                throw;
            }
            return obj;
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<EmployeePositionRelationshipEntity>(idArr);
        }

        public async Task<EmployeePositionRelationshipEntity> GetIsHadByDictValue(EmployeePositionRelationshipParam param)
        {
            var expression = ListFilter(param);
            return await this.BaseRepository().FindEntity<EmployeePositionRelationshipEntity>(expression);
        }
        #endregion

        #region 私有方法
        private Expression<Func<EmployeePositionRelationshipEntity, bool>> ListFilter(EmployeePositionRelationshipParam param)
        {
            var expression = LinqExtensions.True<EmployeePositionRelationshipEntity>();
            if (param != null)
            {
                if (param.JobNumber.ParseToInt() > 0)
                {
                    expression = expression.And(t => t.JobNumber == param.JobNumber);
                }

                if (!string.IsNullOrEmpty(param.Name))
                {
                    expression = expression.And(t => t.Name.Contains(param.Name));
                }
            }
            return expression;
        }
        #endregion
    }
}
