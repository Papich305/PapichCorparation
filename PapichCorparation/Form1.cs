using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapichCorparation
{
    public partial class Form1 : Form
    {
        Particle particle = new Particle();
        Emitter emitter = new Emitter();
        Portal portal = new Portal();
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.White,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                ParticlesCount = 1000,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
            portal = new Portal
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2 + 50,
                vX = picDisplay.Width / 2,
                vY = picDisplay.Height / 2 - 50,
            };
            emitter.portal = portal;
        }
        private void picDisplay_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            var g = Graphics.FromImage(picDisplay.Image);
            g.Clear(Color.Black);
            emitter.Render(g);
            picDisplay.Invalidate();
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void picDisplay_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                portal.X = e.X;
                portal.Y = e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                portal.vX = e.X;
                portal.vY = e.Y;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            portal.vn = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            portal.Radius = trackBar2.Value;           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedMin = trackBar3.Value;
            emitter.SpeedMax = trackBar3.Value;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            portal.vs = trackBar4.Value;
        }

        private void trackBar5_Scroll_1(object sender, EventArgs e)
        {
            emitter.Direction = trackBar5.Value;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
