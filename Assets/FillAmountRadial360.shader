Shader "Sprites/FillAmountRadial360" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_FillOriginY("FillOriginY", Float) = 0
		_FillOriginX("FillOriginX", Float) = 0
		[MaterialToggle] _Clockwise("Clockwise", Float) = 0
		_FillAmount("FillAmount", Range(0, 1)) = 1.0
	}
	SubShader{
		Tags { "RenderType" = "Opaque" "Queue" = "Transparent" }
		Lighting Off
		LOD 200

		CGPROGRAM

		#pragma surface surf NoLighting alpha:fade

		#pragma target 3.0

		static const float PI = 3.14159265f;

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};
		
		fixed4 _Color;
		float _FillAmount;
		float _FillOriginX;
		float _FillOriginY;
		float _Clockwise;

		void surf(Input IN, inout SurfaceOutput o) {
			float2 pos = (IN.uv_MainTex - float2(0.5, 0.5)) * 2.0;
			float subtrahend = atan2(pos.y, pos.x);
			float minuend = atan2(_FillOriginY, _FillOriginX);
			float angle = (subtrahend - minuend) / (PI * 2);
			angle = lerp(angle + 1.0, angle, step(0, angle));

			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;

			float appearDirection = lerp(1, -1, step(_Clockwise, 0));
			float fillAmount = lerp(1 - _FillAmount, _FillAmount, step(_Clockwise, 0));
			float cutoff = lerp(_Clockwise, 1 - _Clockwise, step(angle, fillAmount));
			o.Alpha = _Color.a * cutoff;
		}

 		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
		{
			return fixed4(s.Albedo, s.Alpha);
		}
		ENDCG
	}
	FallBack "Diffuse"
}