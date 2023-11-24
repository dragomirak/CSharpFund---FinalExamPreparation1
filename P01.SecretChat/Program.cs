using System;

namespace P01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] instructions = input.Split(":|:");
                string command = instructions[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(instructions[1]);
                    message = message.Insert(index, " ").ToString();
                }
                else if (command == "Reverse")
                {
                    string substring = instructions[1];
                    if (!message.Contains(substring))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    else
                    {
                        int index = message.IndexOf(substring);
                        message = message.Remove(index, substring.Length);
                        substring = new string(substring.Reverse().ToArray());
                        message += substring;
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = instructions[1];
                    string replacementText = instructions[2];
                    message = message.Replace(substring, replacementText);
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}