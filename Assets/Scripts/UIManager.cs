using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _runsText;

    [SerializeField]
    private Text _wicketsText;

    // Start is called before the first frame update
    void Start()
    {
        _runsText.text = "Runs: " + 0;
        _wicketsText.text = "Wickets: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int runs)
    {
        _runsText.text = $"Runs: {runs}";
    }

    public void updateWicket(int wicket)
    {
        _wicketsText.text = $"Wickets {wicket}";
    }
}
