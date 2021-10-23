using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int grid_pos = new Vector2Int();
    public bool is_grass = true;

    public bool north_wall = false;
    public bool east_wall = false;

    [SerializeField] private Sprite floor;
    [SerializeField] private Sprite floor_n;
    [SerializeField] private Sprite floor_e;
    [SerializeField] private Sprite floor_ne;

    public void UpdateTileSprite()
    {
        if(north_wall && east_wall)
        {
            GetComponent<SpriteRenderer>().sprite = floor_ne;
        }
        else if(north_wall)
        {
            GetComponent<SpriteRenderer>().sprite = floor_n;
        }
        else if(east_wall)
        {
            GetComponent<SpriteRenderer>().sprite = floor_e;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = floor;
        }
    }

}
