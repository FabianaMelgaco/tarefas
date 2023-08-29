using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using AutoMapper;

namespace tarefas.web.Controllers
{
    public class TarefaController : Controller 
    {
        private static List<TarefaViewModel> listadetarefas = new List<TarefaViewModel>();
        private TarefaDTO tarefaDTO;
        private readonly IMapper _mapper;

        public TarefaController(IMapper mapper)
        {
          _mapper = mapper;
        }
        public IActionResult Criar()
        {
          return View();
        }

        [HttpPost]
        public IActionResult Criar(TarefaViewModel tarefa)
        {            

            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);
            
            if(!ModelState.IsValid)
            {
                return View();
            }
            var TarefaDAO = new TarefaDAO{};
            TarefaDAO.Criar (tarefaDTO);

                 return View();
        }

        public IActionResult Listar()
        {            
          var tarefaDAO = new TarefaDAO();
          var listaDeTarefasDTO = tarefaDAO.Consultar();
          var listaDeTarefa = new List<TarefaViewModel>();

          foreach (var tarefaDTO in listaDeTarefasDTO)
            {
                listaDeTarefa.Add(_mapper.Map<TarefaViewModel>(tarefaDTO));
                
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
          //return RedirectToAction("Listar");  
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
            
            return RedirectToAction("Listar");   
        }

        public IActionResult Excluir (int id)
        {
          var tarefaDAO = new TarefaDAO{};  
          tarefaDAO.Excluir(id);

          return RedirectToAction("Listar");
        }
          
    }

}
