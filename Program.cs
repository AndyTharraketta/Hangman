using System.Threading.Channels;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Programmiere das Spiel Hangman. User 1 soll ein Wort eingeben.
            //User 2 muss danach eine Eingabe machen entweder für einen Buchstaben oder das gesuchte Wort.
            //User 2 Gewinnt wenn er entweder alle Buchstaben oder das richte Wort erraten hat.
            //Ansonsten baut sich der Galgen auf mit folgender Ausgabe als Finale:

            //
            //"  ======||  "
            //"  |     ||  "
            //"  O     ||  "
            //" -x-    ||  "
            //"  x     ||  "
            //" | |    ||  "
            //"        ||  "
            //"============"
            //
            //Ist der Galgen fertig aufgebaut hat User 2 Verloren und User 1 Gewinnt 
            //Am Ende soll eine weitere Spielrunde angeboten werden.
            Aufgabe();
            Korrektur();
            static void Aufgabe()
            {


                //Console.ForegroundColor = ConsoleColor.Yellow;
                //string eingabeUser1, eingabeUser2;
                //char charUser2;
                //bool again = true;      // Wahrheitswert für die Wiederholung des Programms  


                //do
                //{
                //    Console.WriteLine("---Willkommen bei 'Hangman'!---");
                //    Console.WriteLine("User 1: Gib bitte ein Wort ein.");
                //    eingabeUser1 = Console.ReadLine().ToLower().Trim();
                //    Console.Clear();

                //    do
                //    {
                //        int anzahlVersuche = 6;
                //        bool verbleibendeVersuche = true;
                //        Console.WriteLine("User 2: Möchtest Du einen Buchstaben(b) eingeben oder möchtest Du lösen(l)?");
                //        eingabeUser2 = Console.ReadLine();

                //        switch (eingabeUser2)
                //        {
                //            case "b":
                //                //Console.WriteLine(charUser2);
                //                break;
                //            case "l":
                //                eingabeUser2 = Console.ReadLine();
                //                if (eingabeUser2 == eingabeUser1)
                //                {
                //                    Console.WriteLine("Herzlichen Glückwunsch Du hast gewonnen!");
                //                }
                //                else
                //                {
                //                    Console.WriteLine("Falsch! Bitte versuche es nochmal!");
                //                    anzahlVersuche--;
                //                    eingabeUser2 = Console.ReadLine();
                //                    verbleibendeVersuche = (eingabeUser2 == eingabeUser1);
                //                }
                //                break;
                //        }
                //    } while (false);



                //    Console.WriteLine("Nochmal spielen? (y/n)");        // Für die Wiederholung des Programms
                //    string nochmal = Console.ReadLine();
                //    Console.Clear();
                //    switch (nochmal)
                //    {
                //        case "y":
                //            again = true;
                //            break;
                //        case "n":
                //            again = false;
                //            Console.WriteLine("Spiel beendet!");
                //            break;
                //    }

                //} while (again == true);
            }       // Lösungsversuch
            static void Korrektur()
            {
           
                //Programmiere das Spiel Hangman. User 1 soll ein Wort eingeben.
                //User 2 muss danach eine Eingabe machen entweder für einen Buchstaben oder das gesuchte Wort.
                //User 2 Gewinnt wenn er entweder alle Buchstaben oder das richte Wort erraten hat.
                //Ansonsten baut sich der Galgen auf mit folgender Ausgabe als Finale:

                //
                //"  ======||  "
                //"  |     ||  "
                //"  O     ||  "
                //" -x-    ||  "
                //"  x     ||  "
                //" | |    ||  "
                //"        ||  "
                //"============"
                //
                //Ist der Galgen fertig aufgebaut hat User 2 Verloren und User 1 Gewinnt 
                //Am Ende soll eine weitere Spielrunde angeboten werden.


                bool nextRound = false;
                string tempWord = "";
                string tempWord2 = "";
                int trys = 5;
                string gallows = "";
                int found = 0;

                do
                {
                    Console.Clear();
                    Console.Write("User 1 bitte gebe ein Wort ein: ");
                    string secreWord = Console.ReadLine().Trim().ToUpper();
                    Console.Clear();

                    for (int i = 0; i < secreWord.Length; i++)
                    {
                        Console.Write("_");
                        tempWord += "_";
                    }
                    Console.WriteLine();

                    while (true)
                    {
                        if (trys > 0)
                        {
                            Console.Write("User 2 bitte gib ein Buchstaben ein oder das Lösungswort: ");
                            string user2Input = Console.ReadLine().Trim().ToUpper();

                            if (user2Input.Length > 1)
                            {
                                if (secreWord == user2Input)
                                {
                                    Console.Clear();
                                    Console.WriteLine("User 2 Du hast gewonnen!");
                                    break;
                                }
                            }
                            else if (user2Input.Length == 1)
                            {
                                bool correctChar = false;
                                Console.Clear();
                                tempWord2 = "";

                                for (int i = 0; i < secreWord.Length; i++)
                                {
                                    if (secreWord[i].ToString() == user2Input && !(tempWord.Contains(user2Input)))
                                    {
                                        found++;
                                        tempWord2 += secreWord[i];
                                        correctChar = true;
                                    }
                                    else
                                    {
                                        if (tempWord[i] == '_')
                                        {
                                            tempWord2 += '_';
                                        }
                                        else
                                        {
                                            tempWord2 += tempWord[i];
                                        }
                                    }
                                }
                                tempWord = tempWord2;
                                Console.WriteLine(tempWord);
                                if (found == secreWord.Length)
                                {
                                    Console.Clear();
                                    Console.WriteLine("User 2 Du hast gewonnen!");
                                    break;
                                }
                                else if (!correctChar)
                                {
                                    trys--;
                                }

                            }
                            else
                            {
                                Console.WriteLine("User 2, du musst ein Eingabe machen!");
                            }

                            if (trys == 4)
                            {
                                gallows = @"
								 
								        
								        
								      
								         
								          
										 
							============										
							";
                            }
                            else if (trys == 3)
                            {
                                gallows = @"
							        ||  
							        ||  
							        ||  
							        ||  
							        ||  
							        ||  
							        ||										 
							============										
							";
                            }
                            else if (trys == 2)
                            {
                                gallows = @"
							========||  
							        ||  
							        ||  
							        ||  
							        ||  
							        ||  
							        ||										 
							============									
							";
                            }
                            else if (trys == 1)
                            {
                                gallows = @"
							========||  
						 	  |     ||  
							        ||  
							        ||  
							        ||  
							        ||  
							        ||										 
							============								
							";
                            }
                            else if (trys == 0)
                            {
                                gallows = @"
							========||  
							  |     ||  
							  O     ||  
							 -x-    ||  
							  x     ||  
							 | |    ||  
							        ||  
							============							
							";
                            }

                        }
                        else
                        {
                            Console.WriteLine("User 2 du wurdest gehängt!");
                            break;
                        }
                        Console.WriteLine(gallows);
                    }

                    Console.WriteLine("User 1 und User 2 möchtet ihr noch eine Runde spielen? (j/n)");
                    if (Console.ReadLine().Trim().ToLower() == "j")
                    {
                        nextRound = true;
                        tempWord = "";
                        trys = 5;
                        found = 0;
                        gallows = "";

                    }
                    else
                    {
                        Console.WriteLine("Auf Wiedersehen!");
                        Console.ReadKey();
                    }


                }
                while (nextRound);

            }       // Korrektur der Aufgabe
        }
    }

}        
   





