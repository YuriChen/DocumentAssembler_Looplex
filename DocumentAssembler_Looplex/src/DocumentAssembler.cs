using System;
using System.Collections.Generic;
using System.IO;

public class DocumentAssembler 
{
    public static void Main(String[] args) 
    {
        Console.WriteLine("Montando �rvore (hardcoded)...");
        //Mesma �rvore que est� no PDF do enunciado da avalia��o
        Node root = new Node(0,null);                   //branch
        Node node11 = new Node(1,"weudh eij fefjei");   //leaf
        Node node12 = new Node(2,null);                 //branch
        Node node21 = new Node(3,"jfcjn relrp");        //leaf
        Node node22 = new Node(4,null);                 //branch
        Node node23 = new Node(5,"rfkr wrf frhoep");    //leaf
        Node node31 = new Node(6,"twgtgyedw");          //leaf
        Node node32 = new Node(7,"wplmgbc xmwcprt");    //leaf

        root.addChild(node11);
        root.addChild(node12);
        node12.addChild(node21);
        node12.addChild(node22);
        node12.addChild(node23);
        node22.addChild(node31);
        node22.addChild(node32);

        Node root2 = new Node(20, null);                   //branch
        Node node211 = new Node(21, "weudh eij fefjei");   //leaf
        Node node212 = new Node(22, null);                 //branch
        Node node221 = new Node(23, "jfcjn relrp");        //leaf
        Node node222 = new Node(24, null);                 //branch
        Node node223 = new Node(25, "rfkr wrf frhoep");    //leaf
        Node node231 = new Node(26, "twgtgyedw");          //leaf
        Node node232 = new Node(27, "wplmgbc xmwcprt");    //leaf

        node22.addChild(root2);
        root2.addChild(node211);
        root2.addChild(node212);
        node212.addChild(node221);
        node212.addChild(node222);
        node212.addChild(node223);
        node222.addChild(node231);
        node222.addChild(node232);

        Tree tree = new Tree(root);
        Console.WriteLine("�rvore montada.");

        //Uso do Design Pattern Observer. Adiciona o treeObserver na lista de observadores da �rvore.
        TreeObserver treeObserver = new TreeObserver();
        tree.addObserver(treeObserver);
        Console.WriteLine("Adicionado observador na �rvore.");

        //Uso do Design Pattern Observer. Adiciona o nodeObserver na lista de observadores do n� 5.
        NodeObserver nodeObserver = new NodeObserver();
        node23.addObserver(nodeObserver);
        Console.WriteLine($"Adicionado observador no n� {node23.id}");

        Console.WriteLine($"\nAperte qualquer tecla para iniciar o print das folhas...\n");

        Console.ReadKey();

        /*Uso do Design Pattern Strategy para deixar extens�vel a funcionalidade de printar. 
          Adiciona a classe respons�vel por fazer o print (derivada da interface IPrinter),
          assim � poss�vel criar outras classes para printar os n�s de outras maneiras.*/
        PrinterTxtFiles printerTxt = new PrinterTxtFiles();
        PrinterConsole printerConsole = new PrinterConsole();
        tree.printLeafsByLevel(printerTxt);
    }
}