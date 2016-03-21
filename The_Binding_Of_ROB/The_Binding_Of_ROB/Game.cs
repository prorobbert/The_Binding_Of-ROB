using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Binding_Of_ROB
{
    class Game
    {
        public void Start()
        {
            RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(800, 600), "The Binding of ROB");
            window.SetFramerateLimit(60);
            window.Closed += Window_Closed;

            //hier gaan we alles in laden en instellen
            Map map = new Map();
            

            Clock clock = new Clock();

            while(window.IsOpen)
                {
                window.DispatchEvents();

                float deltaTime = clock.Restart().AsSeconds();


                //hier gaan we elk frame logica en tekencode aanroepen

                map.Draw(window, 1);
                map.Draw(window, 2);
                map.Draw(window, 3);

                window.Display();
                }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}
