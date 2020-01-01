using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class RandomSkill : MonoBehaviour
{
    [Header("隨機圖片")]
    public Sprite[] spriteBlurSkills;
    [Header("速度"), Range(0.02f, 2f)]
    public float speed = 0.1f;
    [Header("次數"), Range(1, 10)]
    public int count = 5;
    [Header("正常技能圖片")]
    public Sprite[] spriteSkills;
    [Header("音效")]
    public AudioClip soundScroll;
    public AudioClip soundGetSkill;

    private GameObject panel;
    private Button btn;
    private Image img;
    private Text textSkill;
    private AudioSource aud;
    private int index;
    private string[] nameSkills = { "連續射擊", "正向箭", "背向箭", "側向箭", "血量增加", "攻擊增加", "攻速增加", "爆擊增加" };

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        btn = GetComponent<Button>();
        img = GetComponent<Image>();
        textSkill = transform.GetChild(0).GetComponent<Text>();
        panel = GameObject.Find("隨機技能");

        btn.onClick.AddListener(GetSkill);

        StartCoroutine(RandomEffect());
    }

    private void GetSkill()
    {
        print(nameSkills[index]);
        panel.SetActive(false);
    }

    private IEnumerator RandomEffect()
    {
        btn.interactable = false;

        for (int j = 0; j < count; j++)
        {
            for (int i = 0; i < 16; i++)
            {
                img.sprite = spriteBlurSkills[i];
                aud.PlayOneShot(soundScroll, 0.3f);
                yield return new WaitForSeconds(speed);
            }
        }

        index = Random.Range(0, spriteSkills.Length);
        img.sprite = spriteSkills[index];
        btn.interactable = true;
        textSkill.text = nameSkills[index];
        aud.PlayOneShot(soundGetSkill, 0.7f);
    }
}
