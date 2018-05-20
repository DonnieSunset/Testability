using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SubclassToTest.Test
{
    [TestClass]
    public class TimeDisplayTestStubSubclass : TimeDisplay
    {
        #region Behaviour modification for Testability

        /// <summary>
        /// Override to be able to set a specific time
        /// </summary>
        public override DateTime GetCurrentTime()
        {
            DateTime myTime = new DateTime(1990, 10, 10, 12, 0, 0, 0);
            myTime.AddHours(this.Hours);
            myTime.AddMinutes(this.Minutes);
            return myTime;
        }

        /// <summary>
        /// Point of Control
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// Point of Control
        /// </summary>
        public int Minutes { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Test_DisplayCurrentTime_AtMidnight()
        {
            // arrange
            //var theTimeDisplay = new TimeDisplay();     //will fail in most of the runs since depends on real time

            //arrange
            var theTimeDisplay = new TimeDisplayTestStubSubclass()
            {
                Hours = 12,
                Minutes = 0
            };

            // act
            String actualTimeString =
                  theTimeDisplay.DisplayCurrentTime();

            // assert
            Assert.AreEqual("Midnight", actualTimeString);
        }
    }
}
