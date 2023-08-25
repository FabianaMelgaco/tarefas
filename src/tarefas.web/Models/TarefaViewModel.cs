

using System.ComponentModel;

namespace Tarefas.Web.Models
{
  public class TarefaViewModel
  {
    [DisplayName("ID")]
    public int Id { get; set; }
    
    [DisplayName("Descrição")]
    public string Descricao { get; set; }
    
    [DisplayName("Título")]
    public string Titulo { get; set; }
    
    [DisplayName("Status")]
    public string Status { get; set; }

  }
}
