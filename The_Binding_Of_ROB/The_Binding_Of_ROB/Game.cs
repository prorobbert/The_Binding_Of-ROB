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
            View view = new View(new Vector2f(0,0), new Vector2f(800, 600));

            Player player = new Player();

            Chicken kip = new Chicken();
            kip.Waypoints = new List<Waypoint>();
            kip.Waypoints.Add(new Waypoint(200, 200));
            kip.Waypoints.Add(new Waypoint(400, 250));
            kip.Waypoints.Add(new Waypoint(500, 400));
            kip.Waypoints.Add(new Waypoint(400, 300));
            kip.Waypoints.Add(new Waypoint(200, 250));

            Clock clock = new Clock();

            while(window.IsOpen)
                {
                window.DispatchEvents();

                float deltaTime = clock.Restart().AsSeconds();


                //hier gaan we elk frame logica en tekencode aanroepen
                kip.Update(deltaTime);
                player.Update(deltaTime);

                view.Center = new Vector2f(player.Xpos, player.Ypos);
                window.SetView(view);

                map.Draw(window, 1);
                map.Draw(window, 2);               
                map.Draw(window, 3);
                player.Draw(window);

                kip.Draw(window);
                

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
