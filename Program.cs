using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace CadastroPessoa 
{
    class Program
    {
        static void Main(string[] args)
         {
             string opcao;
             List<PessoaFisica> listaPF = new List<PessoaFisica>();
             List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();


          Console.Clear();
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Console.BackgroundColor = ConsoleColor.White;
          Console.WriteLine(@$"

=====================================================
|      Bem vindo ao Sistema de cadastro de pessoas  |  
|                  Fisica e Juridica                |
|                                                   |
=====================================================
");
         
         BarraCarregamento("Iniciando");

        
        
        do
         {
            
            Console.WriteLine(@$"
=====================================================
|          Escolha uma das opções abaixo            |  
|---------------------------------------------------|
|                PESSOA FISICA                      |
|                                                   |
|           1 - Cadastrar Pessoa Fisica             |
|           2 - Listar Pesssoa Fisica               |
|           3 - Remover Pesoa Fisica                |
|                                                   |
|               PESSOA JURIDICA                     |
|                                                   |
|           4 - Cadastrar Pessoa Juridica           |
|           5 - Listar Pesssoa Juridica             |
|           6 - Remover Pesoa Juridica              |
|                                                   |
|             0 - Sair                              |
=====================================================
");
  opcao = Console.ReadLine();
  switch (opcao)
   {  
    case "1":
            PessoaFisica PF = new PessoaFisica();
            PessoaFisica novaPF = new PessoaFisica();
            endereco endPF = new endereco();


            Console.WriteLine($"Digite Seu Logradouro");
            endPF.logradouro = Console.ReadLine();

            Console.WriteLine($"Digite o Numero");
            endPF.numero = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
            endPF.complemento = Console.ReadLine();

            Console.WriteLine($"Este endereco é Comercial ? S/N");
            string enderecoComercial = Console.ReadLine().ToUpper();

            if (enderecoComercial == "S")
            {
                endPF.enderecoComercial = true;
            }else
            {
                endPF.enderecoComercial = false;
            }
            
            novaPF.endereco = endPF;

            Console.WriteLine($"Digite o Seu Nome");
            novaPF.nome = Console.ReadLine();

            Console.WriteLine($"Digite sua data  de Nascimento EX AAAA-MM-DD");
            novaPF.datadeNasc = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"Digite Seu CPF (Apenas Numero)");
            novaPF.cpf = Console.ReadLine();

            Console.WriteLine($"Digite o valor do seu rendimento mensal(Apenas Numero)");
            novaPF.rendimento = float.Parse(Console.ReadLine());

            bool idadeValida = PF.validardatadeNasc(novaPF.datadeNasc);
            
            if (idadeValida == true)
            {
                Console.WriteLine($"Cadastro Aprovado! ");
                listaPF.Add(novaPF);
                Console.WriteLine($"O valor do Desconto do imposto é de: {PF.pagarImposto(novaPF.rendimento).ToString("")} reais");
            }
            else
            {
                Console.WriteLine($"Cadastro Reprovado! ");
            }
       
           break;

    case "2":
            foreach (var cadaItem in listaPF)
            {
              Console.WriteLine($"{cadaItem.nome}, {cadaItem.cpf}, {cadaItem.endereco.logradouro}");  
            }
           break;

    case "3":  
            Console.WriteLine($"Digite o CPF que deseja Remover");
            string cpfProcurado  = Console.ReadLine();
            PessoaFisica pessoaFEncontrada = listaPF.Find(cadaItem => cadaItem.cpf == cpfProcurado);   

            if (pessoaFEncontrada != null)
            {
                listaPF.Remove(pessoaFEncontrada); 
                Console.WriteLine($"Cadastro Removido");
            }else
            {
                Console.WriteLine($"CPF não Encotrado");
            }
            
            

           break;       
        
    case "4":
            PessoaJuridica PJ = new PessoaJuridica();
            PessoaJuridica novaPJ = new PessoaJuridica();
            endereco endPJ = new endereco();
            
            Console.WriteLine($"Digite Seu Logradouro");
            endPJ.logradouro = Console.ReadLine();

            Console.WriteLine($"Digite o Numero");
            endPJ.numero = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
            endPJ.complemento = Console.ReadLine();

            Console.WriteLine($"Este endereco é Comercial ? S/N");
            string enderecoComercialPJ = Console.ReadLine().ToUpper();

            if (enderecoComercialPJ == "S")
            {
                endPJ.enderecoComercial = true;
            }else
            {
                endPJ.enderecoComercial = false;
            }

            novaPJ.endereco = endPJ;

            Console.WriteLine($"Digite seu CNPJ (Somente numeros)");
            novaPJ.cnpj = Console.ReadLine();

            Console.WriteLine($"Digite sua Razao Social");
            novaPJ.razaoSocial = Console.ReadLine();

            Console.WriteLine($"Digite seu rendimento mensal (Somente numeros)");
            novaPJ.rendimento = float.Parse(Console.ReadLine());

            if (PJ.validarCNPJ(novaPJ.cnpj))
            {
                Console.WriteLine("CNPJ Valido !!!");
                listaPJ.Add(novaPJ);
                Console.WriteLine($"O valor do Desconto do imposto é de: {PJ.pagarImposto(novaPJ.rendimento).ToString("")} reais");
            }else
            {
                Console.WriteLine("CNPJ Invalido!!!");

            }  

           break;

    case "5":
            foreach (var cadaItem in listaPJ)
            {
              Console.WriteLine($"{cadaItem.nome}, {cadaItem.cnpj}, {cadaItem.endereco.logradouro}");  
            }
           break;

    case "6":  
            Console.WriteLine($"Digite o CNPJ que deseja Remover");
            string cnpjProcurado  = Console.ReadLine();
            PessoaJuridica pessoaJEncontrada = listaPJ.Find(cadaItem => cadaItem.cnpj == cnpjProcurado);   

            if (pessoaJEncontrada != null)
            {
                listaPJ.Remove(pessoaJEncontrada); 
                Console.WriteLine($"Cadastro Removido");
            }else
            {
                Console.WriteLine($"CNPJ não Encotrado");
            }
            
            

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