using UnityEngine;
using UnityEngine.UI;  // 引用 介面 API
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    [Header("分數介面")]
    public Text textScore;
    [Header("分數")]
    public int score=0;
    [Header("加的分數")]
    public int scoreIn = 1;
    [Header("時間字樣")]
    public Text T_timeText;
    [Header("開始開關")]
    public bool start=false;

    public float T_time = 30;
    
    public void StartGame()
    {
        T_time = 30;
        score = 0;
        start = true;
        
    }
    
    void Update()
    {
        if (start == true)
        {


            T_time -= Time.deltaTime;
            T_timeText.text = "Time:" + T_time.ToString("0.0");
            print(T_timeText);
        }
        if (T_time <= 0) { start = false; }
    }
    bool t, c, k, f;

    
    // OTE 條件：
    // 兩個碰撞物件 其中一個 必須勾選 IsTrigger
    // 要偵測此腳本子物件是否產生碰撞
    // 必須添加剛體 Rigidbody
    private void OnTriggerEnter(Collider other)
    {
        // 如果 碰撞物件的標籤 為 籃球 就加分 並且 籃球 的 高度 > 2.5
        

        if (other.tag == "Tray")
        {
            t = true;
        }
        if(other.tag=="coke")
        {
            c = true; 
        }
        else if (other.tag == "ketchup") { k = true; }
        else if (other.tag == "fries") { f = true; }

        if (t == true)
        {
            if (c == true) {
                if (k == true) { scoreIn = 2; }
                else if (f == true) { scoreIn = 2; }
                else { scoreIn = 1; } 
            }
            if (k == true) {
                if (c == true) { scoreIn = 2; }
                else if (f == true) { scoreIn = 2; }
                else { scoreIn = 1; }
            }
            if (f == true) {
                if (k == true) { scoreIn = 2; }
                else if (c == true) { scoreIn = 2; }
                else { scoreIn = 1; }
           }
            if (c == true && k == true && f == true) { scoreIn = 6; }
            AddScore();
        }
        // 如果 碰撞的根物件名稱為 Player
        if (other.transform.root.name == "Player")
        {
            
        }
    }

    // 當碰撞物件離開碰撞範圍時執行一次
    private void OnTriggerExit(Collider other)
    {
        t = false;
        c = false;
        k = false;
        f = false;
    }

    /// <summary>
    /// 加分數
    /// </summary>
    private void AddScore()
    {
        score += scoreIn;                                   // 分數遞增 投進的分數
        textScore.text = "Score：" + score;                   // 更新介面
          
    }
}
