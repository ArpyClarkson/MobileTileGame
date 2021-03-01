using System.Collections;
using System.Collections.Generic;

//Dan's implementation no touchy
public class GameState {
	public const int GridSizeX = 9;
	public const int GridSizeY = 13;

	int[,] grid = new int[GridSizeX, GridSizeY];
	int score = 0;

	public GameState() {
		
		for(int x = 0; x < GridSizeX; x++) {
			for(int y = 0; y < GridSizeY; y++) {
				grid[x, y] = 0;
			}
		}

	}

	public void Generate() {

	}

	public void Select(int x, int y) {
		//Remove connected matching tiles
		
		//Collapse vertical

		//Collapse horizontal
	}

	public void Undo() {

	}

	public void Redo() {

	}

}