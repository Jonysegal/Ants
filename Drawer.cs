using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
namespace deee
{
    public static class Drawer
    {

        /// <summary>
        /// On invokation of drawer in the game loop, drawer has two responsibilites.
        /// 1) Update the image for any sprites modified in map storer over the past frame.
        /// 2) Draw the image to the window.
        /// </summary>

        static RenderWindow window;
        static Texture texture;
        static Image image;
        static Sprite sprite;
        const int WindowSize = 1000;
        const int Offset = WindowSize / 2;

        public static Dictionary<Tile.Type, Color> typeColorMap = new Dictionary<Tile.Type, Color>()
    {
        {Tile.Type.Water, Color.Blue },
        {Tile.Type.Ground, new Color(16, 48, 0) },
        {Tile.Type.Food, Color.Green },
        {Tile.Type.AntHill, Color.Magenta },
        {Tile.Type.Ant, Color.Red },
        {Tile.Type.AntWithFood, Color.Green },
    };

        static Drawer()
        {
            window = new RenderWindow(new VideoMode(WindowSize, WindowSize), "Window");
            texture = new Texture(WindowSize, WindowSize);
            image = new Image(WindowSize, WindowSize);
            sprite = new Sprite(texture);
            InitializeImage();
        }

        static void InitializeImage()
        {
            for(uint i=0; i < WindowSize; i++)
            {
                for(uint j = 0; j < WindowSize; j++)
                {
                   image.SetPixel(i, j, Color.White);
                }
            }
        }

        static void UpdateImageForModifiedTiles()
        {
            foreach (var modifiedPoint in Map.ModifiedPoints)
            {
                AddTypeToColorsAt(Map.map[modifiedPoint], DrawingTranslatedPoint(modifiedPoint));
            }
            Map.ModifiedPoints.Clear();
        }

        static Point DrawingTranslatedPoint(Point translate)
        {
            return new Point(translate.x + Offset, translate.y + Offset);
        }

        static void AddTypeToColorsAt(Tile.Type toAdd, Point addAt)
        {
            addAt.y = WindowSize - addAt.y;
            if(PointValidForColorPlacement(addAt))
                image.SetPixel((uint)addAt.x, (uint)addAt.y, typeColorMap[toAdd]);
            else
            {
                Console.WriteLine("attempted color place at invalid spot " + addAt.ToString());
                Console.ReadKey(true);
            }
        }

        static bool PointValidForColorPlacement(Point check) => check.y < 1000 && check.x < 1000;

        static void Draw()
        {
            texture.Update(image);
            window.Draw(sprite);
            window.Display();
        }

        public static void Loop()
        {
            UpdateImageForModifiedTiles();
            Draw();
        }
    }
}
