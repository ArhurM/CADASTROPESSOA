using System.Collections.Generic;
using System.IO;
using System;

namespace CadastroPessoa
{
    public class PessoaFisica : Pessoa
    {
        
        public string cpf { get; set; }

        public DateTime datadeNasc { get; set; }

        public string caminho { get; private set; } = "Database/PessoaFisica.csv";

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
        
        
        public string PrepararLinhasCsv(PessoaFisica PF){

            return $"{PF.nome};{PF.cpf}";
        }
        public void Inserir(PessoaFisica PF){

            string[] linhas = {PrepararLinhasCsv(PF)};

            File.AppendAllLines(caminho, linhas);
        }

        public List<PessoaFisica> Ler(){

            List<PessoaFisica> listaPF = new List<PessoaFisica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (var cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(";");

                PessoaFisica cadaPF = new PessoaFisica();
                
                cadaPF.nome = atributos[0];
                cadaPF.cpf = atributos[1];
            
            
                listaPF.Add(cadaPF);

            }

            return listaPF;
            
        }


      }
    }
