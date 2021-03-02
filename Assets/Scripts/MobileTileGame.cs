using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileTileGame : MonoBehaviour, IPointerDownHandler {
	IGrid grid;

    void Start() {
        grid = new GameState();
		//grid = new TileGrid(9, 13);
    }

    void Update() {

		if(Input.GetMouseButtonDown(0)) {
			grid.Generate();
		}
        
    }

	public void OnPointerDown(PointerEventData eventData) {
		Debug.Log("yayay onpointerdown yayayay");
	}
}
