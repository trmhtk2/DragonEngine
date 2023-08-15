using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{
    public abstract class Graphic
    {
        public abstract void DrawGraphic(Vector2D position = null);
        public abstract void Rotate(int rotation);
        public abstract void OnStart();
    }
    public class ASCII : Graphic
    {

        private string art = "";
        private string originalArt = ""; // Store the original art to be used by ResetRotation

        private string[] artLines;
        private int artLinesAmount;

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

        public override void OnStart()
        {
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
            int artHeight = GetArtLinesLength();
            position = position ?? Vector2D.Zero;

            for (int i = 0; i < artHeight; i++)
            {
                string line = artLines[i];
                int artWidth = line.Length;
                int leftX = position.x - artWidth / 2;
                int currentY = position.y - artHeight / 2 + i;

                Console.SetCursorPosition(leftX, currentY);
                Console.Write(line);
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