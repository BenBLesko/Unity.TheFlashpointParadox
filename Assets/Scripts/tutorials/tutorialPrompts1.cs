using UnityEngine;
using UnityEngine.UI;

public class tutorialPrompts1 : MonoBehaviour
{
    [SerializeField] Text tutorialPrompt; // to get access the Tutorial UI!
    [SerializeField] GameObject player; // to get access to the Player

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            tutorialPrompt.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            tutorialPrompt.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
