using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manifest {
	public List<Position> removals = new List<Position>();
	public List<Move> verticalMoves = new List<Move>();
	public List<Move> horizontalMoves = new List<Move>();

	public struct Position {
		public int x, y;
	}

	public struct Move {
		public Position start, end;
	}
}
