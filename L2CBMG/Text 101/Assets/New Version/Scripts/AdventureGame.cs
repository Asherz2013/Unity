using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField]
    Text storyText;

    [SerializeField]
    State startingState;

    State state;

    // Use this for initialization
    void Start()
    {
        state = startingState;
        storyText.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
