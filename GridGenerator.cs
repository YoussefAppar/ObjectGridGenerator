using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{  
    private int gridIndex ;
    private int gridIndex_Y ;
    private int gridLength ;
    public int gridLimit_X;
    public int gridLimit_Y; 
    public GameObject[] objectsInOrder ; 
    private GameObject currentVerticalObject ; 
    public float offSet ; 

    public void f_StartGenerating()
    {
      gridLength =  gridLimit_X * gridLimit_Y;
      objectsInOrder = new GameObject[gridLength];
      gridIndex = 0 ;
      gridIndex_Y = 0 ;
      f_createVerticalGrid();
    }

    public void f_createVerticalGrid()
    {
     objectsInOrder[gridIndex] = Instantiate(gameObject, new Vector3(transform.position.x , transform.position.y + offSet * gridIndex_Y, transform.position.z), transform.rotation);
     currentVerticalObject = objectsInOrder[gridIndex];
     gridIndex ++;
     gridIndex_Y ++;
     f_createHorizontalGrid();
    }

    public void f_createHorizontalGrid()
    {
     for(int i = 0 ; i < (gridLimit_X - 1) ; i++)
     {
      objectsInOrder[gridIndex] = Instantiate(gameObject, new Vector3(currentVerticalObject.transform.position.x + offSet * (i + 1), currentVerticalObject.transform.position.y, currentVerticalObject.transform.position.z), currentVerticalObject.transform.rotation); 
      objectsInOrder[gridIndex].transform.SetParent(currentVerticalObject.transform);
      gridIndex ++ ;  
     }
     if(gridIndex < gridLength)
     {               
      f_createVerticalGrid();
     } else 
     {
      gameObject.SetActive(false);
     }   
    }
}
