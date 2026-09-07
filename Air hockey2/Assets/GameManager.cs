using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0;
    public static int AIScore = 0;

    public GUISkin layout;

    private GameObject puck;

    void Start()
    {
        puck = GameObject.FindGameObjectWithTag("Puck");
    }

    public static void Score(string goalName)
    {
        if (goalName == "GolATop")
            PlayerScore++;
        else if (goalName == "GolVBottom")
            AIScore++;
    }

    void OnGUI()
    {
        if (layout != null)
            GUI.skin = layout;

        // Escala da interface
        Matrix4x4 matrixBackup = GUI.matrix;
        float scale = Screen.height / 600f; // aumenta proporcionalmente à tela
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * scale);

        float center = Screen.width / (2f * scale);

        GUI.Label(new Rect(center - 120, 20, 80, 60), PlayerScore.ToString());
        GUI.Label(new Rect(center + 40, 20, 80, 60), AIScore.ToString());
        GUI.Label(new Rect(center - 10, 20, 20, 60), "X");

        if (PlayerScore >= 7)
            GUI.Label(new Rect(center - 120, 120, 250, 60), "VOCÊ VENCEU!");

        if (AIScore >= 7)
            GUI.Label(new Rect(center - 120, 120, 250, 60), "IA VENCEU!");

        GUI.matrix = matrixBackup;
    }
}