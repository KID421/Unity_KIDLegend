using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [Header("隨機技能")]
    public GameObject skill;
    [Header("是否自動顯示隨機技能")]
    public bool autoShowSkill;
    [Header("是否自動開門")]
    public bool autoOpenDoor;

    private Animator aniDoor;
    private Image imgCross;

    private void Start()
    {
        aniDoor = GameObject.Find("門").GetComponent<Animator>();
        imgCross = GameObject.Find("轉場畫面").GetComponent<Image>();

        if (autoShowSkill) ShowSkill();
        if (autoOpenDoor) Invoke("OpenDoor", 6);
    }

    private void ShowSkill()
    {
        skill.SetActive(true);
    }

    private void OpenDoor()
    {
        aniDoor.SetTrigger("開門觸發");
    }

    private IEnumerator LoadNextLevel()
    {
        for (int i = 0; i < 10; i++)
        {
            imgCross.color += new Color(1, 1, 1, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }

        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++levelIndex);
    }
}
