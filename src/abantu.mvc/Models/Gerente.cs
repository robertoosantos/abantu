using abantu.mvc.Data;

namespace abantu.mvc.Models;

public class Gerente : Funcionario
{
    public Gerente(ApplicationDbContext db) : base(db)
    { }

    public Funcionario Contratar(Funcionario novoFuncionario)
    {
        _db.Add(novoFuncionario);
        _db.SaveChanges();
        return novoFuncionario;
    }

    private decimal CalcularMediaAvaliacoes(List<Avaliacao> avaliacoes)
    {
        var quantidade = avaliacoes.Count;
        decimal total = 0;
        decimal media = 0;

        for (int i = 0; i < quantidade; i++)
        {
            // += significa pegar o valor de total e acrescentar o valor da nota da avaliação
            // na primeira execução, total é 0. Então teremos 0 + nota.
            // Ex.: total = 0 + 3
            // já na segunda execução do for, se a nota for 7
            // total = 3 + 7
            total += avaliacoes[i].Nota;
        }

        return total / quantidade;
    }

    public Funcionario Demitir(Funcionario funcionario)
    {
        if (funcionario.Avaliacoes == null || funcionario.Avaliacoes.Count == 0)
            throw new ApplicationException("Funcionário não possui avaliações. É necessário uma média inferior a 5 para realizar uma demissão");

        var mediaMinima = 5;
        
        var funcionarioDb = _db.Funcionarios.Single(f => f.Id == funcionario.Id);

        if (CalcularMediaAvaliacoes(funcionarioDb.Avaliacoes) < mediaMinima)
        {
            funcionarioDb.Ativo = false;

            _db.SaveChanges();
        }

        return funcionarioDb;
    }

    public Funcionario AumentarSalario(Funcionario funcionario, decimal novoSalario)
    {
        var mediaMinima = 7;

        var funcionarioDb = _db.Funcionarios.Single(f => f.Id == funcionario.Id);

        if (CalcularMediaAvaliacoes(funcionarioDb.Avaliacoes) > mediaMinima)
        {
            funcionarioDb.Salario = novoSalario;

            _db.SaveChanges();
        }

        return funcionarioDb;
    }

    public override List<Funcionario> Listar()
    {
        return Listar(false);
    }
}