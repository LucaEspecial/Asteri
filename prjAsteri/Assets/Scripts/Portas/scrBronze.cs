﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrBronze : MonoBehaviour
{
     private Inventario inventario;
    public GameObject bntItem;
    
    [TextArea(3, 10)]
    public string[] dialogoLinhas;
    public string nome;
    [SerializeField] scrControladorDialogo txtDialogo, txtNome, imgMorpheus, imgHera, imgRobo; 

    public GameObject DiaAntes;

    private void Start() 
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void Update() 
    {
        if (SistemaPorta.Bronze && !txtDialogo.dialogoAtivo)
        {
            Destroy(DiaAntes);
            if (!txtDialogo.dialogoAtivo)
            {
                if (txtDialogo.linhaAtual < dialogoLinhas.Length -1)
                {
                    txtDialogo.dialogoLinhas = dialogoLinhas;
                    txtNome.nome = nome;
                    txtDialogo.linhaAtual = 0;
                    txtDialogo.MostrarDialogo();
                    txtNome.MostrarNome(); 
                    imgMorpheus.MostrarMorpheus();
                    imgHera.RetirarHera();
                    imgRobo.RetirarRobo();
                    SistemaPorta.Bronze = false; 
                }
                else
                {
                   txtDialogo.AcabaDialogo();
                }
                
            }

            for (int i = 0; i < inventario.slots.Length; i++)
            {
                if (inventario.taCheio[i] == false)
                {
                    inventario.taCheio[i] = true;
                    Instantiate(bntItem, inventario.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                    
                }
            }

        }
    }
            
    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.CompareTag("Player"))
        {
            SistemaPorta.BronzeTocou = true;
           
        } 
    }

    void OnTriggerExit2D(Collider2D quem)
    {
        if (quem.CompareTag("Player"))
        {
            SistemaPorta.BronzeTocou = false;
        } 
    }
}