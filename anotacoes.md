## GUIDS

- `Guid.NewGuid()`: Gera um GUID aleatório
- `new Guid(guid)`: Criar um GUID a partir de uma string informada em `guid`, se não for passado nada retorna o GUID com todos caracteres sendo `0`

## Interpolação de Strings
Utilizada para cocatenar strings
- `var texto = "texo" + var + "texto2"`: Cocatena com o operador `+`, convertendo o valor de uma variável automaticamente para string.
- `var texto = string.Format("texto {0} texto2 {1}", var, var2)`: Uma função que converte os valores dentro de `{i}` em uma variável, respeitando o índice colocado dentro das chaves.
- `var texto = $"texto {var} texto2"`: Ao adicionador o operador `$` antes da string é possível formatar colocando a variável dentro de chaves em qualquer lugar da string, pode-se utilizar `\{` e `\}` como caracteres de escape.
- `var texto = $@"String multilinha"`: utilizando o operador `@` pode-se criar um astring multilinha, pode ser cobmbinado com `$` para fazer a interpolação ou utilizado sozinho.

## Comparação de texto

- `text.CompareTo("string")`: É utilizado para comparar dois textos retorna um inteiro, sendo `0` para verdadeiro e `1`para falso, é Case Sensitive
- `text.Contains("word")`: É utilizado para verificar se existe uma palavra dentro de outro texto, retorna um `bool`, é Case Sentitive
- `text.StartsWith("string")`: É utilizado para verificar se o texto começa com a palavra informada, retorna um `bool`, é Case Sensitive
- `text.EndsWith("string")`: É utilizado para verificar se o texto termina com a palavra informada, retorna um `bool`, é Case Sensitive
- `text.Equals("string")`: É utilizado para verificar se um texto é igual a outro texto, retorna um `bool`, é Case Sensitive (Também pode ser usado com outro tipos, desde que seja do mesmo tipo)

Em ambos os métodos acima pode-se utilizar `text.method("string", StringComparison.OrdinalIgnoreCase)`



## Índices em Strings

- `text.IndexOf("u")`: Percorre a string até encontrar a letra `u` e retornar um inteiro que é o índice dessa letra, funciona também com palavras
- `text.LastIndexOf("s")`: Percorre a string e encontra a última letra `s` e retornar um inteiro que é o índice dessa letra, funciona também com palavras

- `text.Insert(7, " batata")`: Insere o texto informado no índice 7 da string, por exemplo se `text` for `"cebola "` retorna `"cebola batata"`, importante não passar o índice da string atual
- `text.Remove(0,2)`: Remove o texto informado do índice 0 ao 2 da string, por exemplo se `text` for `"cebola"` retorna `"bola"`
- `text.Length`: Retorna o tamanho da String

## Manipulação de Strings
- `text.ToLower()`: Transforma toda a string em caracteres minúsculos
- `text.ToUpper()`: Transforma toda a string em caracteres maiúsculos
- `text.Replace("cebola", "batata")`: Transforma todas os caracteres do texto do primeiro argumento pelo do segundo, Então um texto `"cenoura e cebola"` se tornaria `"cenoura e batata"`
- `text.Split(",")`: Transforma o texto e uma lista, dividindo pela string informada no primeiro argumento. Então `"batata,cebola,cenoura"` se tornaria `["batata","cebola","cenoura"]`.
- `text.Substring(5,5)`: Transforma o texto em parte de uma string, o primeiro argumento é o índice inicial e o segundo argumento é a quantidade de caracteres a partir do índice inicial que serão coletados
- `text.Trim()`: Retira os espaços finais e iniciais da string

## StringBuilder

Em algumas situações que fariamos muitas cocatenações com strings o `StringBuilder`pode funcionar melhor já que ele permite a modificação do conteúdo sem criar novos objetos na memória.

Além do métodos `Insert, Remove e Replace` para adicionar uma nova parte ao texto completo usamos o métdo `Append`

```C#
StringBuilder sb = new StringBuilder();
sb.Append("Hello");
sb.Append(" ");
sb.Append("World!");
string result = sb.ToString(); // result: "Hello World!"
```







