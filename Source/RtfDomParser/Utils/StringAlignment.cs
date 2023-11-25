﻿namespace RtfDomParser.Utils
{
    public enum StringAlignment
    {
        /// <summary>
        /// Specifies the text be aligned near the layout. In a left-to-right layout, the near position is left. In a right-to-left layout, the near position is right.
        /// </summary>
        Near = 0,

        /// <summary>
        /// Specifies that text is aligned in the center of the layout rectangle.
        /// </summary>
        Center = 1,

        /// <summary>
        /// Specifies that text is aligned far from the origin position of the layout rectangle. In a left-to-right layout, the far position is right. In a right-to-left layout, the far position is left.
        /// </summary>
        Far = 2
    }
}