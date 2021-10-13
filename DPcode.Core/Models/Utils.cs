using System.Collections.Generic;

namespace DPcode.Core.Models
{
    public class Utils
    {
        public static int GetMaxId<T>(List<T> list) where T : Identifyable
        {
            int max = 0;
            foreach (Identifyable item in list)
            {
                int id = (item.id ?? 0);
                if (id > max)
                {
                    max = id;
                }
            }
            return ++max;
        }
    }
}