namespace WinForms_11
{
    public partial class Form1 : Form
    {
        private const int MovementSpeed = 5; 
        private int direction; 

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
            StartMovingWindow();
        }

        private void InitializeTimer()
        {
            timer1.Interval = 10; 
            timer1.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Rectangle screenBounds = Screen.GetBounds(this);

            switch (direction)
            {
                case 0: 
                    if (Left + Width + MovementSpeed <= screenBounds.Right)
                        Left += MovementSpeed;
                    else
                        direction = 1; 
                    break;
                case 1: 
                    if (Top + Height + MovementSpeed <= screenBounds.Bottom)
                        Top += MovementSpeed;
                    else
                        direction = 2; 
                    break;
                case 2: 
                    if (Left - MovementSpeed >= screenBounds.Left)
                        Left -= MovementSpeed;
                    else
                        direction = 3; 
                    break;
                case 3: 
                    if (Top - MovementSpeed >= screenBounds.Top)
                        Top -= MovementSpeed;
                    else
                        direction = 0; 
                    break;
            }
        }

        private void StartMovingWindow()
        {
            direction = 0; 
            timer1.Start();
        }
    }
}