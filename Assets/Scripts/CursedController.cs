using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursedController : MonoBehaviour
{
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode enterKey = KeyCode.Return;


    private bool isSelectionLocked = false; // Flag to track if selection is locked.


    // Reference to the CharacterSelectionManager script.
    public CharacterSelectionManager characterSelectionManager;


    void Start()
    {
        //find the CharacterSelectionManager automatically if not set in the inspector
        if(characterSelectionManager == null)
        {
            characterSelectionManager = FindObjectOfType<CharacterSelectionManager>();
        }
    }


    void Update()
    {
        // Lock in player selection when Enter key is pressed.
        if (Input.GetKeyDown(enterKey) && !isSelectionLocked)
        {
            isSelectionLocked = true;
           
           
            //If the player's x position is positive, select Vegeta, else select Goku
            CharacterSelectionManager.CharacterId selectedCharacter = transform.position.x > 0 ?
                CharacterSelectionManager.CharacterId.Vegeta :
                CharacterSelectionManager.CharacterId.Goku;


            // Use the CharacterSelectionManager to select the character and load the next scene
            characterSelectionManager.SelectCharacter(selectedCharacter);
        }


        // Allow movement only if the selection hasn't been locked.
        if (!isSelectionLocked)
        {
            if (Input.GetKey(moveLeftKey) && transform.position.x > 0 || Input.GetKey(moveRightKey) && transform.position.x < 0)
            {
                // Movement logic
                transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
            }
        }
    }
}
