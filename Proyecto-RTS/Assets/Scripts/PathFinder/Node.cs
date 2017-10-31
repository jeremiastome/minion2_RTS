using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node NodoPadre;
    public Node NodoFinal;
    private Vector2 position;
    public float costoTotal;
    public float costoG;
    public bool walkable = true;

    public Node(Node nodoPadre, Node nodoFinal, Vector2 position, float costo)
    {
        NodoPadre = nodoPadre;
        NodoFinal = nodoFinal;
        this.position = position;
        costoG = costo;
        if (nodoFinal != null)
        {
            costoTotal = costoG + Calcularcosto();
        }
    }

    public Vector2 getPosition() {        
        return position;
    }

    public void setPosition(Vector2 position) {
        this.position = position;
    }

    public int getX(){
        return (int)position.x; 
    }

    public int getY(){
        return (int)position.y;
    }

    public float Calcularcosto(){
        return Math.Abs(getX() - NodoFinal.getX()) + Math.Abs(getY() - NodoFinal.getY());
    }

    public Boolean esIgual(Node node){
        return (getPosition() == node.getPosition());
    }
}
