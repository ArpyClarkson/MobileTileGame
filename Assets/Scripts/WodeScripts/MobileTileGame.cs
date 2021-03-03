using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileTileGame : MonoBehaviour, IPointerDownHandler {
	IGrid grid;
	float[] buf;

	void OnEnable() {
		Application.targetFrameRate = 30;

        //grid = new GameState();
		grid = new TileGrid();
		grid.Generate(9, 13);
		buf = new float[grid.GridSizeX*grid.GridSizeY];

		var gridImage = FindObjectOfType<RawImage>();
		var trigger = gridImage.gameObject.AddComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerClick;
		entry.callback.AddListener((data) => {
			Debug.Log((data as PointerEventData ).position / gridImage.rectTransform.rect.size);
		});
		trigger.triggers.Add(entry);

		//var gr = gameObject.GetComponent<GridRenderer>();
	}

	void Update() {
		if(grid == null)
			return;

		for (int x = 0; x < grid.GridSizeX; x++) {
			for (int y = 0; y < grid.GridSizeY; y++) {
				buf[x + grid.GridSizeX*y] = grid[x, y];
			}
		}

		Shader.SetGlobalVector("gridSize", new Vector4(grid.GridSizeX, grid.GridSizeY));
		Shader.SetGlobalFloatArray("grid", buf);
	}

	void OnDisable() {

	}

	public void OnPointerDown(PointerEventData eventData) {

		//Debug.Log(eventData.position);
	}
}
