using UnityEngine;

public class StaticBase : MonoBehaviour
{
    //Player
    public int PlayerHP = 100;
    public float PlayerMoveSpeed = 2f;
    public float DashSpeed = 1f;

    //Gun
    public float BulletSpeed = 6f;
    public int DamBullet = 5;

    //Pawn
    public int PawnHP = 20;
    public float PawnMoveSpeed = 1f;
    public int PawnDam = 3;

    //Bishop
    public int BishopHP = 40;
    public float BishopMoveSpeed = 1f;
    public int BishopDam = 4;
    public float BishopBulletSpeed = 4f;

    //Knight
    public int KnightHP = 40;
    public float KnightMoveSpeed = 1f;
    public int KnightDam = 4;

    //Rook
    public int RookHP = 60;
    public float RookMoveSpeed = 1f;
    public int RookDam = 5;

    //Queen
    public int QueenHP = 100;
    public float QueenMoveSpeed = 1.5f;
    public int QueenDam = 10;
}
