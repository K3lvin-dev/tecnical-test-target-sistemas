using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text.Json;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Verificar se um número pertence à sequência de Fibonacci");
            Console.WriteLine("2 - Processar faturamento de arquivos XML e JSON");
            Console.WriteLine("3 - Calcular percentuais de faturamento por estado");
            Console.WriteLine("4 - Inverter uma string");
            Console.WriteLine("0 - Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    VerificarFibonacci();
                    break;
                case "2":
                    ProcessarFaturamento();
                    break;
                case "3":
                    CalcularPercentuaisFaturamento();
                    break;
                case "4":
                    InverterString();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Função 1: Verificar se um número pertence à sequência de Fibonacci
    static void VerificarFibonacci()
    {
        Console.Write("Informe um número: ");
        int number = int.Parse(Console.ReadLine());

        if (IsFibonacci(number))
        {
            Console.WriteLine($"O número {number} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"O número {number} não pertence à sequência de Fibonacci.");
        }

        Console.ReadKey();
    }

    static bool IsFibonacci(int num)
    {
        int a = 0, b = 1;

        while (b <= num)
        {
            if (b == num) return true;

            int temp = a;
            a = b;
            b = temp + b;
        }

        return false;
    }

    // Função 2: Processar faturamento de arquivos XML e JSON
    static void ProcessarFaturamento()
    {
        // Processar o XML
        string xmlPath = "dados (2).xml";
        var faturamentoXml = ProcessarXml(xmlPath);

        // Processar o JSON
        string jsonPath = "dados.json";
        var faturamentoJson = ProcessarJson(jsonPath);

        // Combinar os dados
        var faturamentoTotal = CombinarDados(faturamentoXml, faturamentoJson);

        // Filtrar valores válidos
        var valoresValidos = FiltrarValoresValidos(faturamentoTotal);

        // Calcular estatísticas
        double menorValor = CalcularMenorValor(valoresValidos);
        double maiorValor = CalcularMaiorValor(valoresValidos);
        double mediaMensal = CalcularMedia(valoresValidos);
        int diasAcimaDaMedia = CalcularDiasAcimaDaMedia(valoresValidos, mediaMensal);

        // Exibir resultados
        Console.WriteLine($"Menor faturamento: {menorValor:F2}");
        Console.WriteLine($"Maior faturamento: {maiorValor:F2}");
        Console.WriteLine($"Dias acima da média mensal: {diasAcimaDaMedia}");

        Console.ReadKey();
    }

    static List<double> ProcessarXml(string caminho)
    {
        var doc = XDocument.Load(caminho);
        var valores = new List<double>();
        foreach (var row in doc.Descendants("row"))
        {
            var valor = row.Element("valor")?.Value ?? "0";
            valores.Add(double.Parse(valor));
        }
        return valores;
    }

    static List<double> ProcessarJson(string caminho)
    {
        string jsonContent = System.IO.File.ReadAllText(caminho);
        var dados = JsonSerializer.Deserialize<List<Faturamento>>(jsonContent);
        var valores = new List<double>();
        foreach (var item in dados)
        {
            valores.Add(item.Valor);
        }
        return valores;
    }

    static List<double> CombinarDados(List<double> lista1, List<double> lista2)
    {
        var combinados = new List<double>();
        foreach (var valor in lista1) combinados.Add(valor);
        foreach (var valor in lista2) combinados.Add(valor);
        return combinados;
    }

    static List<double> FiltrarValoresValidos(List<double> valores)
    {
        var filtrados = new List<double>();
        foreach (var valor in valores)
        {
            if (valor > 0) filtrados.Add(valor);
        }
        return filtrados;
    }

    static double CalcularMenorValor(List<double> valores)
    {
        double menor = valores[0];
        foreach (var valor in valores)
        {
            if (valor < menor) menor = valor;
        }
        return menor;
    }

    static double CalcularMaiorValor(List<double> valores)
    {
        double maior = valores[0];
        foreach (var valor in valores)
        {
            if (valor > maior) maior = valor;
        }
        return maior;
    }

    static double CalcularMedia(List<double> valores)
    {
        double soma = 0;
        foreach (var valor in valores)
        {
            soma += valor;
        }
        return soma / valores.Count;
    }

    static int CalcularDiasAcimaDaMedia(List<double> valores, double media)
    {
        int count = 0;
        foreach (var valor in valores)
        {
            if (valor > media) count++;
        }
        return count;
    }

    public class Faturamento
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }

    // Função 3: Calcular percentuais de faturamento por estado
    static void CalcularPercentuaisFaturamento()
    {
        var faturamento = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        double total = 0;
        foreach (var valor in faturamento.Values)
        {
            total += valor;
        }

        foreach (var estado in faturamento)
        {
            double percentual = (estado.Value / total) * 100;
            Console.WriteLine($"{estado.Key}: {percentual:F2}%");
        }

        Console.ReadKey();
    }

    // Função 4: Inverter uma string
    static void InverterString()
    {
        Console.Write("Digite uma string: ");
        string input = Console.ReadLine();

        string inverted = InverterString(input);

        Console.WriteLine($"String invertida: {inverted}");

        Console.ReadKey();
    }

    static string InverterString(string texto)
    {
        char[] invertida = new char[texto.Length];
        int j = 0;
        for (int i = texto.Length - 1; i >= 0; i--)
        {
            invertida[j++] = texto[i];
        }
        return new string(invertida);
    }
}
