using UnityEngine;

public class QuitGameManager : MonoBehaviour
{
    public GameObject quitPanel;

   
    public void ShowQuitPanel()
    {
        quitPanel.SetActive(true);
    }

    // 확인 버튼 클릭 시 호출
    public void QuitGame()
    {
        Debug.Log("게임 종료!");
        Application.Quit();
    }

    // 취소 버튼 클릭 시 호출
    public void HideQuitPanel()
    {
        quitPanel.SetActive(false);
    }
}
