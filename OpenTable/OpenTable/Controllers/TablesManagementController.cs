using OpenTable.Models;
using OpenTable.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenTable.Controllers
{
    public class TablesManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TablesManagementController(
            IUnitOfWork unitOfWork,
            ITableRepository tableRepository
            )
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult TablesManagement()
        {
            return View();
        }

        public ActionResult SaveRestaurantTablesSet(List<Table> tables)
        {
            foreach (var table in tables)
            {
                _unitOfWork.TableRepository.Add(table);
            }
            _unitOfWork.Complete();

            return null;
        }
    }
}