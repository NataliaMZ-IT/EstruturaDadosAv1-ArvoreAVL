namespace AVLTree
{
    public class Tree(int value)
    {
        public Node? RootNode { get; set; } = new Node(value);

        public Node Insert(Node? pointerNode, int value)
        {
            if (pointerNode is null)
            {
                return new Node(value);
            }

            if (pointerNode.Value > value)
            {
                pointerNode.LeftNode = Insert(pointerNode.LeftNode, value);
            }
            else if (pointerNode.Value < value)
            {
                pointerNode.RightNode = Insert(pointerNode.RightNode, value);
            }
                
            return pointerNode;
        }
    }
}
