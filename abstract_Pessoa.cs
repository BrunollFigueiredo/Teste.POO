Teste.POO\Pessoa.cs
using System;

namespace Teste.POO
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public DateTime Data { get; set; }

        protected Pessoa(string nome, int idade, string cpf, DateTime data)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Data = data;
        }

       
        public abstract void ExibirInformacoes();

        
        public virtual string ObterIdade() => $"{Idade} anos";
    }
    public class Aluno:Pessoa
    {
        public string Matricula { get; set; }
        public List <double> Notas { get; set; }= new List<double>();
        public Aluno(string nome, int idade, string cpf, DateTime data)
            : base(nome, idade, cpf, data)
        {
        }
        public override void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}, Idade: {Idade}, CPF: {Cpf}, Data: {Data.ToShortDateString()}");
        }
    }
}