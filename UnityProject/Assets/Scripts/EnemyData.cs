using UnityEngine;

[CreateAssetMenu(fileName = "敵人資料", menuName = "KID/敵人資料")]
public class EnemyData : ScriptableObject
{
    [Header("血量"), Range(0, 5000)]
    public float hp;
    [Header("攻擊"), Range(0, 1000)]
    public float attack;
    [Header("速度"), Range(0, 500)]
    public float speed;
    [Header("攻擊冷卻時間"), Range(0.5f, 5f)]
    public float cd;
    [Header("近距離攻擊延遲時間"), Range(0f, 5f)]
    public float delay;
}
