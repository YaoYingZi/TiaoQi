using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        IfWalk();
    }

    public int blank_x, blank_y;
    public bool Move = false, hasChess = false;
    public Color defaultcolor = Color.white, highlightcolor = Color.yellow;
    private SpriteRenderer sr;
    public string chessTag = "";

    public void SetLocation(int x,int y)
    {
        blank_x = x;
        blank_y = y;
    }

    public void IfWalk()
    {
        if (Move == true)
        {
            sr.color = highlightcolor;
        }
        else
        {
            sr.color = defaultcolor;
        }
    }
}
