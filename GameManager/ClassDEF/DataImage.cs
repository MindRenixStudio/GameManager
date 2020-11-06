using System;
using System.Collections.Generic;
using System.Text;

namespace GameManager.ClassDEF
{
    public class DataImage
    {
        public string GameName { get; set; } //Mandatory
        public int Rating { get; set; } //Mandatory
        public int Playtime { get; set; } //Optional
        public string Style { get; set; } //Optional // COOP | SOLO
        public string Status { get; set; } //Finished | Playing | Plan to play | Pre-ordered
    }
}
