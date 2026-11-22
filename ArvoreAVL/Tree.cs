using System.Reflection.Metadata.Ecma335;

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
