using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;

namespace tarefas.web.Controllers
{
    public class TarefaController : Controller 
    {
 
        public List<TarefaViewModel> listadetarefas = new List<TarefaViewModel>();
        //public <TarefaViewModel> = listadetarefas();


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

            /*
            var tarefa3 = new TarefaViewModel();
            tarefa3.Descricao = "Urgente" ;
            tarefa3.Titulo = "Necessidade";
            tarefa3.Status = "Ativo";
            tarefa3.Id = 3;

            var tarefa4 = new TarefaViewModel();
            tarefa4.Descricao = "Proprietario";
            tarefa4.Titulo = "Responsavel";
            tarefa4.Status = "Ativo";
            tarefa4.Id = 4;  
            */
            listadetarefas.Add(tarefa1);
            listadetarefas.Add(tarefa2);
            //listadetarefas.Add(tarefa3);
            //listadetarefas.Add(tarefa4);
            
      
        }
        public IActionResult Criar()
         {
            return View();
         }
         [HttpGet]
         public IActionResult Index(int Id, string Titulo, string Descricao, string Status)
          {
        // dados inseridos pelo usuário.
        //ViewBag para armazenar os dados inseridos.
        ViewBag.Id = Id;
        ViewBag.Titulo = Titulo;
        ViewBag.Descricao = Descricao;
        ViewBag.Status = Status;
        
        return View();
          }

        [HttpPost]
        public IActionResult Criar(TarefaViewModel fabiana)
         {            
            //return View();
            listadetarefas.Add(fabiana);
            //return View("Listar",listaDeTarefas); //aqui deu certo
            return View(listadetarefas);
          }
        public IActionResult Listar ()
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

