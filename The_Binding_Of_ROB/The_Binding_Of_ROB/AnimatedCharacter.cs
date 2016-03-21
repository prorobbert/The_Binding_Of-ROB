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
        private int frameSize;

        public CharacterState CurrentState { get; set; }

        protected Animation Anim_Up;
        protected Animation Anim_Left;
        protected Animation Anim_Down;
        protected Animation Anim_Right;

        private Clock animationClock;
        protected float moveSpeed = 50;
        protected float animationSpeed = 0.1f;

        public AnimatedCharacter(string filename, int frameSize)
        {
            this.frameSize = frameSize;
            Texture texture = new Texture(filename);

            spriteRect = new IntRect(0, 0, frameSize, frameSize);
            sprite = new Sprite(texture, spriteRect);

            //Haal dit staks weg!!
            Anim_Up = new Animation(0, 0, 4);
            Anim_Left = new Animation(32, 0 ,4);
            Anim_Down = new Animation(64, 0, 4);
            Anim_Right = new Animation(96, 0, 4);

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

                    if(spriteRect.Left == (currentAnimation.numFrames -1) * frameSize)
                    {
                        spriteRect.Left = 0;
                    }
                    else
                    {
                        spriteRect.Left += frameSize;
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
