# Lumini Hire Test
Se você recebeu o link para este documento, está no caminho certo, o intuito é avaliar nossos candidatos, seguindo critérios que os deixem mais livres para a realização dos desafios, assim, podemos avaliar a capacidade criativa de cada candidato, bem como a originalidade, sem a necessidade que tenham que realizar um teste técnico diretamente dentro de nosso escritório, o que pode atrapalhar o tempo do candidato e a disponibilidade de alguém para aplicar os testes.

Abaixo, segue o teste para o perfis: Fullstack Developer Sr.

# Fullstack Developer
## Objetivo
Testar as habilidades dos candidatos em desenvolvimento C# .NET Core.

## Critérios de Avaliação
* Legibilidade de Código
* Originalidade
* Reusabilidade
* Lógica
* Conhecimentos na Linguagem C# e no Framework dotnet core
* Criatividade
* Coerência
* Velocidade
* Documentação

## Desafios de Desenvolvimento
O candidato é livre a usar as técnicas de desenvolvimento que achar melhor, desde que atenda os requisitos. Para dev Jr e Pleno, desconsiderar os arquivos já existentes neste repositório, crie novos.

Poderá incrementar o desafio com funcionalidades dentro do mesmo escopo, caso faça bem feito, terá destaque com pontuação extra, use a criatividade.

O Layout não é relevante, mas uma boa apresentação tem destaque. Semântica HTML não é levada em consideração.

É obrigatório o uso da sua conta Github para realizar o Fork deste repositório e enviar pull-request ao término do desafio, para sabermos se possui conhecimentos básicos de como funciona a ferramenta git.

### Dev SR
Realizar a ingestão dos dados em "sample_data", "[CollegeScorecard_Raw_Data.zip](https://github.com/lumini-it-solutions/lumini-hire-test/raw/master/sample_data/CollegeScorecard_Raw_Data.zip)", a carga deverá ser realizada para dentro de um Elasticsearch, em um índice nomeado como "scorecard". Criar uma aplicação com Dashboard (acesso privado) para a visualização e uma pesquisa dos dados (acesso público).

### Requisitos
* dotnet core 2.2 ou superior.
* Tem que rodar em qualquer sistema operacional.
* SQLite
* Bootstrap
* Razor Pages ou MVC
* ASP.NET Identity
* Elasticsearch

-------------------------------

# Lumini Hire Test - Desenvolvido por Danilo Fernandes
Realização do teste para contratação na Lumini.

## Desenvolviento da Solução (Steps)

### Passos executados

#### 1) Verificação, organização, limpeza e subida dos dados para o ElasticSearch
Realizada uma análise para determinação de dados necessários a serem inseridos no elasticsearch. Identificado que os arquivos disponibilizados contam com aproximadamente 130mb cada e são compostos por mais de 1900 campos.

Os arquivos foram reduzidos para as 150 primeiras colunas. A redução foi realizada através de uma plicação console que apenas determinava os primeiros X campos e os salvava na mesma sequência do arquivo original.

Para a carga no elasticsearch foi utilizado o ***LogStash***, ferramenta da elastic e que compõe a stack da mesma.

Na pasta ***"sample_data/logstash"*** do projeto, constam os arquivos modificados.

A aplicação foi desenvolvida utilizando uma instância do elasticsearch no docker. Porém, para facilitar os testes e análise da solução, foi criada uma instância do Elastic Cloud com os mesmos dados.
Desta forma não é necessário configurar uma instância do elasticsearch para que a aplicação funcione corretamente. 

#### 2) Atualização da solução de ASP.NET Core 2.2 para ASP.NET Core 3.1
Por medida de alinhamento com desempenho e possíveis bugs, decidi atualizar a versão da aplicação Core para a 3.1.
Foram utilizadas como base as seguintes postagens:
* https://medium.com/@alexandre.malavasi/migra%C3%A7%C3%A3o-de-asp-net-core-2-2-para-3-1-projeto-real-6840afaa8845
* https://docs.microsoft.com/pt-br/aspnet/core/migration/22-to-30?view=aspnetcore-3.1&tabs=visual-studio

#### 3) Criação da tela de consulta
Esta tela não necessita de autenticação e ficará aberta para utilização externa.

* O texto digitado será buscando no campo que contem o nome das escolas cadastradas.
* Não são permitidas consultas com o campo de texto vazio.
* Não são permitidas consultas com o campo de texto contendo menos que 3 caracteres.

![](/showcase/TelaConsulta.png)

#### 4) Criação da tela de retorno de consulta
Esta tela não necessita de autenticação e ficará aberta para utilização externa. Ela mostrará os resultados obtidos com a consulta, sempre mostrando o NOME e o ID da escola encontrada.

* O texto digitado será buscando no campo que contem o nome das escolas cadastradas.
* Não são permitidas consultas com o campo de texto vazio.
* Não são permitidas consultas com o campo de texto contendo menos que 3 caracteres.
* São mostradas a quantidade de retornos obtidos e o tempo necessário para a consulta.
* A mesma conta com paginação.

![](/showcase/TelaConsultaRetorno.png)

![](/showcase/TelaConsultaRetorno2.png)

#### 5) Criação do cadastro de usuário e tela de login utilizando o ASP.NET Identity
Usuário para teste:
* teste
* Teste@1234

![](/showcase/TelaRestritaLogin.png)

#### 6) Criação da tela de dashboard
Esta tela demanda autenticação e apenas usuários autorizados terão acesso.
Nela é possível verificar a seguinte informação:

* Quantidade de documentos inseridos no índice

***Futuras Estatísticas***
* Quantidade de consultas realizadas
* Palavras pesquisadas
* Quantidades de consultas por palavra
* Quantidade de retornos por palavra

![](/showcase/TelaRestritaDashboard.png)

## Executar a aplicação
Para a realização de testes na aplicação basta abrir a solução no Visual Studio e executar a mesma.

