using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YiSha.Business.OrganizationManage;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Param;
using YiSha.Util.Model;
using YiSha.Util;
using MiniExcelLibs;
using System.IO;
using YiSha.Util.MiniExcel.Model;
using YiSha.Util.MiniExcel.ExcelHelper;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.CheckingInModel;
using YiSha.Business.AttendanceManagement;
using YiSha.Model.Param.OrganizationManage;
using YiSha.Model.Param.ToolManage;

namespace YiSha.Admin.Web.Areas.AttendanceManagement.Controllers
{
    [Area("AttendanceManagement")]
    public class ImporttAttendanceController : BaseController
    {
        private ImporttAttendanceBll importtAttendanceBll = new ImporttAttendanceBll();

        public IActionResult Attendance()
        {
            return View();
        }

        public IActionResult AttendanceUserImport(int imporType)
        {
            ViewBag.ImporType = imporType;
            return View();
        }

        /// <summary>
        /// 导本月考勤数据表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ImportAttendance(ImportParam param)
        {
            //获取数据
            var data1 = MiniExcelReader.ReadClockingInExcel(param.FilePath);
            var data2 = MiniExcelReader.ReadJobOvertimeExcel(param.FilePath);
            var data3 = MiniExcelReader.ReadLeaveForPersonalAffairsExcel(param.FilePath);
            var data4 = MiniExcelReader.ReadSameWorkingHourForAnnualLeaveExcel(param.FilePath);
            var data5 = MiniExcelReader.ReadSickLeaveModelExcel(param.FilePath);

            var data = new TData();
            var importParam = new ImportParam();
            //模型映射
            if (data1?.Count>0)
            {
                var InData= data1.MapToList<ClockingInEntity>();
                var retData= await importtAttendanceBll.ImportClockingIn(importParam,InData);
                data.Tag = +retData.Tag;
                data.Message += retData.Message;
            }
            if (data2?.Count > 0)
            {
                var InData = data2.MapToList<JobOvertimeEntity>();
                var retData = await importtAttendanceBll.ImportJobOvertime(importParam, InData);
                data.Message += retData.Message;
            }
            if (data3?.Count > 0)
            {
                var InData = data3.MapToList<LeaveForPersonalAffairsEntity>();
                var retData = await importtAttendanceBll.ImporLeaveForPersonalAffairs(importParam, InData);
                data.Message += retData.Message;
            }
            if (data4?.Count > 0)
            {
                var InData = data4.MapToList<SameWorkingHourForAnnualLeaveEntity>();
                var retData = await importtAttendanceBll.ImporSameWorkingHourForAnnualLeave(importParam, InData);
                data.Message += retData.Message;
            }
            if (data5?.Count > 0)
            {
                var InData = data5.MapToList<SickLeaveEntity>();
                var retData = await importtAttendanceBll.ImportSickLeave(importParam, InData);
                data.Message += retData.Message;
            }
            //TData obj = await userBLL.ImportUser(param, list);
            return Json(data);
        }

        /// <summary>
        /// 插入员工对应的部门组织班组信息，并且更新部门管理表数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ImportAttendanceDepartEmployee(ImportParam param)
        {
            var obj= await importtAttendanceBll.ImportEmployeeOrganizationalRelations(param.FilePath);
            return Json(obj);
        }

        [HttpGet]
        //[AuthorizeFilter("organization:user:search")]
        public async Task<IActionResult> GetClockingInListJson(Pagination pagination)
        {
            var param = new ListParam();
            pagination.Sort = "JobNumber";
            var obj = await importtAttendanceBll.GetClockingInPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        //[AuthorizeFilter("organization:user:search")]
        public async Task<IActionResult> GetJobOvertimePageListJson(Pagination pagination)
        {
            var param = new ListParam();
            pagination.Sort = "JobNumber";
            var obj = await importtAttendanceBll.GetJobOvertimePageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        //[AuthorizeFilter("organization:user:search")]
        public async Task<IActionResult> GetLeaveForPersonalAffairsPageListJson(Pagination pagination)
        {
            var param = new ListParam();
            pagination.Sort = "JobNumber";
            var obj = await importtAttendanceBll.GetLeaveForPersonalAffairsPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        //[AuthorizeFilter("organization:user:search")]
        public async Task<IActionResult> GetSameWorkingHourForAnnualLeavePageListJson(Pagination pagination)
        {
            var param = new ListParam();
            pagination.Sort = "JobNumber";
            var obj = await importtAttendanceBll.GetSameWorkingHourForAnnualLeavePageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        //[AuthorizeFilter("organization:user:search")]
        public async Task<IActionResult> GetSickLeavePageListJson(Pagination pagination)
        {
            var param = new ListParam();
            pagination.Sort = "JobNumber";
            var obj = await importtAttendanceBll.GetSickLeavePageList(param, pagination);
            return Json(obj);
        }
    }
}
