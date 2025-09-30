Shader "Custom/XRayShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DensityMap ("Density Map", 2D) = "white" {}
        _ScanIntensity ("Scan Intensity", Range(0, 1)) = 0.5
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _MainTex;
            sampler2D _DensityMap;
            float _ScanIntensity;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed density = tex2D(_DensityMap, i.uv).r;
                
                // X-ray effect: show different colors based on density
                if (density > 0.8)
                    return fixed4(1, 0, 0, 1) * _ScanIntensity; // High density = red
                else if (density > 0.5)
                    return fixed4(1, 1, 0, 1) * _ScanIntensity; // Medium density = yellow
                else
                    return fixed4(0, 1, 1, 1) * _ScanIntensity; // Low density = cyan
            }
            ENDCG
        }
    }
}
