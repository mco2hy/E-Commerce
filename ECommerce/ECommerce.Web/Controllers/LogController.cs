﻿using ECommerce.Data.Enum;
using ECommerce.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerce.Web.Controllers
{
    public class LogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [FilterContext.Log]
        [FilterContext.Auth(UserTitle.Administrator)]
        public IActionResult Index()
        {
            return View();
        }

        [FilterContext.Log]
        [Route("/log/getir")]
        [FilterContext.Auth(UserTitle.Administrator)]
        public IActionResult GetAll()
        {
            var logs = _unitOfWork.LogRepository
                .Query()
                .Include(a => a.User)
                .ToList();

            return new JsonResult(logs);
        }
    }
}