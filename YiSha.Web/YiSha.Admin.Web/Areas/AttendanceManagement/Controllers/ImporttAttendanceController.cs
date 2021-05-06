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

namespace YiSha.Admin.Web.Areas.AttendanceManagement.Controllers
{
    [Area("AttendanceManagement")]
    public class ImporttAttendanceController : BaseController
    {
        public IActionResult Attendance()
        {
            return View();
        }

        public IActionResult AttendanceUserImport()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImportAttendance(ImportParam param)
        {
            //获取数据
            var data1 = MiniExcelReader.ReadClockingInExcel(param.FilePath);
            var data2 = MiniExcelReader.ReadJobOvertimeExcel(param.FilePath);
            var data3 = MiniExcelReader.ReadLeaveForPersonalAffairsExcel(param.FilePath);
            var data4 = MiniExcelReader.ReadSameWorkingHourForAnnualLeaveExcel(param.FilePath);
            var data5 = MiniExcelReader.ReadSickLeaveModelExcel(param.FilePath);


            //TData obj = await userBLL.ImportUser(param, list);
            return Json("");
        }
    }
}
