using System.Collections.Generic;

namespace EyeBleacher.DTOs
{
    public class Data
    {
        public string modhash { get; set; }
        public float dist { get; set; }
        public List<Child> children { get; set; }
        public string after { get; set; }
        public object before { get; set; }
    }
}