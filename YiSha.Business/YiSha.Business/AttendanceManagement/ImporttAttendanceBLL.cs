using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiSha.Entity.CheckingInModel;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Param;
using YiSha.Model.Param.ToolManage;
using YiSha.Service.AttendanceManagement;
using YiSha.Service.OrganizationManage;
using YiSha.Util.Model;

namespace YiSha.Business.AttendanceManagement
{
    public class ImporttAttendanceBll
    {
        private ClockingInService clockingInService = new ClockingInService();
        private LeaveForPersonalAffairsService leaveForPersonalAffairsService = new LeaveForPersonalAffairsService();
        private JobOvertimeService jobOvertimeService = new JobOvertimeService();
        private SameWorkingHourForAnnualLeaveService sameWorkingHourForAnnualLeaveService = new SameWorkingHourForAnnualLeaveService();
        private SickLeaveService sickLeaveService = new SickLeaveService();

        #region 导入数据方法
        public async Task<TData> ImportClockingIn(ImportParam param, List<ClockingInEntity> list)
        {
            var obj= await clockingInService.SaveFormList(param,list);
            return obj;
        }

        public async Task<TData> ImporLeaveForPersonalAffairs(ImportParam param, List<LeaveForPersonalAffairsEntity> list)
        {
            var obj = await leaveForPersonalAffairsService.SaveFormList(param, list);
            return obj;
        }

        public async Task<TData> ImportJobOvertime(ImportParam param, List<JobOvertimeEntity> list)
        {
            var obj = await jobOvertimeService.SaveFormList(param, list);
            return obj;
        }

        public async Task<TData> ImporSameWorkingHourForAnnualLeave(ImportParam param, List<SameWorkingHourForAnnualLeaveEntity> list)
        {
            var obj = await sameWorkingHourForAnnualLeaveService.SaveFormList(param, list);
            return obj;
        }

        public async Task<TData> ImportSickLeave(ImportParam param, List<SickLeaveEntity> list)
        {
            var obj = await sickLeaveService.SaveFormList(param, list);
            return obj;
        }
        #endregion

        #region 查询
        public async  Task<TData<List<ClockingInEntity>>> GetClockingInPageList(ListParam param, Pagination pagination)
        {
            var obj = new TData<List<ClockingInEntity>>();
            var list = await clockingInService.GetPageList(param, pagination);
            obj.Data = list;
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }
        public async Task<TData<List<LeaveForPersonalAffairsEntity>>> GetLeaveForPersonalAffairsPageList(ListParam param, Pagination pagination)
        {
            var obj = new TData<List<LeaveForPersonalAffairsEntity>>();
            var list = await leaveForPersonalAffairsService.GetPageList(param, pagination);
            obj.Data = list;
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<JobOvertimeEntity>>> GetJobOvertimePageList(ListParam param, Pagination pagination)
        {
            var obj = new TData<List<JobOvertimeEntity>>();
            var list = await jobOvertimeService.GetPageList(param, pagination);
            obj.Data = list;
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SameWorkingHourForAnnualLeaveEntity>>> GetSameWorkingHourForAnnualLeavePageList(ListParam param, Pagination pagination)
        {
            var obj = new TData<List<SameWorkingHourForAnnualLeaveEntity>>();
            var list = await sameWorkingHourForAnnualLeaveService.GetPageList(param, pagination);
            obj.Data = list;
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SickLeaveEntity>>> GetSickLeavePageList(ListParam param, Pagination pagination)
        {
            var obj = new TData<List<SickLeaveEntity>>();
            var list = await sickLeaveService.GetPageList(param, pagination);
            obj.Data = list;
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }
        #endregion

    }
}
