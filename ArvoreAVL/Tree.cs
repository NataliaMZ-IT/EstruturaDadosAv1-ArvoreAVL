namespace AVLTree
{
    public class Tree(int value)
    {
        public Node? RootNode { get; set; } = new Node(value);

        private int GetNodeHeight(Node? node)
        {
            return node is not null ? node.Height : 0;
        }

        private void UpdateNodeHeight(Node node)
        {
            if (node is null) return;

            node.Height = 1 + Math.Max(
                GetNodeHeight(node.LeftNode), 
                GetNodeHeight(node.RightNode)
            );
        }

        private int GetBalanceFactor(Node node)
        {
            if (node is null) return 0;

            return GetNodeHeight(node.LeftNode) - GetNodeHeight(node.RightNode);
        }

        private Node RightRotation(Node node)
        {
            Node newRoot = node.LeftNode;
            Node? aux = newRoot.RightNode;

            newRoot.RightNode = node;
            node.LeftNode = aux;

            UpdateNodeHeight(node);
            UpdateNodeHeight(newRoot);

            return newRoot;
        }

        private Node LeftRotation(Node node)
        {
            Node newRoot = node.RightNode;
            Node? aux = newRoot.LeftNode;

            newRoot.LeftNode = node;
            node.RightNode = aux;

            UpdateNodeHeight(node);
            UpdateNodeHeight(newRoot);

            return newRoot;
        }

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

        public Node? Delete(Node? pointerNode, int value)
        {
            if (pointerNode is null)
            {
                return null;
            }

            if (pointerNode.Value > value)
            {
                pointerNode.LeftNode = Delete(pointerNode.LeftNode, value);
            }
            else if (pointerNode.Value < value)
            {
                pointerNode.RightNode = Delete(pointerNode.RightNode, value);
            }
            else
            {
                // Case 1 and 2: No children or one child
                if (pointerNode.LeftNode is null)
                {
                    return pointerNode.RightNode;
                }
                else if (pointerNode.RightNode is null)
                {
                    return pointerNode.LeftNode;
                }

                // Case 3: Two children
                else
                {
                    // Looking for the lowest value to substitute the node to be deleted
                    Node aux = pointerNode.RightNode;
                    while(aux.LeftNode is not null)
                        aux = aux.LeftNode;

                    pointerNode.Value = aux.Value;

                    pointerNode.RightNode = Delete(pointerNode.RightNode, aux.Value);
                }
            }

            return pointerNode;
        }
    }
}
