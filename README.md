# DocumentAssembler_Looplex
Avaliação técnica Looplex: simulação de programa Document Assembler com uso de árvore genérica. Print de nós folhas e monitoramento da execução. Foram usados os designs Patterns Strategy e Observer e Multithreading (Task.Run()).

DocumentAssembler.cs
- onde está o método Main
- são instanciados os nós e a árvore (classes Node e Tree)
- é colocado um observador de árvore na árvore (Observer design pattern)
- é colocado um observador de nó em um dos nós. (Observer design pattern)
- é chamado o método da árvore printLeafsByLevel que recebe uma classe derivada da interface IPrinter que vai determinar como serão printados os nós (console, .txt). Assim é possível criar outras classes para printar os nós de outras maneiras. (Strategy design pattern).

Node.cs
- classe dos nós da árvore
- possui os campos: id(int), text(string), children(lista dos nós filhos), observers (lista de observadores do nó)

Tree.cs
- classe da árvore
- possui os campos: root (nó raiz) e observers (lista de observadores da árvore)
- possui o método da árvore printLeafsByLevel que recebe uma classe derivada da interface IPrinter que vai determinar como serão printados os nós (console, .txt). São criadas threads para fazer a notificação aos observadores da árvore e do nó sobre o início e término do print. Assim o monitoramento não interfere no fluxo de execução.

NodeObserver.cs
- classe do observador do nó
- pode ser colocado em um ou mais nós
- printa no console as informações sobre o(s) nó(s) processado(s) que está observando,

TreeObserver.cs
- classe do observador da árvore
- printa no console as informações sobre todos nós da árvore

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

PrinterConsole
- classe que printa o nó no console

PrinterTxtConsole
- classe que printa o nó em arquivos .txt em uma pasta

