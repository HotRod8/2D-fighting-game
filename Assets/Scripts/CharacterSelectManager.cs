using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectManager : MonoBehaviour
{
    public Image[] characterImages; // Assign in the inspector
    public Color player1Color = Color.blue;
    public Color player2Color = Color.red;

    private int? player1Choice = null;
    private int? player2Choice = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // Player 1 selects character 1
        {
            SelectCharacter(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.S)) // Player 1 selects character 2
        {
            SelectCharacter(1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.K)) // Player 2 selects character 1
        {
            SelectCharacter(0, 2);
        }
        else if (Input.GetKeyDown(KeyCode.L)) // Player 2 selects character 2
        {
            SelectCharacter(1, 2);
        }

        if (player1Choice.HasValue && player2Choice.HasValue)
        {
            // Both characters have been selected, load the fight scene
            SceneManager.LoadScene("SampleScene");
        }
    }

    void SelectCharacter(int charIndex, int player)
    {
        if (player == 1)
        {
            if (player1Choice.HasValue) return; // Player 1 has already selected
            player1Choice = charIndex;
            characterImages[charIndex].color = player1Color;
        }
        else
        {
            if (player2Choice.HasValue) return; // Player 2 has already selected
            player2Choice = charIndex;
            characterImages[charIndex].color = player2Color;
        }
    }
}