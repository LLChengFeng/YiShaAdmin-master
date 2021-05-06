using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YiSha.Entity;

namespace YiSha.Entity.CheckingInModel
{
    [Table("Clocking")]
    public class ClockingInEntity : BaseExtensionEntity
    {
        [ExcelColumnName("工号")]
        public long JobNumber { get; set; }
        [ExcelColumnName("姓名")]
        public string Name { get; set; }
        [ExcelColumnName("1")]
        public string Day1 { get; set; }
        [ExcelColumnName("2")]
        public string Day2 { get; set; }
        [ExcelColumnName("3")]
        public string Da3 { get; set; }
        [ExcelColumnName("4")]
        public string Day4 { get; set; }
        [ExcelColumnName("5")]
        public string Day5 { get; set; }
        [ExcelColumnName("6")]
        public string Day6 { get; set; }
        [ExcelColumnName("7")]
        public string Day7 { get; set; }
        [ExcelColumnName("8")]
        public string Day8 { get; set; }
        [ExcelColumnName("9")]
        public string Day9 { get; set; }
        [ExcelColumnName("10")]
        public string Day10 { get; set; }
        [ExcelColumnName("11")]
        public string Day11 { get; set; }
        [ExcelColumnName("12")]
        public string Day12 { get; set; }
        [ExcelColumnName("13")]
        public string Day13 { get; set; }
        [ExcelColumnName("14")]
        public string Day14 { get; set; }
        [ExcelColumnName("15")]
        public string Day15 { get; set; }
        [ExcelColumnName("16")]
        public string Day16 { get; set; }
        [ExcelColumnName("17")]
        public string Day17 { get; set; }
        [ExcelColumnName("18")]
        public string Day18 { get; set; }
        [ExcelColumnName("19")]
        public string Day19 { get; set; }
        [ExcelColumnName("20")]
        public string Day20 { get; set; }
        [ExcelColumnName("21")]
        public string Day21 { get; set; }
        [ExcelColumnName("22")]
        public string Day22 { get; set; }
        [ExcelColumnName("23")]
        public string Day23 { get; set; }
        [ExcelColumnName("24")]
        public string Day24 { get; set; }
        [ExcelColumnName("25")]
        public string Day25 { get; set; }
        [ExcelColumnName("26")]
        public string Day26 { get; set; }
        [ExcelColumnName("27")]
        public string Day27 { get; set; }
        [ExcelColumnName("28")]
        public string Day28 { get; set; }
        [ExcelColumnName("29")]
        public string Day29 { get; set; }
        [ExcelColumnName("30")]
        public string Day30 { get; set; }
        [ExcelColumnName("31")]
        public string Day31 { get; set; }
        [ExcelColumnName("其他")]
        public double Other { get; set; }
        [ExcelColumnName("1/2年")]
        public double HalfAYear { get; set; }
        [ExcelColumnName("常")]
        public double Oftemn { get; set; }
        [ExcelColumnName("白")]
        public double DayT { get; set; }
        [ExcelColumnName("夜")]
        public double Night { get; set; }
        [ExcelColumnName("年")]
        public double Year { get; set; }
        [ExcelColumnName("事假")]
        public double LeavePersonalAffairs { get; set; }
        [ExcelColumnName("病假")]
        public double SickLeave { get; set; }
        [ExcelColumnName("产检假")]
        public double PrenatalCheckUpLeave { get; set; }
        [ExcelColumnName("产假")]
        public double MaternityLeave { get; set; }
        [ExcelColumnName("哺乳假")]
        public double BreastfeedingLeave { get; set; }
        [ExcelColumnName("公假")]
        public double LeaveOfAbsenceToAttendToPublicAffairs { get; set; }
        [ExcelColumnName("丧假")]
        public double FuneralLeave { get; set; }
        [ExcelColumnName("护理假")]
        public double NursingLeave { get; set; }
        [ExcelColumnName("外出")]
        public double GoOut { get; set; }
        [ExcelColumnName("出差")]
        public double evection { get; set; }
        [ExcelColumnName("加班")]
        public double Overtime { get; set; }
        [ExcelColumnName("病假零星")]
        public double SickLeaveSporadic { get; set; }
        [ExcelColumnName("事假零星")]
        public double PrivateAffairLeaveSporadic { get; set; }
        [ExcelColumnName("病假最终")]
        public double SickLeaveInTheEnd { get; set; }
        [ExcelColumnName("事假最终")]
        public double PersonalLeaveInTheEnd { get; set; }
        [ExcelColumnName("年假同一天工时")]
        public double SameWorkingHourForAnnualLeave { get; set; }
        [ExcelColumnName("总工时")]
        public double TotalProductiveHours { get; set; }
        [ExcelColumnName("应加应减节假日工时")]
        public double HolidayWorkingHoursShouldBeAddedOrReduced { get; set; }
        [ExcelColumnName("区分常日与倒班")]
        public double DistinguishBetweenRegularAndShiftHours { get; set; }
        [ExcelColumnName("常日班应上工时")]
        public double RegularDayShiftShouldBeWorkingHours { get; set; }
        [ExcelColumnName("倒班应上工时")]
        public double ShiftWorkShouldBeDone { get; set; }
        [ExcelColumnName("常日班加班工时(含节假日)")]
        public double OvertimeWorkingHoursIncludingHolidays { get; set; }
        [ExcelColumnName("倒班加班工时（含节假日）")]
        public double OvertimeOnShiftsincludingHolidays { get; set; }
        [ExcelColumnName("12号")]
        public double Particularlyday12 { get; set; }
        [ExcelColumnName("13号")]
        public double Particularlyday13 { get; set; }
        [ExcelColumnName("14号")]
        public double Particularlyday14 { get; set; }
        [ExcelColumnName("节假日前那一天夜班")]
        public double TheNightShiftBeforeTheHoliday { get; set; }
        [ExcelColumnName("节假")]
        public double TheHoliday { get; set; }
        [ExcelColumnName("倒班加班工时（不含节假日）")]
        public double OvertimeOnShiftsExcludingHolidays { get; set; }
        [ExcelColumnName("常日班加班工时（不含节假日）")]
        public double OvertimeWorkingHoursExcludingHolidays { get; set; }
        [ExcelColumnName("平加")]
        public double FlatAnd { get; set; }
        [ExcelColumnName("延时")]
        public double delayed { get; set; }
        [ExcelColumnName("餐补天数")]
        public double MealForDays { get; set; }
        /// <summary>
        /// 考勤数据的月份
        /// </summary>
        public DateTime NowMonth { get; set; }
    }
}
