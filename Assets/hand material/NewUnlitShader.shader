Shader "Custom/InvisibleOccluder"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        // Set the rendering order and other tags
        Tags { "RenderType"="Opaque" "Queue"="Geometry+1" }

        Pass
        {
            // Stencil operations
            Stencil
            {
                Ref 1                // Reference value written to the stencil buffer
                Comp always          // Always pass the stencil test
                Pass replace         // Replace stencil value with Ref
            }

            // Make the surface itself invisible
            ColorMask 0            // Don't write to the color buffer (invisible)
            ZWrite On              // Still write to the depth buffer
        }
    }
}
