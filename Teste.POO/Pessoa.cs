using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Teste.POO
{

    public abstract class Pessoa
    {

        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public Pessoa(string nome, string cpf, DateTime dataNasc)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNasc;
        }

        public abstract void ExibirDados();
    }

    

    

    
   
    }



