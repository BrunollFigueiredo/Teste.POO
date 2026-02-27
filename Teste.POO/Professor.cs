using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.POO
{
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
