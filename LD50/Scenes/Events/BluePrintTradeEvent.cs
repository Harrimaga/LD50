﻿using LD50.Logic.Blueprints;
using LD50.Logic.Rooms;
using LD50.UI;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD50.Scenes.Events
{
    public class BluePrintTradeEvent : Scene
    {

        private Blueprint _toTrade;
        private int _cost;
        private bool _costsFuel;
        private UIElements _blockingBackground = null;

        public BluePrintTradeEvent() : base(Vector2.Zero)
        {
            uiElements.Add(new Resources());

            int randNum = Globals.rng.Next(1);
            switch (randNum)
            {
                case 0:
                    _toTrade = new BaseGunBlueprint();
                    break;
                default:
                    _toTrade = new BaseGunBlueprint();
                    break;
            }
            uiElements.Add(_toTrade.GetLabel(new Vector2(5, 100)));
            uiElements.Add(new Label("Offering: ", TextAlignment.LEFT, new Vector4(1, 1, 1, 1), new Vector2(5, 50), 25, true, Graphics.DrawLayer.BACKGROUND));

            _cost = _toTrade.Cost;
            _costsFuel = Globals.rng.Next(2) == 0;

            uiElements.Add(new Label($"Costs {_cost} " + (_costsFuel ? "Fuel" : "Food"), TextAlignment.LEFT, new Vector4(1, 1, 1, 1), new Vector2(5, 275), 25, true, Graphics.DrawLayer.BACKGROUND));

            Button takeButton = new Button(new Vector4(0.8f, 0.8f, 0.8f, 1), new Vector4(0.5f, 0.5f, 0.5f, 1), new Vector2(155, 350), new Vector2(300, 100), 10, Graphics.DrawLayer.BACKGROUND, true);
            takeButton.SetText("Trade!", TextAlignment.CENTER, new Vector4(0, 0, 0, 1));
            takeButton.OnClickAction = () => Take();
            uiElements.Add(takeButton);

            Button moveOnButton = new Button(new Vector4(0.8f, 0.8f, 0.8f, 1), new Vector4(0.5f, 0.5f, 0.5f, 1), new Vector2(460, 350), new Vector2(300, 100), 10, Graphics.DrawLayer.BACKGROUND, true);
            moveOnButton.SetText("Move on", TextAlignment.CENTER, new Vector4(0, 0, 0, 1));
            moveOnButton.OnClickAction = () => MoveOn();
            uiElements.Add(moveOnButton);

            Button lookAtCarButton = new Button(new Vector4(0.8f, 0.8f, 0.8f, 1), new Vector4(0.5f, 0.5f, 0.5f, 1), new Vector2(1650, 200), new Vector2(300, 100), 10, Graphics.DrawLayer.BACKGROUND, true);
            lookAtCarButton.SetText("Look at car", TextAlignment.CENTER, new Vector4(0, 0, 0, 1));
            lookAtCarButton.OnClickAction = () => LookAtCar();
            uiElements.Add(lookAtCarButton);

        }

        private void Take()
        {
            if (_costsFuel)
            {
                if (Globals.player.car.TotalFuelStored >= _cost)
                {
                    MoveOn();
                    Globals.player.car.ConsumeFuel(_cost);
                    Globals.player.blueprints.Add(_toTrade);
                }
            }
            else
            {
                if (Globals.player.car.TotalFoodStored >= _cost)
                {
                    MoveOn();
                    Globals.player.car.ConsumeFood(_cost);
                    Globals.player.blueprints.Add(_toTrade);
                }
            }
        }

        private void MoveOn()
        {
            // TODO: this function
        }

        private void LookAtCar()
        {
            Rectangle blockingBackground = new Rectangle(new Vector4(0, 0, 0, 0.9f), new Vector2(960, 540), new Vector2(1920, 1080), true, TexName.PIXEL, Graphics.DrawLayer.BACKGROUND);

            Button backToTrade = new Button(new Vector4(0.8f, 0.8f, 0.8f, 1), new Vector4(0.5f, 0.5f, 0.5f, 1), new Vector2(1650, 200), new Vector2(300, 100), 10, Graphics.DrawLayer.UI, true);
            backToTrade.SetText("Back", TextAlignment.CENTER, new Vector4(0, 0, 0, 1));
            backToTrade.OnClickAction = () => BackToTrade();

            _blockingBackground = new UIElements();
            _blockingBackground.Add(blockingBackground);
            _blockingBackground.Add(backToTrade);

            uiElements.Add(_blockingBackground);
        }

        private void BackToTrade()
        {
            uiElements.Remove(_blockingBackground);
            _blockingBackground = null;
        }

        public override void Draw()
        {
            base.Draw();
            if (_blockingBackground != null)
            {
                Globals.player.car.Draw();
            }
        }

    }
}
