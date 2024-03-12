using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que implementa el algoritmo de árbol de expansión mínima
// Está optimizado con las patas :u

public class MinimumSpanningTree
{
    public Graph2D graph2D;
    private List<Vector2> S1 = new List<Vector2>();
    private List<Vector2> S2 = new List<Vector2>();
    private List<Vector2Int> E = new List<Vector2Int>();
    public List<Vector2Int> T = new List<Vector2Int>();
    public bool algorithmCompleted;

    public MinimumSpanningTree(Graph2D graph2D)
    {
        this.graph2D = graph2D;
    }

    public void InitAlgorithm()
    {
        // Selecciona un nodo de manera aleatoria
        int i = Random.Range(0, graph2D.nodePositions.Count);
        Vector2 u = graph2D.nodePositions[i];

        // Inicializa S1
        S1.Add(u);

        // Inicializa S2
        S2 = graph2D.GraphWithout(u);

        // Inicializa E
        foreach (Vector2 v in S2)
        {
            int j = graph2D.nodePositions.IndexOf(v);
            Vector2Int nodePair = new Vector2Int(i, j);
            if (graph2D.edgeCost.ContainsKey(nodePair))
            {
                E.Add(nodePair);
            }
        }
        algorithmCompleted = false;
    }

    // Cuidado con donde se llama esta función!!
    public void MST_Algorithm()
    {
        while (S2.Count > 0 || !algorithmCompleted)
        {
            // Selecciona la conexión entre elementos de S1
            // y elementos de S2 con el costo mínimo

            Vector2Int minCostPair = Vector2Int.zero;

            int minCost = 1000000;
            foreach (Vector2Int nodePair in E)
            {
                if (graph2D.edgeCost[nodePair] < minCost)
                {
                    minCost = graph2D.edgeCost[nodePair];
                    minCostPair = nodePair;
                }
            }

            Vector2 u = graph2D.nodePositions[minCostPair.x];
            Vector2 v = graph2D.nodePositions[minCostPair.y];

            if (!S1.Contains(v))
            {
                S1.Add(v);
                T.Add(minCostPair);
            }

            S2.Remove(v);
            E.Remove(minCostPair);

            int j = graph2D.nodePositions.IndexOf(v);
            foreach (Vector2 w in S2)
            {
                int k = graph2D.nodePositions.IndexOf(w);
                Vector2Int pair = new Vector2Int(j, k);
                if (graph2D.edgeCost.ContainsKey(pair))
                    E.Add(pair);
            }


            if (S2.Count == 0)
            {
                algorithmCompleted = true;
                //CreateMSTEdges();
                //CreateMazeWalls();
                //CreateMazeBorders();
            }

        }
    }

    public List<Vector2> MSTNeighbours(Vector2 node)
    {
        List<Vector2> directions =
                    new List<Vector2> {Vector2.right, Vector2.up,
                                        Vector2.left, Vector2.down };

        List<Vector2> result = new List<Vector2>();
        foreach (Vector2 direction in directions)
        {
            Vector2 neighbour = node + direction;
            int i = graph2D.nodePositions.IndexOf(node);
            int j = graph2D.nodePositions.IndexOf(neighbour);
            Vector2Int pair1 = new Vector2Int(i, j);
            Vector2Int pair2 = new Vector2Int(j, i);
            bool cond1 = graph2D.nodePositions.Contains(neighbour);
            bool cond2 = (T.Contains(pair1) || T.Contains(pair2));
            if (cond1 && cond2)
                result.Add(neighbour);
        }
        return result;
    }

}
