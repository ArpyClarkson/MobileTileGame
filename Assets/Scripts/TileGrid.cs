﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Should TileGrid use an int array or an array of Tile objects?
 */

public class TileGrid : GameState {

    protected override bool CheckGameOver() {

        // Create list of remaining tiles
        // -- If no tiles, game over
        // -- If tiles check for any adjacent
        // -- -- If no adjacent, game over
        // -- -- If adjacent game not over

        List<Vector2Int> tiles = new List<Vector2Int>();
        bool gameover = false;

        for ( int x = 0; x < Size.x; x++ ) {
            for ( int y = 0; y < Size.y; y++ ) {
                if ( grid[x, y] != 0 ) {
                    tiles.Add( new Vector2Int( x, y ) );
                }
            }
        }

        if ( tiles.Count == 0 )
            gameover = true;
        else
            foreach ( Vector2Int t in tiles ) {
                int tt = grid[t.x, t.y];
                bool x1 = CheckTile( t.x - 1, t.y, tt );
                bool x2 = CheckTile( t.x + 1, t.y, tt );
                bool y1 = CheckTile( t.x, t.y - 1, tt );
                bool y2 = CheckTile( t.x, t.y + 1, tt );

                //shorter alternative ^.^
                //gameover = !(x1 || x2 || y1 || y2);
                if ( x1 == true || x2 == true || y1 == true || y2 == true )
                    gameover = false;
                else
                    gameover = true;
            }

        return gameover;
    }

    bool CheckTile( int _x, int _y, int _t ) {
        if ( _x >= 0 && _x < Size.x && _y >= 0 && _y < Size.y) {
            return grid[_x, _y] == _t;
        } else {
            return false;
        }
    }

}
