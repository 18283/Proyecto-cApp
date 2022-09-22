/*************************************************************
Institución:    Universidad Gabriel Rene Moreno
Carrera:        Ingenieria Informatica
Materia:        Estructura de Datos I
Proyecto:       cApp (Proyecto de Clases)
Descripción:    Implementacion del TAD clsPoly utilizando Arreglos.
Creador:        Sara Eunice Navarro Acosta
Lenguaje:       C#
Herramienta:     Visual Studio 2019 - Windows Aplications
*************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProyectocApp
{
    public class clsPoly
    {
        const int MAX = 100;
        float[] vCoef;
        int[] vExp;
        int nTerm;

        public clsPoly()
        {
            vCoef = new float[MAX];
            vExp = new int[MAX];
            for (int i = 0; i < MAX; i++)
            {
                vCoef[i] = 0;
                vExp[i] = 0;
            }
            nTerm = 0;
        }

        public clsPoly(clsPoly P)
        {
            vCoef = new float[MAX];
            vExp = new int[MAX];
            for (int i = 0; i <= P.nTerm; i++)
            {
                vCoef[i] = P.vCoef[i];
                vExp[i] = P.vExp[i];
            }
            this.nTerm = P.nTerm;

        }

        // Declare el Polinomio Zero
        public clsPoly Zero()
        {
            return new clsPoly();
        }

        // Es Zero un Polinomio P
        public bool IsZero()
        {
            return (nTerm == 0);
        }

        // Adciona un termino al polinomio
        public clsPoly Attach(clsPoly P, float Coef, int Exp)
        {
            if ((Coef != 0) && (Exp >= 0))
            {
                P.nTerm++;
                P.vExp[Exp] = Exp;
                P.vCoef[Exp] = P.vCoef[Exp] + Coef;
            }
            return P;
        }

        // Elimina el termino con exponente Exp del polinomio P
        public clsPoly Rem(clsPoly P, int Exp)
        {

            if (Exp >= 0)
            {
                P.vCoef[Exp] = 0;
                P.vExp[Exp] = 0;
                P.nTerm--;
            }
            return P;
        }


        // Obtiene el coheficiente de un termino con exponente Exp del polinomio 
        public float Coef(int Exp)
        {
            return vCoef[Exp];
        }

        // Obtiene el grado de un Polinomio
        public int Grado()
        {
            int Exp = 0;
            for (int k = 0; k < MAX; k++)
            {
                if (vExp[k] > 0)
                    Exp = vExp[k];
            }
            return Exp;
        }

        // Suma de dos polinomios
        public clsPoly Add(clsPoly P, clsPoly Q)
        {
            clsPoly C = new clsPoly();

            while ((P.IsZero() == true && Q.IsZero() == true) == false)
            {
                if (P.Grado() < Q.Grado())
                {
                    C = Attach(C, Q.Coef(Q.Grado()), Q.Grado());
                    Q = Rem(Q, Q.Grado());
                }
                if (P.Grado() > Q.Grado())
                {
                    C = Attach(C, P.Coef(P.Grado()), P.Grado());
                    P = Rem(P, P.Grado());

                }
                if (P.Grado() == Q.Grado())
                {
                    C = Attach(C, P.Coef(P.Grado()) + Q.Coef(Q.Grado()), P.Grado());
                    P = Rem(P, P.Grado());
                    Q = Rem(Q, Q.Grado());
                }
            }
            return C;
        }
    }