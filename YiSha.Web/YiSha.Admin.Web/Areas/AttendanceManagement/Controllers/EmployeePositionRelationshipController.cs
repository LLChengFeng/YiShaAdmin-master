using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YiSha.Admin.Web.Controllers;
using YiSha.Business.AttendanceManagement;
using YiSha.Business.OrganizationManage;
using YiSha.Business.SystemManage;
using YiSha.Entity.CheckingInModel;
using YiSha.Entity.OrganizationManage;
using YiSha.Entity.SystemManage;
using YiSha.Model.Param.AttendanceManagement;
using YiSha.Model.Param.OrganizationManage;
using YiSha.Model.Result;
using YiSha.Util.Model;

namespace YiSha.Admin.Web.Areas.AttendanceManagement.Controllers
{
    [Area("AttendanceManagement")]
    public class EmployeePositionRelationshipController : BaseController
    {
        private EmployeePositionRelationshipBLL employeePositionRelationshipBll = new EmployeePositionRelationshipBLL();

        #region 视图
        public IActionResult EmployeePositionRelationshipIndex()
        {
            return View();
        }

        public IActionResult EmployeePositionRelationshipForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        public async Task<IActionResult> GetFormJson(long id)
        {
            TData<EmployeePositionRelationshipEntity> obj = await employeePositionRelationshipBll.GetEntity(id);
            return Json(obj);
        }

        [HttpGet]
        //[AuthorizeFilter("organization:department:search,organization:user:search")]
        public async Task<IActionResult> GetPageListJson(EmployeePositionRelationshipParam param, Pagination pagination)
        {
            TData<List<EmployeePositionRelationshipEntity>> obj = await employeePositionRelationshipBll.GetEmployeePositionRelationshipBySql(param, pagination);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        //[AuthorizeFilter("organization:department:add,organization:department:edit")]
        public async Task<IActionResult> SaveFormJson(EmployeePositionRelationshipEntity entity)
        {
            TData<string> obj = await employeePositionRelationshipBll.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        //[AuthorizeFilter("organization:department:delete")]
        public async Task<IActionResult> DeleteFormJson(string ids)
        {
            TData obj = await employeePositionRelationshipBll.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
