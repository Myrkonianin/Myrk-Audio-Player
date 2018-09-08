using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass.AddOn.Tags;
namespace MAP
{
    public class TagModel
    {
        public int bitRate;
        public int freq;
        public string artist;
        public string title;
        public string album;

        //Dictionary<int, string> ChannelDict = new Dictionary<int, string>()
        //{
        //    {0, "None" },
        //    {1, "Mono" },
        //    {2, "Stereo"}
        //};

        public TagModel(string file)
        {
            TAG_INFO ti = new TAG_INFO();
            ti = BassTags.BASS_TAG_GetFromFile(file);
            bitRate = ti.bitrate;
            freq = ti.channelinfo.freq;
            artist = ti.artist;
            album = ti.album;
            title = ti.title;
            //if(ti.title == " ")
            //{
            //    title = v.GetFileName(file);
            //}
        }
    }
}
