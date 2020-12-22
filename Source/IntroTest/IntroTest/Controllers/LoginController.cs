using IntroTest.Models;
using IntroTest.Repositories;
using IntroTest.Shared;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IntroTest.Controllers
{
    public class LoginController : BaseController
    {
        /// <summary>
        /// Data information
        /// </summary>
        private DataContext dbContext;

        /// <summary>
        /// 
        /// </summary>
        public LoginController(DataContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.rolesRepository = new RolesRepository(dbContext);
            this.passcodeRepository = new PasscodeRepository(dbContext);
            this.useStateRepository = new UseStateRepository(dbContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View("/Views/Login/Login.cshtml");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CheckLogin(Passcode passcode)
        {
            try
            {
                WriteLog(LogsDef.StartLogMsg);

                var passcodeDt = passcodeRepository.ReadByIdAndCode(passcode);

                if(passcodeDt != null)
                {
                    var token = AuthenticationConfig.GenerateJSONWebToken(passcodeDt);

                    var useState = new UseState();
                    useState.Date = DateTime.UtcNow;
                    useState.IdRole = passcodeDt.IdRole;
                    useState.Token = token;
                    useStateRepository.Add(useState);

                    HttpContext.Session.SetObjectAsJson(SessionDef.SESSION_USESTATE, useState);
                    HttpContext.Session.SetObjectAsJson(SessionDef.SESSION_USERLOGIN, passcodeDt);
                    return Json("/rating");
                }

                return Json("/login");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult LogOut(string passcode)
        {
            WriteLog(LogsDef.StartLogMsg);

            var user = HttpContext.Session.GetObjectFromJson<Passcode>(SessionDef.SESSION_USERLOGIN);

            if (user.Code == passcode)
            {
                HttpContext.Session.Remove(SessionDef.SESSION_USESTATE);
                HttpContext.Session.Remove(SessionDef.SESSION_USERLOGIN);
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        public IActionResult ChangeRole(Passcode passcode)
        {
            try
            {
                WriteLog(LogsDef.StartLogMsg);

                var passcodeDt = passcodeRepository.ReadByIdAndCode(passcode);

                if (passcodeDt != null)
                {
                    var token = AuthenticationConfig.GenerateJSONWebToken(passcodeDt);

                    var useState = new UseState();
                    useState.Date = DateTime.UtcNow;
                    useState.IdRole = passcodeDt.IdRole;
                    useState.Token = token;
                    useStateRepository.Add(useState);

                    HttpContext.Session.SetObjectAsJson(SessionDef.SESSION_USESTATE, useState);
                    HttpContext.Session.SetObjectAsJson(SessionDef.SESSION_USERLOGIN, passcodeDt);
                    return Json(true);
                }

                return Json(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}