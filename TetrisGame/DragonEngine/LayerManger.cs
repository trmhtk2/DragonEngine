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
        // Constructor with only content provided, uses default color
        public Pixel(char content = '█')
        {
            this.content = content;
            this.color = Defaults.Color;
        }

        // Constructor with both content and color provided
        public Pixel(char content, ConsoleColor customColor)
        {
            this.content = content;
            this.color = customColor;
        }
    }
    public class Layer
    {
        private Pixel[,] content = new Pixel[Screen.GetSize().x, Screen.GetSize().y];
        public string layerName = "New Layer";

        public Layer(string name = "", Pixel[,] content = null) {
            if(name == "")
            {
                MathFunctions.GetRandomDigitSequence(10);
            }
            this.layerName = name;
            this.content = content;
        }
        public Layer(Pixel[,] content)
        {
            this.content = content;
            layerName = MathFunctions.GetRandomDigitSequence(10).ToString();

        }

        public Pixel[,] GetContent()
        {
            return content;
        }
    }
    public class LayerManger
    {
        private List<Layer> layers = new List<Layer>();

        public Layer AddLayer(Layer layer, int order = -1)
        {
            layers.Add(layer);
            return layer;
        }

        public void Display()
        {
            foreach (var layer in layers)
            {
                for (int i = 0; i < Screen.GetSize().x; i++)
                {
                    for (int j = 0; j < Screen.GetSize().y; j++)
                    {
                        Pixel pixel = layer.GetContent()[i, j];
                        Console.ForegroundColor = pixel.color;
                        Console.Write(pixel.content);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
