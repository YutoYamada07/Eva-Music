using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] Text countDownText = default; 

    [SerializeField] Text scoreText = default;
    [SerializeField] Text comboText = default;
    [SerializeField] Slider lifeGage;
    [SerializeField] GameObject AsukaPanel;
    [SerializeField] GameObject ReiPanel;
    [SerializeField] AudioClip AsukaSE;
    [SerializeField] AudioClip ReiSE;
    AudioSource audioSource;

    int score;
    int combo;
    
    int recover = 20;

    //ゲーム開始の実装
    //タイムラインの終了を検知する
    //signalを使う
    // Start is called before the first frame update
    void Start()
    {
        //AsukaPanel.SetActive(false);
        //ReiPanel.SetActive(false);
        StartCoroutine(GameMain());
        combo = 0;
        
        audioSource = GetComponent<AudioSource>();

    }

    IEnumerator GameMain()
    {
        countDownText.text = "3";
        yield return new WaitForSeconds(1);
        countDownText.text = "2";
        yield return new WaitForSeconds(1);
        countDownText.text = "1";
        yield return new WaitForSeconds(1);
        countDownText.text = "GO!";
        yield return new WaitForSeconds(0.3f);
        countDownText.text = "";
        playableDirector.Play();
        
    }
    public void OnEndEvent()
    {
        if (score < 500000)
        {
            SceneManager.LoadScene("TVEnd");
        }
        else if (score >= 500000 && score <= 750000)
        {
            SceneManager.LoadScene("OldEnd");
        }
        else
        {
            SceneManager.LoadScene("MariEnd");
        }
        Debug.Log("ゲーム終了");
    }
    public void AddScore(float point)
    {
        score +=(int) point;
        scoreText.text = score.ToString();
        
    }
    public void Combo()
    {
        combo++;
        comboText.text = combo.ToString();
    }

    public int ComboScore()
    {
        return combo;
    }
    public void ComboReset()
    {
        combo = 0;
        comboText.text = combo.ToString();
        lifeGage.value--;
        if (lifeGage.value <= 0)
        {
            Debug.Log("ゲームオーバー");
            SceneManager.LoadScene("BadEnd");
        }

    }
    public void ComboReset2()
    {
        combo = 0;
        comboText.text = combo.ToString();
    }
    public void Rei()
    {
        lifeGage.value += recover;
        ReiPanel.SetActive(true);
        audioSource.PlayOneShot(ReiSE);
    }
    public void Asuka()
    {
        scoreText.color = Color.red;
        AsukaPanel.SetActive(true);
        audioSource.PlayOneShot(AsukaSE);
    }
    public void OnRetry()
    {
        SceneManager.LoadScene("Main");
    }
}


