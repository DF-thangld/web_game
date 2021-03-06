﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class MovingCommandLandingTimeComparer:IComparer<MovingCommand>
    {
        #region IComparer<MovingCommand> Members

        public int Compare(MovingCommand x, MovingCommand y)
        {
            return (int)(x.LandingTime - y.LandingTime).TotalMilliseconds;
        }

        #endregion
    }
}
