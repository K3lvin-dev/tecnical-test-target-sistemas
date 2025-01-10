
# Technical Test Target Sistemas

Este repositório contém o código para o teste técnico da empresa **Target Sistemas**

## Funcionalidades

O projeto inclui os seguintes recursos:

1. **Validação de número Fibonacci**: Um programa que verifica se um número informado pertence à sequência de Fibonacci.
2. **Processamento de Faturamento**:
    - Leitura de dados de faturamento a partir de arquivos XML e JSON.
    - Combinação dos dados e cálculos de estatísticas, como menor valor, maior valor, média e dias acima da média.
3. **Cálculo de percentual de faturamento por estado**: Calcula e exibe o percentual de faturamento por estado a partir de um dicionário.
4. **Inversão de string**: Um programa simples para inverter uma string fornecida pelo usuário.
5. **Testes automatizados**:
    - Validação de formato e dados de um arquivo XML, incluindo a verificação de um campo numérico específico.

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter as seguintes ferramentas instaladas:

- **.NET SDK** 6.0 ou superior: [Download](https://dotnet.microsoft.com/download/dotnet)
- **xUnit**: Framework de testes utilizado para a validação do código. O xUnit será instalado automaticamente durante a restauração das dependências.
  
## Como Executar

### Clonando o Repositório

Clone o repositório para sua máquina local:

```bash
git clone https://github.com/seu-usuario/tecnical-test-target-sistemas.git
cd tecnical-test-target-sistemas
```

### Restaurar Dependências

Para restaurar as dependências do projeto, execute:

```bash
dotnet restore
```

### Executar o Projeto

Para rodar o programa principal, execute:

```bash
dotnet run
```

### Executar os Testes

Para rodar os testes, execute:

```bash
dotnet test
```

## Estrutura do Projeto

O projeto contém os seguintes arquivos e pastas principais:

- **Program.cs**: Contém a implementação dos programas principais para validação de Fibonacci, processamento de faturamento, cálculo de percentual de faturamento e inversão de string.
- **XmlValidatorTests.cs**: Contém os testes automatizados, incluindo a validação de formato de XML.
- **dados (2).xml**: Exemplo de arquivo XML de faturamento a ser processado.
- **dados.json**: Exemplo de arquivo JSON de faturamento a ser processado.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
