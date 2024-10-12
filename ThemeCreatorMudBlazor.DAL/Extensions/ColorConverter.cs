﻿using System.Globalization;
using System.Text.RegularExpressions;

namespace ThemeCreatorMudBlazor.DAL.Extensions
{
    public static partial class ColorConverter
    {
        public static string ToHex(string colorValue)
        {
            if (string.IsNullOrWhiteSpace(colorValue))
                return "#000000"; // Default to black if no value provided

            // Check if it's already a hex value
            if (colorValue.StartsWith('#'))
                return colorValue.ToUpper();

            // Handle rgb/rgba format
            if (colorValue.StartsWith("rgb"))
            {
                var matches = MyRegex().Matches(colorValue);
                if (matches.Count >= 3)
                {
                    byte r = ParseColorComponent(matches[0].Value);
                    byte g = ParseColorComponent(matches[1].Value);
                    byte b = ParseColorComponent(matches[2].Value);
                    return $"#{r:X2}{g:X2}{b:X2}".ToUpper();
                }
            }

            // Handle named colors
            try
            {
                var color = System.Drawing.ColorTranslator.FromHtml(colorValue);
                return $"#{color.R:X2}{color.G:X2}{color.B:X2}".ToUpper();
            }
            catch
            {
                // If it's not a valid color name, continue to the next check
            }

            // If it's a double (for opacity values), convert to an 8-bit integer representation
            if (double.TryParse(colorValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleValue))
            {
                int intValue = (int)(doubleValue * 255);
                return $"#{intValue:X2}{intValue:X2}{intValue:X2}".ToUpper();
            }

            // If we can't parse it, return black
            return "#000000";
        }

        private static byte ParseColorComponent(string component)
        {
            if (double.TryParse(component, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                // If the value is between 0 and 1, assume it's a percentage and multiply by 255
                if (value <= 1)
                    value *= 255;
                return (byte)Math.Clamp(value, 0, 255);
            }
            return 0;
        }

        [GeneratedRegex(@"(\d*\.?\d+)")]
        private static partial Regex MyRegex();
    }
}