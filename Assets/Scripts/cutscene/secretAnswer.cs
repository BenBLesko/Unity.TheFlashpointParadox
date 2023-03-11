using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class secretAnswer : MonoBehaviour
{
    public GameObject areYouSure; // accessible GameObject

    // https://answers.unity.com/questions/896434/new-ui-input-field-getting-a-correct-answer.html
    public void CheckAnswer() // to check the answer
    {
        {
            StartCoroutine(wrongAnswer()); // to start a coroutine
        }

        IEnumerator wrongAnswer()
        {
            string value = gameObject.GetComponent<InputField>().text; // to get a value from the InputField

            if (value.CompareTo("A") == 0 || value.CompareTo("a") == 0) // if the input is A or a
            {
                SceneManager.LoadScene("Alternative-Ending"); // load a scene
            }
            else // otherwise
            {
                areYouSure.SetActive(true); // make the character say, "you're wrong"
                yield return new WaitForSecondsRealtime(4); // to wait three seconds
                areYouSure.SetActive(false); // to set gameobject inactive
            }
        }
    }
}
