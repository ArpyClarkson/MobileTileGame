using System.Collections;
using System.Collections.Generic;

//Dan's implementation no touchy
public class GameState : IGrid {
	public int GridSizeX { protected set; get; }
	public int GridSizeY { protected set; get; }
	public int Score { protected set; get; }
	public bool IsGameOver { protected set; get; }

	protected int[,] grid;

	public virtual void Generate(int GridSizeX, int GridSizeY) {
		this.GridSizeX = GridSizeX;
		this.GridSizeY = GridSizeY;

		Score = 0;
		grid = new int[GridSizeX, GridSizeY];

		for(int x = 0; x < GridSizeX; x++) {
			for(int y = 0; y < GridSizeY; y++) {
				grid[x, y] = 0;
			}
		}
	}

	void Remove(int x, int y, int match) {
		if(grid[x, y] != match)
			return;

		grid[x, y] = 0;
		Remove(x+1, y, match);
		Remove(x-1, y, match);
		Remove(x, y+1, match);
		Remove(x, y-1, match);
	}

	void CollapseVertical() {
		for(int x = 0; x < GridSizeX; x++) {
			for(int y = 0; y < GridSizeY; y++) {
				if(grid[x, y] != 0)
					continue;

				for(int y2 = y+1; y2 < GridSizeY; y++) {
					if(grid[x, y2] == 0)
						continue;

					grid[x, y] = grid[x, y2];
					grid[x, y2] = 0;
					break;
				}
			}
		}
	}

	void CollapseHorizontal() {
		int midX = GridSizeX/2;
		for(int x = 0; x < GridSizeX; x++) {
			bool isColumnEmpty = true;
			int destX = x <= midX ? midX - x : x;
			int sourceX = x <= midX ? destX-1 : destX+1;

			for(int y = 0; y < GridSizeY; y++) {
				if(grid[destX, y] == 0)
					continue;

				isColumnEmpty = false;
				break;
			}

			if(!isColumnEmpty)
				continue;

			for(int y = 0; y < GridSizeY; y++) {
				grid[destX, y] = grid[sourceX, y];
			}
		}
	}

	public virtual bool Pop(int x, int y) {
		int g = grid[x, y];
		
		//Ensure at least 2 adjacent tiles match
		if((grid[x+1, y] != g) && (grid[x-1, y] != g) && (grid[x, y+1] != g) && (grid[x, y-1] != g))
			return false;

		Remove(x, y, g);
		CollapseVertical();
		CollapseHorizontal();
		IsGameOver = CheckGameOver();
		return true;
	}

	protected virtual bool CheckGameOver() {
		return true;
	}

	public virtual void Undo() {

	}

	public virtual void Redo() {

	}

}