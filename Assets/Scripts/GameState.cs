using System.Collections;
using System.Collections.Generic;

public class GameState {
	int[,] grid = new int[13,13];

	public GameState() {
		for(int x = 0; x < 13; x++) {
			for(int y = 0; y < 13; y++) {
				grid[x, y] = 0;
			}
		}
	}


}