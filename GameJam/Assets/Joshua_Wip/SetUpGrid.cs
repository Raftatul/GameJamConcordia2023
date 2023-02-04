using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SetUpGrid : MonoBehaviour
{
    [Header("Board")]
    public int gridX;
    public int gridZ;
    public int size;

    [Header("Cells")]
    //[SerializeField]  Dictionary<GameObject, float> Cell = new Dictionary<GameObject, float>();
    public Vector2 Offset;

    public List<GameObject> Tiles = new List<GameObject>();
    public GameObject startingPoint;

    // The size of each cell in the grid
    public float cellSize = 1.0f;

    void Start()
    {
        size = gridX * gridZ;
        GridSpawn();
    }

    void GridSpawn()
    {

        int i = 0;
        // Loop through the grid in the X and Z dimensions
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                i++;
                // Create a cube primitive at the current grid cell
                GameObject tile = Instantiate(RandomCell());
                tile.GetComponent<Ressources>().GiveRandomSize();
                SetUpTiles(tile, z, -x);
            }
        }
    }


    void SetUpTiles(GameObject tile, int x, int z)
    {
        tile.transform.SetParent(startingPoint.transform);
        tile.transform.localScale = new Vector2(cellSize, cellSize);

        // Set the position of the cube to the current grid cell plus the offset in x z and between them
        tile.transform.position = new Vector2(
            (x * Offset.x) + startingPoint.transform.position.x + (tile.transform.localScale.x - startingPoint.transform.localScale.x) / 2,
            (z * Offset.y) + startingPoint.transform.position.y + startingPoint.transform.localScale.y - (tile.transform.localScale.y + startingPoint.transform.localScale.y) / 2
            );
        //(z * Offset.z) + startingPoint.transform.position.z + +startingPoint.transform.localScale.x + (tile.transform.localScale.z - startingPoint.transform.localScale.z) / 2*/
    }


    GameObject RandomCell()
    {
        float f = Random.Range(0, Tiles.Count);
        GameObject tile = Tiles[(int)f];
        return tile;
    }

    #region weighted drop
    //    float RandomObject = Random.Range(1, 101);

    //    List<GameObject> drop = new();

    //        foreach (var item in Tiles)
    //        {
    //            float itemDrop = item.GetComponent<Ressources>().Weight;
    //            if (RandomObject <= itemDrop)
    //            {
    //                drop.Add(item);
    //            }
    //        }

    //        if (drop.Count >= 1)
    //{
    //    float f = Random.Range(0, drop.Count + 1);
    //    GameObject tile = Tiles[(int)f];
    //    return tile;
    //}
    //return null;
    #endregion
}
