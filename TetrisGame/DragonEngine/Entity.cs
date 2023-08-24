using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{
    public class Entity
    {
        private Vector2D _position = Vector2D.zero;

        private Vector2D Position
        {
            get { return _position; }
            set { _position = value; }
        }

        int Rotation;
        int Scale;
        Vector2D Velocity;
        Graphic graphic;


        //pre-data, for checking changes
        Vector2D prePos;
        int preRot;
        int preScale;
        Graphic preGraphic;

        public Entity(Graphic graphic = null, int rotation = 0)
        {
            graphic = graphic ?? Graphic.Empty;
            SetGraphic(graphic);

            this.Position = Screen.GetCenterPoint();
        }
        public Entity(Vector2D position, int rotation = 0, Graphic graphic = null)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.graphic = graphic ?? new ASCII();
        }

        public Vector2D GetPosition() { return Position; }
        public Vector2D SetPosition(Vector2D pos) { Position = pos; return Position; }


        public int GetRotation() { return Rotation; }
        public int SetRotation(int rot) { Rotation = rot; return Rotation; }

        public int GetScale() { return Scale; }
        public int SetScale(int scale) { Scale = scale; return Scale; }

        public Graphic GetGraphic() { return graphic; }
        public Graphic SetGraphic (Graphic graphic) { this.graphic = graphic; return this.graphic; }

        public void OnStart() {
            GetGraphic().OnStart();

            graphic.OnStart();
            graphic.DrawGraphic(GetPosition());
        }

        public void OnUpdate()
        {
            graphic.SetLayer(LayerManager.FindLayerByOrder(0));
            graphic.DrawGraphic(GetPosition());



            //Anything else Here

            if (objectDataChanged())
            {
                //TODO: redraw graphic with the data
            //    graphic.Rotate(GetRotation());
                graphic.DrawGraphic(GetPosition());
            }

            prePos = GetPosition();
            preRot = GetRotation();
            preScale = GetScale();
            preGraphic = GetGraphic();
        }

        /// <summary>
        /// Check if any object data changed and returns it
        /// </summary>
        /// <returns></returns>
        public bool objectDataChanged()
        {
            if (prePos != GetPosition()) { return true;  }
            if (preRot != GetRotation()) { return true;  }
            if (preScale != GetScale()) { return true;  }
            if (preGraphic != graphic) { return true;  }
            return false;
        }
    }
}
