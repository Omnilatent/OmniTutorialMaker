using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMakerExampleControl : MonoBehaviour
{
    public void ResetTutorialProgress()
    {
        Omnilatent.TutorialMaker.TutorialManager.ResetData();
        ReloadScene();
    }

    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ExTutorial");
    }
}
