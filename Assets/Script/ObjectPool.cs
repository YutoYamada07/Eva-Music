using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //オブジェクトプールとは
    //生成⇒表示
    //破壊⇒非表示

    //そのためにあからじめオブジェクトを複数ためておく：pool
    //使うときに幼児する
    //いらなくなったら非表示にする
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
