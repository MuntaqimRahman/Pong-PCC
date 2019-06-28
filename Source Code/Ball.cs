using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Pong_PCC
{
    public class Ball
    {
        protected float xPosition, yPosition; //Position of ball
        protected float xDistance, yDistance; //x and y distance covered each time timer elapsed
        protected bool missed; //If the paddle has missed the ball
        protected uint roundTimeElapsed; //Amount of time in ms passed in the road
        protected float predictedYPosition; //Predicted y position of the ball when it hits the left paddle in single player play
        protected uint boardXSize, boardYSize; //Size of the gameboard
        protected uint ballSize; //Diameter of the ball
        protected float initialXDistance; //Initial x distance per tick when launching a ball from the centre
        protected uint paddleDistance, paddleX, paddleY; //Paddle distance from the edge and size of paddle

        private float maxYDistance; //Highest possible y distance per tick to stop excessively high y velocity
        
        //Predicted y position is read only
        public float PredictedYPosition
        {
            get { return predictedYPosition; }
        }

        //Ball constructor that loads necessary information for limits
        public Ball(uint boardXLimit, uint boardYLimit, uint ballDimension, 
            uint paddleDistanceFromEdge, uint paddleWidth, uint paddleHeight)
        {
            initialXDistance = 3 *(boardYLimit / 365f); //initial x velocity based off constant ratio * board height
            maxYDistance = 1.5f * (boardYLimit / (boardXLimit / initialXDistance)); //Makes maximum y distance 1.5 * corner to corner slope
            
            //Ball dimensions,board size, paddle distance from edge, and paddle size to find ball limits
            boardXSize = boardXLimit;
            boardYSize = boardYLimit;
            ballSize = ballDimension;
            paddleDistance = paddleDistanceFromEdge;
            paddleX = paddleWidth;
            paddleY = paddleHeight;

            //If paddle has missed ball
            missed = false;
            //Elapsed time of round default to 0
            roundTimeElapsed = 0;
        }

        //Accessor for yPosition limited to ensure within bounds of board
        public float YPosition
        {
            get { return yPosition; }
            set {
                    if ((value >= ballSize) && value <= (boardYSize - ballSize))
                    {
                        yPosition = value;
                    }
                }
        }

        public float XPosition
        {
            get { return xPosition; }
            set
            {
                if ((value >= 0) && value <= (boardXSize - ballSize))
                {
                    xPosition = value;
                }
            }
        }

        public float YDistance
        {
            get { return yDistance; }
            set
            {
                if (yDistance > (-1*maxYDistance)  && yDistance < maxYDistance)
                {
                    yDistance = value;
                }
            }
        }

        public float XDistance
        {
            get { return xDistance; }
            set
            {
                xDistance = value;
            }
        }

        //Time elapsed accesor - set as long as below uint maximum value
        public uint RoundTimeElapsed
        {
            get { return roundTimeElapsed; }
            set
            {
                if (value < 4294967295)
                {
                    roundTimeElapsed = value;
                }
            }
        }
        

        public void Draw(Graphics g, Brush graphicsBrush)
        {
            //Draw ball based off given dimensions
            g.FillEllipse(graphicsBrush,xPosition, yPosition, ballSize, ballSize);
            
        }

        //Move the ball by the x and y distance per tick
        public void moveBall()
        {
            xPosition += xDistance;
            yPosition += yDistance;
        }

        public void ballMultiplier() //Speeds ball up  by x1.25 multiplier every 10 seconds to accelerate game
        {
            if (roundTimeElapsed > 10000)
            {
                roundTimeElapsed = 0;
                xDistance *= 1.25f;
            }
        }

        public bool ballRegenerationCheck(int direction)
        {
            //When ball is 50px beyond edge of panel, relaunch ball
            if (xPosition < -50 || xPosition > boardXSize+50 ) 
            {
                roundTimeElapsed = 0;
                ballLaunch(direction);

                return true;
            }

            return false;
            
        }

        //Relaunches ball from centre
        public void ballLaunch(int direction) 
        {
            xPosition = ((float)boardXSize/2)-(ballSize/2); // Centre of the gameboard

            Random rnd = new Random();
            int startYPosition = rnd.Next((int)ballSize, (int)boardYSize - (int)ballSize);

            //Picks lower and higher y distance limit that keeps it from being too high
            float xDistanceDivision = xPosition / initialXDistance; //Number of intervals from centre to edge
            //Multiplied by 1000 to allow for more granular distance (rand pick between integers)
            int yLowerLimit = Convert.ToInt32(Math.Ceiling(1000*((startYPosition-boardYSize)/xDistanceDivision)));
            int yHigherLimit = Convert.ToInt32(Math.Floor(1000*(startYPosition/xDistanceDivision)));


            yPosition = startYPosition; //yPosition set to random y

            //Finds random y distance between limits as long as it is sufficiently high
            float yDist = 0;
            while (yDist > yLowerLimit/20 && yDist < yHigherLimit/20) //Keeps it from being too slow
            {
                yDist = rnd.Next(yLowerLimit, yHigherLimit);
            }
            
            yDistance = yDist/1000; //Sets yDistance to the actual value (/1000)
            xDistance = initialXDistance * direction; // xDistance set to the initial distance in the direction of the loser

            missed = false; //Sets misssed back to false
        }

        public void yDetection()
        {
            //Finds the number of intervals needed to get to the other side and finds where y exists in that same time
            uint distance = (uint)(xPosition-paddleDistance-paddleX);

            int intervalAmount = Convert.ToInt32(Math.Ceiling(distance/Math.Abs(xDistance)));
            predictedYPosition = yPosition + (intervalAmount * yDistance);
            
            //Deals with the case where projected y position beyond bounds of the board
            /*Takes advantage of the fact that speed in transit is constant - so don't need to actually
             run an accelerated simulation in a for loop
             */
            while (predictedYPosition > (boardYSize-ballSize) || predictedYPosition < 0)
            {
                    if (predictedYPosition < 0)
                    {
                        predictedYPosition = -1 * predictedYPosition;
                    } else
                    {
                        predictedYPosition = 2*(boardYSize-ballSize) - predictedYPosition; 
                    }       
            }
        }
        
        //Checks if the ball has hit the paddle
        public int paddleDetection(int paddlePositionY)
        {
            if (missed == false) //Checks if ball has already missed paddle
            {
                //Checks if within the x position of the ball-paddle interface
                if (xPosition <= (paddleDistance+paddleX) || xPosition >= (boardXSize-paddleDistance-paddleX-ballSize)) 
                {
                    //Checks if within the possible y positions that would result in the paddle hitting the ball back
                    if (yPosition > (paddlePositionY-ballSize) && yPosition < (paddlePositionY + paddleY))
                    {
                        
                        float middleDeviation = Math.Abs(yPosition - (paddlePositionY + (paddleY/2))); //Deviation from the middle of the paddle
                        float anglePercentage = (middleDeviation / (paddleY/2)); // Pecentage from middle of the paddle

                        //y velocity increases based off distance from middle of the paddle
                        yDistance *= (0.85f +anglePercentage);
                        
                        //Ensures new y value not beyond maximum value
                        if (yDistance > maxYDistance)
                        {
                            yDistance = maxYDistance;
                        } else if (yDistance < -1*maxYDistance)
                        {
                            yDistance = -1*maxYDistance;
                        }

                        //Returns the ball back
                        xDistance *= -1;

                        //Changes the speed of the ball only after hitting the paddle
                        //Ensures transit speeds are constant
                        ballMultiplier();



                        return 1; // Hit paddle

                    }
                    else
                    {
                        
                            missed = true;
                            return -1; // Has missed the paddle
                        
                    }
                }
            } else
            {
                return -1; //Has missed the paddle
            }
            return 0; // Requires no further processing
        }

        public void sideDetection()
        {
            //Checks if the ball hits the edges of board
            if (yPosition <= 0 || yPosition >= boardYSize-ballSize)
            {
                //Hits the ball back off the wall
                yDistance *= -1;
            }
        }
        
    }
}
