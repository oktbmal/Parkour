using UnityEngine;
using UnityEngine.Playables;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public List<PlayableDirector> cutscenes; // Danh sách các PlayableDirector

    private int currentCutsceneIndex = 0;     // Chỉ số của cutscene hiện tại

    void Start()
    {
        PlayCutscene(currentCutsceneIndex); // Phát cutscene đầu tiên
    }

    void Update()
    {
        if (currentCutsceneIndex < cutscenes.Count)
        {
            PlayableDirector currentCutscene = cutscenes[currentCutsceneIndex];

            // Kiểm tra xem cutscene hiện tại đã chạy xong chưa
            if (currentCutscene.state != PlayState.Playing && currentCutscene.time >= currentCutscene.duration)
            {
                Debug.Log("Cutscene " + currentCutsceneIndex + " đã chạy xong.");

                // Nếu cutscene hiện tại là cutscene đầu tiên
                if (currentCutsceneIndex == 0)
                {
                    // Chuyển đến scene GamePlayer
                    SceneManager.LoadScene("GamePlayer");
                }
            }
        }
    }

    // Hàm phát cutscene theo chỉ số
    public void PlayCutscene(int index)
    {
        if (index >= 0 && index < cutscenes.Count)
        {
            PlayableDirector cutsceneToPlay = cutscenes[index];
            cutsceneToPlay.Play();
            Debug.Log("Đang phát cutscene " + index);
        }
        else
        {
            Debug.LogError("Chỉ số cutscene không hợp lệ: " + index);
        }
    }
}
