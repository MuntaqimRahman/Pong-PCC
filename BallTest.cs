using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pong_PCC;

namespace Ball.Test
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void yDetection_DifferentYPositionStarts_ReturnsEqualValue()
        {
            Pong_PCC.Ball ball = new Pong_PCC.Ball(640, 480, 10, 10, 5, 60);

            //Expected values and ball initialized with current settings
            float[] expectedValues = new float[6] {126,34,58,150,242,334}; //Expected Values derived from theory and experimentation
            

            //yDistance and xDistance constant - always starting from xPosition 618
            ball.YDistance = 4;
            ball.XDistance = 3 * (480 / 365);
            ball.XPosition = 618;
            

            //Testing different y values
            for (int i = 0; i < expectedValues.Length; i ++)
            {
                ball.YPosition = 10+i*92;
                ball.yDetection();
                float actualPosition = ball.PredictedYPosition;

                Assert.AreEqual(expectedValues[i], actualPosition);
                
            }
        }

        [TestMethod]
        public void paddleDetection_TouchingPaddleSituations_ReturnsOne()
        {
            Pong_PCC.Ball ball = new Pong_PCC.Ball(640, 480, 10, 10, 5, 60);

            int[] paddleYPositions = new int[3] {0, 210, 420};
            int[] ballYPositions = new int[] { 30, 220, 470 };


            ball.XPosition = 615;
            for (int i =0; i < paddleYPositions.Length; i++)
            {
                ball.YPosition = ballYPositions[i];
                int actual = ball.paddleDetection(paddleYPositions[i]);

                Assert.AreEqual(1, actual);
            }

            ball.XPosition = 15;
            for (int i = 0; i < paddleYPositions.Length; i++)
            {
                ball.YPosition = ballYPositions[i];
                int actual = ball.paddleDetection(paddleYPositions[i]);

                Assert.AreEqual(1, actual);
            }

        }

        [TestMethod]
        public void paddleDetection_MissingPaddleSituations_ReturnsNegativeOne()
        {
            Pong_PCC.Ball ball = new Pong_PCC.Ball(640, 480, 10, 10, 5, 60);

            //Sitations where ball is below and above paddle, and past paddle
            int[] paddleYPositions = new int[4] { 0, 210, 420,0 };
            int[] ballYPositions = new int[4] { 70, 10, 470,30 };
            int[] ballXPositions = new int[4] { 615, 15, 640, 0 };
            
            
            for (int i =0; i < paddleYPositions.Length; i ++)
            {
                ball.XPosition = ballXPositions[i];
                ball.YPosition = ballYPositions[i];
                int actual = ball.paddleDetection(paddleYPositions[i]);
                Assert.AreEqual(-1, actual);
            }
        }

        [TestMethod]
        public void paddleDetection_NotTouchingPaddleSituations_ReturnsZero()
        {
            Pong_PCC.Ball ball = new Pong_PCC.Ball(640, 480, 10, 10, 5, 60);

            int[] paddleYPositions = new int[5] { 0, 100,200, 300,420 };
            int[] ballYPositions = new int[5] { 30, 130, 230,330,450 };

            
            for (int i = 0; i < paddleYPositions.Length; i++)
            {
                ball.XPosition = 20 + 147.5f * i;
                ball.YPosition = ballYPositions[i];
                int actual = ball.paddleDetection(paddleYPositions[i]);
                Assert.AreEqual(0, actual);
            }
        }

        [TestMethod]
        public void ballRegenerationCheck_XPositionWithinLimits_ReturnsFalse()
        {
            Pong_PCC.Ball ball = new Pong_PCC.Ball(640, 480, 10, 10, 5, 60);
            int[] xPositions = new int[] { -10,15, 100, 400, 615,650 };

            for (int i = 0; i < xPositions.Length; i++)
            {
                ball.XPosition = xPositions[i];
                bool actual = ball.ballRegenerationCheck(1);

                Assert.IsFalse(actual);
            }
        }

        [TestMethod]
        public void sideDetection_HittingSides_ReturnsNegativeYDistance()
        {
            Pong_PCC.Ball ball = new Pong_PCC.Ball(640, 480, 10, 10, 5, 60);
            int[] xPositions = new int[] { 0,470};

            for (int i = 0; i < xPositions.Length; i++)
            {
                ball.YDistance = 1;
                ball.XPosition = xPositions[i];
                ball.sideDetection();

                Assert.AreEqual(-1, ball.YDistance);
            }

        }
    }
}
