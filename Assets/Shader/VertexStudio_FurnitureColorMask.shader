Shader "VertexStudio/FurnitureColorMask" {
	Properties {
		[NoScaleOffset] _Mask ("Mask (RGB)", 2D) = "black" {}
		[NoScaleOffset] _MainTex ("Diffuse", 2D) = "white" {}
		[NoScaleOffset] _Spec ("Specular", 2D) = "black" {}
		[NoScaleOffset] _Normal ("Normal", 2D) = "bump" {}
		[NoScaleOffset] _OcclusionMap ("Ambient Occlusion", 2D) = "white" {}
		_OcclusionStrength ("AO intensity", Range(0, 1)) = 1
		[NoScaleOffset] _Emission ("Emission", 2D) = "white" {}
		_ColorR ("Color (R)", Vector) = (1,1,1,1)
		_ColorG ("Color (G)", Vector) = (1,1,1,1)
		_ColorB ("Color (B)", Vector) = (1,1,1,1)
		[HDR] _EmissionColor ("EmissionColor", Vector) = (0,0,0,1)
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}