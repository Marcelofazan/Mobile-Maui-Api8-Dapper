## 📱 Maui-Mobile-Login-Api8-Dapper
Exemplo de App Mobile de Login de usuário em C# .NET MAUI Xamarin Forms.

#### 📋 O que você vai encontrar neste projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **HTTPClient**  | Classe primária utilizada para enviar solicitações HTTP e receber respostas de recursos identificados por um URI. |
| **XAML**  | Linguagem baseada em XML, para definir interfaces de usuário de forma declarativa para Android, iOS, macOS e Windows. |
  
#### 🔄 Executar a aplicação
- Necessário banco de dados MySQL que deve estar hospedado Online , necessário para emulador Android .NET MAUI funcionar.

- Para executar a aplicação é necessário hospedar a API em Hospedagem Online
```json
https://[LINKWEB].tryasp.net/api/pessoa
```

#### 🧪 Executar Endpoints

O Arquivo **(PessoaService.cs)** executa :

| Metodo | Descrição |
|-----------|-----------|
| Metodo: GET | /api/Pessoa |
| Metodo: POST | /api/Pessoa |

## 🚀 Api8-Mobile-Mysql
Exemplo de API para em C# .ASP.NET Core 8 com banco de dados MySQL.

#### 📋 O que você vai encontrar neste projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **Dapper** |  Utilização de mapeamento rápido de resultados de consultas SQL diretas pela aplicação. |
| **Resource** | Armazenar em arquivo informações de maneira estruturada |

#### 💬 Requisitos do Projeto
- Para executar a aplicação é necessário executar o Script do MySQL.

#### ⚠️ String de conexão do banco
Modifique a string de conexão no arquivo appsettings.json, no trecho indicado:

```json 
 "server=[SEUSERVIDOR];userid=[SEUUSUARIO];password=[SUASENHA];database=[SEUBANCO];persistsecurityinfo=True;"
 ```
 
O script para criação da tabela do exemplo encontra-se na pasta **Database**.

#### 🔄 Executar da aplicação
- Para executar a aplicação é necessário executar o Script em uma Hospedagem Online.  

## 📁 HttpClientConsumirAPI
Exemplo de consumo da API com comandos HTTPClient por aplicativo console C#. 

#### 🔄 Executar a aplicação 
- Para executar a aplicação é necessário alterar a url no arquivo **program.cs**

```json
https://[SEU_HOST].tryasp.net/api/pessoa
```
