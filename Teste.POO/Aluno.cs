using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.POO
{
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
            if (Notas.Count == 0) return 0;
            double soma = 0;
            foreach (double nota in Notas)
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
}
