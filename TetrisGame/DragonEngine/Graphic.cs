using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{
    public abstract class Graphic
    {
     /*   public enum GraphicType
        {
            ASCII,
            Text,
        } */

        public abstract Layer GetLayer();
        public abstract Layer SetLayer(Layer layer);

        public abstract void DrawGraphic(Vector2D position = null);
        public abstract void Rotate(int rotation);
        public abstract void OnStart();

        // public abstract GraphicType GetGraphicType();

        public abstract Graphic Clone();
    }

    public class Text : Graphic
    {
        public override Graphic Clone()
        {
            Text clone = new Text(GetBasicText(), GetTextSize());
            clone.OnStart();
            return clone;
        }
        /*    GraphicType graphicType = GraphicType.Text;
            public override GraphicType GetGraphicType()
            {
                return graphicType;
            } */


        string basicText;
        string text;
        string[] sizedTextLines;
        TextSystem.TextSize textSize;
        public Text(string graphic = "", TextSystem.TextSize textSize = TextSystem.TextSize.Medium) 
        {
            SetText(graphic, textSize);
            //SyncTextSize();
        }


        public override void OnStart()
        {
            //Start
            sizedTextLines = GetSizedTextLines();
        }

        public override void Rotate(int rotation)
        {
            //Rotate
        }

        public string SyncTextSize()
        {
           text = TextSystem.ConvertTextSize(basicText, textSize);
            return text;
        }

        public override void DrawGraphic(Vector2D position = null)
        {
            int sizedTextHeight = GetSizedTextLinesLength();
            position = position ?? Vector2D.Zero;

            for (int i = 0; i < sizedTextHeight; i++)
            {
                string line = GetSizedTextLine(i);
                int artWidth = line.Length;
                int leftX = position.x - artWidth / 2;
                int currentY = position.y - sizedTextHeight / 2 + i;

                Console.SetCursorPosition(leftX, currentY);
                Console.Write(line);
            }
        }

        public string GetBasicText() { return basicText; }
        public string GetText() { return text; }
        public string GetTextLength() { return text; }

        public string[] GetSizedTextLines() { return text.Split('\n'); }
        public string GetSizedTextLine(int line) { if (line <= sizedTextLines.Length || line <= 0) { return sizedTextLines[line]; } return string.Empty; }
        public int GetTextLineLength(int line) { if (line <= sizedTextLines.Length || line <= 0) { return sizedTextLines[line].Length; } return 0; }
        public int GetSizedTextLinesLength() { return sizedTextLines.Length; }

        public string SetText(string text, TextSystem.TextSize textSize, bool syncTextSize = true)
        {
            basicText = text;
            this.textSize = textSize;

            if(syncTextSize) SyncTextSize();
            return text;

        }

        public int GetBasicTextLength() { return basicText.Length; }
        public TextSystem.TextSize GetTextSize() { return textSize; }

        public Layer layer;

        public override Layer GetLayer() { return layer; }
        public override Layer SetLayer(Layer layer) { return this.layer = layer; }


    }

    public class ASCII : Graphic
    {
       /* GraphicType graphicType = GraphicType.ASCII;
        public override GraphicType GetGraphicType()
        {
            return graphicType;
        } */

        public override Graphic Clone()
        {
            ASCII clone = new ASCII(GetArt());
            clone.OnStart();
            return clone;
        }

        private string art = "";
        private string originalArt = ""; // Store the original art to be used by ResetRotation

        private string[] artLines;
        private int artLinesAmount;
        private Object attachedObject = null;

        public ASCII(string graphic = "")
        {
            art = graphic;
            originalArt = art;  // Set the original art on creation
        }


        private int currentRotation = 0; // Store the current rotation of the graphic

        public void SetRotation(int rotation)
        {
            int rotationDifference = (rotation - currentRotation + 360) % 360;
            Rotate(rotationDifference);
            currentRotation = rotation % 360;
        }


        public string GetArt() { return art; }
        public string SetArt(string art)
        {
            this.art = art;
            artLines = this.art.Split('\n');  // Update artLines whenever art changes
            artLinesAmount = artLines.Length; // Update artLinesAmount whenever art changes
            return this.art;
        }

        public int GetArtLength() { return art.Length; }
        public string[] GetArtLines() { return art.Split('\n'); }
        public string GetArtLine(int line) { if (line <= artLines.Length || line <= 0) { return artLines[line]; } return string.Empty; }
        public int GetArtLineLength(int line) { if (line <= artLines.Length || line <= 0) { return artLines[line].Length; } return 0; }
        public int GetArtLinesLength() { return artLines.Length; }

        public int GetLongestLineLength()
        {
            int maxLength = 0;
            foreach (string line in GetArtLines())
            {
                if (line.Length > maxLength)
                {
                    maxLength = line.Length;
                }
            }

            return maxLength;
        }

        public Layer layer;

        public override Layer GetLayer() { return layer; }
        public override Layer SetLayer(Layer layer) { return this.layer = layer; }

        public Pixel[,] GetArtAsPixels()
        {
            string[] lines = GetArtLines();
            int maxWidth = GetLongestLineLength();
            int height = lines.Length;

            Pixel[,] result = new Pixel[maxWidth, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < maxWidth; x++)
                {
                    if (x < lines[y].Length)
                    {
                        result[x, y] = new Pixel(lines[y][x]);
                    }
                    else
                    {
                        result[x, y] = new Pixel(' '); // fill with space for lines shorter than the maxWidth
                    }
                }
            }

            return result;
        }

        public override void OnStart()
        {
            SetLayer(LayerManager.FindLayerByOrder(0));
            artLines = GetArtLines();
            artLinesAmount = GetArtLinesLength();
        }


        public override void Rotate(int rotation)
        {
            art = RotateString(art, rotation);
            artLines = art.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); // Update artLines
            artLinesAmount = artLines.Length; // Update artLinesAmount
        }

        public void ResetRotation()
        {
            art = originalArt;
            artLines = art.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); // Update artLines
            artLinesAmount = artLines.Length; // Update artLinesAmount
        }


        public override void DrawGraphic(Vector2D position = null)
        {
            position = position ?? Screen.GetCenterPoint();

            Pixel[,] pixels = GetArtAsPixels();
            Vector2D size = new Vector2D(pixels.GetLength(0), pixels.GetLength(1));

            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    Vector2D pixelPosition = new Vector2D(position.x + x - size.x / 2, position.y + y - size.y / 2);
                    layer.SetPixel(pixelPosition, pixels[x, y]);
                    Console.Write(layer.GetPixel(new Vector2D(x, y)).content);
                }
            }
        }

        private string RotateString(string s, int rotation)
        {
            var lines = s.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            switch (rotation)
            {
                case 0:
                case 360:
                    return s;

                case 90:
                    var transposed90 = Transpose(lines);
                    for (int i = 0; i < transposed90.Length; i++)
                    {
                        Array.Reverse(transposed90[i]);
                    }
                    return string.Join("\n", transposed90.Select(line => new string(line)));

                case 180:
                    var rotated180 = lines.Select(line => new string(line.Reverse().ToArray())).ToArray();
                    Array.Reverse(rotated180);
                    return string.Join("\n", rotated180);

                case 270:
                    var transposed270 = Transpose(lines);
                    Array.Reverse(transposed270);
                    return string.Join("\n", transposed270.Select(line => new string(line)));

                default:
                    return s;
            }
        }

        private char[][] Transpose(string[] lines)
        {
            int maxLength = lines.Max(line => line.Length);
            char[][] result = new char[maxLength][];
            for (int i = 0; i < maxLength; i++)
            {
                result[i] = new char[lines.Length];
                for (int j = 0; j < lines.Length; j++)
                {
                    result[i][j] = j < lines.Length && i < lines[j].Length ? lines[j][i] : ' ';
                }
            }
            return result;
        }
    }
}