using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YiSha.Entity.CheckingInModel
{
    [Table("EmployeePositionRelationship")]
    public class EmployeePositionRelationshipEntity : BaseExtensionEntity
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
        /// <summary>
        /// 部门关联Id
        /// </summary>
        /// <returns></returns>
        public long? DepartmentID { get; set; }
        /// <summary>
        /// 科室关联Id
        /// </summary>
        /// <returns></returns>
        public long? AdministrativeOfficeID { get; set; }
        /// <summary>
        /// 组织关联Id
        /// </summary>
        /// <returns></returns>
        public long? TeamOrGroupID { get; set; }
    }
}
