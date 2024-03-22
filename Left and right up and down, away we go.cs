using System;
using System.IO;
using System.Text.Json;

public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public class Stats
    {
        public int Sum { get; }
        public int DeepestLevel { get; }
        public int Nodes { get; }

        public Stats(int sum, int deepestLevel, int nodes)
        {
            Sum = sum;
            DeepestLevel = deepestLevel;
            Nodes = nodes;
        }
    }

    public static Stats CalculateStats(Node node)
    {
        return Calculate(node, 1);
    }

    private static Stats Calculate(Node node, int level)
    {
        if (node == null)
        {
            return new Stats(0, 0, 0);
        }

        Stats leftStats = Calculate(node.Left, level + 1);
        Stats rightStats = Calculate(node.Right, level + 1);
        int sum = node.Value + leftStats.Sum + rightStats.Sum;
        int deepestLevel = Math.Max(leftStats.DeepestLevel, rightStats.DeepestLevel);

        int nodes = 1 + leftStats.Nodes + rightStats.Nodes;

        deepestLevel = Math.Max(deepestLevel, level);

        return new Stats(sum, deepestLevel, nodes);
    }

    public static void Main()
    {
       
        string json = File.ReadAllText("nodes.json");

        Node node = JsonSerializer.Deserialize<Node>(json);
      
        Stats result = CalculateStats(node);

        Console.WriteLine($"Sum = {result.Sum}");
        Console.WriteLine($"Deepest level = {result.DeepestLevel}");
        Console.WriteLine($"Nodes = {result.Nodes}");
    }
}