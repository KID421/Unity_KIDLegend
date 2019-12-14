using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class RandomController : MonoBehaviour
{
    [Header("技能陣列")]
    public Image imageSkill;
    [Header("隨機圖片")]
    public Sprite[] spriteBlurSkills;
    [Header("速度"), Range(0.02f, 2f)]
    public float speed = 0.1f;
    [Header("次數"), Range(1, 10)]
    public int count = 5;
    [Header("正常技能圖片")]
    public Sprite[] spriteSkills;
    [Header("音效")]
    public AudioClip sound;

    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(RandomSkill());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator RandomSkill()
    {
        for (int j = 0; j < count; j++)
        {
            for (int i = 0; i < 16; i++)
            {
                imageSkill.sprite = spriteBlurSkills[i];
                aud.PlayOneShot(sound, 0.7f);
                yield return new WaitForSeconds(speed);
            }
        }

        int r = Random.Range(0, spriteSkills.Length);
        imageSkill.sprite = spriteSkills[r];
    }
}
