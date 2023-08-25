using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;

namespace tarefas.web.Controllers
{
    public class TarefaController : Controller 
    {
        private static List<TarefaViewModel> listadetarefas = new List<TarefaViewModel>();
        private TarefaDTO tarefaDTO;

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

        [HttpPost]
        public IActionResult Criar(TarefaViewModel tarefa)
        {            
          //listadetarefas.Add(fabiana);
          //return RedirectToAction("Listar","Tarefa");
            var tarefaDTO = new TarefaDTO()
            {
              Titulo = tarefa.Titulo,
              Descricao = tarefa.Descricao,
              Status = tarefa.Status
              
            };
            var TarefaDAO = new TarefaDAO{};
            TarefaDAO.Criar (tarefaDTO);
            
            return View();
        }

            //}
            //public IActionResult Listar()
        public IActionResult Listar()
        {            
          var tarefaDAO = new TarefaDAO();
          var listaDeTarefasDTO = tarefaDAO.Consultar();
          var listaDeTarefa = new List<TarefaViewModel>();

          foreach (var tarefaDTO in listaDeTarefasDTO)
            {
                listaDeTarefa.Add(new TarefaViewModel()
                {
                  Id = tarefaDTO.Id,
                  Titulo = tarefaDTO.Titulo,
                  Descricao = tarefaDTO.Descricao,
                  Status = tarefaDTO.Status
                }
                );
            }

          return View(listaDeTarefa);

        }
        public IActionResult Detalhe (int id)
        {
          var TarefaDAO  = new TarefaDAO();
          var TarefaDTO = TarefaDAO.Consultar(id);

          var TarefaViewModel = new TarefaViewModel
            {
              Id = TarefaDTO.Id,
              Titulo = TarefaDTO.Titulo,
              Descricao = TarefaDTO.Descricao,
              Status = TarefaDTO.Status
              
            };
                
          return View(TarefaViewModel);
          }

        public IActionResult Editar (int id)
        {            
          var TarefaDAO  = new TarefaDAO();
          var TarefaDTO = TarefaDAO.Consultar(id);

          var TarefaViewModel = new TarefaViewModel
            {
              Id = TarefaDTO.Id,
              Titulo = TarefaDTO.Titulo,
              Descricao = TarefaDTO.Descricao,
              Status = TarefaDTO.Status
              
            };
                
          return View(TarefaViewModel);
        }

        [HttpPost]
        public IActionResult Editar (TarefaViewModel tarefa)
        {            
            var tarefaDTO = new TarefaDTO()
            {
              Titulo = tarefa.Titulo,
              Descricao = tarefa.Descricao,
              Status = tarefa.Status,
              Id = tarefa.Id
              
              
            };
            var TarefaDAO = new TarefaDAO{};
            TarefaDAO.Editar (tarefaDTO);
            
             return View();
        }

        public IActionResult Excluir (int id)
        {
          var tarefaDAO = new TarefaDAO{};  
          tarefaDAO.Excluir(id);

          return RedirectToAction("Listar");
        }
          
    }

}
