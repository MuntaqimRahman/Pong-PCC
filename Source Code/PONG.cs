using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Input;

namespace Pong_PCC
{
    public partial class formGame : Form
    {
        public formGame()
        {
            InitializeComponent();
            
            /* Loads the width and height of the gameboard which is used to
             determine all conditions and limits. Therefore, the game should still work
             if the gameboard size was changed*/
            boardSizeX = (uint)pboxGameboard.Size.Width;
            boardSizeY = (uint)pboxGameboard.Size.Height;

            //Initializing the paddle and ball with gameboard size and paddle size information
            leftPaddle = new Vertical_Block(paddleDistance,(boardSizeY/2)-(paddleHeight/2),paddleWidth,
                paddleHeight,boardSizeY-paddleHeight,false);
            rightPaddle = new Vertical_Block(boardSizeX - paddleDistance - paddleWidth, (boardSizeY / 2) - (paddleHeight / 2), 
                paddleWidth, paddleHeight, boardSizeY - paddleHeight, true);
            ball = new Ball(boardSizeX, boardSizeY, ballSize, paddleDistance, paddleWidth, paddleHeight);

            //Makes all labels transparent and proportional to gameboard size
            //Font size must still be changed manually
            graphicsSettings();

            //Initialize and start the timer
            setTimer();
            timeInterval.Start();
            
            //Start the ball towards the left player
            ball.ballLaunch(1);
        }
        

        System.Timers.Timer timeInterval;

        uint boardSizeX,boardSizeY; 
        public static bool singlePlayer; //Static singleplayer variable which can be changed from other forms

        //Controls on the placement and size of balls and paddle
        //All limits based off these controls
        //Game will still work if any of these controls are changed
        uint ballSize = 10;
        uint paddleDistance = 10;
        uint paddleWidth = 5;
        uint paddleHeight = 60;

        //Vertical block and ball objects to be used
        //Vertical block separated from paddle class so horizontal paddle can be implemented later
        Vertical_Block leftPaddle;
        Vertical_Block rightPaddle;
        Ball ball;
        

        //Pause and play timer
        public void pauseTimer()
        {
            if (timeInterval.Enabled)
                timeInterval.Stop();
            else
                timeInterval.Start();
        }

        //Makes labels and buttons transparent and bases their location off panel size
        public void graphicsSettings()
        {
            lblScoreLeft.Parent = pboxGameboard;
            lblScoreLeft.BackColor = Color.Transparent;
            lblScoreLeft.Location = new Point((int)(0.3*boardSizeX),(int)(0.05*boardSizeY));
            
            lblScoreRight.Parent = pboxGameboard;
            lblScoreRight.BackColor = Color.Transparent;
            lblScoreRight.Location = new Point((int)(0.54 * boardSizeX), (int)(0.05 * boardSizeY));

            btnRestart.Parent = pboxGameboard;
            btnRestart.BackColor = Color.Transparent;
            btnRestart.Location = new Point((int)(0.85 * boardSizeX), (int)(0.025 * boardSizeY));

            lblWinMessage.Parent = pboxGameboard;
            lblWinMessage.BackColor = Color.Transparent;
            lblWinMessage.Location = new Point((int)(0.01 * boardSizeX), (int)(0.5 * boardSizeY));
            ;
        }

        //Changes the score display
        public void displayScore()
        {
            //Updated in timer so requires checking if thread is switiching
            if (InvokeRequired)
            {
                //If thread switching required, invoke the method
                MethodInvoker updateMethod = new MethodInvoker(displayScore);
                Invoke(updateMethod);
                return;
            }

            lblScoreLeft.Text = leftPaddle.Score.ToString("00");
            lblScoreRight.Text = rightPaddle.Score.ToString("00");

            //Stop game and change message if either player reaches score 10
            if (rightPaddle.Score == 10)
            {
                timeInterval.Stop();
                lblWinMessage.Text = "Right Player Wins!"; 
            } else if (leftPaddle.Score == 10)
            {
                timeInterval.Stop();
                lblWinMessage.Text = "Left Player Wins!";
            }
        }

        //Set timer to 10ms timer that's always repeating
        //Running OnTimedEvent when timer finishes to change board
        public void setTimer()
        {
            timeInterval = new System.Timers.Timer(10);
            timeInterval.Elapsed += OnTimedEvent;
            timeInterval.AutoReset = true;
        }

