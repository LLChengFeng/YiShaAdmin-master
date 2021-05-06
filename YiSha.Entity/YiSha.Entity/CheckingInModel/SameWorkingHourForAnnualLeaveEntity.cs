using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YiSha.Entity;

namespace YiSha.Entity.CheckingInModel
{
    [Table("SameWorkingHourForAnnualLeave")]
    public class SameWorkingHourForAnnualLeaveEntity : BaseExtensionEntity
    {
        [ExcelColumnName("工号")]
        public long JobNumber { get; set; }
        [ExcelColumnName("姓名")]
        public string Name { get; set; }
        [ExcelColumnName("1")]
        public double Day1 { get; set; }
        [ExcelColumnName("2")]
        public double Day2 { get; set; }
        [ExcelColumnName("3")]
        public double Day3 { get; set; }
        [ExcelColumnName("4")]
        public double Day4 { get; set; }
        [ExcelColumnName("5")]
        public double Day5 { get; set; }
        [ExcelColumnName("6")]
        public double Day6 { get; set; }
        [ExcelColumnName("7")]
        public double Day7 { get; set; }
        [ExcelColumnName("8")]
        public double Day8 { get; set; }
        [ExcelColumnName("9")]
        public double Day9 { get; set; }
        [ExcelColumnName("10")]
        public double Day10 { get; set; }
        [ExcelColumnName("11")]
        public double Day11 { get; set; }
        [ExcelColumnName("12")]
        public double Day12 { get; set; }
        [ExcelColumnName("13")]
        public double Day13 { get; set; }
        [ExcelColumnName("14")]
        public double Day14 { get; set; }
        [ExcelColumnName("15")]
        public double Day15 { get; set; }
        [ExcelColumnName("16")]
        public double Day16 { get; set; }
        [ExcelColumnName("17")]
        public double Day17 { get; set; }
        [ExcelColumnName("18")]
        public double Day18 { get; set; }
        [ExcelColumnName("19")]
        public double Day19 { get; set; }
        [ExcelColumnName("20")]
        public double Day20 { get; set; }
        [ExcelColumnName("21")]
        public double Day21 { get; set; }
        [ExcelColumnName("22")]
        public double Day22 { get; set; }
        [ExcelColumnName("23")]
        public double Day23 { get; set; }
        [ExcelColumnName("24")]
        public double Day24 { get; set; }
        [ExcelColumnName("25")]
        public double Day25 { get; set; }
        [ExcelColumnName("26")]
        public double Day26 { get; set; }
        [ExcelColumnName("27")]
        public double Day27 { get; set; }
        [ExcelColumnName("28")]
        public double Day28 { get; set; }
        [ExcelColumnName("29")]
        public double Day29 { get; set; }
        [ExcelColumnName("30")]
        public double Day30 { get; set; }
        [ExcelColumnName("31")]
        public double Day31 { get; set; }
        [ExcelColumnName("合计")]
        public long Total { get; set; }
        /// <summary>
        /// 考勤数据的月份
        /// </summary>
        public DateTime NowMonth { get; set; }
    }
}
