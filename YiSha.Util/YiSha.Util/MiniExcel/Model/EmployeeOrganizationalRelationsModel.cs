using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace YiSha.Util.MiniExcel.Model
{
    public class EmployeeOrganizationalRelationsModel
    {
        [ExcelColumnName("工号")]
        public long JobNumber { get; set; }
        [ExcelColumnName("姓名")]
        public string Name { get; set; }
        [ExcelColumnName("部门")]
        public string Department { get; set; }
        [ExcelColumnName("科室")]
        public string AdministrativeOffice { get; set; }
        [ExcelColumnName("班组")]
        public string TeamOrGroup { get; set; }
        public string DepartmentID { get; set; }
        public string AdministrativeOfficeID { get; set; }
        public string TeamOrGroupID { get; set; }

        #region 用于循环遍历的字段     
        /// <summary>
        /// 真实的ID
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 真实的ID
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 用于模拟关系的id
        /// </summary>
        public Guid AdministrativeOfficeId { get; set; }

        /// <summary>
        /// 用于模拟关系的id
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// 用于模拟关系的id
        /// </summary>
        public Guid TeamOrGroupId { get; set; }

        /// <summary>
        /// 模拟的父ID
        /// </summary>
        public Guid DParentId { get; set; }
        #endregion
    }
}
