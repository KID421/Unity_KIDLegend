using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 2000)]
    public float speed = 1.5f;
    [Header("目標物件距離"), Range(1f, 3.5f)]
    public float targetDistance = 2f;

    public PlayerData playerData;

    private Joystick joy;
    private Transform target;
    private Rigidbody rig;
    private Animator ani;
    #endregion

    #region 事件
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();

        joy = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();
        target = GameObject.Find("目標物件").transform;
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }
    #endregion

    #region 方法
    private void Move()
    {
        Vector3 player = transform.position;
        Vector3 pos = new Vector3(player.x - joy.Horizontal * targetDistance, 0.6f, player.z - joy.Vertical * targetDistance);
        target.position = pos;

        rig.AddForce(-joy.Horizontal * speed, 0, -joy.Vertical * speed);
        ani.SetBool("跑步開關", joy.Horizontal != 0 || joy.Vertical != 0);
    }

    private void Turn()
    {
        Vector3 pos = new Vector3(target.position.x, 0.5f, target.position.z);
        transform.LookAt(pos);
    }
    #endregion
}
