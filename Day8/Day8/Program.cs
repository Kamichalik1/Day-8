using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Lines = System.IO.File.ReadAllLines(@"E:\Advent Code\Day 8\Data.txt");


            /*
            bool CodeLooped = false;
            int Index = 0;
            int Accumulator = 0;

            HashSet<int> CompletedLines = new HashSet<int>();

            while (CodeLooped == false)
            {
                if (CompletedLines.Contains(Index))
                {
                    CodeLooped = true;
                }
                else
                {
                    CompletedLines.Add(Index);

                    if (Lines[Index].Substring(0, 3) == "acc")
                    {
                        if (Lines[Index].Substring(4, 1) == "+")
                        {
                            Accumulator += Convert.ToInt32(Lines[Index].Substring(5));
                        }
                        else
                        {
                            Accumulator -= Convert.ToInt32(Lines[Index].Substring(5));
                        }

                        Index++;

                    }
                    else if (Lines[Index].Substring(0, 3) == "jmp")
                    {
                        if (Lines[Index].Substring(4, 1) == "+")
                        {
                            Index += Convert.ToInt32(Lines[Index].Substring(5));
                        }
                        else
                        {
                            Index -= Convert.ToInt32(Lines[Index].Substring(5));
                        }
                    }
                    else
                    {
                        Index++;
                    }
                }

            }

            Console.WriteLine(Accumulator);
            Console.Read();

            */

            bool CodeTerminates = false;
            int LastEditedIndex = -1;
            while (CodeTerminates == false)
            {
                bool EditedCurrentCode = false;
                string[] AlteredCode = new string[Lines.Length];

                for  (int i = 0; i < Lines.Length; i++)
                {
                    if ( (Lines[i].Substring(0, 3) == "jmp" || Lines[i].Substring(0, 3) == "nop") && !EditedCurrentCode && i > LastEditedIndex)
                    {
                       
                        if (Lines[i].Substring(0, 3) == "jmp")
                        {
                            AlteredCode[i] = "nop +0";
                        }
                        else
                        {
                            AlteredCode[i] = "jmp" + Lines[i].Substring(3);
                        }

                        LastEditedIndex = i;
                        EditedCurrentCode = true;
                        
                    }
                    else
                    {
                        AlteredCode[i] = Lines[i];
                    }
                }





                CodeTerminates = Termiantes(AlteredCode);

                if (CodeTerminates)
                {
                    Execute(AlteredCode);
                }

            }





            bool Termiantes(string[] Code)
            {
                bool CodeLooped = false;
                int Index = 0;

                HashSet<int> CompletedLines = new HashSet<int>();

                while (CodeLooped == false && Index < Code.Length)
                {
                    if (CompletedLines.Contains(Index))
                    {
                        CodeLooped = true;
                    }
                    else
                    {
                        CompletedLines.Add(Index);

                        if (Code[Index].Substring(0, 3) == "jmp")
                        {
                            if (Code[Index].Substring(4, 1) == "+")
                            {
                                Index += Convert.ToInt32(Code[Index].Substring(5));
                            }
                            else
                            {
                                Index -= Convert.ToInt32(Code[Index].Substring(5));
                            }
                        }
                        else
                        {
                            Index++;
                        }

                    }

                }

                return !CodeLooped;
            }

            void Execute(string[] Code)
            {
                int Index = 0;
                int Accumulator = 0;
                
                while (Index < Code.Length)
                {    
                    if (Code[Index].Substring(0, 3) == "acc")
                    {
                        if (Code[Index].Substring(4, 1) == "+")
                        {
                            Accumulator += Convert.ToInt32(Code[Index].Substring(5));
                        }
                        else
                        {
                            Accumulator -= Convert.ToInt32(Code[Index].Substring(5));
                        }

                        Index++;

                    }
                    else if (Code[Index].Substring(0, 3) == "jmp")
                    {
                        if (Code[Index].Substring(4, 1) == "+")
                        {
                            Index += Convert.ToInt32(Code[Index].Substring(5));
                        }
                        else
                        {
                            Index -= Convert.ToInt32(Code[Index].Substring(5));
                        }
                    }
                    else
                    {
                        Index++;
                    }                    
                }

                Console.WriteLine(Accumulator);
                Console.Read();
            }


        }
    }
}
