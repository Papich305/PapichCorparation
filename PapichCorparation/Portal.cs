using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PapichCorparation
{
    class Portal
    {
        public int X;
        public int Y;
        public int Radius = 50;
        public int vX;
        public int vY;
        public float vn = 0;
        public float vs = 5;
        public void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < Radius / 2)
            {
                particle.X = vX ;
                particle.Y = vY ;
                particle.SpeedX = (float)(Math.Cos(vn / 180 * Math.PI) * vs);
                particle.SpeedY = -(float)(Math.Sin(vn / 180 * Math.PI) * vs);
            }
        }
        public void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Orange), vX - Radius / 2, vY - Radius / 2, Radius, Radius);
            g.DrawEllipse(new Pen(Color.Blue), X - Radius / 2, Y - Radius / 2, Radius, Radius);
        }
    }
}
