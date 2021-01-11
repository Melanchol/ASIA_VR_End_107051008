using UnityEngine;
using UnityEngine.UI;   // 引用 介面 API

public class ScoreManager : MonoBehaviour
{
    [Header("分數介面")]
    public Text textScore;
    [Header("分數")]
    public int score;
    [Header("投進的分數")]
    public int scoreIn = 2;
    [Header("進球音效")]
    public AudioClip soundIn;

    private AudioSource aud;

    private void Awake()
    {
        // 音效來源 = 取得元件<音效來源>()
        aud = GetComponent<AudioSource>();
    }

    // OTE 條件：
    // 兩個碰撞物件 其中一個 必須勾選 IsTrigger
    // 要偵測此腳本子物件是否產生碰撞
    // 必須添加剛體 Rigidbody
    private void OnTriggerEnter(Collider other)
    {
        // 如果 碰撞物件的標籤 為 籃球 就加分 並且 籃球 的 高度 > 2.5
        if (other.tag == "籃球" && other.transform.position.y > 2.5f)
        {
            AddScore();
        }
        // 如果 碰撞的根物件名稱為 Player
        if (other.transform.root.name == "Player")
        {
            // 玩家進入三分區域，將投進的分數改為三分
            scoreIn = 3;
        }
    }

    // 當碰撞物件離開碰撞範圍時執行一次
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.name == "Player")
        {
            // 將投進的分數改為兩分
            scoreIn = 2;
        }
    }

    /// <summary>
    /// 加分數
    /// </summary>
    private void AddScore()
    {
        score += scoreIn;                                   // 分數遞增 投進的分數
        textScore.text = "分數：" + score;                   // 更新介面
        aud.PlayOneShot(soundIn, Random.Range(1f, 2f));     // 音效來源.播放一次(音效片段，音量)
    }
}
