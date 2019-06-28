using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pong_PCC
{
    class Vertical_Block:Paddle
    {



        /*Vertical block constructor of start x and y position, size, 
        maximum y limit and if the ball is moving towards it*/
        public Vertical_Block(uint positionX, uint positionY, 
            uint xSize,uint ySize, uint maxPaddle, bool ballMovement)
        {
            xPosition = positionX;
            yPosition = positionY;
            width = xSize;
            height = ySize;
            downLimit = maxPaddle;

            ballDirection = ballMovement;
        }

        public void Draw(Graphics g, Brush graphicsBrush)
        {
            //Draw rectangle according to dimensions outlined
            g.FillRectangle(graphicsBrush, xPosition, yPosition, width, height);
        }



        //Vertical block has negative movement down
        public void negativeMove(uint movementValue) 
        {
            //Change yPosition of paddle as long as not below maximum y limit
            if ((int)yPosition + movementValue > downLimit)
                return;

            yPosition += movementValue;
        }

        //Vertical block has positive movement up
        public void positiveMove(uint movementValue)
        {
            //Change yPosition of paddle as long as not above 0
            if (((int)yPosition - movementValue) < 0)
                return;

            yPosition -= movementValue;
        }


        //Will try to move middle of the paddle towards where the projected y exists
        public void moveY(float projectedYPosition,uint intervalMovementValue)
        {
            float middlePosition = yPosition + (height / 2); //Location of the middle position of the paddle
            float difference = Math.Abs(projectedYPosition - middlePosition); //Difference in position 

            if (difference > intervalMovementValue) //Stops infinite surrounding of point - allows for some inaccuracy
            {
                //Moves towards projected y position
                if (middlePosition < projectedYPosition)
                {
                    negativeMove(intervalMovementValue);
                }
                else if (middlePosition > projectedYPosition)
                {
                    positiveMove(intervalMovementValue);
                }


            }
        }
    }
}
