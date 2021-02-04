using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Should TileGrid use an int array or an array of Tile objects?
 */

public class TileGrid {
    private int[,] grid;

    public TileGrid( int _gridSizeX, int _gridSizeY ) {
        grid = new int[_gridSizeX, _gridSizeY];

        Initialize( grid );
    }

    // Set tilegrid as -1; null tile value
    public void Initialize( int[,] _grid ) {
        for ( int y = 0; y < _grid.GetLength( 1 ); y++ ) {
            for ( int x = 0; x < _grid.GetLength( 0 ); x++ ) {
                _grid[x, y] = -1;
            }
        }
    }
}
