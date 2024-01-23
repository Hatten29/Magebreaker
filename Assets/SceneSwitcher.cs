using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nextSceneName;

    void Start()
    {

        Button button = GetComponent<Button>();

        if (button != null)
        {
 
            button.onClick.AddListener(SwitchScene);
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject!");
        }
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(1);
    }
}
