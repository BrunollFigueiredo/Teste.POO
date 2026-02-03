using Teste.POO;


    Pessoa obj1 = new Pessoa("Maria", 25,"0952345-11","24/08/2004");
    obj1.ExibirInformacoes();
Pessoa obj2 = new Pessoa("Ricardo", 27, "0952345-11", "24/08/2004");
obj2.ExibirInformacoes();
string retorno = obj2.ObterIdade();
Console.WriteLine($"Ricardo é {retorno}");


