using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changemodel : MonoBehaviour
{
    public GameObject venatormodel;
    public GameObject xwingmodel;
    public GameObject ywingmodel;

    private GameObject[] models;
    private int currentModelIndex = -1;

    private void Start()
    {
        // Inicializar el array de modelos
        models = new GameObject[] { venatormodel, xwingmodel, ywingmodel };

        // Desactivar todos los modelos al inicio
        DeactivateAllModels();

        // Activar un modelo aleatorio al inicio
        ShowRandomModel();
    }

    // Método público que será llamado por el botón
    public void ChangeToRandomModel()
    {
        ShowRandomModel();
    }

    private void ShowRandomModel()
    {
        // Desactivar todos los modelos
        DeactivateAllModels();

        // Generar un índice aleatorio diferente al actual
        int newIndex;
        do
        {
            newIndex = Random.Range(0, models.Length);
        }
        while (newIndex == currentModelIndex && models.Length > 1);

        // Activar el nuevo modelo
        if (models[newIndex] != null)
        {
            models[newIndex].SetActive(true);
            currentModelIndex = newIndex;

            Debug.Log("Modelo activado: " + models[newIndex].name);
        }
        else
        {
            Debug.LogWarning("El modelo en el índice " + newIndex + " es null!");
        }
    }

    private void DeactivateAllModels()
    {
        foreach (GameObject model in models)
        {
            if (model != null)
            {
                model.SetActive(false);
            }
        }
    }

}