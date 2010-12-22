﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace PressPlay.FFWD.Import
{
    [ContentTypeSerializer]
    public class ColorTypeSerializer : ContentTypeSerializer<Color>
    {
        protected override Color Deserialize(IntermediateReader input, Microsoft.Xna.Framework.Content.ContentSerializerAttribute format, Color existingInstance)
        {
            string s = input.Xml.ReadContentAsString();
            if (s.Length != 8 && s.Length != 6)
            {
                throw new Exception("Color string must either be AARRGGBB or RRGGBB. Was: " + s);
            }
            Color c = new Color();
            if (s.Length == 8)
            {
                c.a = ParseHexData(s, 0);
                s = s.Substring(2);
            }
            c.r = ParseHexData(s, 0);
            c.g = ParseHexData(s, 2);
            c.b = ParseHexData(s, 4);
            return c;
        }

        private float ParseHexData(string s, int start)
        {
            return ((float)Int32.Parse(s.Substring(start, 2), System.Globalization.NumberStyles.HexNumber)) / 255f;
        }

        protected override void Serialize(IntermediateWriter output, Color value, Microsoft.Xna.Framework.Content.ContentSerializerAttribute format)
        {
            throw new NotImplementedException();
            //return ((int)(c.a * 255)).ToString("X") + ((int)(c.r * 255)).ToString("X") + ((int)(c.g * 255)).ToString("X") + ((int)(c.b * 255)).ToString("X");
        }
    }
}
