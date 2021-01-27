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

    Transform[] points;//[動畫部分]

    void Awake()
    {
        //int i = 0;(用while時要定義)
        float step = 2f / resolution;//讓位子範圍保持在-1~1之間
        var scale = Vector3.one / 5f * step;//為了不用重複打 Vector3.one /5f
        var position = Vector3.zero;//將未分配的yz座標值設為零//Vector3 position;//簡短程式碼

        points = new Transform[resolution];//[動畫部分]

        for (int i=0; i< points.Length; i++)//while轉for//while (i<10)//while執行多次(執行10次)
        {
            //i++;
            Transform point = Instantiate(pointPrefab);//將預置物(Prefab)加入場景
            //Transform point 給他一個變數來追蹤
            //point.localPosition = Vector3.right * ((i + 0. 5f) / 5f - 1f);//將localPosition分配給3D向量，right將物件右移一個單位
            //*i將方塊位置生成在右邊i個單位的地方 實際座標-1~0,8
            //使其範圍在-1~1之間(i/5f-1f) 實際座標-1~1
            //讓其貼齊-1~1((i+0,5f)/5f-1f)
            position.x = (i+0.5f) * step - 1f;
            //position.y = position.x;//使用x定義y(xy值相同f(x)=x)
            //position.y = position.x * position.x;//f(x)=x^2
            //position.y = position.x * position.x * position.x;//f(x)=x^3
            point.localPosition = position;
            //i++;//為了將開始位子定在原點(用while時要寫)
            point.localScale = scale;//Vector3.one / 5f;//將物件大小除以5，同時將位移也除以5
            point.SetParent(transform,false);//設置父子關係，使point全為Graph的子物件
                                             //設置父子關係unity會將物件嘗試保持其在原世界的值(position,rotate,scale)，不需要則打false

            //[動畫部分]
            points[i] = point;

        }

        //Transform point = Instantiate(pointPrefab);point不能重複定義，改成下面那行
        //point = Instantiate(pointPrefab);
        //point.localPosition = Vector3.right * 2f;
    }

    //[動畫部分]
    void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;//獲取point的位置
            //position.y = position.x * position.x * position.x;同之前的作法
            //position.y = Mathf.Sin（position.x）;
            //Mathf空間中的結構，包含函數及常量集合，可使用float
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            //每隔2π=6.28重複一次
            //Time.time隨時間推移沿-x方向移動
            point.localPosition = position;
        }
    }
}
