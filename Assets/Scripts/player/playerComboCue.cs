using System.Collections;
using UnityEngine;

public class playerComboCue : MonoBehaviour
{
    private bool canCombo;
    public GameObject comboVisual;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ComboCueCan());

            IEnumerator ComboCueCan()
            {
                canCombo = true;

                yield return new WaitForSeconds(0.5f);

                canCombo = false;
            }
        }

        if (Input.GetButtonDown("Fire2") && canCombo)
        {
            StartCoroutine(ComboVisual());

            IEnumerator ComboVisual()
            {
                yield return new WaitForSeconds(0.20f);

                comboVisual.GetComponent<SpriteRenderer>().enabled = true;
                comboVisual.GetComponent<AudioSource>().Play();

                yield return new WaitForSeconds(0.25f);

                comboVisual.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {

        }
    }
}
