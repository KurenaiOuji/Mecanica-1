using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Genera un laberinto de dimensiones dadas por mazeSize

public class MazeGenerator : MonoBehaviour
{
    public Vector2Int mazeSize;
    public GameObject wallPrefab;

    protected Graph2D graph2D;
    protected MinimumSpanningTree mst;

    void Start()
    {
        CreateMaze();
    }

    void CreateMaze()
    {
        CreateGraph();
        CreateMST();
        CreateMazeWalls();
        CreateMazeBorders();
        transform.Find("Maze").localRotation = Quaternion.Euler(90, 0, 0);
        transform.Find("Maze").localScale = new Vector3(1,1,0.75f);


    }
    void CreateGraph()
    {
        graph2D = new Graph2D(mazeSize);
        graph2D.CreateRandomCostGraph();
    }

    void CreateMST()
    {
        mst = new MinimumSpanningTree(graph2D);
        mst.InitAlgorithm();
        mst.MST_Algorithm();
    }

    void CreateMazeBorders()
    {
        Vector2Int size = graph2D.size;

        for (int i = 0; i < size.x; i++)
        {
            Vector2 posBottom = new Vector2(i, -0.5f);
            Vector2 posTop = new Vector2(i, size.y - 0.5f);
            GameObject bottom = Instantiate(wallPrefab, posBottom, Quaternion.identity, transform.Find("Maze"));
            GameObject top = Instantiate(wallPrefab, posTop, Quaternion.identity, transform.Find("Maze"));
            bottom.transform.localScale = new Vector3(1, 0.1f, 1);
            top.transform.localScale = new Vector3(1, 0.1f, 1);
        }
        for (int j = 0; j < size.y; j++)
        {
            Vector2 posLeft = new Vector2(-0.5f, j);
            Vector2 posRight = new Vector2(size.x - 0.5f, j);

            GameObject left = Instantiate(wallPrefab, posLeft, Quaternion.identity, this.transform.Find("Maze"));
            GameObject right = Instantiate(wallPrefab, posRight, Quaternion.identity, this.transform.Find("Maze"));

            left.transform.localScale = new Vector3(0.1f, 1, 1);
            right.transform.localScale = new Vector3(0.1f, 1, 1);

        }
    }

    void CreateMazeWalls()
    {

        for (int i = 0; i < graph2D.nodePositions.Count; i++)
            for (int j = 0; j < graph2D.nodePositions.Count; j++)
            {
                if (i != j && graph2D.AreNeighbours(i, j))
                {
                    Vector2Int pair1 = new Vector2Int(i, j);
                    Vector2Int pair2 = new Vector2Int(j, i);
                    if (!mst.T.Contains(pair1) && !mst.T.Contains(pair2))
                    {
                        Vector2 nodei = graph2D.nodePositions[i];
                        Vector2 nodej = graph2D.nodePositions[j];
                        Vector2 wallPos = 0.5f * (nodei + nodej);
                        GameObject wall = Instantiate(wallPrefab, wallPos, Quaternion.identity, transform.Find("Maze"));
                        Vector3 scaleVector = new Vector3(Mathf.Abs(nodei.x - nodej.x), Mathf.Abs(nodei.y - nodej.y), 0);
                        wall.transform.localScale = Vector3.one - 0.9f * scaleVector;
                    }
                }
            }
    }

}
