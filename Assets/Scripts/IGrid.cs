﻿
public interface IGrid {
	int GridSizeX { get; }
	int GridSizeY { get; }
	int this[int x, int y] { get; }

	void Generate(int sizeX, int sizeY);
	Manifest Pop(int x, int y);
	void Undo();
	void Redo();
}
