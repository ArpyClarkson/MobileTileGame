using UnityEngine;

public interface IGrid {
	Vector2Int Size { get; }
	int Score { get; }
	int this[int x, int y] { get; }

	void Generate(int sizeX, int sizeY);
	Manifest Pop(int x, int y);
	void Undo();
	void Redo();
}
