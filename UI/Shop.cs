using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Gravity")]
    [SerializeField] private Text _gravityValue = null;
    [SerializeField] private Button _minusBtn = null;
    [SerializeField] private Button _plusBtn = null;
    [SerializeField] private Button _buyG = null;
    [SerializeField] private Text _priceTextG = null;

    [Header("Power")]
    [SerializeField] private Text _powerValue = null;
    [SerializeField] private Button _minusPowerBtn = null;
    [SerializeField] private Button _plusPowerBtn = null;
    [SerializeField] private Button _buyP = null;
    [SerializeField] private Text _priceTextP = null;
    [Space]
    [SerializeField] private Text _moneyText = null;

    private int _money = 0;
    private int _priceG = 40;
    private int _priceP = 40;

    public void CheckButtons() 
    {
        //Is it possible to increase gravity?
        if (VariablesManager.fGravityLimit - VariablesManager.fGravityMulti <= -1)
        {
            _plusBtn.interactable = false;
        }
        else 
        {
            _plusBtn.interactable = true;
        }
        //Is it possible to decrese gravity?
        if (VariablesManager.fGravityLimit + VariablesManager.fGravityMulti > 1)
        {
            _minusBtn.interactable = true;
        }
        else 
        {
            _minusBtn.interactable = false;
        }

        //Is it possible to increase Power?
        if (VariablesManager.fPowerLimit - VariablesManager.fPowerMult <= -1)
        {
            _plusPowerBtn.interactable = false;
        }
        else
        {
            _plusPowerBtn.interactable = true;
        }
        //Is it possible to decrese gravity?
        if (VariablesManager.fPowerLimit + VariablesManager.fPowerMult > 1)
        {
            _minusPowerBtn.interactable = true;
        }
        else
        {
            _minusPowerBtn.interactable = false;
        }

        //How many bees
        _money = VariablesManager.iTotalBees - VariablesManager.iSpentBees;

        //prices
        _priceG = Mathf.FloorToInt((VariablesManager.fGravityLimit + 1) * 40);
        _priceP = Mathf.FloorToInt((VariablesManager.fPowerLimit + 1) * 40);

        if (_money >= _priceG && VariablesManager.fGravityLimit < 0.5f)
        {
            _buyG.interactable = true;
        }
        else 
        {
            _buyG.interactable = false;
        }

        if (_money >= _priceP && VariablesManager.fPowerLimit < 0.5f)
        {
            _buyP.interactable = true;
        }
        else
        {
            _buyP.interactable = false;
        }

        //update UI texts
        _gravityValue.text = VariablesManager.fGravityMulti.ToString("N1");
        _powerValue.text = VariablesManager.fPowerMult.ToString("N1");
        _priceTextG.text = _priceG.ToString("N0");
        _priceTextP.text = _priceP.ToString("N0");
        _moneyText.text = _money.ToString();
    }

    public void AddGravity() 
    {
        VariablesManager.fGravityMulti += 0.1f;
        CheckButtons();
    }

    public void SubGravity() 
    {
        VariablesManager.fGravityMulti -= 0.1f;
        CheckButtons();
    }

    public void AddPower()
    {
        VariablesManager.fPowerMult += 0.1f;
        CheckButtons();
    }

    public void SubPower()
    {
        VariablesManager.fPowerMult -= 0.1f;
        CheckButtons();
    }

    public void BuyG() 
    {
        _money -= _priceG;
        VariablesManager.iSpentBees += _priceG;
        VariablesManager.fGravityLimit += 0.1f;
        CheckButtons();
    }

    public void BuyP()
    {
        _money -= _priceP;
        VariablesManager.iSpentBees += _priceP;
        VariablesManager.fPowerLimit += 0.1f;
        CheckButtons();
    }
}
