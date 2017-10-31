using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder {

    private int costoIrDerecho;
    private int costoIrDiagonal;
    private List<Node> listaAbierta;
    private List<Vector2> listaCerrada;
    public MapManager motor;

    public PathFinder(MapManager motor){
        costoIrDerecho = 10;
        costoIrDiagonal = 15;
        listaAbierta = new List<Node>();
        listaCerrada = new List<Vector2>();
        this.motor = motor;
    }

    private void adicionarNodoAListaAbierta(Node nodo) {
        int indice = 0;
        float costo = nodo.costoTotal;
        while ((listaAbierta.Count > indice) && (costo < listaAbierta[indice].costoTotal)) {
            indice++;
        }
        listaAbierta.Insert(indice, nodo);
    }

    public List<Vector2> encontrarCamino(Vector2 posTileInicial, Vector2 posTileFinal)
    { 
        Tile tileInicial = motor.getTile((int)posTileInicial.x, (int)posTileInicial.y);
        Tile tileFinal = motor.getTile((int)posTileFinal.x, (int)posTileFinal.y);

        if (!tileInicial.walkable || !tileFinal.walkable) {
            return null;
        }

        listaAbierta.Clear();
        listaCerrada.Clear();

        Node nodoInicial;
        Node nodoFinal;

        nodoFinal = new Node(null, null, posTileFinal, 0);
        nodoInicial = new Node(null, nodoFinal, posTileInicial, 0);

        // se adiciona el nodo inicial
        adicionarNodoAListaAbierta(nodoInicial);
        while (listaAbierta.Count > 0)
        {
            Node nodoActual = listaAbierta[listaAbierta.Count - 1];
            // si es el nodo Final
            if (nodoActual.esIgual(nodoFinal))
            {
                List<Vector2> mejorCamino = new List<Vector2>();
                while (nodoActual != null)
                {
                    mejorCamino.Insert(0, nodoActual.getPosition()); //Hola
                    nodoActual = nodoActual.NodoPadre;
                }
                return mejorCamino;
            }
            listaAbierta.Remove(nodoActual);

            foreach (Node posibleNodo in encontrarNodosAdyacentes(nodoActual, nodoFinal))
            {
                // si el nodo no se encuentra en la lista cerrada
                if (!listaCerrada.Contains(posibleNodo.getPosition()))
                {
                    // si ya se encuentra en la lista abierta
                    if (listaAbierta.Contains(posibleNodo))
                    {
                        if (posibleNodo.costoG >= posibleNodo.costoTotal)
                        {
                            continue;
                        }
                    }
                    adicionarNodoAListaAbierta(posibleNodo);
                }
            }
            // se cierra el nodo actual
            listaCerrada.Add(nodoActual.getPosition());
        }
        return null;
    }

    public List<Node> encontrarNodosAdyacentes(Node nodoActual, Node nodoFinal)
    {
        List<Node> nodosAdyacentes = new List<Node>();
        int X = nodoActual.getX();
        int Y = nodoActual.getY();
        bool arribaIzquierda = true;
        bool arribaDerecha = true;
        bool abajoIzquierda = true;
        bool abajoDerecha = true;

        //Izquierda
        if (motor.existTile(X - 32, Y - 16)) {
            nodosAdyacentes.Add(new Node(nodoActual, nodoFinal, new Vector2(X - 32, Y - 16), costoIrDerecho + nodoActual.costoG));
        }
        else
        {
            arribaIzquierda = false;
            abajoIzquierda = false;
        }

        //Derecha
        if (motor.existTile(X + 32, Y + 16))        {
            nodosAdyacentes.Add(new Node(nodoActual, nodoFinal, new Vector2(X + 32, Y + 16), costoIrDerecho + nodoActual.costoG));
        }
        else
        {
            arribaDerecha = false;
            abajoDerecha = false;
        }

        //Arriba
        if (motor.existTile(X + 32, Y - 16))
        {
            nodosAdyacentes.Add(new Node(nodoActual, nodoFinal, new Vector2(X + 32, Y - 16), costoIrDerecho + nodoActual.costoG));
        }
        else
        {
            arribaIzquierda = false;
            arribaDerecha = false;
        }

        // Abajo
        if (motor.existTile(X - 32, Y + 16)) {
            nodosAdyacentes.Add(new Node(nodoActual, nodoFinal, new Vector2(X - 32, Y + 16), costoIrDerecho + nodoActual.costoG));
        }
        else
        {
            abajoIzquierda = false;
            abajoDerecha = false;
        }

        // Diagonales
        if ((arribaIzquierda) && (motor.existTile(X, Y - 32))) {
            nodosAdyacentes.Add(new Node(nodoActual, nodoFinal, new Vector2(X, Y - 32), costoIrDiagonal + nodoActual.costoG));
        }

        if ((arribaDerecha) && (motor.existTile(X + 64, Y))) {
            nodosAdyacentes.Add(new Node(nodoActual, nodoFinal, new Vector2(X + 64, Y), costoIrDiagonal + nodoActual.costoG));
        }

        if ((abajoIzquierda) && (motor.existTile(X - 64, Y))){
            nodosAdyacentes.Add(new Node(nodoActual, nodoFinal, new Vector2(X - 64, Y), costoIrDiagonal + nodoActual.costoG));
        }

        if ((abajoDerecha) && (motor.existTile(X, Y + 32))){
            nodosAdyacentes.Add(new Node(nodoActual, nodoFinal, new Vector2(X, Y + 32), costoIrDiagonal + nodoActual.costoG));
        }

        return nodosAdyacentes;
    }
}
