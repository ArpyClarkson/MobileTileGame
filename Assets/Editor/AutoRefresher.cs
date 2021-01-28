using System.IO;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class AutoRefresher {
    static FileSystemWatcher watcher;
	static bool shouldRefresh = false;

	static AutoRefresher() {
		watcher = new FileSystemWatcher(Application.dataPath);	
		watcher.NotifyFilter = NotifyFilters.LastWrite| NotifyFilters.FileName;
		watcher.IncludeSubdirectories = true;
		watcher.EnableRaisingEvents = true;

		EditorApplication.update += () => {
			if(shouldRefresh) {
				shouldRefresh = false;
				AssetDatabase.Refresh();

				foreach(var window in Resources.FindObjectsOfTypeAll<EditorWindow>())
					window.Repaint();
			}
		};
		
		watcher.Changed += (s, e) => shouldRefresh = true;
	}
}
