using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2008
{
    public enum PopupAnimations
    {
        // Summary:
        //     Uses no animation.
        None = 0,
        //
        // Summary:
        //     Animates the window from left to right. This flag can be used with roll or
        //     slide animation.
        LeftToRight = 1,
        //
        // Summary:
        //     Animates the window from right to left. This flag can be used with roll or
        //     slide animation.
        RightToLeft = 2,
        //
        // Summary:
        //     Animates the window from top to bottom. This flag can be used with roll or
        //     slide animation.
        TopToBottom = 4,
        //
        // Summary:
        //     Animates the window from bottom to top. This flag can be used with roll or
        //     slide animation.
        BottomToTop = 8,
        //
        // Summary:
        //     Makes the window appear to collapse inward if it is hiding or expand outward
        //     if the window is showing.
        Center = 16,
        //
        // Summary:
        //     Uses a slide animation.
        Slide = 262144,
        //
        // Summary:
        //     Uses a fade effect.
        Blend = 524288,
        //
        // Summary:
        //     Uses a roll animation.
        Roll = 1048576,
        //
        // Summary:
        //     Uses a default animation.
        SystemDefault = 2097152,
    }
}
