using UnityEngine;
using UnityEngine.UI;

public class ParkTusu : MonoBehaviour
{
    public string targetTag = "Arac";
    public string areaTag = "Area";
    public Text textToDisplay;

    private bool enteredArea = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && !enteredArea)
        {
            enteredArea = true;
            DisplayText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag) && enteredArea)
        {
            enteredArea = false;
            HideText();
        }
    }

    private void DisplayText()
    {
        if (textToDisplay != null)
        {
            textToDisplay.enabled = true;
        }
    }

    private void HideText()
    {
        if (textToDisplay != null)
        {
            textToDisplay.enabled = false;
        }
    }
}
