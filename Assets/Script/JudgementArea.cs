using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementArea : MonoBehaviour
{
    //判定したいノーツが落ちてきたときに、キーボードを押したら判定したい
    //近くにノーツがあるのかを確認：Rayを飛ばす
    //どのくらいの近さなのか
    
    float radius = 5.0f;

    [SerializeField] KeyCode keycode;

    [SerializeField] GameManager gameManager = default;
    [SerializeField] JudgementArea judgementArea = default;
    float AsukaPoint = 1.0f;
    public AudioClip sound1;
    AudioSource audioSource;


    public LayerMask m_layerMask;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            //Debug.Log("Sを入力");
            GetComponent<ParticleSystem>().Play();
            audioSource.PlayOneShot(sound1);

            //var hit = Physics.CapsuleCast(transform.position,transform.position,2.5f,Vector3.zero);

            Vector3 origin = new Vector3(0.001f, 0.5f, 1f);
            Vector3 direction = transform.position;

            if (Physics.SphereCast(new Ray(origin,direction), radius,out RaycastHit hit,m_layerMask.value))
            {
                
                if (hit.collider.CompareTag("Asuka"))
                {
                    Debug.Log("Asuka");
                    gameManager.Combo();
                    Asuka();
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.CompareTag("Rei"))
                {
                    Debug.Log("Rei");
                    gameManager.Combo();
                    gameManager.Rei();
                    Destroy(hit.collider.gameObject);
                }

                int point;
                float judgePoint;
                var positionDiff = hit.transform.position - transform.position;
                var distance = positionDiff.magnitude;
                if (hit.collider.CompareTag("Note"))
                {
                    if (distance < 3)
                    {
                        gameManager.Combo();
                        point = Score();
                        judgePoint = 1.2f;
                        gameManager.AddScore(point * judgePoint * AsukaPoint);
                    }
                    else if (distance < 5)
                    {
                        gameManager.Combo();
                        judgePoint = 1.1f;
                        point = Score();
                        gameManager.AddScore(point * judgePoint * AsukaPoint);
                    }
                    else
                    {
                        gameManager.Combo();
                        judgePoint = 1.0f;
                        point = Score();
                        gameManager.AddScore(point * judgePoint * AsukaPoint);
                    }
                    Destroy(hit.collider.gameObject);
                }
                
                    
                   
                    

                
                
                
            }
            

        }
    }
    void Asuka()
    {
        AsukaPoint = 1.5f;
        gameManager.Asuka();
    }

    int comboScore(int m)
    {
        if (m <= 9)
        {
            return 0;
        }
        else if (10 <= m &&m<= 29)
        {
            return 1;
        }
        else if (30 <= m && m <= 49)
        {
            return 2;
        }
        else if (50<= m && m <= 99)
        {
            return 4;
        }
        else
        {
            return 8;
        }
        
    }

    int Score() {
        //(1050000 - 300m)/(4 * (3m - 232))
        int combo = gameManager.ComboScore();
        int ComboX = comboScore(combo);

        int score = 200 * ComboX + 300;
        return score;
    }


    private void OnDrawGizmos()
    {
        Vector3 vector = transform.position + new Vector3(0.001f, 0.5f, 1f);
       Gizmos.color = Color.red;
       Gizmos.DrawSphere(vector,radius);

    }
}
