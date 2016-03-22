using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Binding_Of_ROB
{
    class Map
    {
        Sprite[,] tiles1;
        Sprite[,] tiles2;
        Sprite[,] tiles3;
        int mapWidth = 100;
        int mapHeight = 100;

        public Map()
        {
            int tilemapWidth = 32;
            int tilemapHeight = 32;
            int tileSize = 32;

            Texture texture = new Texture(@"Sprites\Terrain\terrain_atlas.png");
            Sprite[] tilemap = new Sprite[tilemapWidth * tilemapHeight];

            for(int y = 0; y < tilemapHeight; y++)
            {
                for(int x = 0; x < tilemapWidth; x++)
                {
                    IntRect rect = new IntRect(x * tileSize, y * tileSize, tileSize, tileSize);
                    tilemap[(y * tilemapWidth) + x] = new Sprite(texture, rect);
                }
            }

            tiles1 = new Sprite[mapWidth, mapHeight];
            StreamReader readLayer1 = new StreamReader(@"C:\Users\Robbert\SkyDrive\The_Binding_Of_ROB\The_Binding_Of_ROB\The_Binding_Of_ROB\Maps\TestMap_Tilelaag 1.csv");
            reading(readLayer1, tilemap, tileSize, tiles1);
            readLayer1.Close();

            tiles2 = new Sprite[mapWidth, mapHeight];
            StreamReader readLayer2 = new StreamReader(@"C:\Users\Robbert\SkyDrive\The_Binding_Of_ROB\The_Binding_Of_ROB\The_Binding_Of_ROB\Maps\TestMap_Tilelaag 2.csv");
            reading(readLayer2, tilemap, tileSize, tiles2);
            readLayer2.Close();

            tiles3 = new Sprite[mapWidth, mapHeight];
            StreamReader readLayer3 = new StreamReader(@"C:\Users\Robbert\SkyDrive\The_Binding_Of_ROB\The_Binding_Of_ROB\The_Binding_Of_ROB\Maps\TestMap_Tilelaag 3.csv");
            reading(readLayer3, tilemap, tileSize, tiles3);
            readLayer2.Close();
        }

        public void reading(StreamReader reader, Sprite[] tilemap, int tileSize, Sprite[,] tiles)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(',');

                for (int x = 0; x < mapWidth; x++)
                {
                    int id = Convert.ToInt32(items[x]);
                    tiles[x, y] = new Sprite(tilemap[id]);
                    tiles[x, y].Position = new SFML.System.Vector2f(tileSize * x, tileSize * y);
                }
            }
        }

        public void Draw(RenderWindow window, int i)
        {
            for(int y = 0; y < mapHeight; y++)
            {
                for(int x = 0; x < mapWidth; x++)
                {
                    switch(i)
                    {
                        case 1:
                            window.Draw(tiles1[x, y]);
                            break;
                        case 2:
                            window.Draw(tiles2[x, y]);
                            break;
                        case 3:
                            window.Draw(tiles3[x, y]);
                            break;
                        default:
                            window.Draw(tiles1[x, y]);
                            break;

                    }
                    
                }
            }
        }
    }
}
