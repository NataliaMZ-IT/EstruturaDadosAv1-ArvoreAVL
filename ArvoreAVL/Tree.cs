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

        public void Insert(int value)
        {
            var newRootNode = Insert(RootNode, value);

            if (RootNode != newRootNode)
                RootNode = newRootNode;
        }

        private Node Insert(Node? currentNode, int value)
        {
            if (currentNode is null)
            {
                return new Node(value);
            }

            if (currentNode.Value > value)
            {
                currentNode.LeftNode = Insert(currentNode.LeftNode, value);
            }
            else if (currentNode.Value < value)
            {
                currentNode.RightNode = Insert(currentNode.RightNode, value);
            }

            UpdateNodeHeight(currentNode);

            int balanceFactor = GetBalanceFactor(currentNode);

            // Simple Right Rotation (LL)
            if (balanceFactor > 1 && value < currentNode.LeftNode.Value)
                return RightRotation(currentNode);

            // Simple Left Rotation (RR)
            if (balanceFactor < -1 && value > currentNode.RightNode.Value)
                return LeftRotation(currentNode);

            // Right Rotation on the SubRoot then Left Rotation (RL)
            if (balanceFactor < -1 && value < currentNode.RightNode.Value)
            {
                currentNode.RightNode = RightRotation(currentNode.RightNode);
                return LeftRotation(currentNode);
            }

            // Left Rotation on the SubRoot then Right Rotation (LR)
            if (balanceFactor > 1 && value > currentNode.LeftNode.Value)
            {
                currentNode.LeftNode = LeftRotation(currentNode.LeftNode);
                return RightRotation(currentNode);
            }

            return currentNode;
        }

        public void Delete(int value)
        {
            var newRootNode = Delete(RootNode, value);

            if (newRootNode != RootNode)
                RootNode = newRootNode;
        }

        private Node? Delete(Node? currentNode, int value)
        {
            if (currentNode is null)
            {
                return null;
            }

            if (currentNode.Value > value)
            {
                currentNode.LeftNode = Delete(currentNode.LeftNode, value);
            }
            else if (currentNode.Value < value)
            {
                currentNode.RightNode = Delete(currentNode.RightNode, value);
            }
            else
            {
                // Case 1 and 2: No children or one child
                if (currentNode.LeftNode is null)
                {
                    return currentNode.RightNode;
                }
                else if (currentNode.RightNode is null)
                {
                    return currentNode.LeftNode;
                }

                // Case 3: Two children
                else
                {
                    // Looking for the lowest value to substitute the node to be deleted
                    Node aux = currentNode.RightNode;
                    while(aux.LeftNode is not null)
                        aux = aux.LeftNode;

                    currentNode.Value = aux.Value;

                    currentNode.RightNode = Delete(currentNode.RightNode, aux.Value);
                }
            }

            UpdateNodeHeight(currentNode);

            int balanceFactor = GetBalanceFactor(currentNode);

            // Simple Right Rotation (LL)
            if (balanceFactor > 1 && GetBalanceFactor(currentNode.LeftNode) >= 0)
                return RightRotation(currentNode);

            // Simple Left Rotation (RR)
            if (balanceFactor < -1 && GetBalanceFactor(currentNode.RightNode) <= 0)
                return LeftRotation(currentNode);

            // Right Rotation on the SubRoot then Left Rotation (RL)
            if (balanceFactor < -1 && GetBalanceFactor(currentNode.RightNode) > 0)
            {
                currentNode.RightNode = RightRotation(currentNode.RightNode);
                return LeftRotation(currentNode);
            }

            // Left Rotation on the SubRoot then Right Rotation (LR)
            if (balanceFactor > 1 && GetBalanceFactor(currentNode.LeftNode) < 0)
            {
                currentNode.LeftNode = LeftRotation(currentNode.LeftNode);
                return RightRotation(currentNode);
            }

            return currentNode;
        }
    }
}
