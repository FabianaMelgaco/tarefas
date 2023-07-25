using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;

namespace tarefas.web.Controllers
{
    public class TarefaController : Controller 
    {
        public List<TarefaViewModel> listadetarefas = new List<TarefaViewModel>();

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

            var tarefa3 = new TarefaViewModel();
            tarefa3.Descricao = "Fazer Urgente";
            tarefa3.Titulo = "Necessidade";
            tarefa3.Status = "Ativo";
            tarefa3.Id = 3;

            var tarefa4 = new TarefaViewModel();
            tarefa4.Descricao = "Proprietario";
            tarefa4.Titulo = "Responsavel";
            tarefa4.Status = "Ativo";
            tarefa4.Id = 4;  

            listadetarefas.Add(tarefa1);
            listadetarefas.Add(tarefa2);
            listadetarefas.Add(tarefa3);
            listadetarefas.Add(tarefa4);
      
        }
        public IActionResult Criar()
         {
            return View();
         }
         
        [HttpPost]
        public IActionResult Criar(TarefaViewModel fabiana)
        {            
            return View();
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
