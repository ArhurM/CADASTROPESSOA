using System;
using System.IO;
using System.Threading;

namespace CadastroPessoa 
{
    class Program
    {
        static void Main(string[] args)
         {
             string opcao;


          Console.Clear();
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Console.WriteLine(@$"

=====================================================
|      Bem vindo ao Sistema de cadastro de pessoas  |  
|                  Fisica e Juridica                |
|                                                   |
=====================================================
");
         Console.ResetColor();
         Thread.Sleep(3000);
         Console.ForegroundColor = ConsoleColor.DarkBlue;
         Console.ForegroundColor = ConsoleColor.White;

         Console.Write($"Iniciando");
         Thread.Sleep(500);
         for (var i = 0; i < 10; i++)
         {
              Console.Write($".");
              Thread.Sleep(500);
         }
         Console.ResetColor();

         Console.Clear();

        do
         {
            Console.WriteLine(@$"
=====================================================
|          Escolha uma das opções abaixo            |  
|---------------------------------------------------|
|            1 - Pessoa Fisica                      |
|            2 - Pessoa Juridica                    |
|                                                   |
|            0 - Sair                               |
=====================================================
");
  opcao = Console.ReadLine();
  switch (opcao)
   {  
    case "1":
            PessoaFisica PF = new PessoaFisica();
            PessoaFisica novaPF = new PessoaFisica();
            endereco endPF = new endereco();

            endPF.logradouro = "Rua Santa Monica" ;
            endPF.numero = 71;
            endPF.complemento = "proximo a Delegacia" ;
            endPF.enderecoComercial = false;

            novaPF.endereco = endPF;
            novaPF.cpf = "23678465257";
            novaPF.nome = "Nome Pessoa Fisica";
            novaPF.datadeNasc = new DateTime(1994, 12, 11);
            novaPF.rendimento = 1500;
            
            Console.WriteLine($@"Rua: {novaPF.endereco.logradouro}, {novaPF.endereco.numero}");

            bool idadeValida = PF.validardatadeNasc(novaPF.datadeNasc);
            
            if (idadeValida == true)
            {
                Console.WriteLine($"Cadastro Aprovado! ");
            }
            
            else
            {
                Console.WriteLine($"Cadastro Reprovado! ");
            }
       
           break;
        
    case "2":
            PessoaJuridica PJ = new PessoaJuridica();
            PessoaJuridica novaPJ = new PessoaJuridica();
            endereco endPJ = new endereco();

            endPJ.logradouro = "Rua Turma da Monica" ;
            endPJ.numero = 41;
            endPJ.complemento = "proximo a Padaria" ;
            endPJ.enderecoComercial = true;

            novaPJ.endereco = endPJ;
            novaPJ.cnpj = "23676000000101";
            novaPJ.razaoSocial = "Pessoa Juridica";
            novaPJ.rendimento = 10000;

            if (PJ.validarCNPJ(novaPJ.cnpj))
            {
                Console.WriteLine("CNPJ Valido !!!");
            }else
            {
                Console.WriteLine("CNPJ Invalido!!!");

            } 

            Console.WriteLine($"O valor do Desconto do imposto é de: {PJ.pagarImposto(novaPJ.rendimento).ToString("")} reais"); 

           break; 
    case "0":
            Console.Clear();
            Console.WriteLine($" THANK YOU !!! ");
               
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        
            Console.Write($"Finalizando");
            Thread.Sleep(500);
            for (var i = 0; i < 10; i++)
        {
            Console.Write($".");
            Thread.Sleep(500);
        }
            Console.ResetColor();
            break;
                                      
        default:
            Console.ResetColor();
            Console.WriteLine($"Opção Invalida,Apenas Numeros");    
            break;
   }    
    } while (opcao != "0");


    }

        static void BarraCarregamento(string textoCarregamento)
        {

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(textoCarregamento);
            Thread.Sleep(300);

            for (var contador = 0; contador < 5; contador++)
            {
                Console.Write($".");
                Thread.Sleep(180);

     }
  }
 }

}