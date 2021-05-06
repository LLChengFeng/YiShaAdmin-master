using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YiSha.Util.MiniExcel.Model;

namespace YiSha.Util.MiniExcel.ExcelHelper
{
    public static class MiniExcelReader
    {

        /// <summary>
        /// 读取开启记录从excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<ClockingInModel> ReadClockingInExcel(string filePath)
        {
            string absoluteFilePath = GlobalContext.HostingEnvironment.ContentRootPath + filePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            using (var stream = File.OpenRead(absoluteFilePath))
            {
                var rows = stream.Query<ClockingInModel>("考勤", ExcelType.XLSX).ToList();
                rows = rows.Where(e => !string.IsNullOrEmpty(e.Name) & e.JobNumber != 0).ToList();
                return rows;
            }
        }

        /// <summary>
        /// 读取开启记录从excel
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<JobOvertimeModel> ReadJobOvertimeExcel(string filePath)
        {
            string absoluteFilePath = GlobalContext.HostingEnvironment.ContentRootPath + filePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            using (var stream = File.OpenRead(absoluteFilePath))
            {
                var rows = stream.Query<JobOvertimeModel>("加班", ExcelType.XLSX).ToList();
                rows = rows.Where(e => !string.IsNullOrEmpty(e.Name) & e.JobNumber != 0).ToList();
                return rows;
            }
        }


        /// <summary>
        /// 读取开启记录从excel
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<LeaveForPersonalAffairsModel> ReadLeaveForPersonalAffairsExcel(string filePath)
        {
            string absoluteFilePath = GlobalContext.HostingEnvironment.ContentRootPath + filePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            using (var stream = File.OpenRead(absoluteFilePath))
            {
                var rows = stream.Query<LeaveForPersonalAffairsModel>("年假同一天工时", ExcelType.XLSX).ToList();
                rows = rows.Where(e => !string.IsNullOrEmpty(e.Name) & e.JobNumber != 0).ToList();
                return rows;
            }
        }


        /// <summary>
        /// 读取开启记录从excel
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<SameWorkingHourForAnnualLeaveModel> ReadSameWorkingHourForAnnualLeaveExcel(string filePath)
        {
            string absoluteFilePath = GlobalContext.HostingEnvironment.ContentRootPath + filePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            using (var stream = File.OpenRead(absoluteFilePath))
            {
                var rows = stream.Query<SameWorkingHourForAnnualLeaveModel>("事假", ExcelType.XLSX).ToList();
                rows = rows.Where(e => !string.IsNullOrEmpty(e.Name) & e.JobNumber != 0).ToList();
                return rows;
            }
        }


        /// <summary>
        /// 读取开启记录从excel
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<SickLeaveModel> ReadSickLeaveModelExcel(string filePath)
        {
            string absoluteFilePath = GlobalContext.HostingEnvironment.ContentRootPath + filePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            using (var stream = File.OpenRead(absoluteFilePath))
            {
                var rows = stream.Query<SickLeaveModel>("病假", ExcelType.XLSX).ToList();
                rows = rows.Where(e => !string.IsNullOrEmpty(e.Name) & e.JobNumber != 0).ToList();
                return rows;
            }
        }
    }
}
