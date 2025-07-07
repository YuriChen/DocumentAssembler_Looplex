# Árvore genérica em C# | design patterns Strategy e Observer | Multithreading
Implementação de árvore genérica em C#. É executado o print de nós folhas e monitoramento da execução em threads à parte. Foram usados os designs Patterns Strategy, para deixar a funcionalidade de printar nós extensível, e Observer mais a técnica de Multithreading, para fazer o monitoramento do procesamento sem interferir no fluxo de execução.

- Para executar o programa: abrir documentAssembler.csproj no Visual Studio e executar.
- Ao iniciar o programa, a árvore é montada (a mesma árvore presente no documento do enunciado da avaliação).
- Para a questão do monitoramento, foi usado o design pattern **Observer** mais a técnica de **Multithreading** (função Task.Run()). A árvore notifica, em uma thread a parte, seus observadores quando um nó folha começa ou termina de ser printada. Os observadores, por sua vez, exibem as informações do nó processado no console. Também é possível colocar observadores de nós para apenas um ou mais nós.
- O printar também é uma funcionalidade extensível, sendo usado o design pattern **Strategy**. Há duas classes que podem ser escolhidas para o print: PrintConsole.cs e PrintTxtFiles.cs. A primeira apenas printa o texto dos nós folhas no console, e a segunda, em uma pasta criada na pasta Downloads. Está sendo usada no programa a classe PrintTxtFiles.cs
- Depois de montada a árvore, é adicionado o observador da árvore e um observador de nó em um dos nós (para apenas mostrar que é possível fazer o monitoramento de um nó em particular). **Então, pede-se para apertar qualquer tecla que irá iniciar o processo de print dos textos dos nós folhas e o monitoramento dessa execução.**
- **Os textos dos nós folhas serão printados em arquivos .txt em uma pasta criada na pasta "Downloads" e monitoramento do print dos nós será exibido no console.**


Arquivos/Classes do programa:

DocumentAssembler.cs
- onde está o método Main
- são instanciados os nós e a árvore (classes Node e Tree)
- é colocado um observador de árvore na árvore (Observer design pattern)
- é colocado um observador de nó em um dos nós. (Observer design pattern)
- é chamado o método da árvore printLeafsByLevel que recebe uma classe derivada da interface IPrinter que vai determinar como serão printados os nós (console, .txt). Assim é possível criar outras classes para printar os nós de outras maneiras. (Strategy design pattern). Está sendo passado o PrinterTxtFiles, que vai printar os textos dos nós folhas **em uma pasta criada na pasta "Downloads"**.

Node.cs
- classe dos nós da árvore
- possui os campos: id(int), text(string), children(lista dos nós filhos), observers (lista de observadores do nó)

Tree.cs
- classe da árvore
- possui os campos: root (nó raiz) e observers (lista de observadores da árvore)
- possui o método notifyObservers que chama o método nodeStatusUpdate de cada observador na lista de observadores da árvore. O método notifyObservers é chamado antes e depois do print do nó, e é executado em outra thread, assim não interferindo no fluxo de execução do printar.
- possui o método da árvore printLeafsByLevel que recebe uma classe derivada da interface IPrinter que vai determinar como serão printados os nós (console, .txt). Os nós são printados por nível. São criadas threads para fazer a notificação aos observadores da árvore e do nó sobre o início e término do print. Assim o monitoramento não interfere no fluxo de execução. :warning: Foi colocado um delay de 2 segundos ao printar o nó para simular como se estivesse sendo feito um processamento maior e para melhor ver o monitoramento agindo.

NodeObserver.cs
- classe do observador do nó
- pode ser colocado em um ou mais nós
- printa no console as informações sobre o(s) nó(s) processado(s) que está observando,

TreeObserver.cs
- classe do observador da árvore
- irá exibir, no console, informações dos nós folhas no início e término do print executando o método nodeStatusUpdate. São exibidas as informações: id do nó, se o nó é branch ou folha, profundidade do nó, horário, status (início/fim do print) e duração. **Por ser executada em uma thread própria, os informações dos nós no console, não irão aparecer exatamente na ordem cronológica, porém é possível saber a ordem exata olhando o campo "horário"**.

IObserver.cs
- interface observador
- método abstrato nodeStatusUpdate (print da informação sobre o subject no console)

ISubject.cs
- interface observável
- métodos abstratos addObserver, removerObserver e notifyObservers

InfoNode.cs
- classe da informação do nó processado
- possui os campos: id do nó, se o nó é branch ou folha, profundidade do nó, horário, status (início/fim do print), duração.

IPrinter.cs
- interface de classes que fazem o print do nó
- método abstrato printNode

PrinterConsole.cs
- classe que printa o nó no console

PrinterTxtConsole.cs
- classe que printa o nó em arquivos .txt em uma pasta
- É possível escolher o caminho onde a pasta vai ser criada e o nome da pasta. É só passar como parâmetros no construtor. :warning: Se não passar nada, como está atualmente, **a pasta será criada na pasta "Downloads"**.

