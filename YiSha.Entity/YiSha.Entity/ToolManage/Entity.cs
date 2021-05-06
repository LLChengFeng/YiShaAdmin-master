using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.ToolManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-05-06 03:24
    /// 描 述：实体类
    /// </summary>
    [Table("leaveforpersonalaffairs")]
    public class Entity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Da3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day10 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day13 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day14 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day15 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day16 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day17 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day18 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day19 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day20 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day21 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day22 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day23 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day24 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day25 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day26 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day27 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day28 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day29 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day30 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day31 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day7 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day8 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Day9 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? JobNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? NowMonth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? Total { get; set; }
    }
}
