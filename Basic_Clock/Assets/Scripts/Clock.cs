using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]//使物件能附上附加屬性(將物件拉給此變數，類似給物件一個別名)
    Transform hoursPivot = default, minutesPivot = default, secondsPivot = default;//Transform挑整此屬性(旋轉/位移)
    //default給他一個默認值才不會跳警告
    //[SerializeField]如上合併再一起
    //Transform minutesPivot;
    //[SerializeField]
    //Transform secondsPivot;

    const float hoursToDegress = -30f, minutesToDegress = -6f, secondsToDegress = -6f;//f確保是type型態，const強制執行使其變成量而非字段
    void Updata()//Awake()可自己命名(就是函式啦)
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        //Debug.Log(DateTime.Now.Hour);移到下面
        hoursPivot.localRotation = Quaternion.Euler(0f,0f,hoursToDegress* (float)time.TotalHours);//Quaternion用於表示3D旋轉
        //localRotation父級旋轉，rotation整個物件旋轉
        minutesPivot.localRotation = Quaternion.Euler(0f,0f,minutesToDegress* (float)time.TotalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0f,0f,secondsToDegress* (float)time.TotalSeconds);
    }
}
