using System.Collections;
using System.Collections.Generic;

//Dan's implementation no touchy
public class GameState : IGrid {
	public int GridSizeX { protected set; get; }
	public int GridSizeY { protected set; get; }
	public int score { protected set; get; }

	protected int[,] grid;

	public virtual void Generate(int GridSizeX, int GridSizeY) {
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

	public virtual bool Pop(int x, int y) {
		//Remove connected matching tiles
		
		//Collapse vertical

		//Collapse horizontal

		return false;
	}

	public virtual void Undo() {

	}

	public virtual void Redo() {

	}

}