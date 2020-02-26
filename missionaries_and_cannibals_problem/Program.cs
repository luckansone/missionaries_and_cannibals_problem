using System;
using System.Collections.Generic;

namespace missionaries_and_cannibals_problem
{
    class Program
    {
        static void Main(string[] args)
        {
            State startState = new State(3, 3, Position.LEFT, 0, 0,0,0);
            DepthSearch search = new DepthSearch();
            State result = search.IDDFS(startState);
            Print(result);
            Console.ReadKey();
        }

        public static void Print(State result)
        {
            if(result == null)
            {
                Console.WriteLine("There is no solution.");
            }
            else
            {
                List<State> path = new List<State>();
                State state = result;
                
                while (state != null)
                {
                    path.Add(state);
                    state = state.ParentState;
                }

                int depth = path.Count - 1;

                for(int i =depth; i >= 0; i--)
                {
                    state = path[i];
                  
                    Console.WriteLine("cannibalsLeft:{0}, missionariesLeft: {1}, boat:{2}, cannibalsBoat:{3}, missionariesBoat: {4}, " +
                                        "cannibalsRight: {5}, missionariesRight: {6} ",
                                        state.CannibalLeft, state.MissionaryLeft, state.Boat, state.CannibalBoat, state.MissionaryBoat, state.CannibalRight, state.MissionaryRight);
                    Console.WriteLine();
                }

                Console.WriteLine("Depth: {0}", depth);
            }
        }
    }
}
