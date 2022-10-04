using UnityEngine;
using UnityEngine.SceneManagement;

namespace _CheatConsole.Scripts
{
    public class Commands
    {
        // Freezes the time.
        public void FreezeTime() => Time.timeScale = 0;
        
        // Unfreezes the time.
        public void UnfreezeTime() => Time.timeScale = 1;
        
        // Restarts the scene
        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        // Loads next scene, if there is no next scene.. Loops through all scenes.
        public void LoadNextScene() => SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
}