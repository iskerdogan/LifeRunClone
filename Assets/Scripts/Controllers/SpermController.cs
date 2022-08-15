using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class SpermController : Singleton<SpermController>
{
    [SerializeField]
    private Transform[] spermsPositions;

    [SerializeField]
    private GameObject spermPrefab;

    [SerializeField]
    private int finalSpermCount;

    public int FinalSpermCount => finalSpermCount;
    private bool isSuccess;
    public bool IsSuccess => isSuccess;
    private int currentSpermCount;
    public int CurrentSpermCount => currentSpermCount;
    private List<Sperm> sperms = new List<Sperm>();
    private List<Sperm> activeSperms = new List<Sperm>();

    public List<Sperm> ActiveSperms => activeSperms;

    public event Action OnSpermCountChanged;

    private void Awake()
    {
        GenerateSperms();
        Add();
    }

    private void Start()
    {
        GameManager.OnAfterStateChanged += OnAfterStateChanged;
    }

    public void Add()
    {
        if (currentSpermCount >= spermsPositions.Length) return;
        var sperm = sperms[currentSpermCount];
        activeSperms.Add(sperm);
        sperm.gameObject.SetActive(true);
        sperm.SetTarget(spermsPositions[currentSpermCount++]);
        OnSpermCountChanged?.Invoke();
    }

    public void Remove(Sperm sperm = null)
    {
        if (currentSpermCount <= 0) return;
        if (sperm == null)
        {
            sperms[--currentSpermCount].gameObject.SetActive(false);
            activeSperms.RemoveAt(activeSperms.Count - 1);
            OnSpermCountChanged?.Invoke();
        }
        else
        {
            sperm.gameObject.SetActive(false);
            currentSpermCount--;
            OnSpermCountChanged?.Invoke();
            activeSperms.Remove(sperm);
            Rearrange();
        }
    }

    private void GenerateSperms()
    {
        for (int i = 0; i < spermsPositions.Length; i++)
        {
            var sperm = Instantiate(spermPrefab, Vector3.zero, Quaternion.identity, transform);
            sperm.SetActive(false);
            sperms.Add(sperm.GetComponent<Sperm>());

        }
    }

    private void Rearrange()
    {
        for (int i = 0; i < activeSperms.Count; i++)
        {
            activeSperms[i].SetTarget(spermsPositions[i]);
            activeSperms[i].gameObject.SetActive(true);
        }
    }

    private void SuccesOrFail() => isSuccess = currentSpermCount >= finalSpermCount ? true : false;

    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.InGame:
                currentSpermCount = 0;
                Add();
                break;
            case GameState.Final:
                SuccesOrFail();
                break;
        }
    }

}
