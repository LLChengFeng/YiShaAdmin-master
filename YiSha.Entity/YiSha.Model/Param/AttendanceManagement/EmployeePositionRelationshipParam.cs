using System;
using System.Collections.Generic;
using System.Text;

namespace YiSha.Model.Param.AttendanceManagement
{
    public class EmployeePositionRelationshipParam
    {
        /// <summary>
        /// 工号
        /// </summary>
        /// <returns></returns>
        public long? JobNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
    }
}
