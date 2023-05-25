using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneController1 : MonoBehaviour
{
    public GameObject camera;
    private Transform camTran;
    public float camAng;
    public TextMeshProUGUI exp;
    public GameObject objects;
    public GameObject canvas;
    public GameObject markerButton;
    public GameObject trashButton;
    public Image note;
    public GameObject marker1;
    public GameObject marker2;
    public GameObject str12;
    public GameObject marker4;
    public GameObject str24;
    public GameObject expStr12;
    public GameObject expStr24;
    public GameObject marker6;
    public GameObject str26;
    public GameObject expStr26;
    public GameObject expObjects;
    public GameObject expCanvas;        
    public float exp0;
    public float exp00;
    public float exp1;
    public float exp10;
    public float exp11;
    public float exp12;
    public float exp2;
    public float exp20;
    public float exp21;
    public float exp22;
    public float exp3;
    public float exp30;
    public float exp31;
    public float exp32;
    public float exp4;
    public float exp40;
    public float exp41;
    public float exp5;
    public float exp50;
    public float exp6;
    public float exp7;
    public float exp70;
    public float exp71;
    public float exp8;
    public float exp80;
    public float exp81;
    public Vector3 pos;
    public float toPos0;
    public Vector3 pos0;
    public float toPos1;
    public Vector3 pos1;
    public float toPos3;
    public Vector3 pos3;
    public float toPos4;
    public Vector3 pos4;
    public float toPos8;
    public Vector3 pos8;  
    public float noteAppear31;
    public float noteDisappear32;
    public float rotateAngle40;
    public float rotateSpeed40;      

    // Start is called before the first frame update
    void Start()
    {
        objects.SetActive(true);
        canvas.SetActive(false);
        marker1.SetActive(false);
        marker2.SetActive(false);
        str12.SetActive(false);
        marker4.SetActive(false);
        str24.SetActive(false);
        expStr12.SetActive(false);
        expStr24.SetActive(false);
        marker6.SetActive(false);
        str26.SetActive(false);
        expStr26.SetActive(false);         
        camTran = camera.transform;
        camTran.position = pos;
        camTran.localEulerAngles = new Vector3(camAng, -75.63f, 0f);
        exp.text = "これは現実空間にARの弦を\n張り巡らせて音を奏でるアプリです";
        Invoke("Exp0", exp0); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Exp0()
    {
        objects.SetActive(false);
        canvas.SetActive(true);
        Invoke("Exp00", exp00);        
        Invoke("Exp1", exp1);        
    }
    void Exp00()
    {
        StartCoroutine("Camera00");
    }
    IEnumerator Camera00()
    {
        float sec = 0f;
        Vector3 velocity = Vector3.zero;
        while (true)
        {
            sec += Time.deltaTime;
            camTran.position = Vector3.SmoothDamp(camTran.position, pos0, ref velocity, toPos0);
            if (sec  > exp1)
            {
                break;
            }
            yield return null;
        }
    }

    void Exp1()
    {
        exp.text = "① 中央のボタンを押すと\n現在地にピンが置かれます";
        Invoke("Exp10", exp10);
        Invoke("Exp11", exp11);
        Invoke("Exp12", exp12);
        Invoke("Exp2", exp2);
    }
    void Exp10()
    {
        markerButton.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }
    void Exp11()
    {
        marker1.SetActive(true);        
        markerButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    void Exp12()
    {
        StartCoroutine("Camera12");
    }
    IEnumerator Camera12()
    {
        float sec = 0f;
        Vector3 velocity = Vector3.zero;
        while (true)
        {
            sec += Time.deltaTime;
            camTran.position = Vector3.SmoothDamp(camTran.position, pos1, ref velocity, toPos1);
            if (sec  > exp2)
            {
                break;
            }
            yield return null;
        }
    }    

    void Exp2()
    {
        exp.text = "② 2つ目のピンを置くと\nピンの間に弦が張られます";
        Invoke("Exp20", exp20);
        Invoke("Exp21", exp21);
        Invoke("Exp22", exp22);        
        Invoke("Exp3", exp3);
    }
    void Exp20()
    {
        markerButton.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }
    void Exp21()
    {
        marker2.SetActive(true);        
        markerButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    void Exp22()
    {
        str12.SetActive(true);        
    }        

    void Exp3()
    {
        exp.text = "③ 弦に近づくと弦が弾かれ\nドの音が鳴ります";
        Invoke("Exp30", exp30);
        Invoke("Exp31", exp31);
        Invoke("Exp32", exp32);
        Invoke("Exp4", exp4);
    }
    void Exp30()
    {
        StartCoroutine("Camera30");
    }  
    IEnumerator Camera30()
    {
        float sec = 0f;
        Vector3 velocity = Vector3.zero;
        while (true)
        {
            sec += Time.deltaTime;
            camTran.position = Vector3.SmoothDamp(camTran.position, pos3, ref velocity, toPos3);
            if (sec  > exp4)
            {
                break;
            }
            yield return null;
        }
    }
    void Exp31()
    {
        StartCoroutine("Note31");
    }      
    IEnumerator Note31()
    {
        for ( float i = 0 ; i < 1 ; i+=0.1f ){
            note.transform.localScale = new Vector3(i,i,i);
            yield return new WaitForSeconds(noteAppear31);
        }
    }
    void Exp32()
    {
        StartCoroutine("Note32");
    }
    IEnumerator Note32()
    {
        Color c = note.color;
        c.a = 1f; 
        note.color = c; // 画像の不透明度を1にする
    
        while (true)
        {
            c.a -= 0.02f;
            note.color = c; // 画像の不透明度を下げる
    
            if (c.a <= 0f) // 不透明度が0以下のとき
            {
                c.a = 0f;
                note.color = c; // 不透明度を0
                break;
            }
            yield return new WaitForSeconds(noteDisappear32);
        }
    }           

    void Exp4()
    {
        exp.text = "④ さらにピンを置くと\n新たな弦が張られます";
        Invoke("Exp40", exp40);
        Invoke("Exp41", exp41);
        Invoke("Exp5", exp5);
    }
    void Exp40()
    {
        StartCoroutine("Camera40");
    }  
    IEnumerator Camera40()
    {
        float sec = 0f;
        while (true)
        {
            sec += Time.deltaTime;
            Vector3 velocity = Vector3.zero;
            camTran.position = Vector3.SmoothDamp(camTran.position, pos4, ref velocity, toPos4);
            if (camTran.localEulerAngles.x < rotateAngle40)
            {
                var angle = rotateSpeed40 * sec;
                camTran.rotation = Quaternion.AngleAxis(angle, camTran.right) * camTran.rotation;
            }
            if (sec  > exp5)
            {
                break;
            }
            yield return null;
        }
    }
    void Exp41()
    {
        marker4.SetActive(true);
        str24.SetActive(true);
    }      

    void Exp5()
    {
        exp.text = "⑤ 最初の弦の長さとの比で\n弦の音の高さが決まります";
        expStr12.SetActive(true);
        expStr24.SetActive(true);        
        Invoke("Exp50", exp50);
        Invoke("Exp6", exp6);
    }
    void Exp50()
    {
        exp.text = "⑤ 弦が長いほど音は低く\n短いほど高くなります（0.5~2倍まで）";
    }    

    void Exp6()
    {
        exp.text = "⑥ さらに他の人が置いたピンとの間に\n弦が張られることもあります";
        marker6.SetActive(true);
        str26.SetActive(true);
        expStr26.SetActive(true);
        Invoke("Exp7", exp7);
    }

    void Exp7()
    {
        exp.text = "⑦ 最後に右のボタンを押すと\nピンと弦がリセットされます";
        Invoke("Exp70", exp70);
        Invoke("Exp71", exp71);
        Invoke("Exp8", exp8);
    }
    void Exp70()
    {
        trashButton.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }
    void Exp71()
    {
        expObjects.SetActive(false);
        expCanvas.SetActive(false);         
        trashButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }    

    void Exp8()
    {
        exp.text = "自分や他人のいた場所を\n繋ぐように張られた弦から";
        Invoke("Exp80", exp80);
        Invoke("Exp81", exp81);
    }
    void Exp80()
    {
        objects.SetActive(true);
        StartCoroutine("Camera80");
    }
    IEnumerator Camera80()
    {
        float sec = 0f;
        Vector3 velocity = Vector3.zero;
        while (true)
        {
            sec += Time.deltaTime;
            camTran.position = Vector3.SmoothDamp(camTran.position, pos8, ref velocity, toPos8);

            yield return null;
        }
    }         
    void Exp81()
    {
        exp.text = "いろんなメロディやコードを\n奏でてみましょう";
    }                           
}
