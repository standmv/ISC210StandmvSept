﻿using System;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Entities
{
    public class Tile : BaseGameObject
    {
        
        public Tile(GameObject prefab, string uniqueObjectName, float posX, float posY) : base( prefab, uniqueObjectName, posX, posY)
        {
        }
    }
}
