using System;
namespace AssemblyCSharp.Assets.Scripts.Entities
{
    public static class Game
    {
        public static Level CurrentLevel;

        public static GameOptions Options
        {
            get
            {
                return GameOptions.Instance;
            }
        }
    }
}
