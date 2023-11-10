# Projeto de Admissão - Serviço REST para Contas a Pagar

## Objetivo
O projeto foi um desafio criado pela Metadados para testar as habilidades como Desenvolvedor, e é decorrente de um processo seletivo.

## Premissa
Desenvolver um serviço REST para tratar as regras de negócio descritas abaixo.

### Tecnologias
- .NET Core
- Testes unitários (sugestão xUnit)
- Entity Framework Core
- Front-end em SvelteKit

## Serviços
### Inclusão de Conta a Pagar
- Nome: Texto
- Valor Original: Numeral
- Data de Vencimento: Data
- Data de Pagamento: Data

### Listagem das Contas Cadastradas
- Nome: Texto
- Valor Original: Numeral
- Valor Corrigido: Numeral
- Quantidade de Dias de Atraso: Numeral
- Data de Pagamento: Data

## Regras de Negócio
- Todos os campos são obrigatórios.

## Estrutura do Projeto
O projeto utiliza como referência Clean Architecture, e utiliza conceitos como Clean Code, Single Resposability Principle, Unit Tests e mais.

## Instruções para Execução
1. Certifique-se de ter o ambiente de desenvolvimento configurado para a linguagem escolhida.
2. Clone este repositório.
3. Execute o serviço em um ambiente local ou de sua escolha.
4. Inicie o frontend, utilizando:
   ```npm install & npm run dev```
5. Inicie o Backend com sua IDE de preferência.
6. 
## Considerações Finais
Agradeço por participar do processo seletivo. Qualquer dúvida ou observação, sinta-se à vontade para entrar em contato.
