﻿using OpenTK.Mathematics;
using LD50.UI;
using OpenTK.Windowing.Common;

namespace LD50.Logic.Rooms
{
    public class Room : GameObject
    {
        public Vector2 OnCarPosition { get; set; }

        public string description;

        protected Label label;
        protected readonly int _fontSize = 16;

        public Room(Sprite sprite, Vector2 onCarPosition, string description) : base(sprite)
        {
            this.description = description;
            OnCarPosition = onCarPosition;
            label = new Label("", TextAlignment.LEFT, new Vector4(.5f, .5f, 0, .5f), new Vector2(0, 0), _fontSize, true);
        }

        public override void Draw()
        {
            var roomPosition = OnCarPosition * new Vector2(300, 150) + Globals.player.CarPosition - new Vector2(900, 480);

            _sprite.Position = roomPosition;
            _sprite.Draw();

            label.SetPosition(roomPosition);
            label.Draw();
        }

        public virtual void OnClick(MouseButtonEventArgs e, Vector2 mousePosition)
        {

        }
    }
}
