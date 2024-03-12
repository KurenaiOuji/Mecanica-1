using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script NO VA asociado a ningún objeto
// (para empezar ni se le puede pegar a nada -_-, ya que no hereda de MonoBehaviour :p)

// Crea los grafos necesarios para distintos algoritmos.
// Breath First Search
// Dijkstra
// A*
// Minimum Spanning Tree

public class Graph2D
{
    public Transform graphParent;
    public Vector2Int size;
    private GameObject nodePrefab;

    public List<GameObject> nodes = new List<GameObject>();
    public List<Vector2> nodePositions = new List<Vector2>();

    public Dictionary<Vector2, int> nodeKind = new Dictionary<Vector2, int>();
    public Dictionary<Vector2Int, int> edgeCost = new Dictionary<Vector2Int, int>();

    public Graph2D(Transform graphParent, Vector2Int size, GameObject nodePrefab)
    {
        this.size = size;
        this.nodePrefab = nodePrefab;
        this.graphParent = graphParent;
    }

    public Graph2D(Vector2Int size, GameObject nodePrefab)
    {
        this.size = size;
        this.nodePrefab = nodePrefab;
    }

    public Graph2D(Vector2Int size)
    {
        this.size = size;
    }

    public void ClearGraph()
    {
        nodes.Clear();
        nodePositions.Clear();
        nodeKind.Clear();
        edgeCost.Clear();
    }

    // Funciones para crear grafos

    public void CreateSimpleGraph(bool hasObstacles)
    {
        

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Vector2 newNodePosition = new Vector2(i, j);
                GameObject newNode = MonoBehaviour.Instantiate(nodePrefab, graphParent);
                newNode.transform.localPosition = newNodePosition;
                nodes.Add(newNode);
                nodePositions.Add(newNodePosition);

                // El número 50 controla la probabilidad de que se genere un obstaculo
                bool createObstacle = Random.Range(1, 101) < 50;

                if (hasObstacles && createObstacle)
                {
                    nodes.Remove(newNode);
                    nodePositions.Remove(newNodePosition);
                    MonoBehaviour.Destroy(newNode);
                }

            }
        }
    }

    public void CreateCostGraph()
    {
        Color sandColor = new Color(0.78f, 0.70f, 0.37f);
        Color greenColor = new Color(0f, 0.45f, 0.08f);


        for (int i = 0; i < size.x; i++)
            for (int j = 0; j < size.y; j++)
            {
                Vector2 newNodePosition = new Vector2(i, j);
                GameObject newNode = MonoBehaviour.Instantiate(nodePrefab, graphParent);
                newNode.transform.localPosition = newNodePosition;
                nodePositions.Add(newNodePosition);

                // El número 50 controla la probabilidad de que se genere
                // un nodo de tipo I o tipo II
                bool nodeKind_toss = Random.Range(1, 101) < 50;
                if (nodeKind_toss)
                {
                    nodeKind.Add(newNodePosition, 1);
                    newNode.GetComponent<SpriteRenderer>().color = sandColor;
                }
                else
                {
                    nodeKind.Add(newNodePosition, 2);
                    newNode.GetComponent<SpriteRenderer>().color = greenColor;
                }

            }
    }

    // El grafo que emplea el MST!
    public void CreateRandomCostGraph()
    {
        // Crea los nodos
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Vector2 newNodePosition = new Vector2(i, j);
                //GameObject newNode = MonoBehaviour.Instantiate(nodePrefab, graphParent);
                //newNode.transform.localPosition = newNodePosition;
                nodePositions.Add(newNodePosition);
            }
        }

        // Define los costos entre vecinos

        for (int i = 0; i < nodePositions.Count; i++)
        {
            for (int j = 0; j < nodePositions.Count; j++)
            {
                Vector2Int nodePair1 = new Vector2Int(i, j);
                Vector2Int nodePair2 = new Vector2Int(j, i);

                bool cond0 = (i != j);
                bool cond1 = AreNeighbours(i, j);
                bool cond2 = !edgeCost.ContainsKey(nodePair1);
                bool cond3 = !edgeCost.ContainsKey(nodePair2);

                if (cond0 && cond1 && cond2 && cond3)
                {
                    int cost = Random.Range(0, 101);
                    edgeCost.Add(nodePair1, cost);
                    edgeCost.Add(nodePair2, cost);
                }
            }
        }

    }

    // Funciones para obtener los vecinos
    public List<Vector2> NearNeighboursPositions(Vector2 nodePosition)
    {
        List<Vector2> directions = new List<Vector2> {Vector2.right,
                                                      Vector2.up,
                                                      Vector2.left,
                                                      Vector2.down };

        List<Vector2> list = new List<Vector2>();

        foreach (Vector2 direction in directions)
        {
            Vector2 neighbourPosition = nodePosition + direction;
            if (nodePositions.Contains(neighbourPosition))
                list.Add(neighbourPosition);
        }

        return list;
    }

    public bool AreNeighbours(int i, int j)
    {
        Vector2 node1 = nodePositions[i];
        Vector2 node2 = nodePositions[j];

        List<Vector2> neighbours = NearNeighboursPositions(node1);

        if (neighbours.Contains(node2))
            return true;

        else
            return false;
    }

    // Funciones especificas de algún algoritmo
    public List<Vector2> GraphWithout(Vector2 u)
    {
        List<Vector2> result = new List<Vector2>();
        foreach (Vector2 v in nodePositions)
        {
            if (v != u)
                result.Add(v);
        }
        return result;
    }
}
