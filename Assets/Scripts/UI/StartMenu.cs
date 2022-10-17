using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // For start menu
    public void StartButton(){
        SceneManager.LoadScene("Levels");
    }

    public void InstructionButton(){
        SceneManager.LoadScene("Instruction");
    }

    public void QuitButton(){
        Application.Quit();
    }

    public void BackToMenu(){
        SceneManager.LoadScene("StartMenu");
    }

    public void NextButton(){
        SceneManager.LoadScene("Instruction2");
    }

    public void BackToInstruction(){
        SceneManager.LoadScene("Instruction");
    }
}
