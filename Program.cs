using System.Data.SqlTypes;
Random rng = new Random();

List<string> verbos = ["correr", "pular", "voar", "nadar", "brincar", "comer", "dormir", "assaltar", "miar", "rugir", "ventilar", "asfixiar"];
List<string> animais = ["cachorro", "gato", "elefante", "leao", "tigre", "girafa", "urso", "macaco", "coelho", "cavalo", "mamute", "besouro", "orangutango"];
List<string> adjetivos = ["amavel", "valente", "esperto", "tranquilo", "forte", "fofo", "sagaz", "leal", "agil", "bravo", "malvado", "inteligente", "perfeccionista"];
List<string> objetos = ["mesa", "cadeira", "livro", "caneta", "espelho", "telefone", "chave", "mochila", "lampada", "relogio"];

string? input;

string palavra = "";
string categoria = "";

menu();

string pickWord()
{
    switch (rng.Next(0, 4))
    {
        case 0:
            categoria = "Verbo";
            return palavra = verbos[rng.Next(verbos.Count)];
            
        case 1:
            categoria = "Animal";
            return palavra = animais[rng.Next(animais.Count)];
            
        case 2:
            categoria = "Adjetivo";
            return palavra = adjetivos[rng.Next(adjetivos.Count)];
            
        case 3:
            categoria = "Objeto";
            return palavra = objetos[rng.Next(objetos.Count)];     
    }
    return "";
}

void menu()
{
    bool Exit = false;

    while (Exit == false)
    {
        Console.Clear();
        Console.WriteLine("Bem vindo ao clássico FORCA - Adivinhe a Palavra!\nP- Jogar\nH- Aprenda a Jogar(recomendado)\nE- Sair");
        input = Console.ReadLine();

        if (input != null && input != " ")
        {
            switch (input.ToLower())
            {
                case "p":
                    Forca();
                    break;
                case "h":
                    Console.Clear();
                    Console.WriteLine("Chute letras para adivinhar a palavra.\nVocê terá 8 vidas\nCaso chute uma palavra, apenas a primeira letra sera considerada\nSe divirta!");
                    Console.ReadLine();
                    break;
                case "e":
                    Exit = true;
                    break;
            }
        }
    }
}

void mostrarVidas(int vidas)
{
    for (int i = 0; i < vidas; i++)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("♥ ");
        Console.ResetColor();
    }
}

bool ganhar(List<char> linhas, char[] wordArray)
{
    if (!linhas.SequenceEqual(wordArray)){return false;}

    Console.Clear();
    Console.WriteLine("Parabéns você adivinhou a palavra!");
    Console.ReadLine();
    return true;
}

bool perder(int vidas)
{
    if (vidas > 0){return false;}
    
    Console.WriteLine("Opa, suas vidas acabaram.");
    Console.ReadLine();
    return true;
}

void Forca()
{
    int vidas = 8;
    Console.Clear();
    bool encerrar = false;

    pickWord();
    
    char[] wordArray = palavra.ToCharArray(); //transforma a palavra em uma char array (fome = [f, o, m, e])
    List<char> input_lines = []; 

    Console.WriteLine($"A categoria é {categoria}");

    mostrarVidas(vidas);
    
    Console.WriteLine();

    for (int i = 0; i < palavra.Length; i++)
    {
        input_lines.Add('_');

        Console.Write($"{input_lines[i]} ");
    }

    while (encerrar == false)
    {
        Console.WriteLine();
        input = Console.ReadLine().ToLower();

        encerrar = ganhar(input_lines, wordArray);

        if (encerrar == false){ encerrar = perder(vidas);}

        if (!new string(wordArray).Contains(input.ToLower())) { vidas--; }

        Console.Clear();

        mostrarVidas(vidas);

        Console.WriteLine();

        if (input != "" && input != " ")
        {
            for (int i = 0; i < wordArray.Length; i++)
            {
                if (input[0] == wordArray[i])
                {
                    input_lines[i] = wordArray[i];
                }
                Console.Write(input_lines[i] + " ");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Por favor, insira uma letra!");
            Console.ResetColor();
            for (int i = 0; i < wordArray.Length; i++)
            {
                Console.Write(input_lines[i] + " ");
            }
        }
    }
}        