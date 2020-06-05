
    class BinaryTree<T>
    {
        public BinaryTree(T value, BinaryTree<T> leftNode = null, BinaryTree<T> rightTree = null)
        {
            this.Value = value;
            this.LeftNode = leftNode;
            this.RightNode = rightTree;
        }
        public T Value { get; set; }
        public BinaryTree<T> LeftNode { get; set; }
        public BinaryTree<T> RightNode { get; set; }
    }

