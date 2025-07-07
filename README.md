# DocumentAssembler_Looplex
Simulação de programa Document Assembler com uso de árvore genérica. Uso dos designs Patterns Strategy e Observer e de Multithreading (Task.Run()).

DocumentAssembler.cs
Onde está o método Main
São instanciados os nós e a árvore (classes Node e Tree)
É colocado um observador de árvore na árvore (Observer design pattern)
É colocado um observador de nó em um dos nós. (Observer design pattern)
É chamado o método da árvore printLeafsByLevel que recebe uma classe derivada da interface IPrinter que vai determinar como serão printados os nós (console, .txt). Assim é possível criar outras classes para printar os nós de outras maneiras. (Strategy design pattern).

Node.cs
Classe dos nós da árvore
Possui os campos: id(int), text(string), children(lista dos nós filhos), observers (lista de observadores do nó)

Tree.cs
Classe da árvore
Possui os campos: root (nó raiz) e observers (lista de observadores da árvore)
Possui o método da árvore printLeafsByLevel que recebe uma classe derivada da interface IPrinter que vai determinar como serão printados os nós (console, .txt). São criadas threads para fazer a notificação aos observadores da árvore e do nó sobre o início e término do print. Assim o monitoramento não interfere no fluxo de execução.

NodeObserver.cs
Classe do observador do nó
Pode ser colocado em um ou mais nós
Printa no console as informações sobre o(s) nó(s) processado(s) que está observando,

TreeObserver.cs
Classe do observador da árvore
Printa no console as informações sobre todos nós da árvore

IObserver.cs
Interface observador
Método abstrato nodeStatusUpdate (print da informação sobre o subject no console)

ISubject.cs
Interface assunto
Métodos abstratos addObserver, removerObserver e notifyObservers

InfoNode.cs
Classe da informação do nó processado
Possui os campos: id do nó, se o nó é branch ou folha, profundidade do nó, horário, status (início/fim do print), duração.

IPrinter.cs
interface de classes que fazem o print do nó
método abstrato printNode

PrinterConsole
Classe que printa o nó no console

PrinterTxtConsole
Classe que printa o nó em arquivos .txt em uma pasta

