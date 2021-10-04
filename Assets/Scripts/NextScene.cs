using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void SwitchScene() {
        SceneManager.LoadScene("SampleScene");
    }
}
