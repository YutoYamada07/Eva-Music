using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //�ړ�������
    [SerializeField]GameObject targetObject = default;
    [SerializeField]GameObject generateObject = default;
    [SerializeField] GameObject judgementArea = default;
    GameObject gameManager;


    Vector3 targetPosition;

    //�����ꏬ�ߕ����点�Ė炷�˃m�[�c�͈ꏬ�ߕ��������������
    //����ꏊ�ɗ������ɉ�����΂������G���x�F����ꏊ�܂ł̋���/�ꏬ�ߕ��̒���

    //BPM120��60�b�ԂɂP�Q�O�񉹂�����ˈ�񓖂���0.5�b�i60/120�j
    //�ꏬ�߁F�����l��Ȃ��4*0.5=2�ˈꏬ�߂̒����Q�b

    //����ꏊ�܂ł̋����͂����炩
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
