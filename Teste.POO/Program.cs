using Teste.POO;

class Principal
{
    class Program
    {

        static List<Pessoa> escola = new List<Pessoa>();

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTÃO ESCOLAR ===");
                Console.WriteLine("1 - Cadastrar Aluno");
                Console.WriteLine("2 - Cadastrar Professor");
                Console.WriteLine("3 - Listar Todos");
                Console.WriteLine("4 - Relatório Estatístico");
                Console.WriteLine("0 - Sair");
                Console.Write(">> Opção: ");

                string opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1": CadastrarAluno(); break;
                    case "2": CadastrarProfessor(); break;
                    case "3": ListarTodos(); break;
                    case "4": ExibirEstatisticas(); break;
                    case "0": executando = false; break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }

                if (executando)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
            }
        }

        static void CadastrarAluno()
        {
            Console.WriteLine("--- CADASTRO DE ALUNO ---");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            DateTime dataNasc = LerData("Data de Nascimento (dd/mm/aaaa): ");

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            Aluno aluno = new Aluno(nome, cpf, dataNasc, matricula);

            Console.WriteLine("Digite as notas (digite 'fim' para parar):");
            while (true)
            {
                Console.Write("- Nota: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "fim") break;

                if (double.TryParse(input, out double nota) && nota >= 0 && nota <= 10)
                {
                    aluno.Notas.Add(nota);
                }
                else
                {
                    Console.WriteLine("Nota inválida! Digite entre 0 e 10.");
                }
            }

            escola.Add(aluno);
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }

        static void CadastrarProfessor()
        {
            Console.WriteLine("--- CADASTRO DE PROFESSOR ---");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            DateTime dataNasc = LerData("Data de Nascimento (dd/mm/aaaa): ");

            decimal salario = 0;
            while (true)
            {
                Console.Write("Salário: ");
                if (decimal.TryParse(Console.ReadLine(), out salario) && salario > 0) break;
                Console.WriteLine("Valor inválido.");
            }

            Professor prof = new Professor(nome, cpf, dataNasc, salario);

            Console.WriteLine("Digite as turmas/disciplinas (digite 'fim' para parar):");
            while (true)
            {
                Console.Write("- Turma: ");
                string turma = Console.ReadLine();
                if (turma.ToLower() == "fim") break;
                if (!string.IsNullOrWhiteSpace(turma)) prof.Turmas.Add(turma);
            }

            escola.Add(prof);
            Console.WriteLine("Professor cadastrado com sucesso!");
        }

        static void ListarTodos()
        {
            Console.WriteLine("--- LISTA GERAL ---");
            if (escola.Count == 0)
            {
                Console.WriteLine("Nenhum registro encontrado.");
                return;
            }

            foreach (var p in escola)
            {
                p.ExibirDados();
            }
        }

        static void ExibirEstatisticas()
        {
            Console.WriteLine("--- ESTATÍSTICAS ---");

            var alunos = escola.OfType<Aluno>().ToList();
            var professores = escola.OfType<Professor>().ToList();

            if (alunos.Any())
            {
                double mediaGeral = alunos.Average(a => a.CalcularMedia());
                Console.WriteLine($"Qtd Alunos: {alunos.Count} | Média Geral das Notas: {mediaGeral:F2}");
            }
            else Console.WriteLine("Sem dados de alunos.");

            if (professores.Any())
            {
                decimal folhaPagamento = professores.Sum(p => p.Salario);
                Console.WriteLine($"Qtd Professores: {professores.Count} | Total Folha Salarial: {folhaPagamento:C}");
            }
            else Console.WriteLine("Sem dados de professores.");
        }


        static DateTime LerData(string mensagem)
        {
            DateTime data;
            while (true)
            {
                Console.Write(mensagem);
                if (DateTime.TryParse(Console.ReadLine(), out data)) return data;
                Console.WriteLine("Data inválida.");
            }
        }
    }
}




