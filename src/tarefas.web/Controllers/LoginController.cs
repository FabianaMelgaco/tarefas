using System;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Tarefas.DTO;
using Tarefas.Web.Models;
using Tarefas.DAO;

namespace tarefas.web.Controllers


{

    public class LoginController : Controller
    {
        public LoginController()
        {

        }
        public IActionResult IndexUsur()
        {
            return View();
        }




    }
}



