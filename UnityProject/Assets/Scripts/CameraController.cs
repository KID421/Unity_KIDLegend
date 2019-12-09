using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 10;
    [Header("追蹤範圍限制")]
    public float limitTop;
    public float limitBottom;

    private Transform player;
    private float distanceZ;

    private void Start()
    {
        player = GameObject.Find("玩家").transform;
        distanceZ = player.position.z - transform.position.z;
    }

    private void LateUpdate()
    {
        Track();
    }

    private void Track()
    {
        Vector3 posPlayer = player.position;
        Vector3 posCamera = new Vector3(0, transform.position.y, posPlayer.z - distanceZ);

        posCamera.z = Mathf.Clamp(posCamera.z, limitBottom, limitTop);

        transform.position = Vector3.Lerp(transform.position, posCamera, 0.5f * Time.deltaTime * speed);
    }
}
