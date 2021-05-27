using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiSha.Entity.CheckingInModel;
using YiSha.Entity.OrganizationManage;
using YiSha.Entity.SystemManage;
using YiSha.Model.Param;
using YiSha.Model.Param.ToolManage;
using YiSha.Service.AttendanceManagement;
using YiSha.Service.OrganizationManage;
using YiSha.Service.SystemManage;
using YiSha.Util.MiniExcel.ExcelHelper;
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
        private DataDictService dataDictService = new DataDictService();
        private DataDictDetailService dataDictDetailService = new DataDictDetailService();
        private EmployeePositionRelationshipService employeePositionRelationshipService = new EmployeePositionRelationshipService();

        #region 导入数据方法
        public async Task<TData> ImportClockingIn(ImportParam param, List<ClockingInEntity> list)
        {
            var obj = await clockingInService.SaveFormList(param, list);
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
        public async Task<TData<List<ClockingInEntity>>> GetClockingInPageList(ListParam param, Pagination pagination)
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

        #region 导入部门表和导入员工部门关系表
        public async Task<TData> ImportEmployeeOrganizationalRelations(string filePath)
        {
            //拿到表格数据
            var data = MiniExcelReader.ReadEmployeeOrganizationalRelationsModelExcel(filePath);
            var reTdata = new TData();
            if (data.Count == 0)
            {
                reTdata.Message = "没有数据";
            }

            //获取模拟的部门子父数据
            #region 模拟数据
            //部门
            var DepartmentList = data.GroupBy(e => e.Department).Select(e =>
              new
              {
                  Department = e.Key
              });

            //科室
            var AdministrativeOfficeList = data.GroupBy(e => e.AdministrativeOffice).Select(e =>
              new
              {
                  AdministrativeOffice = e.Key
              });

            //班组
            var TeamOrGroupList = data.GroupBy(e => e.TeamOrGroup).Select(e =>
              new
              {
                  TeamOrGroup = e.Key
              });
            #endregion

            #region 真实录入或者获取真实的部门Id
            var num = await dataDictDetailService.GetMaxSort();
            //插入数据到对应的字典
            var DataDictDetailEntityList = DepartmentList.Select((e, a) =>
                new DataDictDetailEntity()
                {
                    DictKey = num++,
                    DictValue = e.Department,
                    DictSort = num++,
                    DictType = "Department",
                    DictStatus = 1,
                    ListClass = "primary",
                    Remark = "部门类型"
                }).ToList();

            num += DataDictDetailEntityList.Count;

            foreach (var item in DataDictDetailEntityList)
            {
                await dataDictDetailService.SaveForm(item);
            }

            var DataDictDetailEntityList1 = (AdministrativeOfficeList.Select((e, a) =>
                 new DataDictDetailEntity
                 {
                     DictKey = num + a++,
                     DictValue = e.AdministrativeOffice,
                     DictSort = num + a++,
                     DictType = "AdministrativeOffice",
                     DictStatus = 1,
                     ListClass = "primary",
                     Remark = "科室类型"
                 }));

            foreach (var item in DataDictDetailEntityList1)
            {
                await dataDictDetailService.SaveForm(item);
            }

            num += DataDictDetailEntityList.Count;
            var DataDictDetailEntityList2 = (TeamOrGroupList.Select((e, a) =>
                 new DataDictDetailEntity
                 {
                     DictKey = num + a++,
                     DictValue = e.TeamOrGroup,
                     DictSort = num + a++,
                     DictType = "TeamOrGroup",
                     DictStatus = 1,
                     ListClass = "primary",
                     Remark = "班组类型"
                 }));

            foreach (var item in DataDictDetailEntityList2)
            {
                await dataDictDetailService.SaveForm(item);
            }

            //更新模拟数据的对应id值
            data.ForEach(e =>
            {
                var ma = DataDictDetailEntityList.FirstOrDefault(a => a.DictValue == e.Department);
                if (ma != null)
                {
                    e.DepartmentID = ma.Id;
                }
                ma = DataDictDetailEntityList1.FirstOrDefault(a => a.DictValue == e.AdministrativeOffice);
                if (ma != null)
                {
                    e.AdministrativeOfficeID = ma.Id;
                }
                ma = DataDictDetailEntityList2.FirstOrDefault(a => a.DictValue == e.TeamOrGroup);
                if (ma != null)
                {
                    e.TeamOrGroupID = ma.Id;
                }
            });

            //添加数据到用户对应关系表
            var InsetData = data.Select(e => new EmployeePositionRelationshipEntity()
            {
                JobNumber = e.JobNumber,
                Name = e.Name,
                DepartmentID = e.DepartmentID,
                AdministrativeOfficeID = e.AdministrativeOfficeID,
                TeamOrGroupID = e.TeamOrGroupID
            }).ToList();
            reTdata = await employeePositionRelationshipService.SaveFormList(null, InsetData);
            #endregion
            return reTdata;
        }
        #endregion
    }
}
