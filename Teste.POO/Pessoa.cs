using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Teste.POO
{
     class Pessoa
    {
     
        public string Nome;
        public int Idade;
        public string Cpf;
        public string Data;
        
        public Pessoa(string nome, int idade,string cpf, string data)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Data = data;
        }
        
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}, Idade: {Idade}, CPF {Cpf}, Data de Nascimento {Data}");
        }
        public string ObterIdade()
        {
            return Idade >= 18 ? "Maior de idade" : "Menor de idade";
        }
    }
}
