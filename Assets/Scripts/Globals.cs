public readonly struct Globals
{
    // gameplay globals
    public const int ShipCollisionDamage = 90;
    public const int HitScore = 100;
    public const int BackgroundZOrder = 2;

    public enum Screens
    {
        Menu,
        Options,
        HighScore,
        GameOver,
        HighScoreInput
    }

    public readonly struct Scenes
    {
        public const string MainMenu = "MainMenu";
        public const string Sandbox = "Sandbox";
    }
}