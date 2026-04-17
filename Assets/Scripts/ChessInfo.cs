using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessInfo : MonoBehaviour
{
    public int OldChess_x,OldChess_y;
    public string Chess_Tag;
    public void SetLocation(int x,int y)
    {
        OldChess_x = x;
        OldChess_y = y;
    }
}
