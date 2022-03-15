namespace Points
{
    public partial class Form1 : Form
    {
        Graphics g, gf;
        Bitmap frame;
        ObjectManager om;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            frame = new Bitmap(Width - 16 , Height - 38);
            gf = Graphics.FromImage(frame);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            om = new ObjectManager();
            for (int i = 0; i < 100; i++)
            {
                new Agent(gf,om, Width, Height);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Render();
        }

        public void Render()
        {
            
            gf.Clear(Color.Black);
            foreach (Agent agent in om.agents) agent.Step();
            foreach (Agent agent in om.agents) agent.Render();
            g.FillEllipse(new SolidBrush (Color.OrangeRed),new RectangleF(om.p1.X-10,om.p1.Y-10,20,20));
            g.FillEllipse(new SolidBrush (Color.LightBlue),new RectangleF(om.p2.X-10,om.p2.Y-10,20,20));            
            g.DrawImage(frame, 0, 0);
        }
        
    }
    
    

}