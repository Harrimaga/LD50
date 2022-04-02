﻿using System;
using System.Collections.Generic;
using System.Text;
using LD50.IO;
using LD50.Scenes.Events;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace LD50.Logic
{
    public class Player : GameObject
    {

        public Car car;
        private Person _person;
        private Hotkey _hkUp, _hkDown, _hkLeft, _hkRight;

        public Vector2 CarPosition { get { return car.Position; } }
        public Vector2 Size { get { return _person.Size; } }
        public override Vector2 Position { get { return _person.Position; } set { _person.Position = value; } }

        public Player()
        {
            car = new Car(new Vector2(1300, 925), new Vector2(800, 200));
            _person = new Person(TexName.PLAYER_IDLE, Balance.playerHealth);

            _hkUp = new Hotkey(true).AddKeys(Keys.W, Keys.Up);
            _hkDown = new Hotkey(true).AddKeys(Keys.S, Keys.Down);
            _hkLeft = new Hotkey(true).AddKeys(Keys.A, Keys.Left);
            _hkRight = new Hotkey(true).AddKeys(Keys.D, Keys.Right);
        }

        public void Attack(Vector2 direction)
        {
            _person.Attack(direction);
        }

        public override void Draw()
        {
            if (Globals.CurrentScene is Event)
            {
                _person.Draw();
            }
            else
            {
                car.Draw();
            }
        }

        public override bool Update()
        {
            if (Globals.CurrentScene is Event)
            {
                if (_hkUp.IsPressed())
                {
                    _person.Move(new Vector2(0, -(float)(Balance.playerMovementSpeed * Globals.deltaTime)));
                }
                if (_hkDown.IsPressed())
                {
                    _person.Move(new Vector2(0, (float)(Balance.playerMovementSpeed * Globals.deltaTime)));
                }
                if (_hkLeft.IsPressed())
                {
                    _person.Move(new Vector2(-(float)(Balance.playerMovementSpeed * Globals.deltaTime), 0));
                }
                if (_hkRight.IsPressed())
                {
                    _person.Move(new Vector2((float)(Balance.playerMovementSpeed * Globals.deltaTime), 0));
                }
                _person.Update();
            }
            else
            {
                car.Update();
            }
            return true;
        }

    }
}
