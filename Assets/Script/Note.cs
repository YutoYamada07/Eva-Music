using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //ˆÚ“®‚³‚¹‚é
    [SerializeField]GameObject targetObject = default;
    [SerializeField]GameObject generateObject = default;
    [SerializeField] GameObject judgementArea = default;
    GameObject gameManager;


    Vector3 targetPosition;

    //‰¹‚ğˆê¬ß•ª‘—‚ç‚¹‚Ä–Â‚ç‚·Ëƒm[ƒc‚Íˆê¬ß•ª‘‚­¶¬‚³‚ê‚é
    //”»’èêŠ‚É—ˆ‚½‚É‰¹‚ª–Â‚ê‚Î‚¢‚¢‚¢G‘¬“xF”»’èêŠ‚Ü‚Å‚Ì‹——£/ˆê¬ß•ª‚Ì’·‚³

    //BPM120Ë60•bŠÔ‚É‚P‚Q‚O‰ñ‰¹‚ª“ü‚éËˆê‰ñ“–‚½‚è0.5•bi60/120j
    //ˆê¬ßF‰¹‚ªl‰ñ‚È‚éË4*0.5=2Ëˆê¬ß‚Ì’·‚³‚Q•b

    //”»’èêŠ‚Ü‚Å‚Ì‹——£‚Í‚¢‚­‚ç‚©
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
