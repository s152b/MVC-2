//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Apps.Models;
using Apps.Models.Sys;
using Apps.IBLL;
using Apps.IDAL;
using Microsoft.Practices.Unity;
using Apps.Common;
using Apps.BLL.Core;

namespace Apps.BLL
{
	public class Virtual_SysRightBLL 
	{
		[Dependency]
        public ISysRightRepository m_Rep { get; set; }

		public DBContainer db = new DBContainer();
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">JQgrid分页</param>
        /// <param name="queryStr">搜索条件</param>
        /// <returns>列表</returns>
        public virtual List<SysRightModel> GetList(ref GridPager pager,string queryStr)
        {

            IQueryable<SysRight> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
										a => (a.Id != null && a.Id.Contains(queryStr))
															|| (a.ModuleId != null && a.ModuleId.Contains(queryStr))
														|| (a.RoleId != null && a.RoleId.Contains(queryStr))
														
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            List<SysRightModel> modelList = (from r in queryData
                                              select new SysRightModel
                                              {
                                                 													 Id = r.Id,
                                                  													 ModuleId = r.ModuleId,
                                                  													 RoleId = r.RoleId,
                                                  													 Rightflag = r.Rightflag,
                                                  
                                              }).ToList();
            return modelList;
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public virtual bool Create(ref ValidationErrors errors, SysRightModel model)
        {
            try
            {
                SysRight entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysRight();
                					entity.Id = model.Id;
                    					entity.ModuleId = model.ModuleId;
                    					entity.RoleId = model.RoleId;
                    					entity.Rightflag = model.Rightflag;
                    
                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.add("插入失败");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.add(ex.Message);
                ExceptionHandler.WriteException(ex);
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        public virtual bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    errors.add(Suggestion.DeleteFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public virtual bool Edit(ref ValidationErrors errors, SysRightModel model)
        {
            try
            {
                SysRight entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.add(Suggestion.Disable);
                    return false;
                }
                					entity.Id = model.Id;
                    					entity.ModuleId = model.ModuleId;
                    					entity.RoleId = model.RoleId;
                    					entity.Rightflag = model.Rightflag;
                    


                if (m_Rep.Edit(entity))
                {
                    return true;
                }
                else
                {
                    errors.add(Suggestion.EditFail);
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.add(ex.Message);
                ExceptionHandler.WriteException(ex);
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 判断是否存在实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否存在</returns>
        public virtual bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
        /// <summary>
        /// 根据ID获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        public virtual SysRightModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysRight entity = m_Rep.GetById(id);
                SysRightModel model = new SysRightModel();
                					 model.Id = entity.Id;
                    					 model.ModuleId = entity.ModuleId;
                    					 model.RoleId = entity.RoleId;
                    					 model.Rightflag = entity.Rightflag;
                    
                return model;
            }
            else
            {
                return null;
            }
        }
	}
}
