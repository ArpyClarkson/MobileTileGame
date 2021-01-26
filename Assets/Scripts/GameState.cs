using System.Collections;
using System.Collections.Generic;

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


}