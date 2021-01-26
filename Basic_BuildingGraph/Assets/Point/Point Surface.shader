//Point Surface(material)要拉到 Point預置物上
Shader "Graph/Point Surface"//著色器語法類似 C# 新增方法:Assets / Create / Shader / Standard Surface Shader
{
    Properties{//設置平滑度標籤
        _Smoothness("Smoothness", Range(0,1)) = 0.5//範圍0~1，預設0.5
    }
    SubShader//子著色器，可有多個
    {
        CGPROGRAM//表面著色器的子著色器需要用CGPROGRAM和ENDCG關鍵字括起來。
            #pragma surface ConfigureSurface Standard fullforwardshadows//支持陰影
            #pragma target 3.0//此指令將各項值設置了最小值

            struct Input {//設置色塊結構，圖形移動會影響顏色
                float3 worldPos;
            };

            float _Smoothness;
            void ConfigureSurface(Input input, inout SurfaceOutputStandard surface)//Input輸入參數，SurfaceOutputStandard配置數據
            {
                surface.Albedo.rg = input.worldPos.xy * 0.5 + 0.5;//根據位置著色x紅色y綠色z藍色
                //* 0.5 + 0.5負數無意義，所以要變成正的
                //因z都接近零，所以藍色都接近0.5，指定反射僅通過紅綠通道使其消除藍色(.rg)，指使用xy值(.xy)
                surface.Smoothness = _Smoothness;//0.5;//讓其看起來像預設材質(光滑度0.5)
            }
        ENDCG//表面著色器的子著色器需要用CGPROGRAM和ENDCG關鍵字括起來。
    }
    FallBack "Diffuse"//添加到標準著色器
}
