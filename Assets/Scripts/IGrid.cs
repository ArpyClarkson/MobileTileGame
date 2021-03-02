
public interface IGrid {
	void Generate(int sizeX, int sizeY);
	bool Pop(int x, int y);
	void Undo();
	void Redo();
}