        //Default position at the begining of the game
        public void restart()
        {
            lblWinMessage.Text = "";
            leftPaddle.Score = 0;
            rightPaddle.Score = 0;

            //Always moves ball towards right when restarting
            leftPaddle.BallDirection = false;
            rightPaddle.BallDirection = true;
            displayScore();
            ball.ballLaunch(1);
            ball.RoundTimeElapsed = 0;
            timeInterval.Start();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            uint distancePerTick = 5; //Amount of y px moved per tick

            //Checks if key is pressed down and moves accordingly
            // Done in timer to avoid keyboard repeat delay when holding
            if (leftPaddle.negativeMovement == true)
            {
                leftPaddle.negativeMove(distancePerTick);
                pboxGameboard.Invalidate();

            } else if (leftPaddle.positiveMovement == true)
            {
                leftPaddle.positiveMove(distancePerTick);
                pboxGameboard.Invalidate();
            }

            if (rightPaddle.negativeMovement == true)
            {
                rightPaddle.negativeMove(distancePerTick);
                pboxGameboard.Invalidate();

            }
            else if (rightPaddle.positiveMovement == true)
            {
                rightPaddle.positiveMove(distancePerTick);
                pboxGameboard.Invalidate();
            }

            

            ball.moveBall(); //Moves the ball each tick
            
            //Processing  only done when ball moving in the direction of the paddle
            if (leftPaddle.BallDirection == true)
            {
                //Result of whether or not ball has hit paddle (1=hit the paddle, -1= missed the paddle)
                int result = ball.paddleDetection((int)leftPaddle.YPosition);

                //Change the y position of the ball automatically if playing singleplayer
                if (singlePlayer)
                {
                    leftPaddle.moveY(ball.PredictedYPosition, boardSizeY/240);
                    
                }

                
                if (result == 1)
                {
                    //Changes the direction the ball is heading towards
                    leftPaddle.BallDirection = false;
                    rightPaddle.BallDirection = true;
                } else if (result == -1)
                {
                    
                    bool regeneration = ball.ballRegenerationCheck(-1); //If missed, wait until ball is 50px beyond edge of panel
                    if (regeneration)
                    {
                        //Change the score of the opposite paddle
                        rightPaddle.Score += 1;

                        //Creates new thread to start the update method
                        Thread labelThread = new Thread(new ThreadStart(updateThread));
                        labelThread.Start();
                        
                        //Finds new y from launch point
                        if (singlePlayer)
                        {
                            ball.yDetection();
                        }

                    }

                }
            } else if (rightPaddle.BallDirection == true)
            {
                //Result of whether or not ball has hit paddle (1=hit the paddle, -1= missed the paddle)
                int result = ball.paddleDetection((int)rightPaddle.YPosition);


                if (result == 1)
                {
                    //Changes the projected y position to new point
                    if (singlePlayer == true)
                    { 
                    ball.yDetection();
                    }

                    //Changes the direction the ball is heading towards
                    rightPaddle.BallDirection = false;
                    leftPaddle.BallDirection = true;



                }else if (result == -1)
                {
                    bool regeneration = ball.ballRegenerationCheck(1); //If missed, wait until ball is 50px beyond edge of panel
                    if (regeneration)
                    {
                        //Change the score of the opposite paddle
                        leftPaddle.Score += 1;

                        //Creates new thread to start the update method
                        Thread labelThread = new Thread(new ThreadStart(updateThread));
                        labelThread.Start();

                        //Finds new y from launch point
                        if (singlePlayer)
                        {
                            ball.yDetection();
                        }
                        
                    }
                        
                }
            }

            //Add 10ms to the time elapsed
            ball.RoundTimeElapsed += 10;
            
            ball.sideDetection();//Check if the ball hit the sides, processing done in the class
            pboxGameboard.Invalidate(); //Redraw the gameboard

        }
        
        //Update method to call the score display 
        private void updateThread()
        {
            displayScore();
        }

        //All drawing done
        private void pboxGameboard_Paint(object sender, PaintEventArgs e)
        {
            //Middle dotted line
            Brush whiteBrush = new SolidBrush(Color.White);
            Graphics g = e.Graphics;

            
            float rectSizeX = (1f / 73f) * boardSizeX; //Square size of the dotted line changes based on width of board
            int intervalNumber = (int)Math.Floor(boardSizeY / (rectSizeX*2)); //Number of times it needs the draw the square

            //Draws all rectangles
            for (int i =0; i < intervalNumber; i++)
            {
                g.FillRectangle(whiteBrush, (boardSizeX-rectSizeX)/2, i*rectSizeX*2, rectSizeX, rectSizeX);
            }
            

            //Draws paddles and ball, information on how to draw stored in class
            leftPaddle.Draw(g,whiteBrush);
            rightPaddle.Draw(g, whiteBrush);
            ball.Draw(g,whiteBrush);


        }

        

        private void PONG_KeyDown(object sender, KeyEventArgs e)
        {
            //Updates bool to tell timer to move paddle if key held down
            switch (e.KeyData)
            {
                case Keys.K:
                    rightPaddle.positiveMovement = true;
                    break;
                case Keys.M:
                    rightPaddle.negativeMovement = true;
                    break;
                
            }

            //Allow user to change left paddle if not in singleplayer
            if (!singlePlayer)
            {
                switch (e.KeyData)
                {
                    case Keys.W:
                        leftPaddle.positiveMovement = true;
                        break;
                    case Keys.S:
                        leftPaddle.negativeMovement = true;
                        break;
                }
            }

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            //Calls restart method to return to default position
            restart();
        }

        private void PONG_KeyUp(object sender, KeyEventArgs e)
        {

            //Updates bool to tell timer to stop moving paddle if key released
            //Also allows user to pause the game
            switch (e.KeyData)
            {
                case Keys.K:
                    rightPaddle.positiveMovement = false;
                    break;
                case Keys.M:
                    rightPaddle.negativeMovement = false;
                    break;
                case Keys.Escape:
                    pauseTimer();
                    break;

            }

            //Allows user to stop moving paddle if not in singleplayer
            if (!singlePlayer)
            {
                switch (e.KeyData)
                {
                    case Keys.W:
                        leftPaddle.positiveMovement = false;
                        break;
                    case Keys.S:
                        leftPaddle.negativeMovement = false;
                        break;
                }
            }
        }
    }
}
