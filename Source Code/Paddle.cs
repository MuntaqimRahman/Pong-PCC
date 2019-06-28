using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pong_PCC
{
    class Paddle
    {
        public bool positiveMovement = false, negativeMovement = false; //If user is moving paddle

        //Locations and size of the paddle
        protected uint xPosition;
        protected uint yPosition;
        protected uint width, height;

        protected bool ballDirection; //Whether or not ball is moving in direction of paddle
        protected uint downLimit; // Bottom y limit of paddle given gameboard size and paddle size
        protected uint score; //Score earned by the paddle

        //Get set accessors to change ball direction boolean
        public bool BallDirection
        {
            get { return ballDirection; }
            set { ballDirection = value; }
        }

        //Get set accesor only allowing score if less than 00 limit
        public uint Score
        {
            get { return score;}
            set
            {
                if (value >=0 && value <99)
                {
                    score = value;
                }
            }

        }

        //x and y position readonly
        public uint XPosition
        {
            get
            {
                return xPosition;
            }
        }
        public uint YPosition
        {
            get
            {
                return yPosition;
            }
        }
        

        

        

    }
}
