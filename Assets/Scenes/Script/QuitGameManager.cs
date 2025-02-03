using UnityEngine;

public class QuitGameManager : MonoBehaviour
{
    public GameObject quitPanel;

   
    public void ShowQuitPanel()
    {
        quitPanel.SetActive(true);
    }

    // Ȯ�� ��ư Ŭ�� �� ȣ��
    public void QuitGame()
    {
        Debug.Log("���� ����!");
        Application.Quit();
    }

    // ��� ��ư Ŭ�� �� ȣ��
    public void HideQuitPanel()
    {
        quitPanel.SetActive(false);
    }
}
