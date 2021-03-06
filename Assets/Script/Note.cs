using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //移動させる
    [SerializeField]GameObject targetObject = default;
    [SerializeField]GameObject generateObject = default;
    [SerializeField] GameObject judgementArea = default;
    GameObject gameManager;


    Vector3 targetPosition;

    //音を一小節分送らせて鳴らす⇒ノーツは一小節分早く生成される
    //判定場所に来た時に音が鳴ればいいい；速度：判定場所までの距離/一小節分の長さ

    //BPM120⇒60秒間に１２０回音が入る⇒一回当たり0.5秒（60/120）
    //一小節：音が四回なる⇒4*0.5=2⇒一小節の長さ２秒

    //判定場所までの距離はいくらか
    //

    public float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        var positionDiff = generateObject.transform.position - judgementArea.transform.position;
        var distance = positionDiff.magnitude;
        speed = distance / 2;

        targetPosition = targetObject.transform.position;

        gameManager = GameObject.FindGameObjectWithTag("GameManager"); ;
        //Debug.Log(targetPosition);

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        if (transform.position.z <= -15)
        {
            
            gameManager.GetComponent<GameManager>().ComboReset();
            Destroy(this.gameObject);
            
        }
    }
}
