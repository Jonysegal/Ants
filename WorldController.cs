using System;
using System.Collections.Generic;
using System.Text;

namespace deee
{
    public static class WorldController
    {
        /// <summary>
        /// This class is responsible for the following initiation:
        /// 1) Add rivers
        /// 2) Add anthills
        /// 3) Add food
        /// 4) Initialize and add ants
        /// 
        /// This class is responsible for the following on loop:
        /// 1) Process Ants
        /// </summary>
        /// 

        static AntMemory antOne = new AntMemory() { Location = new Point(0, 450), LastDestination = new Point(0, -450) };

        public static void Initialize()
        {
            RiverMaker.MakeRiver(new Point(0, 0));
            Map.AddAntAt(antOne.Location);
        }

        public static void Loop()
        {
            AntBrain.MoveAntToGoal(antOne);
        }
    }
}
