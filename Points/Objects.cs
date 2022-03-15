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
            target = false; //random.Next(2) > 5;
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
            toA++;
            toB++;
            if (new Vector(om.p1, pos).getLength() <= 10 && target)
            {
                toA = 0;
                dir *= -1;
                target = !target;
            }
            if (new Vector(om.p2, pos).getLength() <= 10 && !target)
            {
                toB = 0;
                dir *= -1;
                target = !target;
            }

        }
        public void Render()
        {
            Pen pen;
            if (target) pen = new Pen(Color.Green);
            else pen = new Pen(Color.Red);
            g.DrawEllipse(pen, pos.X, pos.Y, 1, 1);
        }
       
    }
    public class ObjectManager
    {
        public List<Agent> agents = new List<Agent>();
        public PointF p1 = new PointF(40, 93);
        public PointF p2 = new PointF(698, 642);
    }
}
