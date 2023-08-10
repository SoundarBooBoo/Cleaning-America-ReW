// Toony Colors Free
// (c) 2012,2016 Jean Moreno


// Want more features ? Check out Toony Colors Pro+Mobile 2 !
// http://www.jeanmoreno.com/toonycolorspro/


Shader "Toony Colors Free/Rim BumpSpec"
{
	Properties
	{
		//TOONY COLORS
		_Color ("Color", Color) = (0.5,0.5,0.5,1.0)
		_HColor ("Highlight Color", Color) = (0.6,0.6,0.6,1.0)
		_SColor ("Shadow Color", Color) = (0.3,0.3,0.3,1.0)
		
		//DIFFUSE
		_MainTex ("Main Texture (RGB)", 2D) = "white" {}
		_BumpMap ("Bumpmap", 2D) = "bump" {}
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
    	[PowerSlider(5.0)] _Shininess ("Shininess", Range (0.01, 1)) = 0.07812

		//TOONY COLORS RAMP
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}
		
		//RIM LIGHT
		_RimColor ("Rim Color", Color) = (0.8,0.8,0.8,0.6)
		_RimMin ("Rim Min", Range(0,1)) = 0.5
		_RimMax ("Rim Max", Range(0,1)) = 1.0
		
		
	}
	
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		
		CGPROGRAM
		
		#pragma surface surf ToonyColorsCustom
		#pragma target 2.0
		#pragma glsl
		
		
		//================================================================
		// VARIABLES
		
		fixed4 _Color;
		sampler2D _MainTex;
		sampler2D _BumpMap;
		fixed _Shininess;
		fixed4 _RimColor;
		fixed _RimMin;
		fixed _RimMax;
		float4 _RimDir;
		
		struct Input
		{
			half2 uv_MainTex;
			float2 uv_BumpMap : TEXCOORD1;
			float3 viewDir;
		};
		
		//================================================================
		// CUSTOM LIGHTING
		
		//Lighting-related variables
		fixed4 _HColor;
		fixed4 _SColor;
		sampler2D _Ramp;
		
		//Custom SurfaceOutput
		struct SurfaceOutputCustom
		{
			fixed3 Albedo;
			fixed3 Normal;
			fixed3 Emission;
			half Specular;
			fixed Gloss;
			fixed Alpha;
		};
		
		inline half4 LightingToonyColorsCustom (SurfaceOutputCustom s, half3 lightDir, half3 viewDir, half atten)
		{
			s.Normal = normalize(s.Normal);
			fixed ndl = max(0, dot(s.Normal, lightDir)*0.5 + 0.5);
			
			fixed3 ramp = tex2D(_Ramp, fixed2(ndl,ndl));
		#if !(POINT) && !(SPOT)
			ramp *= atten;
		#endif
			_SColor = lerp(_HColor, _SColor, _SColor.a);	//Shadows intensity through alpha
			ramp = lerp(_SColor.rgb,_HColor.rgb,ramp);
			//Specular
			half3 h = normalize(lightDir + viewDir);
			float ndh = max(0, dot (s.Normal, h));
			float spec = pow(ndh, s.Specular*128.0) * s.Gloss * 2.0;
			spec *= atten;

			fixed4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * ramp;
			c.a = s.Alpha;
		#if (POINT || SPOT)
			c.rgb *= atten;
		#endif
			c.rgb *= 2;
			c.rgb += _LightColor0.rgb * _SpecColor.rgb * spec;
			c.a = s.Alpha + _LightColor0.a * _SpecColor.a * spec;
			return c;
		}
		
		
		//================================================================
		// SURFACE FUNCTION
		
		void surf (Input IN, inout SurfaceOutputCustom o)
		{
			fixed4 mainTex = tex2D(_MainTex, IN.uv_MainTex);
			
			o.Albedo = mainTex.rgb * _Color.rgb;
			//o.Alpha = mainTex.a * _Color.a;
			o.Gloss =  mainTex.a;
			o.Specular = _Shininess;
			//Normal map
			o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
			//Rim
			float3 viewDir = normalize(IN.viewDir);
			//half rim = clamp((1.0f - saturate( dot(viewDir, o.Normal))),0,1);
			half rim = 1.0f - saturate( dot(viewDir, o.Normal));
			rim = smoothstep(_RimMin, _RimMax, rim );
			o.Emission += (_RimColor.rgb * rim) * _RimColor.a;
		}
		
		ENDCG
	}
	
	Fallback "Diffuse"
	CustomEditor "TCF_MaterialInspector"
}
