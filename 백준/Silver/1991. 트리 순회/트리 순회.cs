using System.Text;
node root = null;
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    var input = Console.ReadLine().Split();
    var makeNode = (string c) => c switch { "." => null, _ => new node(c, null, null) };

    if (root is null)
    {
        root = new node(input[0], makeNode(input[1]), makeNode(input[2]));
    }
    else
    {
        node parent = node.search(root, input[0]);
        parent.left = makeNode(input[1]);
        parent.right = makeNode(input[2]);
    }

}

Console.WriteLine(root.answer(new StringBuilder()));

class node
{
    public delegate void Mydelegate(node root, StringBuilder sb);
    public Mydelegate mydelegate;

    public string inform;
    public node left;
    public node right;

    public node(string inform, node left = null, node right = null)
    {
        this.inform = inform;
        this.left = left;
        this.right = right;
    }

    static public node search(node root, string target)
    {
        node result = null;

        if (root != null)
        {
            if (root.inform == target)
            {
                result = root;
            }
            else
            {
                result = search(root.left, target) ?? result;
                result = search(root.right, target) ?? result;
            }
        }
        return result;
    }

    public string answer(StringBuilder sb)
    {
        mydelegate = node.preorder;
        mydelegate += node.newLine;
        mydelegate += node.inorder;
        mydelegate += node.newLine;
        mydelegate += node.postorder;
        mydelegate(this, sb);
        return sb.ToString();
    }
    static public void newLine(node root, StringBuilder sb) => sb.AppendLine();

    static public void preorder(node root, StringBuilder sb)
    {
        if (root is null) return;
        sb.Append(root.inform);
        preorder(root.left, sb);
        preorder(root.right, sb);
    }
    static public void inorder(node root, StringBuilder sb)
    {
        if (root is null) return;
        inorder(root.left, sb);
        sb.Append(root.inform);
        inorder(root.right, sb);
    }
    static public void postorder(node root, StringBuilder sb)
    {
        if (root is null) return;
        postorder(root.left, sb);
        postorder(root.right, sb);
        sb.Append(root.inform);
    }
}