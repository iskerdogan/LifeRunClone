using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Gate : MonoBehaviour,ICollectable
{
    [SerializeField]
    private GateController gateController;

    [SerializeField]
    private GameObject movementObstacle;
    
    public OperationType operationType;

    public ColorType colorType;
    public TextMeshPro text;
    public int value;
    public bool activateGate;
    public bool activateMovementGate;

    private void Start() 
    {
        InitGate();    
    }

    private void InitGate()
    {
         if (!activateGate)
        {
            gameObject.SetActive(false);
            return;
        }
        if (activateMovementGate)
        {
            movementObstacle.transform.LeanMoveLocalY(1.320624f,2f).setLoopPingPong();
        }

        switch (operationType)
        {
            case OperationType.Div:
                text.text="/";
                break;
            case OperationType.Mul:
                text.text="x";
                break;
            case OperationType.Sum:
                text.text="-";
                break;
            case OperationType.Sub:
                text.text="+";
                break;
        }

        var renderer = gameObject.GetComponent<Renderer>();
        switch (colorType)
        {
            case ColorType.Blue:
                renderer.material = gateController.Blue;
                break;
            case ColorType.Red:
                renderer.material = gateController.Red;
                break;    
        }

        text.text += value.ToString();
    }

    public void DoOperation()
    {
        switch (operationType)
        {
            case OperationType.Div:
                PlayerController.Instance.DecraseSpermCount(value,OperationType.Div);
                break;
            case OperationType.Mul:
                PlayerController.Instance.IncreaseSpermCount(value,OperationType.Mul);
                break;
            case OperationType.Sub:
                PlayerController.Instance.IncreaseSpermCount(value,OperationType.Sub);
                break;
            case OperationType.Sum:
                PlayerController.Instance.DecraseSpermCount(value,OperationType.Sum);
                break;
        }
    }
    
    private void Close()
    {
        gateController.CloseGates();
        this.gameObject.SetActive(false);
    }
    public void Collect()
    {
        //PlayerController.Instance.Upgrade();
        DoOperation();
        Close();
    }
}
