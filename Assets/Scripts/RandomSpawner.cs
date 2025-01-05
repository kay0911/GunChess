using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; // Th? vi?n A* Pathfinding

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // M?ng ch?a c�c Prefab qu�i
    public GameObject warningPrefab; // Prefab d?u X ??
    public int enemiesPerWave = 3; // S? l??ng qu�i spawn m?i ??t
    public float spawnInterval = 5f; // Th?i gian gi?a c�c l?n spawn
    public float warningDuration = 2f; // Th?i gian hi?n d?u X ?? tr??c khi qu�i xu?t hi?n

    private GridGraph gridGraph;

    private void Start()
    {
        // L?y tham chi?u ??n GridGraph
        gridGraph = AstarPath.active.data.gridGraph;

        // B?t ??u spawn qu�i
        InvokeRepeating(nameof(SpawnEnemies), 2f, spawnInterval);
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            // L?y v? tr� ng?u nhi�n tr�n b?n ??
            Vector3 randomPosition = GetRandomPositionOnMap();

            // Hi?n d?u X ?? v� spawn qu�i sau 2 gi�y
            StartCoroutine(ShowWarningAndSpawn(randomPosition));
        }
    }

    private IEnumerator ShowWarningAndSpawn(Vector3 position)
    {
        // Hi?n d?u X ??
        GameObject warning = Instantiate(warningPrefab, position, Quaternion.identity);

        // ??i trong 2 gi�y
        yield return new WaitForSeconds(warningDuration);

        // Ch?n ng?u nhi�n lo?i qu�i
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);

        // Spawn qu�i t?i v? tr�
        Instantiate(enemyPrefabs[randomEnemyIndex], position, Quaternion.identity);

        // X�a d?u X ??
        Destroy(warning);
    }

    private Vector3 GetRandomPositionOnMap()
    {
        // Danh s�ch c�c node kh? d?ng (walkable)
        var walkableNodes = new List<GraphNode>();

        // Duy?t qua t?t c? c�c node trong GridGraph
        for (int x = 0; x < gridGraph.width; x++)
        {
            for (int z = 0; z < gridGraph.depth; z++)
            {
                var node = gridGraph.GetNode(x, z);

                // Ki?m tra n?u node l� walkable
                if (node.Walkable)
                {
                    walkableNodes.Add(node);
                }
            }
        }

        // Ch?n ng?u nhi�n m?t node t? danh s�ch c�c node kh? d?ng
        if (walkableNodes.Count > 0)
        {
            var randomNode = walkableNodes[Random.Range(0, walkableNodes.Count)];

            // Chuy?n ??i node sang v? tr� trong th? gi?i
            return (Vector3)randomNode.position;
        }

        // N?u kh�ng c� node kh? d?ng, tr? v? v? tr� m?c ??nh (0, 0, 0)
        return Vector3.zero;
    }
}
