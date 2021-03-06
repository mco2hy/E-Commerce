﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Data.Enum;
using ECommerce.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [FilterContext.Log]
        [FilterContext.Auth(UserTitle.Customer)]
        public IActionResult Profile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _unitOfWork.UserRepository.GetById((int)userId);
            return View(user);
        }
        [FilterContext.Log]
        [FilterContext.Auth(UserTitle.Customer)]
        public IActionResult ProfileSaveAction([FromBody]Data.DTO.Account_ProfileSaveAction_Request dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("bad boy");
            }
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _unitOfWork.UserRepository.Get((int)userId);

            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.Email = dto.Email;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Complete();

            return new JsonResult(user);
        }
        [FilterContext.Log]
        [FilterContext.Auth(UserTitle.Customer)]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [FilterContext.Log]
        [FilterContext.Auth(UserTitle.Customer)]
        public IActionResult ChangePasswordAction([FromBody] Data.DTO.Account_ChangePasswordAction_Request dto)
        {
            if (!ModelState.IsValid) return BadRequest("Kötü çocuk");

            int userId = HttpContext.Session.GetInt32("UserId").Value;
            var user = _unitOfWork.UserRepository.GetById(userId);

            if (user.Password == Helper.CryptoHelper.Sha1(dto.Password))
            {
                user.Password = Helper.CryptoHelper.Sha1(dto.NewPassword);
                _unitOfWork.Complete();
            }
            else
            {
                return BadRequest("Şifre, mevcut şifreniz ile aynı değil.");
            }
            return new JsonResult("Ok");
        }
    }
}