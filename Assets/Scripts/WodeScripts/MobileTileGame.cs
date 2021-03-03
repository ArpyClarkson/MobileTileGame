using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileTileGame : MonoBehaviour, IPointerDownHandler {
	IGrid grid;
	float[] buf;

	void Start() {
		Application.targetFrameRate = 30;

        //grid = new GameState();
		grid = new TileGrid();
		grid.Generate(9, 13);
		buf = new float[grid.GridSizeX*grid.GridSizeY];

		//var gr = gameObject.GetComponent<GridRenderer>();
	}

	void Update() {

		for (int x = 0; x < grid.GridSizeX; x++) {
			for (int y = 0; y < grid.GridSizeY; y++) {
				buf[x + grid.GridSizeX*y] = grid[x, y];
			}
		}

		Shader.SetGlobalFloatArray("_grid", buf);

		if(Input.GetMouseButtonDown(0)) {
			
		}

	}

	public void OnPointerDown(PointerEventData eventData) {
		Debug.Log("yayay onpointerdown yayayay");
	}
}
