Shader "GridShader" {
SubShader {

Cull Off ZWrite Off ZTest Always

Pass {
    CGPROGRAM
    #pragma vertex vert
    #pragma fragment frag
    #include "UnityCG.cginc"

    struct appdata {
        float4 vertex : POSITION;
        float2 uv : TEXCOORD0;
    };

    struct v2f {
        float2 uv : TEXCOORD0;
        float4 vertex : SV_POSITION;
    };

    v2f vert(appdata v) {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        o.uv = v.uv;
        return o;
    }

    uint _grid[1024];
    

    fixed3 frag(v2f i) : SV_Target {
        float2 GridSize = float2(9,13);
        uint2 index = i.uv*GridSize;
        uint value = _grid[index.x + GridSize.x*index.y];

        float3 result = 0;
        if(value == 1) result = float3(1,0,0);
        if(value == 2) result = float3(0,1,0);
        if(value == 3) result = float3(0,0,1);

        float2 fr = frac(i.uv*GridSize);
        fr = float2(distance(fr.x, 0.5f), distance(fr.y, 0.5f));
        float m = 1.f-max(fr.x, fr.y);
        if(m > 0.52f) return result*m*m*m;
        return sin(_Time.w + i.uv.x + i.uv.y);

        return float4(frac(i.uv*float2(9,13)), 0, 0);
    }
    ENDCG
}

}}
