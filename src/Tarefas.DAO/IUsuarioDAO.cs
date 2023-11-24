using Tarefas.DTO;


namespace Tarefas.DAO
{

    public interface IUsuarioDAO
    {
        void CriarUsuario(UsuarioDTO usuario);
        void EditarUsuario(UsuarioDTO usuario);
        void ExcluirUsuario(int id);
        List<UsuarioDTO> ConsultarUsuario();
        UsuarioDTO ConsultarUsuario(int id);
        UsuarioDTO ValidarUsuario(string email, string senha);
    }
}