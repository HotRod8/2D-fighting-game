using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSelectionManager : MonoBehaviour
{


    public GameObject[] characterPrefabs;
    public enum CharacterId
{
    Goku = 0,
    Vegeta = 1,
}
    public void SelectCharacter(CharacterSelectionManager.CharacterId characterId)
    {
        // Save the selected character ID to PlayerPrefs
        PlayerPrefs.SetInt("SelectedCharacterId", (int)characterId);
        PlayerPrefs.Save(); // Make sure to save changes
       
        // Optionally, load the fight scene after selection
        SceneManager.LoadScene("SampleScene");
    }
}
