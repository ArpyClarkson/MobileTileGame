﻿using System.Collections;
using System.Collections.Generic;

//Dan's implementation no touchy
public class GameState : IGrid {
	public int GridSizeX { private set; get; }
	public int GridSizeY { private set; get; }
	public int score { private set; get; }

	int[,] grid;

	public GameState(int GridSizeX, int GridSizeY) {
		this.GridSizeX = GridSizeX;
		this.GridSizeY = GridSizeY;

		score = 0;
		grid = new int[GridSizeX, GridSizeY];

		for(int x = 0; x < GridSizeX; x++) {
			for(int y = 0; y < GridSizeY; y++) {
				grid[x, y] = 0;
			}
		}

	}

	public void Generate() {

	}

	public bool Pop(int x, int y) {
		//Remove connected matching tiles
		
		//Collapse vertical

		//Collapse horizontal

		return false;
	}

	public void Undo() {

	}

	public void Redo() {

	}

}