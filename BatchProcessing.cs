using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text.Json;

class BatchProcessing
{
    static void Main()
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
}
