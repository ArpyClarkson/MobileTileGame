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
        
        if(value == 1) return float3(1,0,0);
        if(value == 2) return float3(0,1,0);
        if(value == 3) return float3(0,0,1);

        return 0;

        return float4(frac(i.uv*float2(9,13)), 0, 0);
    }
    ENDCG
}

}}
