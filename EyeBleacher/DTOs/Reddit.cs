using System.Collections.Generic;

namespace EyeBleacher.DTOs
{
    public class Reddit
    {
        public string modhash { get; set; }
        public float dist { get; set; }
        public List<Subreddit> Subreddits { get; set; }
        public string after { get; set; }
        public object before { get; set; }
    }
}