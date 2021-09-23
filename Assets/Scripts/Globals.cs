public static class Globals
{
	public static float Gravity = 200f;

	public static int GetSceneIndex(Scenes scene) => (int) scene;

	public enum Scenes
	{
		Preload = 0,
		GameScreen = 1,
		EndScreen = 2,
	}
}
