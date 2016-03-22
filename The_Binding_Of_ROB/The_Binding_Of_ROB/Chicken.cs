using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Binding_Of_ROB
{
    class Chicken : AnimatedCharacter
    {
        public Chicken() : base("Sprites/Monsters/Chicken_walk.png", 32, 32)
        {
            Anim_Up = new Animation(0, 0, 4);
            Anim_Left = new Animation(32, 0, 4);
            Anim_Down = new Animation(64, 0, 4);
            Anim_Right = new Animation(96, 0, 4);
        }
    }
}
