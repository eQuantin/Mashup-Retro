using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchStage : MonoBehaviour
{
    public void StageSwitcher (string cible)
    {
        SceneManager.LoadScene(cible);
    }
}