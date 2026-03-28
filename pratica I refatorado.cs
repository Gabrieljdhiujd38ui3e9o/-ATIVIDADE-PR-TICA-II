/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
using System.Collections.Generic;

class Program
{
    
    static Dictionary<string, (string grupo, double carga, int repeticoes)> exercicios
        = new Dictionary<string, (string, double, int)>();

    static void Main()
    {
        int opcao;

        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1 - Adicionar exercício");
            Console.WriteLine("2 - Listar exercícios");
            Console.WriteLine("3 - Buscar por nome");
            Console.WriteLine("4 - Filtrar por grupo muscular");
            Console.WriteLine("5 - Carga total");
            Console.WriteLine("6 - Exercício mais pesado");
            Console.WriteLine("7 - Remover exercício");
            Console.WriteLine("0 - Sair");

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: Adicionar(); break;
                case 2: Listar(); break;
                case 3: Buscar(); break;
                case 4: Filtrar(); break;
                case 5: CargaTotal(); break;
                case 6: MaisPesado(); break;
                case 7: Remover(); break;
            }

        } while (opcao != 0);
    }

    static void Adicionar()
    {
        Console.Write("Nome do exercício: ");
        string nome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido!");
            return;
        }

        if (exercicios.ContainsKey(nome))
        {
            Console.WriteLine("Exercício já existe!");
            return;
        }

        Console.Write("Grupo muscular: ");
        string grupo = Console.ReadLine();

        Console.Write("Carga (kg): ");
        if (!double.TryParse(Console.ReadLine(), out double carga) || carga < 0)
        {
            Console.WriteLine("Carga inválida!");
            return;
        }

        Console.Write("Repetições: ");
        if (!int.TryParse(Console.ReadLine(), out int rep) || rep < 1)
        {
            Console.WriteLine("Repetições inválidas!");
            return;
        }

        exercicios[nome] = (grupo, carga, rep);

        Console.WriteLine("Exercício adicionado!");
    }

    static void Listar()
    {
        if (exercicios.Count == 0)
        {
            Console.WriteLine("Lista vazia.");
            return;
        }

        foreach (var item in exercicios)
        {
            Console.WriteLine($"{item.Key} - {item.Value.grupo} - {item.Value.carga}kg - {item.Value.repeticoes} reps");
        }
    }

    static void Buscar()
    {
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine();

        if (!exercicios.ContainsKey(nome))
        {
            Console.WriteLine("Exercício não encontrado.");
            return;
        }

        var ex = exercicios[nome];
        Console.WriteLine($"{nome} - {ex.grupo} - {ex.carga}kg - {ex.repeticoes} reps");
    }

    static void Filtrar()
    {
        Console.Write("Grupo muscular: ");
        string grupo = Console.ReadLine();

        bool encontrou = false;

        foreach (var item in exercicios)
        {
            if (item.Value.grupo.Equals(grupo, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(item.Key);
                encontrou = true;
            }
        }

        if (!encontrou)
        {
            Console.WriteLine("Nenhum exercício encontrado.");
        }
    }

    static void CargaTotal()
    {
        if (exercicios.Count == 0)
        {
            Console.WriteLine("Lista vazia.");
            return;
        }

        double total = 0;

        foreach (var item in exercicios)
        {
            total += item.Value.carga;
        }

        Console.WriteLine($"Carga total: {total} kg");
    }

    static void MaisPesado()
    {
        if (exercicios.Count == 0)
        {
            Console.WriteLine("Lista vazia.");
            return;
        }

        string nomeMaior = "";
        double maior = -1;

        foreach (var item in exercicios)
        {
            if (item.Value.carga > maior)
            {
                maior = item.Value.carga;
                nomeMaior = item.Key;
            }
        }

        Console.WriteLine($"Mais pesado: {nomeMaior} - {maior} kg");
    }

    static void Remover()
    {
        Console.Write("Nome para remover: ");
        string nome = Console.ReadLine();

        if (!exercicios.Remove(nome))
        {
            Console.WriteLine("Exercício não encontrado.");
            return;
        }

        Console.WriteLine("Removido com sucesso!");
    }
}