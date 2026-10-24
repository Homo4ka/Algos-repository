package ru.Homo4ka;

public class BinarySearchTree<T extends Comparable<T>> {
    private TreeNode<T> root;

    public void insert(T value)
    {
        root = insertRecusive(root, value);
    }

    private TreeNode<T> insertRecusive(TreeNode<T> node, T value) {
        if(node == null) {
            return new TreeNode<T>(value);
        }

        if(value.compareTo(node.value) < 0) {
            node.left = insertRecusive(node.left, value);
        } else if (value.compareTo(node.value) > 0) {
            node.right = insertRecusive(node.right, value);
        }

        return node;
    }

    public void printInOrder() {
        printInOrderRecusive(root);
        System.out.println();
    }

    private void printInOrderRecusive(TreeNode<T> node) {
        if (node != null) {
            printInOrderRecusive(node.left);
            System.out.print(node.value + " ");
            printInOrderRecusive(node.right);
        }
    }

    public boolean contains(T value) {
        TreeNode<T> current = root;

        while (current != null) {
            int cmp = value.compareTo(current.value);

            if(cmp == 0) {
                return true;
            } else if(cmp < 0) {
                current = current.left;
            } else {
                current = current.right;
            }
        }

        return false;
    }

    private TreeNode<T> findMin(TreeNode<T> node) {
        while (node.left != null) {
            node = node.left;
        }

        return node;
    }

    public void removeValue(T value) {
        root = removeValueRecusive(root, value);
    }

    private TreeNode<T> removeValueRecusive(TreeNode<T> node, T value) {
        if(node == null) {
            return null;
        }

        int cmp = value.compareTo(node.value);
        if(cmp < 0) {
            node.left = removeValueRecusive(node.left, value);
        } else if(cmp > 0) {
            node.right = removeValueRecusive(node.right, value);
        } else {
            if(node.left == null) {
                return node.right;
            } else if (node.right == null) {
                return node.left;
            }

            TreeNode<T> minNode = findMin(node.right);
            node.value = minNode.value;
            node.right = removeValueRecusive(node.right, minNode.value);
        }

        return node;
    }

    public int getHeight() {
        return getHeightRecusive(root);
    }

    private int getHeightRecusive(TreeNode<T> node) {
        if(node == null) {
            return 0;
        }

        int leftH = getHeightRecusive(node.left);
        int rightH = getHeightRecusive(node.right);

        return 1 + Math.max(leftH, rightH);
    }

    public boolean isBalanced() {
        return checkBalance(root) != -1;
    }

    private int checkBalance(TreeNode<T> node) {
        if(node == null) {
            return 0;
        }

        int leftH = checkBalance(node.left);
        if(leftH < 0) {
            return -1; //маркер дисбаланса
        }

        int rightH = checkBalance(node.right);
        if(rightH < 0) {
            return -1;
        }

        if(Math.abs(rightH - leftH) > 1) {
            return -1;
        }

        return 1 + Math.max(leftH, rightH);
    }
}
