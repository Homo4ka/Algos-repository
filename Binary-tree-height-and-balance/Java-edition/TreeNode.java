package ru.Homo4ka;

public class TreeNode<T extends Comparable<T>>{
    public T value;
    public TreeNode<T> left;
    public TreeNode<T> right;

    public TreeNode(T value) {
        this.value = value;
    }
}
