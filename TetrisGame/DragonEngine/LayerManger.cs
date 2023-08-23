using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{
    public class Pixel
    {
        public char content;
        public ConsoleColor color;
        private static Pixel opaque;

        public static Pixel GetOpaque()
        {
            opaque = opaque ?? new Pixel('█');
            return opaque;
        }
        public Pixel(char content = ' ')
        {
            this.content = content;
            this.color = Defaults.Color;
        }

        public Pixel(char content, ConsoleColor customColor)
        {
            this.content = content;
            this.color = customColor;
        }
    }

    public class Layer
    {
        private Pixel[,] content;
        public string layerName;

        public Layer(string name = "", Pixel[,] content = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                layerName = MathFunctions.GetRandomDigitSequence(10).ToString();
            }
            else
            {
                this.layerName = name;
            }

            this.content = content ?? InitializeEmptyContent();
        }

        public Layer(Pixel[,] content)
        {
            this.content = content;
            layerName = MathFunctions.GetRandomDigitSequence(10).ToString();
        }

        public Pixel GetPixel(Vector2D position)
        {
            return content[position.x, position.y] ?? new Pixel();
        }

        public Pixel SetPixel(Vector2D position, Pixel pixel)
        {
            LayerManager.IsBufferDirty = true;
            return content[position.x, position.y] = pixel;
        }

        private Pixel[,] InitializeEmptyContent()
        {
            Vector2D size = Screen.GetSize();
            Pixel[,] tempContent = new Pixel[size.x, size.y];

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    tempContent[x, y] = null; // Lazily initialize pixels.
                }
            }

            return tempContent;
        }
    }

    public static class LayerManager
    {
        private static List<Layer> layers = new List<Layer>();
        private static Pixel[,] screenBuffer = new Pixel[Screen.GetSize().x, Screen.GetSize().y];

        public static bool IsBufferDirty { get; set; } = true;

        public static void OnStart()
        {
            for (int i = 0; i < 5; i++) // Using 5 directly, but you can use a named constant
            {
                AddLayer(new Layer());
            }
        }

        public static Layer FindLayerByOrder(int order)
        {
            return layers[order];
        }

        public static Layer AddLayer(Layer layer)
        {
            IsBufferDirty = true;
            layers.Add(layer);
            return layer;
        }

        public static void OnLoop()
        {
          /*  Vector2D RandomPoint = new Vector2D(MathFunctions.GetRandom(1, Screen.GetSize().x - 1), MathFunctions.GetRandom(1, (int)(Screen.GetSize().y * 1f)));
            Console.WriteLine(Screen.GetSize().ToString() + "  :  " + RandomPoint.ToString());
            FindLayerByOrder(0).SetPixel(RandomPoint, Pixel.GetOpaque()); */
        }

        public static void Display()
        {
            if (!IsBufferDirty) return;

            StringBuilder screenBuilder = new StringBuilder();

            ClearBuffer();

            foreach (var layer in layers)
            {
                CompositeLayerOntoBuffer(layer);
            }

            for (int i = 0; i < Screen.GetSize().x; i++)
            {
                for (int j = 0; j < Screen.GetSize().y; j++)
                {
                    Pixel pixel = screenBuffer[i, j] ?? new Pixel();
                    Console.ForegroundColor = pixel.color;
                    screenBuilder.Append(pixel.content);
                }
                screenBuilder.AppendLine();
            }

            Console.Write(screenBuilder.ToString());
            IsBufferDirty = false;
        }

        private static void ClearBuffer()
        {
            for (int i = 0; i < Screen.GetSize().x; i++)
            {
                for (int j = 0; j < Screen.GetSize().y; j++)
                {
                    screenBuffer[i, j] = null; 
                }
            }
        }

        private static void CompositeLayerOntoBuffer(Layer layer)
        {
            for (int i = 0; i < Screen.GetSize().x; i++)
            {
                for (int j = 0; j < Screen.GetSize().y; j++)
                {
                    Pixel pixel = layer.GetPixel(new Vector2D(i, j));
                    if (pixel != null && pixel.content != ' ')
                    {
                        screenBuffer[i, j] = pixel;
                    }
                }
            }
        }
    }
}
