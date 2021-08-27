using System.Collections.Generic;

namespace DPcode.Core.Models
{
    public class Utils
    {
        public static int GetMaxId(List<IIdentifyable> list)
        {
            int max = 0;
            foreach (IIdentifyable item in list)
            {
                int id = (item.GetId() ?? 0);
                if (id > max)
                {
                    max = id;
                }
            }
            return max;
        }
        
    }
}