using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SubclassToTest.Test
{
    [TestClass]
    public class TimeDisplayTestStubSubclass : TimeDisplay
    {
        #region Behaviour modification for Testability

        /// <summary>
        /// Override to be able to set a specific time
        /// </summary>
        public new string GetCurrentTime()
        {
            DateTime myTime = new DateTime(1990, 10, 10, 0, 0, 0, 0);
            myTime.AddHours(this.Hours);
            myTime.AddMinutes(this.Minutes);
            return myTime.ToString();
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
                  theTimeDisplay.GetCurrentTime();

            // assert
            Assert.AreEqual("Midnight", actualTimeString);
        }
    }
}
