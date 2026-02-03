using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Teste.POO
{
    class Aluno
    {
        public string Nome;
        public int Idade;
        public string Materia;
        public int Nota;
        public Aluno(string nome, int idade, int nota)
        {
            Nome = nome;
            Idade = idade;
            Nota= nota;
        }
        public string ObterMedia()
        {
            return Nota >= 7 ? "Aprovado" : "Reprovado";
        }
    }
}
