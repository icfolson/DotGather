using DotGather.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotGather.GatherContent.Objects
{
    public class SectionField : ISectionField
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public static implicit operator SectionField (Field field)
        {
            return new SectionField
            {
                Type = "section",
                Name = field.Name,
                Title = field.Title,
                Subtitle = field.Subtitle
            };

        }
    }
}
