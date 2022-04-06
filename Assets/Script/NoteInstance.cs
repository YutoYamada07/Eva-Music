using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInstance : MonoBehaviour
{
    [SerializeField] NoteGenerator noteGenerator=default;
    [SerializeField] GameObject nomalNoteA = default;
    [SerializeField] GameObject nomalNoteS = default;
    [SerializeField] GameObject nomalNoteD = default;
    [SerializeField] GameObject PenPen = default;
    [SerializeField] GameObject Asuka = default;
    [SerializeField] GameObject Rei = default;

    [SerializeField] GameObject generatePositionA = default;
    [SerializeField] GameObject generatePositionB = default;
    [SerializeField] GameObject generatePositionC = default;
    public void NoteEventC()
    {
        //float i = Random.Range(0,5f);
        //if (i < 1.5f)
        //{
         //   Vector3 pos = generatePositionA.transform.position;
            //noteGenerator.SpawnNote(PenPen, pos);
       // }
       // else {

            Vector3 pos = generatePositionA.transform.position;
            noteGenerator.SpawnNote(nomalNoteA, pos);
        //}
        
    }

    public void NoteEventD()
    {
        Vector3 pos = generatePositionB.transform.position;
        noteGenerator.SpawnNote(nomalNoteS, pos);
    }
    public void NoteEventE()
    {
        Vector3 pos = generatePositionC.transform.position;
        noteGenerator.SpawnNote(nomalNoteD, pos);
    }
    public void NoteEventF()
    {
        Vector3 pos = generatePositionA.transform.position;
        noteGenerator.SpawnNote(Asuka, pos);
    }
    public void NoteEventG()
    {
        Vector3 pos = generatePositionC.transform.position;
        noteGenerator.SpawnNote(Rei, pos);
    }

}
