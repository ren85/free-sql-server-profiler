using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace AnfiniL.SqlExpressProfiler.VisualStyles
{
    public static class VisualStyleUtils
    {
        public static Color GetColor(VisualStyleElement element, ColorProperty colorProperty, Color defaultColor)
        {
            if(VisualStyleRenderer.IsSupported && VisualStyleRenderer.IsElementDefined(element))
            {
                return new VisualStyleRenderer(element).GetColor(colorProperty);
            }
            else
            {
                return defaultColor;
            }
            
        }
    }
}
