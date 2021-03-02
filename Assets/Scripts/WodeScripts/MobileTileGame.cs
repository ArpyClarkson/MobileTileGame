using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileTileGame : MonoBehaviour, IPointerDownHandler {
	IGrid grid;

    void Start() {
        //grid = new GameState();
		grid = new TileGrid();
    }

    void Update() {

		if(Input.GetMouseButtonDown(0)) {
			grid.Generate(9, 13);
		}
        
    }

	public void OnPointerDown(PointerEventData eventData) {
		Debug.Log("yayay onpointerdown yayayay");
	}
}
