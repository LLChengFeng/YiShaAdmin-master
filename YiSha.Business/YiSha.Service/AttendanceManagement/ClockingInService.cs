using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YiSha.Model.Param.ToolManage;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Util;
using YiSha.Data.Repository;
using YiSha.Entity.CheckingInModel;
using System.Linq;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Param;
using YiSha.Service.OrganizationManage;
using NPOI.POIFS.FileSystem;

namespace YiSha.Service.AttendanceManagement
{
    public class ClockingInService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ClockingInEntity>> GetList(ListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<ClockingInEntity>> GetPageList(ListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<ClockingInEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ClockingInEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ClockingInEntity entity)
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

        public async Task<TData> SaveFormList(ImportParam param, List<ClockingInEntity> list)
        {
            TData obj = new TData();
            var db = await this.BaseRepository().BeginTrans();
            try
            {
                if (list.Any())
                {
                    foreach (ClockingInEntity entity in list)
                    {
                        await entity.Create();
                    }
                    await this.BaseRepository().Insert<ClockingInEntity>(list);
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
            await this.BaseRepository().Delete<ClockingInEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<ClockingInEntity, bool>> ListFilter(ListParam param)
        {
            var expression = LinqExtensions.True<ClockingInEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
