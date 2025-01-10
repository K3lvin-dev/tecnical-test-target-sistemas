using System;
using System.IO;
using System.Xml.Linq;
using Xunit;

public class XmlValidatorTests
{
    [Fact]
    public void TestXmlFormat()
    {
        // Caminho para o arquivo XML que será testado
        string xmlPath = "dados (2).xml";

        // Verifica se o arquivo existe
        Assert.True(File.Exists(xmlPath), $"Arquivo {xmlPath} não encontrado.");

        try
        {
            // Carrega o documento XML
            var doc = XDocument.Load(xmlPath);

            // Verifica se existem elementos <row> no XML
            var rows = doc.Descendants("row");
            Assert.NotEmpty(rows); // Garante que exista pelo menos um elemento <row>

            foreach (var row in rows)
            {
                // Garante que cada elemento <row> tenha um elemento <valor> e que ele seja válido
                var valorElement = row.Element("valor");
                Assert.NotNull(valorElement); // O elemento <valor> deve existir
                Assert.True(double.TryParse(valorElement?.Value, out _), "O elemento <valor> deve conter um número válido.");
            }
        }
        catch (Exception ex)
        {
            // Caso ocorra um erro ao tentar parsear o XML, o teste falha
            Assert.True(false, $"Falha ao tentar analisar o XML: {ex.Message}");
        }
    }
}
