//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
import java.util.Scanner;

class Nodo {
    int dato;
    Nodo siguiente;
    Nodo anterior;

    public Nodo(int dato) {
        this.dato = dato;
        this.siguiente = null;
        this.anterior = null;
    }
}

class ListaDoble {
    Nodo inicio;
    Nodo fin;
    int tamaño;

    public ListaDoble() {
        inicio = null;
        fin = null;
        tamaño = 0;
    }

    public void insertarInicio(int dato) {
        Nodo nuevo = new Nodo(dato);

        if (inicio == null) {
            inicio = fin = nuevo;
        } else {
            nuevo.siguiente = inicio;
            inicio.anterior = nuevo;
            inicio = nuevo;
        }
        tamaño++;
    }

    public void insertarFinal(int dato) {
        Nodo nuevo = new Nodo(dato);

        if (inicio == null) {
            inicio = fin = nuevo;
        } else {
            fin.siguiente = nuevo;
            nuevo.anterior = fin;
            fin = nuevo;
        }
        tamaño++;
    }

    public void recorrerAdelante() {
        Nodo actual = inicio;

        while (actual != null) {
            System.out.print(actual.dato + " <-> ");
            actual = actual.siguiente;
        }
        System.out.println("null");
    }

    public void recorrerAtras() {
        Nodo actual = fin;

        while (actual != null) {
            System.out.print(actual.dato + " <-> ");
            actual = actual.anterior;
        }
        System.out.println("null");
    }

    public int tamaño() {
        return tamaño;
    }

    public boolean estaVacia() {
        return inicio == null;
    }

    public int buscarPorValor(int valor) {
        Nodo actual = inicio;
        int indice = 0;

        while (actual != null) {
            if (actual.dato == valor) {
                return indice;
            }
            actual = actual.siguiente;
            indice++;
        }
        return -1;
    }

    public Integer buscarPorIndice(int indice) {
        if (indice < 0 || indice >= tamaño) {
            return null;
        }

        Nodo actual = inicio;
        int contador = 0;

        while (contador < indice) {
            actual = actual.siguiente;
            contador++;
        }

        return actual.dato;
    }

    public void borrarElemento(int valor) {
        Nodo actual = inicio;

        while (actual != null) {
            if (actual.dato == valor) {

                if (actual == inicio) {
                    inicio = actual.siguiente;
                    if (inicio != null)
                        inicio.anterior = null;
                } else if (actual == fin) {
                    fin = actual.anterior;
                    fin.siguiente = null;
                } else {
                    actual.anterior.siguiente = actual.siguiente;
                    actual.siguiente.anterior = actual.anterior;
                }

                tamaño--;
                System.out.println("Elemento eliminado.");
                return;
            }

            actual = actual.siguiente;
        }

        System.out.println("Elemento no encontrado.");
    }
}

public class Main {

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        ListaDoble lista = new ListaDoble();

        int opcion;

        do {

            System.out.println("\nLista Doblemente Enlazada");
            System.out.println("1. Insertar al inicio");
            System.out.println("2. Insertar al final");
            System.out.println("3. Recorrer hacia adelante");
            System.out.println("4. Recorrer hacia atras");
            System.out.println("5. Mostrar tamaño de la lista");
            System.out.println("6. Mostrar si la lista esta vacia");
            System.out.println("7. Buscar elemento por valor");
            System.out.println("8. Buscar elemento por indice");
            System.out.println("9. Borrar un elemento");
            System.out.println("0. Salir");

            System.out.print("Seleccione una opcion: ");
            opcion = sc.nextInt();

            switch (opcion) {

                case 1:
                    System.out.print("Ingrese dato: ");
                    lista.insertarInicio(sc.nextInt());
                    break;

                case 2:
                    System.out.print("Ingrese dato: ");
                    lista.insertarFinal(sc.nextInt());
                    break;

                case 3:
                    lista.recorrerAdelante();
                    break;

                case 4:
                    lista.recorrerAtras();
                    break;

                case 5:
                    System.out.println("Tamaño de la lista: " + lista.tamaño());
                    break;

                case 6:
                    if (lista.estaVacia())
                        System.out.println("La lista está vacía");
                    else
                        System.out.println("La lista NO está vacía");
                    break;

                case 7:
                    System.out.print("Valor a buscar: ");
                    int valor = sc.nextInt();
                    int pos = lista.buscarPorValor(valor);

                    if (pos == -1)
                        System.out.println("No encontrado");
                    else
                        System.out.println("Encontrado en indice: " + pos);
                    break;

                case 8:
                    System.out.print("Indice a buscar: ");
                    int indice = sc.nextInt();
                    Integer dato = lista.buscarPorIndice(indice);

                    if (dato == null)
                        System.out.println("Indice inválido");
                    else
                        System.out.println("Elemento: " + dato);
                    break;

                case 9:
                    System.out.print("Elemento a borrar: ");
                    lista.borrarElemento(sc.nextInt());
                    break;

            }

        } while (opcion != 0);

    }
}