using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileTileGame : MonoBehaviour, IPointerDownHandler {
	IGrid grid;
	float[] buf;

	void Start() {
        //grid = new GameState();
		grid = new TileGrid();
		grid.Generate(9, 13);
		buf = new float[9*13];

		var gr = gameObject.AddComponent<GridRenderer>();
	}

    void Update() {

		if(Input.GetMouseButtonDown(0)) {
			
		}

	}

	public void OnPointerDown(PointerEventData eventData) {
		Debug.Log("yayay onpointerdown yayayay");
	}
}
