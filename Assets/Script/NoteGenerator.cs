using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    //Note�𐶐�����
    [SerializeField] GameObject generateObject = default;
    [SerializeField] GameObject notePrefab;

    public void SpawnNote(GameObject note,Vector3 pos)
    {
        Instantiate(note, pos, Quaternion.identity);
        
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
