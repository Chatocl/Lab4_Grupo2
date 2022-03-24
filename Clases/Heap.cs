using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Heap<T> : ICloneable
    {
        public Node<T> Raiz;//Raiz
        public int TCont;//Contador
        private List<T> listaOrdenada = new List<T>();
        public Heap()
        {
            TCont = 0;
        }

        public bool VerificarVacio()
        {
            return Raiz == null ? true : false;
        }

        public bool VerificarLleno()
        {
            return TCont == 10 ? true : false;
        }

        public void Add(T key, DateTime date, int priority)
        {
            var newNode = new Node<T>(key, date, priority);
            if (VerificarVacio())
            {

                Raiz = newNode;
                TCont = 1;
            }
            else
            {
                TCont++;
                var NewNodeNPadre = SearchLastNode(Raiz, 1);
                if (NewNodeNPadre.NIzquierdo != null)
                {
                    NewNodeNPadre.NDerecho = newNode;
                    newNode.NPadre = NewNodeNPadre;
                    OrdenarMenoraMayor(newNode);
                }
                else
                {
                    NewNodeNPadre.NIzquierdo = newNode;
                    newNode.NPadre = NewNodeNPadre;
                    OrdenarMenoraMayor(newNode);
                }
            }
        }

        private Node<T> SearchLastNode(Node<T> current, int number)
        {
            try
            {
                int previousn = TCont;
                if (previousn == number)
                {
                    return current;
                }
                else
                {
                    while (previousn / 2 != number)
                    {
                        previousn = previousn / 2;
                    }
                    if (previousn % 2 == 0)
                    {
                        if (current.NIzquierdo != null)
                        {
                            return SearchLastNode(current.NIzquierdo, previousn);
                        }
                        else
                        {
                            return current;
                        }
                    }
                    else
                    {
                        if (current.NDerecho != null)
                        {
                            return SearchLastNode(current.NDerecho, previousn);
                        }
                        else
                        {
                            return current;
                        }
                    }
                }
            }
            catch
            {
                return current;
            }

        }
        private void OrdenarMenoraMayor(Node<T> current)
        {
            if (current.NPadre != null)
            {
                if (current.Priority < current.NPadre.Priority)
                {
                    Intercambio(current);
                }
                else if (current.Priority == current.NPadre.Priority)
                {
                    //Segundo criterio prioridad
                    if (current.DatePriority < current.NPadre.DatePriority)
                    {
                        Intercambio(current);
                    }
                }
                OrdenarMenoraMayor(current.NPadre);
            }
        }
        private void Intercambio(Node<T> node)
        {
            var Priority1 = node.Priority;
            var Key1 = node.Key;
            var Date1 = node.DatePriority;
            node.Priority = node.NPadre.Priority;
            node.Key = node.NPadre.Key;
            node.DatePriority = node.NPadre.DatePriority;
            node.NPadre.Priority = Priority1;
            node.NPadre.Key = Key1;
            node.NPadre.DatePriority = Date1;
        }
        public Node<T> Delete()
        {
            Node<T> LastNode = SearchLastNode(Raiz, 1);
            Node<T> FirstNode = Raiz;
            Raiz.Key = LastNode.Key;
            Raiz.Priority = LastNode.Priority;
            if (LastNode.NPadre == null)
            {
                Raiz = null;
                TCont--;
                return LastNode;
            }
            else
            {
                if (LastNode.NPadre.NIzquierdo == LastNode)
                {
                    LastNode.NPadre.NIzquierdo = null;
                }
                else
                {
                    LastNode.NPadre.NDerecho = null;
                }
            }
            OrdenarMayoraMenor(Raiz);
            TCont--;
            return FirstNode;
        }
        private void OrdenarMayoraMenor(Node<T> current)
        {
            if (current.NDerecho != null && current.NIzquierdo != null)
            {
                if (current.NIzquierdo.Priority > current.NDerecho.Priority)
                {
                    if (current.Priority > current.NDerecho.Priority)
                    {
                        Intercambio(current.NDerecho);
                        OrdenarMenoraMayor(current.NDerecho);
                    }
                    else if (current.Priority == current.NDerecho.Priority)
                    {
                        if (current.DatePriority > current.NDerecho.DatePriority)
                        {
                            Intercambio(current.NDerecho);
                            OrdenarMenoraMayor(current.NDerecho);
                        }
                    }
                }
                else if (current.NIzquierdo.Priority < current.NDerecho.Priority)
                {
                    if (current.Priority > current.NIzquierdo.Priority)
                    {
                        Intercambio(current.NIzquierdo);
                        OrdenarMenoraMayor(current.NIzquierdo);
                    }
                    else if (current.Priority == current.NIzquierdo.Priority)
                    {
                        if (current.DatePriority > current.NIzquierdo.DatePriority)
                        {
                            Intercambio(current.NIzquierdo);
                            OrdenarMenoraMayor(current.NIzquierdo);
                        }
                    }
                }
                else
                {
                    if (current.NIzquierdo.DatePriority > current.NDerecho.DatePriority)
                    {
                        if (current.Priority > current.NDerecho.Priority)
                        {
                            Intercambio(current.NDerecho);
                            OrdenarMenoraMayor(current.NDerecho);
                        }
                        else if (current.Priority == current.NDerecho.Priority)
                        {
                            if (current.DatePriority > current.NDerecho.DatePriority)
                            {
                                Intercambio(current.NDerecho);
                                OrdenarMenoraMayor(current.NDerecho);
                            }
                        }
                    }
                    else
                    {
                        if (current.Priority > current.NIzquierdo.Priority)
                        {
                            Intercambio(current.NIzquierdo);
                            OrdenarMenoraMayor(current.NIzquierdo);
                        }
                        else if (current.Priority == current.NIzquierdo.Priority)
                        {
                            if (current.DatePriority > current.NIzquierdo.DatePriority)
                            {
                                Intercambio(current.NIzquierdo);
                                OrdenarMenoraMayor(current.NIzquierdo);
                            }
                        }
                    }
                }
            }
            else if (current.NDerecho != null)
            {
                if (current.Priority > current.NDerecho.Priority)
                {
                    Intercambio(current.NDerecho);
                    OrdenarMenoraMayor(current.NDerecho);
                }
                else if (current.Priority == current.NDerecho.Priority)
                {
                    if (current.DatePriority > current.NDerecho.DatePriority)
                    {
                        Intercambio(current.NDerecho);
                        OrdenarMenoraMayor(current.NDerecho);
                    }
                }
            }
            else if (current.NIzquierdo != null)
            {
                if (current.Priority > current.NIzquierdo.Priority)
                {
                    Intercambio(current.NIzquierdo);
                    OrdenarMenoraMayor(current.NIzquierdo);
                }
                else if (current.Priority == current.NIzquierdo.Priority)
                {
                    if (current.DatePriority > current.NIzquierdo.DatePriority)
                    {
                        Intercambio(current.NIzquierdo);
                        OrdenarMenoraMayor(current.NIzquierdo);
                    }
                }
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public List<T> GetList()
        {
            listaOrdenada.Clear();
            InOrder(Raiz);
            return listaOrdenada;
        }
        private void InOrder(Node<T> nodo)
        {
            if (nodo != null)
            {
                InOrder(nodo.NIzquierdo);
                listaOrdenada.Add(nodo.Key);
                InOrder(nodo.NDerecho);
            }
        }
        public int Prioraty(string Sexo, int edad, string Especializacion, string Ingreso)
        {
            int Prioridad = 0;
            if (Sexo == "FEMENINO")
            {
                Prioridad += 3;
            }
            else
            {
                Prioridad += 5;
            }

            if (edad >= 0 && edad <= 5)
            {
                Prioridad += 8;
            }
            else if (edad >= 6 && edad <= 17)
            {
                Prioridad += 5;
            }
            else if (edad >= 18 && edad <= 49)
            {
                Prioridad += 3;
            }
            else if (edad >= 50 && edad <= 69)
            {
                Prioridad += 8;
            }
            else if (edad >= 70)
            {
                Prioridad += 10;
            }

            if (Especializacion == "INTERNA")
            {
                Prioridad += 3;
            }
            else if (Especializacion == "EXPUESTA")
            {
                Prioridad += 8;
            }
            else if (Especializacion == "GINECOLOGIA")
            {
                Prioridad += 5;
            }
            else if (Especializacion == "CARDIOLOGIA")
            {
                Prioridad += 10;
            }
            else if (Especializacion == "NEUMOLOGIA")
            {
                Prioridad += 8;
            }

            if (Ingreso == "AMBULANCIA")
            {
                Prioridad += 5;
            }
            else
            {
                Prioridad += 3;
            }

            return Prioridad;
        }

    }
}
