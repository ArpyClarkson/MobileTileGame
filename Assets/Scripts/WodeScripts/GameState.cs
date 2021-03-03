using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dan's implementation no touchy
public class GameState : IGrid {
	public int GridSizeX { protected set; get; }
	public int GridSizeY { protected set; get; }
	public int Score { protected set; get; }
	public bool IsGameOver { protected set; get; }
	public int this[int x, int y] { get => grid[x, y]; }

	protected int[,] grid;

	public virtual void Generate(int GridSizeX, int GridSizeY) {
		this.GridSizeX = GridSizeX;
		this.GridSizeY = GridSizeY;

		Score = 0;
		grid = new int[GridSizeX, GridSizeY];
		
		Random.InitState((int)Time.realtimeSinceStartup*0xBEEF);

		for(int x = 0; x < GridSizeX; x++) {
			for(int y = 0; y < GridSizeY; y++) {
				grid[x, y] = Random.Range(1, 5);
			}
		}
	}

	protected bool IsWithinBounds(int x, int y) => (x > 0) && (x < GridSizeX) && (y > 0) && (y < GridSizeY);

	void Remove(int x, int y, int match, List<Manifest.Position> removals) {
		if(!IsWithinBounds(x, y))
			return;

		if(grid[x, y] != match)
			return;

		grid[x, y] = 0;
		removals.Add(new Manifest.Position{ x = x, y = y });

		Remove(x+1, y, match, removals);
		Remove(x-1, y, match, removals);
		Remove(x, y+1, match, removals);
		Remove(x, y-1, match, removals);
	}

	void CollapseVertical(List<Manifest.Move> moves) {
		for (int x = 0; x < GridSizeX; x++) {
			for(int y = 0; y < GridSizeY; y++) {
				if(grid[x, y] != 0)
					continue;

				for(int y2 = y+1; y2 < GridSizeY; y++) {
					if(grid[x, y2] == 0)
						continue;

					grid[x, y] = grid[x, y2];
					grid[x, y2] = 0;
					moves.Add(new Manifest.Move { start = { x = x, y = y2 }, end = { x = x, y = y } });
					break;
				}
			}
		}
	}

	void CollapseHorizontal(List<Manifest.Move> moves) {
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
				grid[sourceX, y] = 0;
				moves.Add(new Manifest.Move{ start = { x = sourceX, y = y }, end = { x = destX, y = y } });
			}
		}
	}

	public virtual Manifest Pop(int x, int y) {
		int g = grid[x, y];
		
		//Ensure at least 2 adjacent tiles match
		if((grid[x+1, y] != g) && (grid[x-1, y] != g) && (grid[x, y+1] != g) && (grid[x, y-1] != g))
			return null;

		var manifest = new Manifest();

		Remove(x, y, g, manifest.removals);
		CollapseVertical(manifest.verticalMoves);
		CollapseHorizontal(manifest.horizontalMoves);
		IsGameOver = CheckGameOver();

		return manifest;
	}

	protected virtual bool CheckGameOver() {
		return true;
	}

	public virtual void Undo() {

	}

	public virtual void Redo() {

	}

}