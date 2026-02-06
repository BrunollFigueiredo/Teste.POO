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
                if (input == "fim" || input == "FIM") break;

                double nota;
                if (double.TryParse(input, out nota) && nota >= 0 && nota <= 10)
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
                if (turma == "fim" || turma == "FIM") break;
                if (turma != "" && turma != null) prof.Turmas.Add(turma);
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

            for (int i = 0; i < escola.Count; i++)
            {
                escola[i].ExibirDados();
            }
        }

        static void ExibirEstatisticas()
        {
            Console.WriteLine("--- ESTATÍSTICAS ---");

            int qtdAlunos = 0;
            int qtdProfessores = 0;
            double somaNotasGeral = 0;
            decimal totalFolha = 0;

            for (int i = 0; i < escola.Count; i++)
            {
                if (escola[i] is Aluno)
                {
                    Aluno a = (Aluno)escola[i];
                    qtdAlunos++;
                    somaNotasGeral += a.CalcularMedia();
                }
                else if (escola[i] is Professor)
                {
                    Professor p = (Professor)escola[i];
                    qtdProfessores++;
                    totalFolha += p.Salario;
                }
            }

            if (qtdAlunos > 0)
            {
                double mediaGeral = somaNotasGeral / qtdAlunos;
                Console.WriteLine("Qtd Alunos: " + qtdAlunos + " | Média Geral das Notas: " + mediaGeral.ToString("F2"));
            }
            else
            {
                Console.WriteLine("Sem dados de alunos.");
            }

            if (qtdProfessores > 0)
            {
                Console.WriteLine("Qtd Professores: " + qtdProfessores + " | Total Folha Salarial: R$ " + totalFolha.ToString("F2"));
            }
            else
            {
                Console.WriteLine("Sem dados de professores.");
            }
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




