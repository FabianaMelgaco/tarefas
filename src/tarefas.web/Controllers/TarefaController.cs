using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using AutoMapper;
using System.Security.Cryptography.X509Certificates;


namespace tarefas.web.Controllers
{
  public class TarefaController : Controller
  {
    private static List<TarefaViewModel> listadetarefas = new List<TarefaViewModel>();
    

    private readonly IMapper _mapper;
    private readonly ITarefaDAO _tarefaDAO;


    public TarefaController(IMapper mapper, ITarefaDAO tarefaDAO)
    {
      _mapper = mapper;
      _tarefaDAO = tarefaDAO;
     
    }
    public IActionResult Criar()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Criar(TarefaViewModel tarefa)
    {

      var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);

      if (!ModelState.IsValid)
      {
        return View();
      }

      _tarefaDAO.Criar(tarefaDTO);

      return RedirectToAction("Listar");
    }

    public IActionResult Listar()
    {

      var listaDeTarefasDTO = _tarefaDAO.Consultar();
      var listaDeTarefa = new List<TarefaViewModel>();

      foreach (var tarefaDTO in listaDeTarefasDTO)
      {
        listaDeTarefa.Add(_mapper.Map<TarefaViewModel>(tarefaDTO));
      }

      return View(listaDeTarefa);

    }
    public IActionResult Detalhe(int id)
    {

      var TarefaDTO = _tarefaDAO.Consultar(id);
      var TarefaViewModel = new TarefaViewModel();

      TarefaViewModel = _mapper.Map<TarefaViewModel>(TarefaDTO);

      return View(TarefaViewModel);
    }

    public IActionResult Editar(int id)
    {

      var TarefaDTO = _tarefaDAO.Consultar(id);

      var TarefaViewModel = new TarefaViewModel();

      TarefaViewModel = _mapper.Map<TarefaViewModel>(TarefaDTO);

      return View(TarefaViewModel);

    }

    [HttpPost]
    public IActionResult SalvarEdicao(TarefaViewModel tarefa)

    {
      var TarefaDTO = new TarefaDTO();

      TarefaDTO = _mapper.Map<TarefaDTO>(tarefa);

      _tarefaDAO.Editar(TarefaDTO);

      return RedirectToAction("Listar");
    }

    public IActionResult Excluir(int id)
    {

      _tarefaDAO.Excluir(id);

      return RedirectToAction("Listar");
    }



  }
}


