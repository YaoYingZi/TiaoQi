using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initChessBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateChessBoard();
        CreateChesses(RedChess, 4, 7, 0, 3);
        CreateChesses(GreenChess, 13, 16, 9, 12);
        CreateChesses(BlueChess, 4, 7, 9, 12);
        CreateChesses(PurpleChess, 0, 3, 4, 7);
        CreateChesses(PinkChess, 9, 12, 13, 16);
        CreateChesses(CyanChess, 9, 12, 4, 7);
    }

    // Update is called once per frame
    void Update()
    {
        SelectChess();
        if (HaveMoved == true)
        {
            if (RoundOverButton.activeSelf == false)
            {
                RoundIsOver = true;
            }
        }
    }  

    private void OnGUI()
    {
        if (Friend_tag != " ")
        {
            if(RoundIsOver == false && HaveMoved==true)
            {
                string a = Friend_tag + "回合";
                GUIStyle b = new GUIStyle();
                b.normal.textColor = Color.yellow;
                b.fontSize = 80;
                GUILayout.Label(a, b);
            }
            else
            {
                string c = Friend_tag + "回合已结束";
                GUIStyle d = new GUIStyle();
                d.normal.textColor = Color.white;
                d.fontSize = 80;
                GUILayout.Label(c, d);
            }
        }
        if (GameOver("RedChess"))
        {
            if (Red_Once)
            {
                Red_Order = order;
            }
            string a = "RedChess获得第"+Red_Order+"名";
            GUIStyle b = new GUIStyle();
            b.normal.textColor = Color.red;
            b.fontSize = 80;
            GUILayout.Label(a, b);
            if (Red_Once)
            {
                order++;
                GameIsOver = false;
                Red_Once = false;
            }
        }
        if (GameOver("CyanChess"))
        {
            if (Cyan_Once)
            {
                Cyan_Order = order;
            }
            string a = "CyanChess获得第"+Cyan_Order+"名";
            GUIStyle b = new GUIStyle();
            b.normal.textColor = Color.cyan;
            b.fontSize = 80;
            GUILayout.Label(a, b);
            if (Cyan_Once)
            {
                order++;
                GameIsOver = false;
                Cyan_Once = false;
            }
        }
        if (GameOver("BlueChess"))
        {
            if (Blue_Once)
            {
                Blue_Order = order;
            }
            string a = "BlueChess获得第"+Blue_Order+"名";
            GUIStyle b = new GUIStyle();
            b.normal.textColor = Color.blue;
            b.fontSize = 80;
            GUILayout.Label(a, b);
            if (Blue_Once)
            {
                order++;
                GameIsOver = false;
                Blue_Once = false;
            }
        }
        if (GameOver("PinkChess"))
        {
            if (Pink_Once)
            {
                Pink_Order = order;
            }
            string a = "PinkChess获得第"+Pink_Order+"名";
            GUIStyle b = new GUIStyle();
            b.normal.textColor = new Color(1,0, 0.8496766f);
            b.fontSize = 80;
            GUILayout.Label(a, b);
            if (Pink_Once)
            {
                order++;
                GameIsOver = false;
                Pink_Once = false;
            }
        }
        if (GameOver("PurpleChess"))
        {
            if (Purple_Once)
            {
                Purple_Order = order;
            }
            string a = "PurpleChess获得第"+Purple_Order+"名";
            GUIStyle b = new GUIStyle();
            b.normal.textColor = new Color(0.5411764f, 0.1686274f, 0.8862745f);
            b.fontSize = 80;
            GUILayout.Label(a, b);
            if (Purple_Once)
            {
                order++;
                GameIsOver = false;
                Purple_Once = false;
            }
        }
        if (GameOver("GreenChess"))
        {
            if (Green_Once)
            {
                Green_Order = order;
            }
            string a = "GreenChess获得第"+Green_Order+"名";
            GUIStyle b = new GUIStyle();
            b.normal.textColor = Color.green;
            b.fontSize = 80;
            GUILayout.Label(a, b);
            if (Green_Once)
            {
                order++;
                GameIsOver = false;
                Green_Once = false;
            }
        }
    }

    public GameObject BlankPrefab, RedChess, GreenChess,BlueChess,PurpleChess,PinkChess,CyanChess,SelectedChess,RoundOverButton;
    private BlankInfo [,] BlankStorage = new BlankInfo [17, 17];
    public enum Direction { UpLeft,UpRight,Left,Right,DownLeft,DownRight}
    public struct NextPos { public int x, y; }
    private NextPos nextpos;
    private int F_x = 0,F_y = 0;
    private string Friend_tag= " ", Only_tag = " ";
    private int round = 0,number = 0;
    private bool GameIsOver = false,RoundIsOver = false,ChangeRound = false,HaveMoved=false;
    private int Red_Order=0,Blue_Order = 0,Cyan_Order = 0,Purple_Order = 0,Pink_Order = 0,Green_Order = 0,order=1;
    private bool Red_Once = true, Blue_Once = true, Cyan_Once = true, Pink_Once = true, Purple_Once = true, Green_Once = true;
    private int[,] LegalBlank =
    {
        {4,4 },
        {4,5 },
        {4,6 },
        {4,7 },
        {0,12 },
        {1,12 },
        {2,12 },
        {3,12 },
        {4,12 },
        {4,13 },
        {4,14 },
        {4,15 },
        {4,16 },
        {9,12 },
        {10,12 },
        {11,12 },
        {12,12 }
    };
    NextPos GetNextPos(int x, int y, Direction dir)
    {
        switch (dir)
        {
            case Direction.UpLeft:
                nextpos.x = x;
                nextpos.y = y + 1;
                break;
            case Direction.UpRight:
                nextpos.x = x + 1;
                nextpos.y = y + 1;
                break;
            case Direction.Left:
                nextpos.x = x - 1;
                nextpos.y = y;
                break;
            case Direction.Right:
                nextpos.x = x + 1;
                nextpos.y = y;
                break;
            case Direction.DownLeft:
                nextpos.x = x - 1;
                nextpos.y = y - 1;
                break;
            case Direction.DownRight:
                nextpos.x = x;
                nextpos.y = y - 1;
                break;
        }
        return nextpos;
    }
    void WinDetection()
    {
        if(GameOver("RedChess"))
        {
            GameIsOver = true;
        }
        else if (GameOver("CyanChess"))
        {
            GameIsOver = true;
        }
        else if (GameOver("GreenChess"))
        {
            GameIsOver = true;
        }
        else if (GameOver("PinkChess"))
        {
            GameIsOver = true;
        }
        else if (GameOver("BlueChess"))
        {
            GameIsOver = true;
        }
        else if (GameOver("PurpleChess"))
        {
            GameIsOver = true;
        }
    }
    bool GameOver(string tag)
    {
        if(tag == "RedChess")
        {
            if(BlankStorage[0,4].chessTag == tag && BlankStorage[1,4].chessTag == tag && BlankStorage[1,5].chessTag == tag
                && BlankStorage[2,4].chessTag == tag && BlankStorage[2,5].chessTag == tag && BlankStorage[2,6].chessTag == tag
                && BlankStorage[3,4].chessTag == tag && BlankStorage[3,6].chessTag == tag && BlankStorage[3,5].chessTag == tag
                && BlankStorage[3,7].chessTag == tag)
            {
                return true;
            }
            else if(BlankStorage[4, 9].chessTag == tag && BlankStorage[4, 10].chessTag == tag && BlankStorage[4, 11].chessTag == tag
                && BlankStorage[4, 12].chessTag == tag && BlankStorage[5, 10].chessTag == tag && BlankStorage[5, 11].chessTag == tag
                && BlankStorage[5, 12].chessTag == tag && BlankStorage[6, 11].chessTag == tag && BlankStorage[6, 12].chessTag == tag
                && BlankStorage[7, 12].chessTag == tag)
            {
                return true;
            }
            else if(BlankStorage[9, 13].chessTag == tag && BlankStorage[10, 13].chessTag == tag && BlankStorage[11, 13].chessTag == tag
                && BlankStorage[12, 13].chessTag == tag && BlankStorage[10, 14].chessTag == tag && BlankStorage[11, 14].chessTag == tag
                && BlankStorage[12, 14].chessTag == tag && BlankStorage[11, 15].chessTag == tag && BlankStorage[12, 15].chessTag == tag
                && BlankStorage[12, 16].chessTag == tag)
            {
                return true;
            }
            else if(BlankStorage[16, 12].chessTag == tag && BlankStorage[15, 12].chessTag == tag && BlankStorage[15, 11].chessTag == tag
                && BlankStorage[14, 12].chessTag == tag && BlankStorage[14, 11].chessTag == tag && BlankStorage[14, 10].chessTag == tag
                && BlankStorage[13, 12].chessTag == tag && BlankStorage[13, 11].chessTag == tag && BlankStorage[13, 10].chessTag == tag
                && BlankStorage[13, 9].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[9, 4].chessTag == tag && BlankStorage[10, 4].chessTag == tag && BlankStorage[11, 4].chessTag == tag
                && BlankStorage[12, 4].chessTag == tag && BlankStorage[10, 5].chessTag == tag && BlankStorage[11, 5].chessTag == tag
                && BlankStorage[12, 5].chessTag == tag && BlankStorage[11, 6].chessTag == tag && BlankStorage[12, 6].chessTag == tag
                && BlankStorage[12, 7].chessTag == tag)
            {
                return true;
            }
        }
        else if(tag == "GreenChess")
        {
            if (BlankStorage[0, 4].chessTag == tag && BlankStorage[1, 4].chessTag == tag && BlankStorage[1, 5].chessTag == tag
                && BlankStorage[2, 4].chessTag == tag && BlankStorage[2, 5].chessTag == tag && BlankStorage[2, 6].chessTag == tag
                && BlankStorage[3, 4].chessTag == tag && BlankStorage[3, 6].chessTag == tag && BlankStorage[3, 5].chessTag == tag
                && BlankStorage[3, 7].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[4, 9].chessTag == tag && BlankStorage[4, 10].chessTag == tag && BlankStorage[4, 11].chessTag == tag
                && BlankStorage[4, 12].chessTag == tag && BlankStorage[5, 10].chessTag == tag && BlankStorage[5, 11].chessTag == tag
                && BlankStorage[5, 12].chessTag == tag && BlankStorage[6, 11].chessTag == tag && BlankStorage[6, 12].chessTag == tag
                && BlankStorage[7, 12].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[9, 13].chessTag == tag && BlankStorage[10, 13].chessTag == tag && BlankStorage[11, 13].chessTag == tag
                && BlankStorage[12, 13].chessTag == tag && BlankStorage[10, 14].chessTag == tag && BlankStorage[11, 14].chessTag == tag
                && BlankStorage[12, 14].chessTag == tag && BlankStorage[11, 15].chessTag == tag && BlankStorage[12, 15].chessTag == tag
                && BlankStorage[12, 16].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[4, 3].chessTag == tag && BlankStorage[4, 2].chessTag == tag && BlankStorage[4, 1].chessTag == tag
                && BlankStorage[4, 0].chessTag == tag && BlankStorage[5, 3].chessTag == tag && BlankStorage[5, 2].chessTag == tag
                && BlankStorage[5, 1].chessTag == tag && BlankStorage[6, 3].chessTag == tag && BlankStorage[6, 2].chessTag == tag
                && BlankStorage[7, 3].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[9, 4].chessTag == tag && BlankStorage[10, 4].chessTag == tag && BlankStorage[11, 4].chessTag == tag
                && BlankStorage[12, 4].chessTag == tag && BlankStorage[10, 5].chessTag == tag && BlankStorage[11, 5].chessTag == tag
                && BlankStorage[12, 5].chessTag == tag && BlankStorage[11, 6].chessTag == tag && BlankStorage[12, 6].chessTag == tag
                && BlankStorage[12, 7].chessTag == tag)
            {
                return true;
            }
        }
        else if(tag == "PinkChess")
        {
            if (BlankStorage[0, 4].chessTag == tag && BlankStorage[1, 4].chessTag == tag && BlankStorage[1, 5].chessTag == tag
                && BlankStorage[2, 4].chessTag == tag && BlankStorage[2, 5].chessTag == tag && BlankStorage[2, 6].chessTag == tag
                && BlankStorage[3, 4].chessTag == tag && BlankStorage[3, 6].chessTag == tag && BlankStorage[3, 5].chessTag == tag
                && BlankStorage[3, 7].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[4, 9].chessTag == tag && BlankStorage[4, 10].chessTag == tag && BlankStorage[4, 11].chessTag == tag
                && BlankStorage[4, 12].chessTag == tag && BlankStorage[5, 10].chessTag == tag && BlankStorage[5, 11].chessTag == tag
                && BlankStorage[5, 12].chessTag == tag && BlankStorage[6, 11].chessTag == tag && BlankStorage[6, 12].chessTag == tag
                && BlankStorage[7, 12].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[4, 3].chessTag == tag && BlankStorage[4, 2].chessTag == tag && BlankStorage[4, 1].chessTag == tag
                && BlankStorage[4, 0].chessTag == tag && BlankStorage[5, 3].chessTag == tag && BlankStorage[5, 2].chessTag == tag
                && BlankStorage[5, 1].chessTag == tag && BlankStorage[6, 3].chessTag == tag && BlankStorage[6, 2].chessTag == tag
                && BlankStorage[7, 3].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[16, 12].chessTag == tag && BlankStorage[15, 12].chessTag == tag && BlankStorage[15, 11].chessTag == tag
                && BlankStorage[14, 12].chessTag == tag && BlankStorage[14, 11].chessTag == tag && BlankStorage[14, 10].chessTag == tag
                && BlankStorage[13, 12].chessTag == tag && BlankStorage[13, 11].chessTag == tag && BlankStorage[13, 10].chessTag == tag
                && BlankStorage[13, 9].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[9, 4].chessTag == tag && BlankStorage[10, 4].chessTag == tag && BlankStorage[11, 4].chessTag == tag
                && BlankStorage[12, 4].chessTag == tag && BlankStorage[10, 5].chessTag == tag && BlankStorage[11, 5].chessTag == tag
                && BlankStorage[12, 5].chessTag == tag && BlankStorage[11, 6].chessTag == tag && BlankStorage[12, 6].chessTag == tag
                && BlankStorage[12, 7].chessTag == tag)
            {
                return true;
            }
        }
        else if(tag == "BlueChess")
        {
            if (BlankStorage[0, 4].chessTag == tag && BlankStorage[1, 4].chessTag == tag && BlankStorage[1, 5].chessTag == tag
                && BlankStorage[2, 4].chessTag == tag && BlankStorage[2, 5].chessTag == tag && BlankStorage[2, 6].chessTag == tag
                && BlankStorage[3, 4].chessTag == tag && BlankStorage[3, 6].chessTag == tag && BlankStorage[3, 5].chessTag == tag
                && BlankStorage[3, 7].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[4, 3].chessTag == tag && BlankStorage[4, 2].chessTag == tag && BlankStorage[4, 1].chessTag == tag
                && BlankStorage[4, 0].chessTag == tag && BlankStorage[5, 3].chessTag == tag && BlankStorage[5, 2].chessTag == tag
                && BlankStorage[5, 1].chessTag == tag && BlankStorage[6, 3].chessTag == tag && BlankStorage[6, 2].chessTag == tag
                && BlankStorage[7, 3].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[9, 13].chessTag == tag && BlankStorage[10, 13].chessTag == tag && BlankStorage[11, 13].chessTag == tag
                && BlankStorage[12, 13].chessTag == tag && BlankStorage[10, 14].chessTag == tag && BlankStorage[11, 14].chessTag == tag
                && BlankStorage[12, 14].chessTag == tag && BlankStorage[11, 15].chessTag == tag && BlankStorage[12, 15].chessTag == tag
                && BlankStorage[12, 16].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[16, 12].chessTag == tag && BlankStorage[15, 12].chessTag == tag && BlankStorage[15, 11].chessTag == tag
                && BlankStorage[14, 12].chessTag == tag && BlankStorage[14, 11].chessTag == tag && BlankStorage[14, 10].chessTag == tag
                && BlankStorage[13, 12].chessTag == tag && BlankStorage[13, 11].chessTag == tag && BlankStorage[13, 10].chessTag == tag
                && BlankStorage[13, 9].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[9, 4].chessTag == tag && BlankStorage[10, 4].chessTag == tag && BlankStorage[11, 4].chessTag == tag
                && BlankStorage[12, 4].chessTag == tag && BlankStorage[10, 5].chessTag == tag && BlankStorage[11, 5].chessTag == tag
                && BlankStorage[12, 5].chessTag == tag && BlankStorage[11, 6].chessTag == tag && BlankStorage[12, 6].chessTag == tag
                && BlankStorage[12, 7].chessTag == tag)
            {
                return true;
            }
        }
        else if(tag == "CyanChess")
        {
            if (BlankStorage[0, 4].chessTag == tag && BlankStorage[1, 4].chessTag == tag && BlankStorage[1, 5].chessTag == tag
                && BlankStorage[2, 4].chessTag == tag && BlankStorage[2, 5].chessTag == tag && BlankStorage[2, 6].chessTag == tag
                && BlankStorage[3, 4].chessTag == tag && BlankStorage[3, 6].chessTag == tag && BlankStorage[3, 5].chessTag == tag
                && BlankStorage[3, 7].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[4, 9].chessTag == tag && BlankStorage[4, 10].chessTag == tag && BlankStorage[4, 11].chessTag == tag
                && BlankStorage[4, 12].chessTag == tag && BlankStorage[5, 10].chessTag == tag && BlankStorage[5, 11].chessTag == tag
                && BlankStorage[5, 12].chessTag == tag && BlankStorage[6, 11].chessTag == tag && BlankStorage[6, 12].chessTag == tag
                && BlankStorage[7, 12].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[9, 13].chessTag == tag && BlankStorage[10, 13].chessTag == tag && BlankStorage[11, 13].chessTag == tag
                && BlankStorage[12, 13].chessTag == tag && BlankStorage[10, 14].chessTag == tag && BlankStorage[11, 14].chessTag == tag
                && BlankStorage[12, 14].chessTag == tag && BlankStorage[11, 15].chessTag == tag && BlankStorage[12, 15].chessTag == tag
                && BlankStorage[12, 16].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[16, 12].chessTag == tag && BlankStorage[15, 12].chessTag == tag && BlankStorage[15, 11].chessTag == tag
                && BlankStorage[14, 12].chessTag == tag && BlankStorage[14, 11].chessTag == tag && BlankStorage[14, 10].chessTag == tag
                && BlankStorage[13, 12].chessTag == tag && BlankStorage[13, 11].chessTag == tag && BlankStorage[13, 10].chessTag == tag
                && BlankStorage[13, 9].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[4, 3].chessTag == tag && BlankStorage[4, 2].chessTag == tag && BlankStorage[4, 1].chessTag == tag
                && BlankStorage[4, 0].chessTag == tag && BlankStorage[5, 3].chessTag == tag && BlankStorage[5, 2].chessTag == tag
                && BlankStorage[5, 1].chessTag == tag && BlankStorage[6, 3].chessTag == tag && BlankStorage[6, 2].chessTag == tag
                && BlankStorage[7, 3].chessTag == tag)
            {
                return true;
            }
        }
        else if(tag == "PurpleChess")
        {
            if (BlankStorage[4, 3].chessTag == tag && BlankStorage[4, 2].chessTag == tag && BlankStorage[4, 1].chessTag == tag
                && BlankStorage[4, 0].chessTag == tag && BlankStorage[5, 3].chessTag == tag && BlankStorage[5, 2].chessTag == tag
                && BlankStorage[5, 1].chessTag == tag && BlankStorage[6, 3].chessTag == tag && BlankStorage[6, 2].chessTag == tag
                && BlankStorage[7, 3].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[4, 9].chessTag == tag && BlankStorage[4, 10].chessTag == tag && BlankStorage[4, 11].chessTag == tag
                && BlankStorage[4, 12].chessTag == tag && BlankStorage[5, 10].chessTag == tag && BlankStorage[5, 11].chessTag == tag
                && BlankStorage[5, 12].chessTag == tag && BlankStorage[6, 11].chessTag == tag && BlankStorage[6, 12].chessTag == tag
                && BlankStorage[7, 12].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[9, 13].chessTag == tag && BlankStorage[10, 13].chessTag == tag && BlankStorage[11, 13].chessTag == tag
                && BlankStorage[12, 13].chessTag == tag && BlankStorage[10, 14].chessTag == tag && BlankStorage[11, 14].chessTag == tag
                && BlankStorage[12, 14].chessTag == tag && BlankStorage[11, 15].chessTag == tag && BlankStorage[12, 15].chessTag == tag
                && BlankStorage[12, 16].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[16, 12].chessTag == tag && BlankStorage[15, 12].chessTag == tag && BlankStorage[15, 11].chessTag == tag
                && BlankStorage[14, 12].chessTag == tag && BlankStorage[14, 11].chessTag == tag && BlankStorage[14, 10].chessTag == tag
                && BlankStorage[13, 12].chessTag == tag && BlankStorage[13, 11].chessTag == tag && BlankStorage[13, 10].chessTag == tag
                && BlankStorage[13, 9].chessTag == tag)
            {
                return true;
            }
            else if (BlankStorage[9, 4].chessTag == tag && BlankStorage[10, 4].chessTag == tag && BlankStorage[11, 4].chessTag == tag
                && BlankStorage[12, 4].chessTag == tag && BlankStorage[10, 5].chessTag == tag && BlankStorage[11, 5].chessTag == tag
                && BlankStorage[12, 5].chessTag == tag && BlankStorage[11, 6].chessTag == tag && BlankStorage[12, 6].chessTag == tag
                && BlankStorage[12, 7].chessTag == tag)
            {
                return true;
            }
        }
        return false;
    }
    bool RoundOverSign(int a,int b,int c,int d)
    {
        nextpos = GetNextPos(a, b, Direction.UpLeft);
        if(nextpos.x ==c && nextpos.y == d)
        {
            return true;
        }
        nextpos = GetNextPos(a, b, Direction.UpRight);
        if (nextpos.x == c && nextpos.y == d)
        {
            return true;
        }
        nextpos = GetNextPos(a, b, Direction.Right);
        if (nextpos.x == c && nextpos.y == d)
        {
            return true;
        }
        nextpos = GetNextPos(a, b, Direction.Left);
        if (nextpos.x == c && nextpos.y == d)
        {
            return true;
        }
        nextpos = GetNextPos(a, b, Direction.DownRight);
        if (nextpos.x == c && nextpos.y == d)
        {
            return true;
        }
        nextpos = GetNextPos(a, b, Direction.DownLeft);
        if (nextpos.x == c && nextpos.y == d)
        {
            return true;
        }
        return false;
    }
    bool IsLegalLocation(int x, int y)
    {
        if (x < 0 || x > 16)
        {
            return false;
        }
        if (y < LegalBlank[x, 0] || y > LegalBlank[x, 1])
        {
            return false;
        }
        return true;
    }
    void ChangeCS(GameObject a, int x, int y, int z)
    {
        a.transform.position = new Vector3(2 * x - y - 8, Mathf.Sqrt(3) * y - 8 * Mathf.Sqrt(3), z);
    }
    void HighlightSc(GameObject a)
    {
        SpriteRenderer highlight = a.transform.GetChild(0).GetComponent<SpriteRenderer>();
        highlight.enabled = !highlight.enabled;
    }
    void DetectSingleJump(int x,int y,Direction dir)
    {
        nextpos = GetNextPos(x, y, dir);
        if (IsLegalLocation(nextpos.x, nextpos.y))
        {
            BlankInfo LandBlank = BlankStorage[nextpos.x, nextpos.y]; 
            if(LandBlank.hasChess==false && LandBlank.Move == false)
            {
                LandBlank.Move = true;
            }
        }
    }
    NextPos DetectConstantJumpBoard(int x,int y,Direction dir)
    {
        nextpos = GetNextPos(x, y, dir);
        while (IsLegalLocation(nextpos.x,nextpos.y))
        {
            if (BlankStorage[nextpos.x, nextpos.y].hasChess == false)
            {
                nextpos = GetNextPos(nextpos.x, nextpos.y, dir);
            }
            else
            {
                break;
            }
        }
        return nextpos;
    }
    bool DetectBarrierBlank(int beg_x,int beg_y,int end_x,int end_y,Direction dir)
    {
        nextpos.x = beg_x;
        nextpos.y = beg_y;
        while(nextpos.x != end_x || nextpos.y != end_y)
        {
            nextpos = GetNextPos(nextpos.x, nextpos.y, dir);
            if (BlankStorage[nextpos.x, nextpos.y].hasChess == true)
            {
                return false;
            }
        }
        return true;
    }
    void DetectConstantJumpLand(int x,int y,NextPos ConstantJumpBoard,Direction dir)
    {
        if (IsLegalLocation(ConstantJumpBoard.x, ConstantJumpBoard.y))
        {
            int end_x = 2 * ConstantJumpBoard.x - x;
            int end_y = 2 * ConstantJumpBoard.y - y;
            if (end_x<=16 && end_x >=0 && end_y>=0 && end_y<=16 && IsLegalLocation(end_x, end_y))
            {
                if(BlankStorage[end_x, end_y].hasChess == false)
                {
                    if (DetectBarrierBlank(ConstantJumpBoard.x, ConstantJumpBoard.y, end_x, end_y, dir))
                    {
                        if (ConstantJumpBoard.x != F_x || ConstantJumpBoard.y != F_y)
                        {
                            BlankStorage[end_x, end_y].Move = true;
                        }
                    }
                }
            }
        }
    }
    void DetectMove(int x,int y,Direction dir)
    {
        nextpos= GetNextPos(x, y, dir);
        if (IsLegalLocation(nextpos.x, nextpos.y)) 
        {
            BlankInfo NextBlank = BlankStorage[nextpos.x,nextpos.y];
            if (NextBlank.hasChess == false && NextBlank.Move == false )
            {
                if(BlankStorage[x, y].hasChess == true && HaveMoved == false)
                {
                    NextBlank.Move = true;
                }
                DetectConstantJumpLand(x, y, DetectConstantJumpBoard(x, y, dir), dir);        
            }
            else if (NextBlank.hasChess == true)
            {
                DetectSingleJump(nextpos.x, nextpos.y, dir);
            }
        }
    }
    void DetectAllMove(int x, int y)
    {
        ClearMove();
        DetectMove(x, y, Direction.UpLeft);
        DetectMove(x, y, Direction.UpRight);
        DetectMove(x, y, Direction.Left);
        DetectMove(x, y, Direction.Right);
        DetectMove(x, y, Direction.DownLeft);
        DetectMove(x, y, Direction.DownRight); 
    }
    void MoveChess(BlankInfo sb)
    {
        int Move_x = sb.blank_x;
        int Move_y = sb.blank_y;
        sb.hasChess = true;
        sb.chessTag = SelectedChess.tag;
        ChangeCS(SelectedChess, Move_x, Move_y, -1);
        HighlightSc(SelectedChess);
        ChessInfo NewChessLocation = SelectedChess.GetComponent<ChessInfo>();
        Only_tag = SelectedChess.GetComponent<ChessInfo>().Chess_Tag;
        ChangeRound = false;
        Friend_tag = SelectedChess.name;
        RoundIsOver =RoundOverSign(NewChessLocation.OldChess_x, NewChessLocation.OldChess_y, Move_x, Move_y);
        if(RoundIsOver == false)
        {
            RoundOverButton.SetActive(true);
        }
        HaveMoved = true;
        BlankStorage[NewChessLocation.OldChess_x, NewChessLocation.OldChess_y].hasChess = false;
        BlankStorage[NewChessLocation.OldChess_x, NewChessLocation.OldChess_y].chessTag = "";
        NewChessLocation.SetLocation(Move_x, Move_y);
        SelectedChess = null;
        WinDetection();
        round++;
    }
    void ClearMove()
    {
        for(int x = 0; x < 17; x++)
        {
            for(int y = 0; y < 17; y++)
            {
                if (BlankStorage[x, y] != null)
                {
                    BlankStorage[x, y].Move = false;
                }
            }
        }
    }
    void CreateChessBoard()
    {
        for (int i = 0; i < 17; i++)
        {
            for(int j = 0; j < 17; j++)
            {
                if (IsLegalLocation(i,j))
                {
                    GameObject Blank = Instantiate(BlankPrefab);
                    BlankStorage[i, j] = Blank.GetComponent<BlankInfo>();
                    Blank.name = "Blank";
                    Blank.GetComponent<BlankInfo>().SetLocation(i, j);
                    ChangeCS(Blank, i, j, 0);
                }
            }
        }
    }
    void CreateChesses(GameObject ChessPrefab,int x_min,int x_max,int y_min,int y_max)
    {
        int count1 = 0,count2=0;
        if (x_min == 4 || x_min == 13)
        {
            count1 = 4;
            for (int x = x_min; x <= x_max; x++)
            {
                for (int y = y_min; y <= y_max; y++)
                {
                    if (IsLegalLocation(x, y) && count1 != count2 && y >= y_max - count1 + 1)
                    {
                        GameObject Chess = Instantiate(ChessPrefab);
                        BlankStorage[x, y].hasChess = true;
                        BlankStorage[x, y].chessTag = Chess.tag;
                        Chess.GetComponent<ChessInfo>().Chess_Tag = Chess.tag + number;
                        Chess.name = ChessPrefab.name;
                        Chess.GetComponent<ChessInfo>().SetLocation(x, y);
                        ChangeCS(Chess, x, y, -1);
                        count2++;
                        number++;
                    }
                }
                count1--;
                count2 = 0;
            }
        }
        else
        {
            count1 = 1;
            for (int x = x_min; x <= x_max; x++)
            {
                for (int y = y_min; y <= y_max; y++)
                {
                    if (IsLegalLocation(x, y) && count1 != count2 )
                    {
                        GameObject Chess = Instantiate(ChessPrefab);
                        BlankStorage[x, y].hasChess = true;
                        BlankStorage[x, y].chessTag = Chess.tag;
                        Chess.GetComponent<ChessInfo>().Chess_Tag = Chess.tag + number;
                        Chess.name = ChessPrefab.name;
                        Chess.GetComponent<ChessInfo>().SetLocation(x, y);
                        ChangeCS(Chess, x, y, -1);
                        count2++;
                        number++;
                    }
                }
                count1++;
                count2 = 0;
            }
        }
    }
    void SelectChess() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward);
            if (hit.collider != null)
            {
                if (hit.transform.tag == "RedChess" && Red_Once || hit.transform.tag == "GreenChess"  && Green_Once
                    || hit.transform.tag== "PinkChess" && Pink_Once  || hit.transform.tag== "CyanChess" && Cyan_Once
                    || hit.transform.tag== "BlueChess" && Blue_Once || hit.transform.tag== "PurpleChess" && Purple_Once)
                {
                    if (SelectedChess != null)
                    {
                        HighlightSc(SelectedChess);
                    }
                    SelectedChess = hit.transform.gameObject;
                    HighlightSc(SelectedChess);
                    if (Only_tag == " " || SelectedChess.GetComponent<ChessInfo>().Chess_Tag == Only_tag || hit.transform.tag != Friend_tag)
                    {
                        if(hit.transform.tag != Friend_tag && Friend_tag != " ")
                        {
                            if(RoundOverButton.activeSelf != true)
                            {
                                RoundIsOver = false;
                                HaveMoved = false;
                                ChangeRound = true;
                            }
                        }
                        ChessInfo ScLocation = SelectedChess.GetComponent<ChessInfo>();
                        F_x = ScLocation.OldChess_x;
                        F_y = ScLocation.OldChess_y;
                        if (!RoundIsOver)
                        {               
                            if(RoundOverButton.activeSelf == true)
                            {
                                if (SelectedChess.GetComponent<ChessInfo>().Chess_Tag == Only_tag)
                                {
                                    DetectAllMove(ScLocation.OldChess_x, ScLocation.OldChess_y);
                                }
                            }
                            else
                            {
                                DetectAllMove(ScLocation.OldChess_x, ScLocation.OldChess_y);
                            }
                        }
                    }
                }
                else if(SelectedChess != null)
                {
                    BlankInfo SelectedBlank = hit.transform.GetComponent<BlankInfo>();
                    if (SelectedBlank.Move == true)
                    {
                        if(Only_tag == SelectedChess.GetComponent<ChessInfo>().Chess_Tag || Only_tag == " " || ChangeRound)
                        {
                            MoveChess(SelectedBlank);
                            ClearMove();
                        }
                    }
                }
             }
            else
            {
                HighlightSc(SelectedChess);
                SelectedChess = null;
                ClearMove();
            }
        }
    }
}
