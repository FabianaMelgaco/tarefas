using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tarefas.DTO;
using Tarefas.Web.Models;
using Tarefas.DAO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;



namespace tarefas.web.Controllers;


public class UsuarioController : Controller
{
    //private readonly UsuarioDTO _usuarioDTO;
    //private object _mapper;
    private readonly IUsuarioDAO _usuarioDAO;
    private readonly IMapper _mapper;

    public UsuarioController(IMapper mapper, IUsuarioDAO usuarioDAO)
    {
        _mapper = mapper;
        _usuarioDAO = usuarioDAO;
    }
    public IActionResult IndexUsur()
    {
        return View();
    }
    public IActionResult CriarUsuario()
    {
        return View();
    }


    [HttpPost]
    
    public IActionResult CriarUsuario(UsuarioViewModel usuario)
    {
        var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

        if (!ModelState.IsValid)
        {
            return View();
        }
        _usuarioDAO.CriarUsuario(usuarioDTO);
        return RedirectToAction("ListarUsuario");
    }
    
    public IActionResult ListarUsuario()
    {
        var listaDeUsuarioDTO = _usuarioDAO.ConsultarUsuario();
        var listaDeUsuario = new List<UsuarioViewModel>();

        foreach (var usuarioDTO in listaDeUsuarioDTO)
        {
            listaDeUsuario.Add(_mapper.Map<UsuarioViewModel>(usuarioDTO));
        }
        return View(listaDeUsuario);
    }
    
    public IActionResult DetalheUsuario(int id)
    {

        var usuarioDTO = _usuarioDAO.ConsultarUsuario(id);
        var UsuarioViewModel = new UsuarioViewModel();
        UsuarioViewModel = _mapper.Map<UsuarioViewModel>(usuarioDTO);
        return View(UsuarioViewModel);

    }
    
    public IActionResult EditarUsuario(int idusur)
    {
        var UsuarioDTO = _usuarioDAO.ConsultarUsuario(idusur);
        var UsuarioViewModel = new UsuarioViewModel();
        UsuarioViewModel = _mapper.Map<UsuarioViewModel>(UsuarioDTO);
        return View(UsuarioViewModel);
    }

    [HttpPost]

    public IActionResult SalvarEdicaoUsuario(UsuarioViewModel usuario)
    {
        var UsuarioDTO = new UsuarioDTO();
        UsuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
        _usuarioDAO.EditarUsuario(UsuarioDTO);
        return RedirectToAction("ListarUsuario");
    }
    
    public IActionResult ExcluirUsuario(int idusur)
    {
        _usuarioDAO.ExcluirUsuario(idusur);
        return RedirectToAction("ListarUsuario");
    }
    public IActionResult ValidarUsuario(LoginViewModel usuario)
    {
        if (ModelState.IsValid)
        {
            UsuarioDTO usuarioDTO;
            try
            {
                usuarioDTO = _usuarioDAO.ValidarUsuario(usuario.Email, usuario.Senha);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("IndexUsur", "Login");
            }

            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name,usuarioDTO.Nome),
            new Claim(ClaimTypes.Email,usuarioDTO.Email)
            };

            var claimsidentify = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperts = new AuthenticationProperties

            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true,
                RedirectUri = "/Home"
            };

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsidentify), authProperts);

            return LocalRedirect(authProperts.RedirectUri);
        }

        return RedirectToAction("IndexUsur", "Login");


    }
}