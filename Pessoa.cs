namespace CadastroPessoa
{
    public abstract class Pessoa
    {
        public string nome { get; set; }

        public endereco endereco { get; set; }

        public bool enderecoComercial { get; set; }

        public float rendimento {get; set; }

        public abstract double pagarImposto(float salario);

       
        }
    }