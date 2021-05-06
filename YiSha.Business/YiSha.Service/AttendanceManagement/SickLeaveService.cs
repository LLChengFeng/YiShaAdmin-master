﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YiSha.Model.Param.ToolManage;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Util;
using YiSha.Data.Repository;
using System.Linq;
using YiSha.Entity.CheckingInModel;
using YiSha.Model.Param;

namespace YiSha.Service.AttendanceManagement
{
    public class SickLeaveService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<SickLeaveEntity>> GetList(ListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<SickLeaveEntity>> GetPageList(ListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<SickLeaveEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<SickLeaveEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(SickLeaveEntity entity) 
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

        public async Task<TData> SaveFormList(ImportParam param, List<SickLeaveEntity> list)
        {
            TData obj = new TData();
            var db = await this.BaseRepository().BeginTrans();
            try
            {
                if (list.Any())
                {
                    foreach (SickLeaveEntity entity in list)
                    {
                        await entity.Create();
                    }
                    await this.BaseRepository().Insert<SickLeaveEntity>(list);
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
            await this.BaseRepository().Delete<SickLeaveEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<SickLeaveEntity, bool>> ListFilter(ListParam param)
        {
            var expression = LinqExtensions.True<SickLeaveEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}