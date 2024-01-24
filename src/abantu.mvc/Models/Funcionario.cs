using System.ComponentModel.DataAnnotations;

namespace abantu.mvc.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Demissao { get; set; }
        public decimal Salario { get; set; }
        /// Todo funcionário tem apenas um cargo
        public Cargo Cargo { get; set; }
        /// Um funcionário pode ter várias avaliações
        public List<Avaliacao> Avaliacoes { get; set; }

        public virtual List<Funcionario> Listar(){
            throw new NotImplementedException();
        }

        protected List<Funcionario> Listar(bool ativos){
            throw new NotImplementedException();
        }
    }
}