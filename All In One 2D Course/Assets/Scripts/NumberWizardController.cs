using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberWizardController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI valueText;
    [SerializeField] TextMeshProUGUI bubbleText;
    [SerializeField] TextMeshProUGUI wonText;
    [SerializeField] List<Button> buttonsList;

    int randomVal;
    int max = 1000;
    int min = 0;
    // Start is called before the first frame update
    void Start()
    {
        randomVal = Random.Range(0,1001);
        valueText.text = randomVal.ToString();
        foreach (var item in buttonsList)
        {
            if (item.name.Contains("Menu"))
                item.onClick.AddListener(()=> { GameController.instance.LoadScene("MainMenu"); });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Calculator(bool higher)
    {
        if (higher)
        {
            min = randomVal;
            randomVal = Random.Range(min,max);
        }
        else
        {
            max = randomVal;
            randomVal = Random.Range(min, max);
        }
        UpdateUI();
    }
    public void ButtonHigher()
    {
        Calculator(true);
    }
    public void ButtonLower() {
        Calculator(false);
    }
    public void ButtonRight()
    {
        wonText.gameObject.SetActive(true);
        bubbleText.text = "I Got it, your value was: ";


        ChangeButtons();
    }

    private void UpdateUI()
    {
        valueText.text = randomVal.ToString();
    }

    public void RestartIt()
    {
        wonText.gameObject.SetActive(false);
        ChangeButtons();
        bubbleText.text = "I think that the number you are thinking is:";
        min = 0;
        max = 1001;
        randomVal = Random.Range(0, 1001);
        UpdateUI();
    }
    private void ChangeButtons()
    {
        foreach (var item in buttonsList)
        {
            item.gameObject.SetActive(!item.gameObject.activeSelf);
        }
    }
}
