﻿
using OpenTK.Mathematics;
using LD50.UI;
namespace LD50.Scenes.Events
{
    class PersonEvent : Scene
    {
        private readonly int _fuel;
        private readonly int _food;
        private readonly int _fontSize = 20;
        

        public PersonEvent() : base(Vector2.Zero)
        {
            _fuel = Globals.rng.Next(1, Balance.maxFuelOnPerson);
            _food = Globals.rng.Next(1, Balance.maxFoodOnPerson);

            string resources = $"{_fuel} Fuel and {_food} Food";

            Vector4 textColour = new Vector4(.5f, .5f, 0, .5f);
            
            uiElements.Add(new Resources());
            uiElements.Add(new Label($"You see a person on the side of the road", TextAlignment.CENTER, textColour, new Vector2(Globals.ScreenResolutionX/2, 300), _fontSize, true));
            uiElements.Add(new Label($"They carry {resources} with them", TextAlignment.CENTER, textColour, new Vector2(Globals.ScreenResolutionX / 2, 350), _fontSize, true));
            uiElements.Add(new Label($"and will happily share if you give them a ride.", TextAlignment.CENTER, textColour, new Vector2(Globals.ScreenResolutionX / 2, 400), _fontSize, true));

            Button acceptButton = new Button(Globals.buttonFillColour, Globals.buttonBorderColour, new Vector2(Globals.ScreenResolutionX / 2 - 100, 450), Globals.buttonSizeSmall, Globals.buttonBorderSmall, Graphics.DrawLayer.UI, true);
            acceptButton.SetText("Accept", TextAlignment.CENTER, new Vector4(0, 0, 0, 1), 12);
            acceptButton.OnClickAction = () => Accept();
            uiElements.Add(acceptButton);

            Button rejectButton = new Button(Globals.buttonFillColour, Globals.buttonBorderColour, new Vector2(Globals.ScreenResolutionX / 2 + 100, 450), Globals.buttonSizeSmall, Globals.buttonBorderSmall, Graphics.DrawLayer.UI, true);
            rejectButton.SetText("Reject", TextAlignment.CENTER, new Vector4(0, 0, 0, 1), 12);
            rejectButton.OnClickAction = () => Reject();
            uiElements.Add(rejectButton);
        }

        void Accept()
        { 
                    
        }

        void Reject()
        {

        }



    }
}
