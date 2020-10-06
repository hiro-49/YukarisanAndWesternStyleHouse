using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject conversationCanvas;
    ConversationManager cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = conversationCanvas.GetComponent<ConversationManager>();
        string csvFileName = "DummyScenario";
        List<string[]> talkData = MyCSVReader.LoadCSV(csvFileName);
        cm.StartConversation(talkData);
    }

        
}
