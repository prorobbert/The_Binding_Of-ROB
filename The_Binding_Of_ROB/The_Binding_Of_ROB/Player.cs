using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Binding_Of_ROB
{
    class Player : AnimatedCharacter
    {
        public Player() : base("Sprites/Player/Player1.png", 33, 48)
        {
            Anim_Down = new Animation(0, 0, 4);
            Anim_Left = new Animation(48, 0, 4);
            Anim_Right = new Animation(96, 0, 4);
            Anim_Up = new Animation(144, 0, 4);

            moveSpeed = 150;
            animationSpeed = 0.05f;
        }

        public override void Update(float deltaTime)
        {
            this.CurrentState = CharacterState.None;

            if(Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                this.CurrentState = CharacterState.MovingUp;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                this.CurrentState = CharacterState.MovingLeft;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                this.CurrentState = CharacterState.MovingDown;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                this.CurrentState = CharacterState.MovingRight;
            }
            base.Update(deltaTime);
        }
    }
}
