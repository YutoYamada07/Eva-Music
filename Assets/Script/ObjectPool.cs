using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[���Ƃ�
    //�����˕\��
    //�j��˔�\��

    //���̂��߂ɂ����炶�߃I�u�W�F�N�g�𕡐����߂Ă����Fpool
    //�g���Ƃ��ɗc������
    //����Ȃ��Ȃ������\���ɂ���
    [SerializeField] GameObject prefabObj;
    List<GameObject> pool;

    public void CreatePool(int maxCount)
    {
        pool = new List<GameObject>();
        for (int i = 0; i<maxCount;i++)
        {
            GameObject obj = Instantiate(prefabObj);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObj(Vector2 position)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeSelf == false)
            {
                GameObject obj = pool[i];
                obj.transform.position = position;
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newobj = Instantiate(prefabObj, position, Quaternion.identity);
        newobj.SetActive(false);
        pool.Add(newobj);
        return newobj;
    }
}
