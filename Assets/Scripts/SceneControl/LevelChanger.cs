using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    private int levelToLoad;

    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            if(SceneManager.GetActiveScene().buildIndex == 1)
//            {
//                FadeToLevel(0);
//            }
//            else
//            {
//                FadeToNextLevel();
//            }
//
//                
//            //FadeToNextLevel();
//        }
//    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
}
