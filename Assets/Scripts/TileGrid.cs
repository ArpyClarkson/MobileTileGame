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

    // Initialize empty tilegrid
    public void Initialize( int[,] _grid ) {
        for ( int y = 0; y < _grid.GetLength( 1 ); y++ ) {
            for ( int x = 0; x < _grid.GetLength( 0 ); x++ ) {
                _grid[x, y] = -1;
            }
        }
    }

    // Pop a given tile
    public bool Pop( int _x, int _y ) {
        if ( !( _x < grid.GetLength( 0 ) && _x >= 0 && _y < grid.GetLength( 1 ) && _y >= 0 ) )
            return false;

        // Check if tile is empty
        // Pop tile
        // Recursive check next tile; stop if end of array
        // If next tile exists, push it to bottom
        // Index
        return true;
    }
}
