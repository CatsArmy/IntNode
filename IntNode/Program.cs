using Lists.IntNode;

IntNode intNodes = new(5);

void AddNodeAndPrint(int val)
{
    intNodes.RecursiveAdd(val);
    Console.WriteLine(intNodes);
}
void RemoveNodeAndPrint(IntNode node)
{
    intNodes.RemoveNode(node);
    Console.WriteLine(intNodes);
}
void RemoveNodeWithValAndPrint(int val)
{
    //intNodes.RemoveNode(val);
    intNodes.RecursiveRemove(val);
    Console.WriteLine(intNodes);
}
intNodes = IntNode.BuildRandList(5,0,99);
Console.WriteLine(intNodes);
/*
AddNodeAndPrint(6);
AddNodeAndPrint(3);
AddNodeAndPrint(7);
AddNodeAndPrint(19);
AddNodeAndPrint(10);

RemoveNodeWithValAndPrint(3);
RemoveNodeWithValAndPrint(7);
//IntNode node = new IntNode(24);
//intNodes.RemoveNode(node);
RemoveNodeWithValAndPrint(5);
RemoveNodeWithValAndPrint(19);
RemoveNodeWithValAndPrint(10);

/* 
 * IntNode n1 = new IntNode(11);
 *
  * AddNodeAndPrint(3);
    AddNodeAndPrint(7);
    AddNodeAndPrint(19);
    AddNodeAndPrint(10);
    intNodes.AddNode(n1);
 *
 * */