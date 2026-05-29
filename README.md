## 📱💻 Mobile-Maui-Login-Pessoa
Exemplo de criação de App Mobile MAUI Xamarin Forms para validação de Usuário, consumindo WebAPI.

#### O que você vai encontrar neste projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **HTTPClient**  | Classe primária utilizada para enviar solicitações HTTP e receber respostas de recursos identificados por um URI. |
| **XAML**  | Linguagem baseada em XML, para definir interfaces de usuário de forma declarativa para Android, iOS, macOS e Windows. |

### Executar a aplicação
- Necessário banco de dados MySQL que deve estar hospedado Online , necessário para emulador Android .NET MAUI funcionar.

#### 🧪 Executar Endpoints

O Arquivo **(PessoaService.cs)** executa :

| Metodo | Descrição |
|-----------|-----------|
| Metodo: GET | /api/Pessoa |
| Metodo: POST | /api/Pessoa |

- Para executar a aplicação é necessário hospedar a APi em Hospedagem Online

```json
https://[LINKWEB].tryasp.net/api/pessoa
```

## 🚀 Api8-Mobile-Mysql
Exemplo de criação de API para CRUD em NET8, com banco de dados MySQL.

#### O que você vai encontrar neste projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **Dapper** |  Utilização de mapeamento rápido de resultados de consultas SQL diretas pela aplicação. |
| **Resource** |  Armazenar dados de maneira estruturada |

#### Executar da aplicação
- Para executar a aplicação é necessário executar o Script em uma Hospedagem Online.  

#### ⚠️ String de conexão do banco
Modifique a string de conexão no arquivo appsettings.json, no trecho indicado:

```json 
 "server=[SEUSERVIDOR];userid=[SEUUSUARIO];password=[SUASENHA];database=[SEUBANCO];persistsecurityinfo=True;"
 ```
 
O script para criação da tabela do exemplo encontra-se na pasta **Database**.

