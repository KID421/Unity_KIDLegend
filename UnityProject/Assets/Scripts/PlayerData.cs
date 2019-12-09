using UnityEngine;

[CreateAssetMenu(fileName = "玩家資料", menuName = "KID/玩家資料")]
public class PlayerData : ScriptableObject
{
    [Header("攻擊力")]
    public float attack = 20;
    [Header("血量")]
    public float hp = 100;
    [Header("攻擊速度")]
    public float speedAttack = 2;
    [Header("數量")]
    public int count;
    [Header("方向生成")]
    public bool back;
    public bool leftRight;
    [Header("連射")]
    public bool doubleAttack;
}