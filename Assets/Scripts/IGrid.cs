
public interface IGrid {
	void Generate();
	bool Pop(int x, int y);
	void Undo();
	void Redo();
}
