using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GridManager will manage the data representation of the tile grid, as well as
 * all data modification to the grid, and any logic related to updating the grid
 */

public class GridManager : MonoBehaviour {
    public const int GridSizeX = 9;
    public const int GridSizeY = 13;

    TileGrid tg;

    // Start is called before the first frame update
    void Start() {
       // tg = new TileGrid( GridSizeX, GridSizeY );

        
    }

    // Update is called once per frame
    void Update() {

    }
}
