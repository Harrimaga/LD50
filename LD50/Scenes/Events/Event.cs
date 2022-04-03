using LD50.UI;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD50.Scenes.Events
{
    public enum Events
    {
        AMBUSH = 0,
        FOODPILE = 1,
        FUELPILE = 2,
        TRADING = 3,
        BLUEPRINTTRADING = 4,
        PERSON = 5,
        last
    }

    public class Event : Scene
    {
        private Sprite _background;

        protected Button exitEventButton;

        public Event(Vector2 playerStartPosition, Sprite background) : base(Vector2.Zero)
        {
            Globals.player.Position = playerStartPosition;
            gameObjects.Add(Globals.player);
            _background = background;

            exitEventButton = new Button(Globals.buttonFillColour, Globals.buttonBorderColour, new Vector2(Globals.windowSize.X - 220, 140), Globals.buttonSizeMedium, Globals.buttonBorderMedium, Graphics.DrawLayer.UI, true);
            exitEventButton.SetText("Exit", TextAlignment.CENTER, new Vector4(0, 0, 0, 1));
            exitEventButton.OnClickAction = () => { Globals.currentScene = (int)Scenes.DRIVING; OnExit(); };

            uiElements.Add(exitEventButton);
        }

        public virtual void OnExit()
        {
            Globals.hud.ToggleButtons();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            _background.Draw();
            base.Draw();
        }

        public static Scene GetRandomEvent()
        {
            return (Events)Globals.rng.Next((int)Events.last) switch
            {
                Events.AMBUSH => new Ambush(false),
                Events.FOODPILE => new FoodPile(),
                Events.FUELPILE => new FuelPile(),
                Events.TRADING => new TradeEvent(),
                Events.BLUEPRINTTRADING => new BlueprintTradeEvent(),
                Events.PERSON => new PersonEvent(),
                _ => null,
            };
        }
    }
}
