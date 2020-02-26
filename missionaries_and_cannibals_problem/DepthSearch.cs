using System;
using System.Collections.Generic;
using System.Text;

namespace missionaries_and_cannibals_problem
{
    public class DepthSearch
    {

        public State IDDFS(State startState)
        {
           for(int i=1; ; i++)
            {
                var result = DLS(startState, i);

                if (result != null)
                {
                    return result;
                }
            }
        }

        public State DLS(State state, int limit)
        {

            if (state.IsGoal()&& limit ==0)
            {
                return state;
            }
            else
            {
                if(limit > 0 )
                {
                    List<State> children = state.GetChildren();

                    foreach (var child in children)
                    {
                        State result = DLS(child, limit - 1);

                        if (result != null)
                        {
                            return result;
                        }
                    }
                }
            }

            return null;
        }
    }
}
