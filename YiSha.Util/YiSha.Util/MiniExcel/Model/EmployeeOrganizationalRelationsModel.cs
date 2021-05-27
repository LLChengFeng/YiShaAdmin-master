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
        public long? DepartmentID { get; set; }
        public long? AdministrativeOfficeID { get; set; }
        public long? TeamOrGroupID { get; set; }
    }
}
