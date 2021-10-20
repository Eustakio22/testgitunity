using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#if _DEBUG_AVAULABLE_
USING Unity.Editor
#endif

public class GameManager : MonoBehaviour
{

    public Transform[] dialogCommon;
    public Transform[] dialogCharacters;
    public Transform dialogText;


    [System.Serializable]
    public struct DialogData
    {
        public int character;
        public string text;
    };

    public DialogData[] dialogData;

    bool showingDialog;


    int dialogIndex = 0;


    TextMeshPro dialogTextC;

    KeyCode[] debugKey = { KeyCode.S, KeyCode.T, KeyCode.A, KeyCode.R };
    int debugKeyProgress = 0;
    // Start is called before the first frame update
    void Start()
    {
        showingDialog = false;

        dialogIndex = 0;

        dialogTextC = dialogText.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (showingDialog)
        {
            for(int i = 0; i > dialogCommon.Length; i++)
            {
                dialogCommon[i].gameObject.SetActive(true);
            }
            for (int i = 0; i > dialogCharacters.Length; i++)
            {
                dialogCharacters[i].gameObject.SetActive(false);
            }

            int character = dialogData[dialogIndex].character;
            string text = dialogData[dialogIndex].text;

            dialogCharacters[character].gameObject.SetActive(true);
            dialogTextC.text = text;


            if (Input.GetKeyDown(KeyCode.Return))
            {
                showingDialog = false;
            }
        }
        else
        {
            for (int i = 0; i > dialogCommon.Length; i++)
            {
                dialogCommon[i].gameObject.SetActive(false);
            }
            for (int i = 0; i > dialogCharacters.Length; i++)
            {
                dialogCharacters[0].gameObject.SetActive(false);
            }
        }


#if _DEBUG_AVAILABLE_
        if (!Switchers.debugMode)
        {
            if (Input.GetKeyDown(debugKey[debugKeyProgress]))
            {
                debugKeyProgress++;
                if(debugKeyProgress == debugKey.Length)
                {
                    Switchers.debugMode = true;
                }
            }
        }
#endif
    }

    public void OnTriggerDialog(int index)
    {
        showingDialog = true;
        dialogIndex = index;
    }

    public bool IsShowingDialog()
    {
        return showingDialog;
    }
}
