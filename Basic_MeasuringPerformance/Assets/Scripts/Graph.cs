using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]//使物件能附上附加屬性(將物件拉給此變數，類似給物件一個別名)
    Transform pointPrefab = default;//Transform挑整此屬性(旋轉/位移)
    //default給他一個默認值才不會跳警告
    [SerializeField,Range(10,100)]//數量必須介於10~100
    int resolution = 10;//能自行定義生成數量(預設10)
    //[SerializeField, Range(0, 2)]
    [SerializeField]
    FunctionLibrary.FunctionName function = default;

    Transform[] points;//[動畫部分]

    void Awake()
    {
        
        float step = 2f / resolution;
        //var scale = Vector3.one / 5f * step;
        var scale = Vector3.one * step;
        //var position = Vector3.zero;

        points = new Transform[resolution * resolution];

        for (int i=0/*, x = 0, z = 0*/; i< points.Length; i++/*,x++*/)
        {
            //if (x == resolution)
            //{
            //    x = 0;
            //    z += 1;
            //}
            Transform point = Instantiate(pointPrefab);
            //position.x = (x + 0.5f) * step - 1f;
            //position.z = (z + 0.5f) * step - 1f;
            //point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform,false);

            points[i] = point;

        }

    }

    //[動畫部分]
    /*void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);

        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            //if (function == 0)
            //{
            //    position.y = FunctionLibrary.Wave(position.x, time);
            //}
            //else if (function == 1)
            //{
            //    position.y = FunctionLibrary.MultiWave(position.x, time);
            //}
            //else
            //{
            //    position.y = FunctionLibrary.Ripple(position.x, time);
            //}改成下面一行
            position.y = f(position.x, position.z, time);

            point.localPosition = position;
        }
    }*/
    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float time = Time.time;
        float step = 2f / resolution;
        float v = 0.5f * step - 1f;
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            //float v = (z + 0.5f) * step - 1f;
            points[i].localPosition = f(u, v, time);
        }
    }
}
