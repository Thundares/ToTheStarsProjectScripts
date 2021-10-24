﻿using UnityEngine;

public class Titan : MonoBehaviour
{
    [SerializeField] private GameObject titanPrefab = null;
    [SerializeField] private AudioSource seSource = null;
    [SerializeField] private AudioClip titanSe = null;
    private bool trigged = false;

    public void CheckTitan()
    {
        if (VariablesManager.dHeight >= 50 && !trigged) 
        {
            trigged = true;
            seSource.PlayOneShot(titanSe);
            GameObject titan = Instantiate(titanPrefab, GameObject.FindGameObjectWithTag("egg").transform);
            Destroy(titan, 10f);
            this.gameObject.SetActive(false);
        }
    }
}

