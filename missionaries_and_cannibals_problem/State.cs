using System;
using System.Collections.Generic;
using System.Text;

namespace missionaries_and_cannibals_problem
{
    public class State
    {
        private int cannibalLeft;
        private int cannibalRight;
        private int missionaryLeft;
        private int missionaryRight;
        private int cannibalBoat;
        private int missionaryBoat;
        private Position boat;

        private State parentState;

        public int CannibalBoat
        {
            get { return cannibalBoat; }
            set { cannibalBoat = value; }
        }

        public int MissionaryBoat
        {
            get { return missionaryBoat; }
            set { missionaryBoat = value; }
        }

        public State ParentState
        {
            get { return parentState; }
            set { parentState = value; }
        }

        public int CannibalLeft
        {
            get { return cannibalLeft; }
            set { cannibalLeft = value; }
        }
        public int CannibalRight
        {
            get { return cannibalRight; }
            set { cannibalRight = value; }
        }

        public int MissionaryLeft
        {
            get { return missionaryLeft; }
            set { missionaryLeft = value; }
        }

        public int MissionaryRight
        {
            get { return missionaryRight; }
            set { missionaryRight = value; }
        }

        public Position Boat
        {
            get { return boat; }
            set { boat = value; }
        }

        public State(int cannibalLeft, int missionaryLeft, Position boat, int cannibalRight, int missionaryRight, int cannibalBoat, int missionaryBoat)
        {
            this.cannibalLeft = cannibalLeft;
            this.missionaryLeft = missionaryLeft;
            this.boat = boat;
            this.cannibalRight = cannibalRight;
            this.missionaryRight = missionaryRight;
            this.cannibalBoat = cannibalBoat;
            this.missionaryBoat = missionaryBoat;
        }

        public bool IsGoal()
        {
            return cannibalLeft == 0 && missionaryLeft == 0 && boat == Position.RIGHT;
        }

        public bool IsValid()
        {
            if((cannibalLeft >= 0 && cannibalRight >= 0 && missionaryLeft >= 0 && missionaryRight >= 0 &&cannibalBoat >= 0 && missionaryBoat >= 0) &&
                (missionaryRight == 0 || cannibalRight == missionaryRight || cannibalRight == 0) &&
                (missionaryLeft == 0 || cannibalLeft == missionaryLeft || cannibalLeft == 0) && (cannibalBoat + missionaryBoat <= 2))
            {
                return true;
            }

            return false;
        }

        private void CheckState(List<State> children, State state  )
        {
            if (state.IsValid())
            {
                state.ParentState = this;
                children.Add(state);
            }
        }

        public List<State> GetChildren()
        {
            List<State> children = new List<State>();

            if (boat == Position.LEFT)
            {
                CheckState(children, new State(cannibalLeft-2, missionaryLeft,Position.LEFTTORIGHT, cannibalRight , missionaryRight, cannibalBoat+2, missionaryBoat));
                CheckState(children, new State(cannibalLeft, missionaryLeft -2, Position.LEFTTORIGHT, cannibalRight, missionaryRight, cannibalBoat, missionaryBoat+2));
                CheckState(children, new State(cannibalLeft -1, missionaryLeft -1, Position.LEFTTORIGHT, cannibalRight, missionaryRight, cannibalBoat+1, missionaryBoat+1));
                CheckState(children, new State(cannibalLeft-1, missionaryLeft, Position.LEFTTORIGHT, cannibalRight, missionaryRight, cannibalBoat+1, missionaryBoat));
                CheckState(children, new State(cannibalLeft, missionaryLeft-1, Position.LEFTTORIGHT, cannibalRight, missionaryRight, cannibalBoat, missionaryBoat+1));
            }

            if (boat == Position.LEFTTORIGHT)
            {
                
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHT, cannibalRight + 2, missionaryRight, cannibalBoat - 2, missionaryBoat));
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHT, cannibalRight, missionaryRight+2, cannibalBoat, missionaryBoat-2));
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHT, cannibalRight + 1, missionaryRight+1, cannibalBoat - 1, missionaryBoat-1));
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHT, cannibalRight + 1, missionaryRight, cannibalBoat - 1, missionaryBoat));
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHT, cannibalRight , missionaryRight+1, cannibalBoat -1, missionaryBoat));
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHTTOLEFT, cannibalRight-1, missionaryRight+2, cannibalBoat+1, missionaryBoat-2));
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHTTOLEFT, cannibalRight+2, missionaryRight - 1, cannibalBoat -2, missionaryBoat+1));

            }

            if(boat == Position.RIGHT)
            {
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHTTOLEFT, cannibalRight - 2, missionaryRight, cannibalBoat + 2, missionaryBoat));
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHTTOLEFT, cannibalRight, missionaryRight-2 , cannibalBoat, missionaryBoat+2));
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHTTOLEFT, cannibalRight - 1, missionaryRight-1, cannibalBoat + 1, missionaryBoat+1));
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHTTOLEFT, cannibalRight - 1, missionaryRight, cannibalBoat + 1, missionaryBoat));
                CheckState(children, new State(cannibalLeft, missionaryLeft, Position.RIGHTTOLEFT, cannibalRight , missionaryRight-1, cannibalBoat, missionaryBoat+1));
           
            }

            if(boat == Position.RIGHTTOLEFT)
            {
                CheckState(children, new State(cannibalLeft + 2, missionaryLeft, Position.LEFT, cannibalRight, missionaryRight, cannibalBoat - 2, missionaryBoat));
                CheckState(children, new State(cannibalLeft, missionaryLeft+2, Position.LEFT, cannibalRight, missionaryRight, cannibalBoat, missionaryBoat-2));
                CheckState(children, new State(cannibalLeft + 1, missionaryLeft+1, Position.LEFT, cannibalRight, missionaryRight, cannibalBoat - 1, missionaryBoat-1));
                CheckState(children, new State(cannibalLeft + 1, missionaryLeft, Position.LEFT, cannibalRight, missionaryRight, cannibalBoat - 1, missionaryBoat));
                CheckState(children, new State(cannibalLeft, missionaryLeft+1, Position.LEFT, cannibalRight, missionaryRight, cannibalBoat, missionaryBoat-1));
                CheckState(children, new State(cannibalLeft + 1, missionaryLeft - 2, Position.LEFTTORIGHT, cannibalRight, missionaryRight, cannibalBoat - 1, missionaryBoat + 2));
                CheckState(children, new State(cannibalLeft - 2, missionaryLeft + 1, Position.LEFTTORIGHT, cannibalRight, missionaryRight, cannibalBoat + 2, missionaryBoat - 1));
            }

            return children;
        }

    }
}
