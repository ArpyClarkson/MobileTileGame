using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class MobileTileGame : MonoBehaviour {
	IGrid grid;
	float[] buf;
	EventTrigger.TriggerEvent clickEvent;

	void OnEnable() {
		Application.targetFrameRate = 30;

        //grid = new GameState();
		grid = new TileGrid();
		grid.Generate(9, 13);
		buf = new float[grid.Size.x * grid.Size.y];

		var gridRect = (RectTransform)GameObject.Find("Grid").transform;
		gridRect.GetComponent<AspectRatioFitter>().aspectRatio = (float)grid.Size.x / grid.Size.y;
		clickEvent = gridRect.GetComponent<EventTrigger>().triggers.Find(x => x.eventID == EventTriggerType.PointerClick).callback;

		clickEvent.AddListener(data => {
			RectTransformUtility.ScreenPointToLocalPointInRectangle(
				gridRect, (data as PointerEventData).position, Camera.main, out Vector2 localPosition);

			var uv = (localPosition / gridRect.rect.size) + new Vector2(0.5f, 0.5f);
			var iTile = new Vector2Int((int)(uv.x * grid.Size.x), (int)(uv.y * grid.Size.y));

			grid.Pop(iTile.x, iTile.y);
			GameObject.Find("Score").GetComponent<Text>().text = grid.Score.ToString();

			//var gr = gameObject.GetComponent<GridRenderer>();
		});
	}

	void Update() {
		if(grid == null)
			return;

		for (int x = 0; x < grid.Size.x; x++) {
			for (int y = 0; y < grid.Size.y; y++) {
				buf[x + grid.Size.x * y] = grid[x, y];
			}
		}

		Shader.SetGlobalVector("gridSize", new Vector4(grid.Size.x, grid.Size.y));
		Shader.SetGlobalFloatArray("grid", buf);
	}

	void OnDisable() {
		clickEvent.RemoveAllListeners();
	}
}
