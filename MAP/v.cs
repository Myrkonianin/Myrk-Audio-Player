using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP
{
    public static class v
    {
        public static List<string> files = new List<string>();
        public static List<string> f = new List<string>();
        public static string appdir = AppDomain.CurrentDomain.BaseDirectory;
        public static bool tagSongShow;
        public static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static string defpl = "-";

        public static string GetFileName(string name)
        {
            string[] tmp = name.Split('\\');
            return tmp[tmp.Length - 1];
        }
    }
}
