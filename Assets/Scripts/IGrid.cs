
public interface IGrid {
	void Generate(int sizeX, int sizeY);
	bool Pop(int x, int y);
	void Undo();
	void Redo();

	int this[int x, int y] { get; }
	void CopyGrid(System.Array dest);
}
