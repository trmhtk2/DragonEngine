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

        public Layer(string name = "New Layer", Pixel[,] content = null) {
            this.layerName = name;
            this.content = content;
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
    }
}
