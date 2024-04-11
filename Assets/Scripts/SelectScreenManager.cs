using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectScreenManager : MonoBehaviour
{
    public int numOfPlayers = 2;
    public List<PlayerInterfaces> p1Interfaces = new List<PlayerInterfaces>();
    public Portrait_Info[] portraitPrefabs; //All our entries as portraits
    public int maxX; // how many portraits we have on the X and Y
    public int maxY;
    Portrait_Info[,] charGrid;

    public GameObject portraitCanvas;

    bool loadlevel;
    public bool bothPlayersSelected;

    CharacterManager charManager;

    #region Singleton
    public static SelectScreenManager instance;
    public static SelectScreenManager GetInstance() 
    {
        return instance;
    }

    void Awake()
    {
        instance = this;    
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        charManager = CharacterManager.GetInstance();
        numOfPlayers = CharacterManager.numOfUsers;

        charGrid = new Portrait_Info[maxX, maxY];

        int x = 0, y = 0;

        portraitPrefabs = portraitCanvas.GetComponentsInChildren<Portrait_Info>();

        for (int i = 0; i < portraitPrefabs.Length; i++) 
        {
            portraitPrefabs[i].posX += x;
            portraitPrefabs[i].posY += y;

            charGrid[x, y] = portraitPrefabs[i];

            if (x < maxX - 1) x++;
            else 
            { 
                x = 0; 
                y++; 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!loadlevel) 
        { 
            for (int i = 0; i < p1Interfaces.Count; i++) 
            {
                if(i < numOfPlayers) 
                {
                    if (Input.GetButtonUp("Fire1" + charManager.players[i].inputId))
                    {
                        p1Interfaces[i].playerBase.hasCharacter = false;
                    }

                    if (!charManager.players[i].hasCharacter)
                    {
                        p1Interfaces[i].playerBase = charManager.players[i];

                        HandleSelectorPosition(p1Interfaces[i]);
                        HandleSelectScreenInput(p1Interfaces[i], charManager.players[i].inputId);
                        HandleCharacterPreview(p1Interfaces[i]);
                    }
                }
                else { charManager.players[i].hasCharacter = true; }
            }
        }
        if (bothPlayersSelected)
        {
            Debug.Log("loading");
            StartCoroutine("LoadLevel");
            loadlevel = true;
        }
        else
        {
            if (charManager.players[0].hasCharacter 
                && charManager.players[1].hasCharacter)
            {
                bothPlayersSelected = true;
            }
        }
    }

    void HandleSelectScreenInput(PlayerInterfaces p1, string playerId)
    {
        #region Grid Navigation

        /*Change the x and y to select an active entry in the grid.
         * We also smooth out the controls so if the user keeps pressing the button
         * it won't switch more than once over half a sec.*/

        float vertical = Input.GetAxis("Vertical" + playerId);

        if (vertical != 0)
        {
            if (!p1.hitInputOnce)
            {
                if (vertical > 0)
                {
                    p1.activeY = (p1.activeY > 0) ? p1.activeY - 1 : maxY - 1;
                }
                else
                {
                    p1.activeY = (p1.activeY > 0) ? p1.activeY + 1 : 0;
                }

                p1.hitInputOnce = true;
            }
        }

        float horizontal = Input.GetAxis("Horizontal" + playerId);

        if(horizontal != 0)
        {
            if (!p1.hitInputOnce)
            {
                if (horizontal > 0)
                {
                    p1.activeX = (p1.activeX > 0) ? p1.activeX - 1 : maxX - 1;
                }
                else
                {
                    p1.activeX = (p1.activeX < maxX - 1) ? p1.activeX + 1 : 0;
                }

                p1.timerToReset = 0;
                p1.hitInputOnce = true;
            }
        }

        if(vertical == 0 && horizontal == 0)
        {
            p1.hitInputOnce = false;
        }

        if (p1.hitInputOnce)
        {
            p1.timerToReset += Time.deltaTime;

            if (p1.timerToReset > 0.8f)
            {
                p1.hitInputOnce = false;
                p1.timerToReset = 0;
            }
        }
        #endregion

        //if the user presses space, he has selected a char.
        if (Input.GetButtonUp("Jump" + playerId))
        {
            //make a reaction on the character, b/c why not?
            //p1.createdCharacter.GetComponentInChildren<Animator>().Play("Kick");

            //pass the character to the character manager so that we know what prefab to create in
            p1.playerBase.playerPrefab = 
                charManager.returnCharacterWithID(p1.activePortrait.charID).prefab;

            p1.playerBase.hasCharacter = true;
        }
    }

    IEnumerator LoadLevel()
    {
        // if any of the players is an AI, then assign a random char to the prefab
        for (int i = 0; i < charManager.players.Count; i++)
        {
            if (charManager.players[i].playerType == PlayerBase.PlayerType.ai)
            {
                if (charManager.players[i].playerPrefab == null)
                {
                    int ranValue = Random.Range(0, portraitPrefabs.Length);

                    charManager.players[i].playerPrefab = 
                        charManager.returnCharacterWithID(portraitPrefabs[ranValue].charID).prefab;

                    Debug.Log(portraitPrefabs[ranValue].charID);
                }
            }
        }

        yield return new WaitForSeconds(2); //after 2 seconds load 
        SceneManager.LoadSceneAsync("level", LoadSceneMode.Single);
    }

    void HandleSelectorPosition(PlayerInterfaces p1)
    {
        p1.selector.SetActive(true); // enable selector

        p1.activePortrait = charGrid[p1.activeX, p1.activeY]; // find active portrait

        //and place selector over its position
        Vector2 selectorPosition = p1.activePortrait.transform.position;
        selectorPosition = selectorPosition + new 
            Vector2(portraitCanvas.transform.localPosition.x, portraitCanvas.transform.localPosition.y);
        p1.selector.transform.position = selectorPosition;
    }

    void HandleCharacterPreview(PlayerInterfaces p1)
    {
        //If the previews portrait we had, is not the same as the active one we have
        //that means we changed characters
        if (p1.previewPortrait != p1.activePortrait)
        {
            if (p1.createdCharacter != null)//delete the one we have now if we do have one
            {
                Destroy(p1.createdCharacter);
            }

            //and create another one
            GameObject go = Instantiate(
                CharacterManager.GetInstance().returnCharacterWithID(p1.activePortrait.charID).prefab,
                p1.charVisPos.position, Quaternion.identity) as GameObject;

            p1.createdCharacter = go;
            p1.previewPortrait = p1.activePortrait;

            //if(!string.Equals(p1.playerBase.playerId, charManager.players[0].playerId))
            //{
            //    p1.createdCharacter.GetComponent<StateManager>().lookRight = false;
            //}
        }
    }

    [System.Serializable]
    public class PlayerInterfaces 
    {
        public Portrait_Info activePortrait; // curr. active portrait for p1
        public Portrait_Info previewPortrait;
        public GameObject selector; //the select indicator for p1
        public Transform charVisPos; //the visualization pos for p1
        public GameObject createdCharacter; //p1's created character

        public int activeX;
        public int activeY;

        //variables for smoothing out input
        public bool hitInputOnce;
        public float timerToReset;

        public PlayerBase playerBase;

    }
}
