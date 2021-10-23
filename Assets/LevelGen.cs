using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public float tile_width = 1.2f;
    public float tile_length = 1.2f;
    public float angle = 45f;
    int level_size = 10;
    [SerializeField]private List<GameObject> grass_tiles = new List<GameObject>();

    public List<GameObject> GetGrassTiles() { return grass_tiles; }

    private List<Tile> tiles = new List<Tile>();

    // Start is called before the first frame update
    void Start()
    {
        BuildLevel();
    }
    bool build = true;
    int u = 0;
    // Update is called once per frame
    void Update()
    {
       

                


    }
    private void FixedUpdate()
    {
        //if (u > 4)
        //{
        //    if (build)
        //    {
        //        BuildLevel();
        //    }
        //    else
        //    {
        //        ClearLevel();
        //    }
        //    u = 0;
        //}

        //build = !build;
        //u++;

    }

    private void BuildLevel()
    {
        Vector3 up = Quaternion.AngleAxis(66.6f, Vector3.forward) * Vector3.up;//66
        Vector3 right = Quaternion.AngleAxis(33.3f, Vector3.forward) * Vector3.right;//28

        for(int y = 0; y < level_size; y++)
        {
            for(int x = 0; x < level_size; x++)
            {
                int tile_index = Random.Range(0, grass_tiles.Count);
                if(grass_tiles.Count > 0)
                {
                    GameObject t = Instantiate(grass_tiles[tile_index], up * y * tile_length + right * x * tile_width, Quaternion.identity);
                    if (t.GetComponent<Tile>() != null)
                    {
                        Tile tile = t.GetComponent<Tile>();
                        tiles.Add(tile);
                    }
                }
            }
        }


    }


    public void CheckTileNeighbours(Vector2Int tile_grid_pos)
    {
        CheckTileNeighbours(FindTile(tile_grid_pos));
    }
    public void CheckTileNeighbours(Tile tile)
    {
        if(FindTile(tile.grid_pos + new Vector2Int(0, 1)).is_grass)
        {
            tile.north_wall = true;
        }
        if(FindTile(tile.grid_pos + new Vector2Int(1, 0)).is_grass)
        {
            tile.east_wall = true;
        }

        tile.UpdateTileSprite();

    }

    public Tile FindTile(Vector2Int grid_pos)
    {
        return tiles[grid_pos.x + grid_pos.y *  level_size];
    }



    private void ClearLevel()
    {
        foreach(var t in tiles)
        {
            Destroy(t.gameObject);
        }
        tiles.Clear();
    }
}


