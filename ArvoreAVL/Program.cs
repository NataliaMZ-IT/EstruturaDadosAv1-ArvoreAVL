using AVLTree;

// Various examples to test Insert with Rebalancing
var tree = new Tree(5);
tree.Insert(10);
tree.Insert(15);
tree.PrintTree();

tree = new Tree(5);
tree.Insert(4);
tree.Insert(3);
tree.PrintTree();

tree = new Tree(5);
tree.Insert(13);
tree.Insert(12);
tree.PrintTree();

tree = new Tree(5);
tree.Insert(2);
tree.Insert(3);
tree.PrintTree();

// Various examples to test Delete with Rebalancing
tree = new Tree(5);
tree.Insert(2);
tree.Insert(10);
tree.Insert(1);
tree.Insert(8); 
tree.Insert(11);
tree.Insert(9);
tree.Delete(11);
tree.PrintTree();

tree = new Tree(5);
tree.Insert(2);
tree.Insert(10);
tree.Insert(1);
tree.Insert(8);
tree.Insert(11);
tree.Insert(7);
tree.Delete(11);
tree.PrintTree();

tree = new Tree(5);
tree.Insert(2);
tree.Insert(10);
tree.Insert(1);
tree.Insert(8);
tree.Insert(15);
tree.Insert(14);
tree.Delete(8);
tree.PrintTree();

tree = new Tree(5);
tree.Insert(2);
tree.Insert(10);
tree.Insert(1);
tree.Insert(8);
tree.Insert(15);
tree.Insert(16);
tree.Delete(8);
tree.PrintTree();