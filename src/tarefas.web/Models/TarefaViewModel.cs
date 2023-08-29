

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models
{
  public class TarefaViewModel
  {
    public int Id { get; set; }
    
    [Required(ErrorMessage = "A descrição deve ser preenchida.")]
    [MinLength(5, ErrorMessage = "A descrição deve ter no mínimo 5 caracteres.")]
    [MaxLength(100, ErrorMessage = "Não é possivel incluir mais de 100 caracteres")]
    [DisplayName("Descrição")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O Título deve ser preenchido.")]
    [MinLength(5, ErrorMessage = "O Titulo deve ter no mínimo 5 caracteres.")]
    [MaxLength(100, ErrorMessage = "Não é possivel incluir mais de 100 caracteres")]
    [DisplayName("Título")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O Status deve ser preenchido.")]
    [MinLength(5, ErrorMessage = "O Status deve ter no mínimo 5 caracteres.")]
    [MaxLength(100, ErrorMessage = "Não é possivel incluir mais de 100 caracteres")]
    [DisplayName("Status")]
    public string Status { get; set; }

  }
}
