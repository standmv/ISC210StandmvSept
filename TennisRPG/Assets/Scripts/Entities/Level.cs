using System;
using System.Collections.Generic;

namespace AssemblyCSharp.Assets.Scripts.Entities
{
    public class Level : BaseGameObject
    {
        public List<Character> Characters;
        public List<Item> Items;
        public Map Map;
        public Level()
        {
        }
    }
}
