using System.Collections.Generic;
using System.IO;

namespace CadastroPessoa
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }

        public string razaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/PessoaJuridica.csv";
        public override double pagarImposto(float rendimento)
        {

             if (rendimento <= 5000)
            {
                return rendimento * .06;

            }else if (rendimento >5000 && rendimento <=10000)
            {
                return rendimento * .08;

            }else
            {
                return(rendimento/100) *10;
            }
        }
        //metodo que valida o CNPJ.
        public bool validarCNPJ(string cnpj){
//cnpj tem 14 caracteres e o metodo substring diminui 14 - 6 , e avalia somente 4 == 0001
            if(cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 6, 4) == "0001")
             {
                 return true;
             }
            return  false;   

       }

            public string PrepararLinhasCsv(PessoaJuridica PJ){

            return $"{PJ.nome};{PJ.cnpj};{PJ.razaoSocial}";
        }

        public void Inserir(PessoaJuridica PJ){

            string[] linhas = {PrepararLinhasCsv(PJ)};

            File.AppendAllLines(caminho, linhas);
        }

        public List<PessoaJuridica> Ler(){

            List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (var cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(";");

                PessoaJuridica cadaPJ = new PessoaJuridica();
                
                cadaPJ.nome = atributos[0];
                cadaPJ.cnpj = atributos[1];
                cadaPJ.razaoSocial = atributos[2];
            
                listaPJ.Add(cadaPJ);

            }

            return listaPJ;
            
        }


    }
}