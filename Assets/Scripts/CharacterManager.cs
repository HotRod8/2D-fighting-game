using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public const int numOfUsers = 2;
    public List<PlayerBase> players = new List<PlayerBase>(2); //the list of all our players and player types

    //the list of all info on any given character.
    //for now, it's their id and their corresponding prefab.
    public List<CharacterBase> roster = new List<CharacterBase>();

    //we use this function to find characters from their ID
    public CharacterBase returnCharacterWithID(string id)
    {
        CharacterBase retval = null;

        for (int i = 0; i < roster.Count; i++)
        {
            if (string.Equals(roster[i].charID, id))
            {
                retval = roster[i];
                break;
            }
        }

        return retval;
    }

    //we use this one to return the player from his created character, states
    //public PlayerBase returnPlayerFromStates(StateManager states)
    //{
    //    PlayerBase retVal = null;

    //    for (int i = 0; i < players.Count; i++)
    //    {
    //        if (players[i].playerStates == states)
    //        {
    //            retVal = players[i];
    //            break;
    //        }
    //    }

    //    return retVal;
    //}

    public static CharacterManager instance;
    public static CharacterManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}

[System.Serializable]
public class CharacterBase
{
    public string charID;
    public GameObject prefab;
}

[System.Serializable]
public class PlayerBase
{
    public string playerId;
    public string inputId;
    public PlayerType playerType;
    public bool hasCharacter;
    public GameObject playerPrefab;
//    public StateManager playerStates;
    public int score;

    public enum PlayerType
    {
        user, //Real person
        ai //CPU algorithm
    }
}
