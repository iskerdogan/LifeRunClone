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

    private int currentSpermCount;
    public int CurrentSpermCount => currentSpermCount;
    private List<Sperm> sperms=new List<Sperm>();
    private List<Sperm> activeSperms=new List<Sperm>();

    public event Action OnSpermCountChanged;

    private void Awake() 
    {
        GenerateSperms();
    }
    private void Start() 
    {
        Add();
    }
    public void Add()
    {
        if (currentSpermCount >= spermsPositions.Length) return;
        var sperm = sperms[currentSpermCount];
        activeSperms.Add(sperm);
        sperm.gameObject.SetActive(true);
        sperm.SetTarget(spermsPositions[currentSpermCount++]);
        OnSpermCountChanged?.Invoke();  
        Rearrange();

    }

    public void Remove(Sperm sperm = null)
    {
        if (currentSpermCount <= 0) return;
        if (sperm == null)
        {
            sperms[--currentSpermCount].gameObject.SetActive(false);
            activeSperms.RemoveAt(activeSperms.Count-1);
            OnSpermCountChanged?.Invoke();
        }
        else
        {
            sperm.gameObject.SetActive(false);
            currentSpermCount--;
            OnSpermCountChanged?.Invoke();
            activeSperms.Remove(sperm);
            Debug.Log(sperm);
            Rearrange();
        }
    }

    private void GenerateSperms()
    {
        for (int i = 0; i < spermsPositions.Length; i++)
        {
            var sperm = Instantiate(spermPrefab, Vector3.zero, Quaternion.identity, transform);
            sperm.LeanRotateY(180,0f);
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


}
