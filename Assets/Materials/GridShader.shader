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

    uint grid[1024];
    float2 gridSize;
    
    fixed3 frag(v2f i) : SV_Target {
        //i.uv.y = (i.uv.y+_Time.x*(floor(i.uv.x*gridSize.x) - gridSize.x/2.f))%1.0f;
        uint2 index = abs(i.uv)*gridSize;
        uint value = grid[index.x + gridSize.x*index.y];

        float3 result = 0;
        if(value == 1) result = float3(1,0,0);
        if(value == 2) result = float3(0,1,0);
        if(value == 3) result = float3(0,0,1);
        if(value == 4) result = float3(1,0,1);

        float2 fr = frac(i.uv*gridSize);
        fr = float2(distance(fr.x, 0.5f), distance(fr.y, 0.5f));
        float m = 1.f-max(fr.x, fr.y);
        if(m > 0.52f && value != 0) return result*m*m*m;

        i.uv *= 3.14f;
        return float3(
            sin(i.uv.x-i.uv.y+_Time.y) * ((i.uv.x + i.uv.y+_Time.x)%1.f),
            cos(-i.uv.x+i.uv.y+_Time.y) * ((i.uv.x - i.uv.y+_Time.x)%1.f),
            sin(i.uv.x+i.uv.y+_Time.y) * ((-i.uv.x - i.uv.y+_Time.x)%1.f)
        );
    }
    ENDCG
}

}}
