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

    

    public class Aluno : Pessoa
    {
        public string Matricula { get; set; }
        public List<double> Notas { get; set; } = new List<double>();

        public Aluno(string nome, string cpf, DateTime dataNasc, string matricula)
            : base(nome, cpf, dataNasc)
        {
            Matricula = matricula;
        }

        public double CalcularMedia()
        {
            if(Notas.Count == 0) return 0;
            double soma = 0;
            foreach(double nota in Notas)
            {
                soma += nota;
            }
            return soma / Notas.Count;
        }

        public override void ExibirDados()
        {
            Console.WriteLine($"[ALUNO] Nome: {Nome} | Matrícula: {Matricula} | Média: {CalcularMedia():F2}");
        }
    }

    
    public class Professor : Pessoa
    {
        public decimal Salario { get; set; }
        public List<string> Turmas { get; set; } = new List<string>();

        public Professor(string nome, string cpf, DateTime dataNasc, decimal salario)
            : base(nome, cpf, dataNasc)
        {
            Salario = salario;
        }

        public override void ExibirDados()
        {
            string listaTurmas = "";

            if (Turmas.Count > 0)
            {
                for (int i = 0; i < Turmas.Count; i++)
                {
                    listaTurmas += Turmas[i];
                    if (i < Turmas.Count - 1)
                    {
                        listaTurmas += ", ";
                    }
                }
            }
            else
            {
                listaTurmas = "Nenhuma";
            }

            Console.WriteLine("[PROF] Nome: " + Nome + " | Salário: R$ " + Salario.ToString("F2") + " | Turmas: " + listaTurmas);
        }
    }
    }



