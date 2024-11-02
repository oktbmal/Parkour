using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;     // Nút để bắt đầu trò chơi
    public Button settingsButton;   // Nút vào phần cài đặt
    public Button exitButton;       // Nút để thoát trò chơi

    void Start()
    {
        // Gán hàm cho các nút
        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(OpenSettings);
        exitButton.onClick.AddListener(ExitGame);
    }

    // Hàm để bắt đầu trò chơi
    void StartGame()
    {
        // Load scene trò chơi (thay đổi "GameScene" thành tên scene của bạn)
        SceneManager.LoadScene("IntroGame");
    }

    // Hàm để mở phần cài đặt
    void OpenSettings()
    {
        // Tạo logic để mở cửa sổ cài đặt ở đây
        Debug.Log("Mở cửa sổ cài đặt.");
        // Ví dụ: mở một Panel cài đặt hoặc một scene khác
    }

    // Hàm để thoát trò chơi
    void ExitGame()
    {
        Debug.Log("Thoát trò chơi.");
        Application.Quit();
    }
}
