using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.GuildHelperr
{
    public class GuildHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
