using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manifest {
	public List<Vector2Int> removals = new List<Vector2Int>();
	public List<Move> verticalMoves = new List<Move>();
	public List<Move> horizontalMoves = new List<Move>();

	public struct Move {
		public Vector2Int start, end;
	}
}
