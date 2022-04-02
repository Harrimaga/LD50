﻿using OpenTK.Mathematics;
using System;

namespace LD50.Logic.Rooms
{
    public class FuelTank : Room
    {
        public int Capacity { get; private set; }
        public int StoredAmount { get; private set; }
        public FuelTank(Vector2 onCarPosition, int capacity) : base(new Sprite(TexName.PIXEL, Vector2.Zero, new Vector2(300, 150), Graphics.DrawLayer.ROOMS, false), onCarPosition)
        {
            Capacity = capacity;
            _sprite.SetColour(new Vector4(1, 0, 0, 1));
        }

        /// <summary>
        /// Adds fuel to the tank.
        /// </summary>
        /// <returns>The amount of fuel that didn't fit.</returns>
        public int AddFuel(int amount)
        {
            var fuelLeft = Math.Max(StoredAmount + amount - Capacity, 0);
            StoredAmount = Math.Min(StoredAmount + amount, Capacity);

            return fuelLeft;
        }
    }
}