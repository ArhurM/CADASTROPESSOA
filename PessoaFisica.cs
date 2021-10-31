using System;

namespace CadastroPessoa
{
    public class PessoaFisica : Pessoa
    {
        
        public string cpf { get; set; }

        public DateTime datadeNasc { get; set; }

        public override double pagarImposto(float rendimento){
            if (rendimento <= 1500)
            {
                return 0;

            }else if (rendimento >1500 && rendimento <=5000)
            {
                return rendimento * .03;

            }else
            {
                return(rendimento/100) *5;
            }
            

        }  

        public bool validardatadeNasc(DateTime data){

        DateTime dataAtual = DateTime.Today;

        double anos = (dataAtual - datadeNasc).TotalDays / 365;

        if (anos >= 18){

            return true;
        }
                     
        return false;

        }
        
      }
    }
