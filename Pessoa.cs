using System.IO;

namespace CadastroPessoa
{
    public abstract class Pessoa
    {
        public string nome { get; set; }

        public endereco endereco { get; set; }

        public bool enderecoComercial { get; set; }

        public float rendimento {get; set; }

        public abstract double pagarImposto(float salario);

       
        public void verificarArquivo(string caminho){

            string pasta = caminho.Split("/")[0];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            if (!File.Exists(caminho))
            {
                File.Create(caminho);
            }
        }
    }

}