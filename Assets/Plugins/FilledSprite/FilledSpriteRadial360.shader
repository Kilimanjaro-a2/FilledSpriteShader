Shader "Unlit/FilledSpriteRadial360"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _FillOriginY("FillOriginY", Float) = 0
        _FillOriginX("FillOriginX", Float) = 0
        [MaterialToggle] _Clockwise("Clockwise", Float) = 0
        _FillAmount("FillAmount", Range(0, 1)) = 1.0
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "AlphaTest"
        }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            static const float PI = 3.14159265f;
            
            fixed4 _Color;
            float _FillAmount;
            float _FillOriginX;
            float _FillOriginY;
            float _Clockwise;

            fixed4 frag (v2f i) : SV_Target
            {
                float2 pos = (i.uv - float2(0.5, 0.5)) * 2.0;
                float angle = (atan2(pos.y, pos.x) - atan2(_FillOriginY, _FillOriginX)) / (PI * 2);
                float correctedAngle = lerp(angle + 1.0, angle, step(0, angle));
                int clockwiseBit = step(1, _Clockwise);
                float fillAmount = lerp(1 - _FillAmount, _FillAmount, step(clockwiseBit, 0));                
                clip(lerp(clockwiseBit, 1 - clockwiseBit, step(correctedAngle, fillAmount)) - 1);

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return tex2D(_MainTex, i.uv) * _Color;
            }
            ENDCG
        }
    }
}