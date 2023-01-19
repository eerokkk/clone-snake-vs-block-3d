using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RefreshUIData : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentLevelText;

    private void Start()
    {
        currentLevelText.text = $"Level: {SceneManager.GetActiveScene().buildIndex + 1}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LastLevel()
    {
        SceneManager.LoadScene(0);
    }
}
