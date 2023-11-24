using Tarefas.DTO;

public interface ITarefaDAO
{
    void Criar(TarefaDTO tarefa);
    void Editar(TarefaDTO tarefa);
    void Excluir(int id);
    List<TarefaDTO> Consultar();
    TarefaDTO Consultar(int id);
}