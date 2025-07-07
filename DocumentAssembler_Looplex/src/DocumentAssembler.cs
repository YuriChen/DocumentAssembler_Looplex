using System;
using System.Collections.Generic;
using System.IO;

public class DocumentAssembler 
{
    public static void Main(String[] args) 
    {
        Console.WriteLine("> Montando árvore (hardcoded)...\n");

        //Mesma árvore que está no PDF do enunciado da avaliação
        //Criando nós:
        Node root = new Node(0,null);                   //branch
        Node node11 = new Node(1,"weudh eij fefjei");   //leaf
        Node node12 = new Node(2,null);                 //branch
        Node node21 = new Node(3,"jfcjn relrp");        //leaf
        Node node22 = new Node(4,null);                 //branch
        Node node23 = new Node(5,"rfkr wrf frhoep");    //leaf
        Node node31 = new Node(6,"twgtgyedw");          //leaf
        Node node32 = new Node(7,"wplmgbc xmwcprt");    //leaf

        //Ligando os nós:
        root.addChild(node11);
        root.addChild(node12);
        node12.addChild(node21);
        node12.addChild(node22);
        node12.addChild(node23);
        node22.addChild(node31);
        node22.addChild(node32);

        Tree tree = new Tree(root);
        Console.WriteLine("> Árvore montada.\n");

        //Uso do Design Pattern Observer. Adiciona o treeObserver na lista de observadores da árvore.
        TreeObserver treeObserver = new TreeObserver();
        tree.addObserver(treeObserver);
        Console.WriteLine("> Adicionado observador na árvore.\n");

        //Uso do Design Pattern Observer. Adiciona o nodeObserver na lista de observadores do nó 5.
        NodeObserver nodeObserver = new NodeObserver();
        node23.addObserver(nodeObserver);
        Console.WriteLine($"> Adicionado observador no nó {node23.id}\n");

        Console.WriteLine($"\nAperte qualquer tecla para iniciar o print das folhas...\n");

        Console.ReadKey();

        /*Uso do Design Pattern Strategy para deixar extensível a funcionalidade de printar. 
          Adiciona a classe responsável por fazer o print (derivada da interface IPrinter),
          assim é possível criar outras classes para printar os nós de outras maneiras.*/

        //PrinterConsole printerConsole = new PrinterConsole();
        PrinterTxtFiles printerTxt = new PrinterTxtFiles();
        tree.printLeafsByLevel(printerTxt);
    }
}