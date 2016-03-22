using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Binding_Of_ROB
{
    public enum CharacterState
    {
        None,
        MovingUp,
        MovingLeft,
        MovingDown,
        MovingRight
    }
    abstract class AnimatedCharacter
    {
        public float Xpos { get; set; }
        public float Ypos { get; set; }

        private Sprite sprite;
        private IntRect spriteRect;
        private int frameWitdh;
        private int frameHeight;

        public CharacterState CurrentState { get; set; }

        protected Animation Anim_Up;
        protected Animation Anim_Left;
        protected Animation Anim_Down;
        protected Animation Anim_Right;

        private Clock animationClock;
        protected float moveSpeed = 50;
        protected float animationSpeed = 0.1f;

        public AnimatedCharacter(string filename, int frameWitdh, int frameHeight)
        {
            this.frameWitdh = frameWitdh;
            this.frameHeight = frameHeight;
            Texture texture = new Texture(filename);

            spriteRect = new IntRect(0, 0, frameWitdh, frameHeight);
            sprite = new Sprite(texture, spriteRect);            

            animationClock = new Clock();
        }

        public virtual void Update(float deltaTime)
        {
            Animation currentAnimation = null;
            switch(CurrentState)
            {
                case CharacterState.MovingUp:
                    currentAnimation = Anim_Up;
                    Ypos -= moveSpeed * deltaTime;
                    break;
                case CharacterState.MovingLeft:
                    currentAnimation = Anim_Left;
                    Xpos -= moveSpeed * deltaTime;
                    break;
                case CharacterState.MovingDown:
                    currentAnimation = Anim_Down;
                    Ypos += moveSpeed * deltaTime;
                    break;
                case CharacterState.MovingRight:
                    currentAnimation = Anim_Right;
                    Xpos += moveSpeed * deltaTime;
                    break;
            }

            sprite.Position = new Vector2f(Xpos, Ypos);

            if(animationClock.ElapsedTime.AsSeconds() > animationSpeed)
            {
                if(currentAnimation != null)
                {
                    spriteRect.Top = currentAnimation.offsetTop;

                    if(spriteRect.Left == (currentAnimation.numFrames - 1) * frameWitdh)
                    {
                        spriteRect.Left = 0;
                    }
                    else
                    {
                        spriteRect.Left += frameWitdh;
                    }
                }
                animationClock.Restart();
            }

            sprite.TextureRect = spriteRect;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}
