using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GridRenderer will handle all visual representations of the tile grid, and will
 * be updated by the GridManager when the tile grid has been updated.
 */

public class GridRenderer : MonoBehaviour {

    public GameObject tile;
    List<GameObject> tiles;

    // Start is called before the first frame update
    void Start() {
        tiles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void Render( IGrid grid, int sizeX, int sizeY ) {
        if ( tiles.Count != 0 ) {
            foreach (GameObject t in tiles) {
                Destroy( t );
            }
            tiles.Clear();
        }
            

        for ( int x = 0; x < sizeX; x++ ) {
            for ( int y = 0; y < sizeY; y++ ) {
                GameObject t = Instantiate( tile, new Vector3( x, y ), Quaternion.identity );
                tiles.Add( t );
            }
        }
    }
}
