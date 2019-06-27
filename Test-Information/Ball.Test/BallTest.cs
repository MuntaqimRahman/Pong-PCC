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
            //Expected values and ball initialized with current settings
            float[] expectedValues = new float[6] {126,34,58,150,242,334}; //Expected Values derived from theory and experimentation
            Pong_PCC.Ball ball = new Pong_PCC.Ball(640, 480, 10, 10, 5, 60);

            //yDistance and xDistance constant - always starting from xPosition 618
            ball.YDistance = 4;
            ball.XDistance = 3 * (480 / 365);
            ball.XPosition = 618;
            

            //Testing different y values
            for (int i = 0; i < 6; i ++)
            {
                ball.YPosition = 10+i*92;
                ball.yDetection();
                float actualPosition = ball.PredictedYPosition;

                Assert.AreEqual(expectedValues[i], actualPosition);
                
            }





        }
    }
}
