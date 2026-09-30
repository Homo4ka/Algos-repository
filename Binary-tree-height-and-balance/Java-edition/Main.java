package ru.Homo4ka;

public class Main {
    public static void main(String[] args) {
        BinarySearchTree<Integer> tree = new BinarySearchTree<>();

        int[] values = { 5, 3, 8, 2, 4, 7, 9 };
        for (int v : values) {
            tree.insert(v);
        }

        System.out.print("Элементы дерева: ");
        tree.printInOrder();

        System.out.println("Содержит 10?: " + tree.contains(10));
        System.out.println("Содержит 4?: " + tree.contains(4));

        System.out.print("Удаляем 4 -> ");
        tree.removeValue(4);
        tree.printInOrder();

        System.out.print("Удаляем 7 -> ");
        tree.removeValue(7);
        tree.printInOrder();

        System.out.print("Удаляем 3 -> ");
        tree.removeValue(3);
        tree.printInOrder();

        System.out.print("Удаляем 5 -> ");
        tree.removeValue(5);
        tree.printInOrder();

        System.out.println("Высота: " + tree.getHeight());
        System.out.println("Сбалансировано?: " + tree.isBalanced());

        BinarySearchTree<Integer> skewed = new BinarySearchTree<>();
        int[] skewedValues = { 1, 2, 3, 4, 5 };
        for (int v : skewedValues) {
            skewed.insert(v);
        }

        System.out.print("Перекошенное дерево: ");
        skewed.printInOrder();
        System.out.println("Высота: " + skewed.getHeight());
        System.out.println("Сбалансировано?: " + skewed.isBalanced());
    }
}