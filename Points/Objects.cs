using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    public class Agent
    {
        Graphics g;
        public PointF pos;
        Vector dir;
        int speed = 2;
        bool target;
        public int toA = 200, toB = 200;
        Size field;
        ObjectManager om;
        public Agent(Graphics g,ObjectManager om ,int Width, int Height)
        {
            this.g = g; 
            Random random = new Random();
            target = random.Next(2) > 0;
            pos = new PointF(random.Next(Width), random.Next(Height));
            dir = new Vector(random.Next(-5, 5), random.Next(-5, 5)).ToUnitVector() * speed;
            field = new Size(Width, Height);
            this.om = om;
            om.agents.Add(this);
        }
        public void Step()
        {
            pos += dir;

            if (pos.X < 0 || pos.X > field.Width) dir.x *= -1;
            if (pos.Y < 0 || pos.Y > field.Height) dir.y *= -1;
        }
        public void Render()
        {
            Pen pen;
            if (target) pen = new Pen(Color.Red);
            else pen = new Pen(Color.Blue);
            g.DrawEllipse(pen, pos.X, pos.Y, 1, 1);
        }

    }
    public class ObjectManager
    {
        public List<Agent> agents = new List<Agent>();
    }
}
