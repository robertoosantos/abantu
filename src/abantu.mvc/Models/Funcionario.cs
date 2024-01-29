using System.ComponentModel.DataAnnotations;
using System.Linq;
using abantu.mvc.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace abantu.mvc.Models
{
    public class Funcionario
    {
        // Variável interna para armazenar o nosso contexto de banco de dados
        protected ApplicationDbContext _db;

        // Construtor recebendo o contexto como parâmetro
        public Funcionario(ApplicationDbContext db)
        {
            _db = db;
            // Sempre que um novo funcionário for criado, ele será ativo.
            Ativo = true;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public decimal Salario { get; set; }
        /// Todo funcionário tem apenas um cargo
        public Cargo Cargo { get; set; }
        /// Um funcionário pode ter várias avaliações
        public List<Avaliacao> Avaliacoes { get; set; }

        public virtual List<Funcionario> Listar()
        {
            return Listar(true);
        }

        protected List<Funcionario> Listar(bool somenteAtivos)
        {
            // Variável do tipo lista de funcionários que vai armazenar o retorno do método
            List<Funcionario> funcionarios;
            // Verificação se devemos filtrar somente funcionários ativos
            if (somenteAtivos)
                // Filtro de funcionários ativos
                funcionarios = _db.Funcionarios.Where(funcionario => funcionario.Ativo == true).ToList();
            else
                // Listagem sem filtro
                funcionarios = _db.Funcionarios.ToList();
            // Retorno da função
            return funcionarios;
        }
    }
}