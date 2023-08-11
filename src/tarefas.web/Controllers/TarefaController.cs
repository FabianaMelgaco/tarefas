using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;

namespace tarefas.web.Controllers
{
    public class TarefaController : Controller 
    {
        private static List<TarefaViewModel> listadetarefas = new List<TarefaViewModel>();

        public TarefaController()
        {
          var tarefa1 = new TarefaViewModel();
          tarefa1.Descricao = "Levar para passear";
          tarefa1.Titulo = "Cachorro";
          tarefa1.Status = "Ativo";
          tarefa1.Id = 1;

          var tarefa2 = new TarefaViewModel();
          tarefa2.Descricao = "Comprar pao doce";
          tarefa2.Titulo = "Pao";
          tarefa2.Status = "Ativo";
          tarefa2.Id = 2;
          if(listadetarefas.Count == 0)
            {
              listadetarefas.Add(tarefa1);
              listadetarefas.Add(tarefa2);
            }  
        }
        public IActionResult Criar()
        {
          return View();
        }
        public IActionResult Index()
        {
          return View();
        }

        [HttpPost]
        public IActionResult Criar(TarefaViewModel fabiana)
        {            
          listadetarefas.Add(fabiana);
          return RedirectToAction("Listar","Tarefa");
        }
        public IActionResult Listar()
        {            
          return View (listadetarefas);
        }
        public IActionResult Detalhe (int id)
        {
          var tarefa = listadetarefas.FirstOrDefault(f => f.Id == id);
          return View(tarefa);
        }
   }
}

