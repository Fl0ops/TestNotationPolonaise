/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// Donne le résultat d'une formule écrite en notation polonaise
        /// </summary>
        /// <param name="formule">formule en notation polonaise</param>
        /// <returns>résultat</returns>
        static Double Polonaise(String formule)
        {
            try
            {
                // Placement de la formule dans un tableau
                string[] tab = formule.Split(' ');
                int nbCases = tab.Length; // nbCases stock le nombre de case dans le tableau

                // boucle tant qu'il ne reste pas qu'une seule case
                while (nbCases > 1)
                {
                    // recherche d'un signe à partir de la fin
                    int k = nbCases - 1;
                    while (k > 0 && tab[k] != "+" && tab[k] != "-" && tab[k] != "*" && tab[k] != "/")
                    {
                        k--;
                    }

                    // récupération des 2 valeurs concernées par l'operateur 
                    float a = float.Parse(tab[k + 1]);
                    float b = float.Parse(tab[k + 2]);

                    // calcul
                    float result = 0;
                    switch (tab[k])
                    {
                        case "+": result = a + b; break;
                        case "-": result = a - b; break;
                        case "*": result = a * b; break;
                        case "/":
                            // éviter la division par 0
                            if (b == 0)
                            {
                                return Double.NaN;
                            }
                            result = a / b; break;
                    }

                    // stockage du résultat à la place du signe
                    tab[k] = result.ToString();

                    // Suppression des 2 cellules suivantes par décalage vers la gauche
                    for (int j = k + 1; j < nbCases - 2; j++)
                    {
                        tab[j] = tab[j + 2];
                    }
                    // les cases suivantes sont mises à blanc
                    for (int j = nbCases - 2; j < nbCases; j++)
                    {
                        tab[j] = " ";
                    }
                    nbCases = nbCases - 2;
                }

                // retour du résultat final
                return Double.Parse(tab[0]);
            }
            catch
            {
                // erreur rencontrée
                return Double.NaN;
            }
        }


        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
