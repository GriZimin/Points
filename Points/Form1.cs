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
            frame = new Bitmap(Width , Height);
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
            foreach (Agent agent in om.agents ) agent.Step();
            gf.Clear(Color.Black);
            foreach (Agent agent in om.agents) agent.Render();
            g.DrawImage(frame, 0, 0);
        }
        
    }
    
    

}