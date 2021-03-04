using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dan's implementation no touchy
public class GameState : IGrid {
	public Vector2Int Size { protected set; get; }
	public int Score { protected set; get; }
	public bool IsGameOver { protected set; get; }
	public int this[int x, int y] { get => grid[x, y]; }

	protected int[,] grid;

	public virtual void Generate(int sizeX, int sizeY) {
		Size = new Vector2Int(sizeX, sizeY);
		Score = 0;
		grid = new int[Size.x, Size.y];

		Random.InitState(System.Environment.TickCount);

		for(int x = 0; x < Size.x; x++) {
			for(int y = 0; y < Size.y; y++) {
				grid[x, y] = Random.Range(1, 5);
			}
		}
	}

	protected bool IsWithinBounds(int x, int y) => (x > -1) && (x < Size.x) && (y > -1) && (y < Size.y);
	protected bool IsMatching(int x, int y, int m) => IsWithinBounds(x, y) && grid[x, y] == m;

	void Remove(int x, int y, int match, List<Vector2Int> removals) {
		if(!IsMatching(x, y, match))
			return;

		grid[x, y] = 0;
		removals.Add(new Vector2Int(x, y));

		Remove(x+1, y, match, removals);
		Remove(x-1, y, match, removals);
		Remove(x, y+1, match, removals);
		Remove(x, y-1, match, removals);
	}

	void CollapseVertical(List<Manifest.Move> moves) {
		for (int x = 0; x < Size.x; x++) {
			for(int y = 0; y < Size.y-1; y++) {
				if(grid[x, y] != 0)
					continue;

				//Empty cell found, look above it for a tile
				for(int y2 = y+1; y2 < Size.y; y2++) {
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
		int midX = Size.x / 2;
		for(int x = 1; x < Size.x-1; x++) {
			int sourceX = (x < midX ? midX-x-1 : x+1);
			int dir = (x < midX ? 1 : -1);

			//Skip if source column is empty
			if(grid[sourceX, 0] == 0)
				continue;

			int destX = sourceX;
			while(grid[destX + dir, 0] == 0)
				destX += dir;

			//Skip if we didn't find an empty column
			if(destX == sourceX)
				continue;

			//Copy over neighboring outer column, exiting early if we run into an empty
			for(int y = 0; y < Size.y && grid[sourceX, y] != 0; y++) {
				grid[destX, y] = grid[sourceX, y];
				grid[sourceX, y] = 0;
				moves.Add(new Manifest.Move{ start = { x = sourceX, y = y }, end = { x = destX, y = y } });
			}
		}
	}

	public virtual Manifest Pop(int x, int y) {
		if(!IsWithinBounds(x, y))
			return null;

		var m = grid[x, y];
		if(!IsMatching(x+1, y, m) && !IsMatching(x-1, y, m) && !IsMatching(x, y+1, m) && !IsMatching(x, y-1, m))
			return null;

		var manifest = new Manifest();
		Remove(x, y, m, manifest.removals);
		Score += manifest.removals.Count*manifest.removals.Count;

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