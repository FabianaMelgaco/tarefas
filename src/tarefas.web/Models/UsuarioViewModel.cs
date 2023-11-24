using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Tarefas.Web.Models

{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }

        [AllowNull]
        [Required(ErrorMessage = "O Email deve ser preenchido.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [AllowNull]
        [Required(ErrorMessage = "A senha deve ser preenchida.")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [AllowNull]
        [Required(ErrorMessage = "O Nome deve ser preenchido.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}