using UnityEngine;
using System.Collections;

public class RandomController : MonoBehaviour
{
    [Header("技能陣列")]
    public RectTransform[] skills;


    private void Start()
    {
        int length = transform.childCount;
        skills = new RectTransform[length];

        for (int i = 0; i < length; i++)
        {
            skills[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }

        StartCoroutine(SlotEffect());
    }

    private IEnumerator SlotEffect()
    {
        int r = Random.Range(10, 30);

        while (r > 0)
        {
            for (int i = 0; i < skills.Length; i++)
            {
                skills[i].anchoredPosition -= Vector2.up * 128;

                if (skills[i].anchoredPosition.y < -192)
                {
                    skills[i].anchoredPosition = new Vector2(64, 704);
                }
            }

            r--;

            yield return new WaitForSeconds(1);
        }
    }
}
