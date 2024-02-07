using System;
using System.Reflection.PortableExecutable;

namespace greatAdventure
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int lives = 0, magic = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            initValues(ref lives, ref magic, ref health, r);
            while (lives > 0 && magic > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref magic, ref health);
                else
                    actions(r.Next(10), ref lives, ref magic, ref health);
                checkResults(ref round, ref lives, ref magic, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully completing your journey!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and did not complete your journey");
            else if (magic <= 0)
                Console.WriteLine("You don't have any magic left and cannot complete your journey");
            else
                Console.WriteLine("You are in poor health and had to stop your journey before it's completion");

        }

        private static void checkResults(ref int round, ref int lives, ref int magic, ref int health, ref bool win)
        {
            round++;
            Console.WriteLine($"Round {round}");
            Console.WriteLine($"You have {health} health");
            Console.WriteLine($"You have {magic} magic");
            Console.WriteLine($"You have {lives} lives");
            if (round >= 25)
            {
                Console.WriteLine("You have won! Congratulations!");
                win = true;
            }
            return;
        }

        private static void actions(int v, ref int lives, ref int magic, ref int health)
        {
            Random r = new Random();
            int num = r.Next(10);
            switch (num)
            {
                case 0:
                    Console.WriteLine("You met three bears who were not happy that their porridge was gone.");
                    Console.WriteLine("You lose 1 unit of health and 1 unit of magic");
                    health -= 1;
                    magic -= 1;
                    break;
                case 1:
                    Console.WriteLine("You were abducted by flying monkeys and had to be rescued by a young girl and a dog");
                    Console.WriteLine("You lost 2 units of health and magic and 1 life");
                    health -= 2;
                    magic -= 2;
                    lives -= 1;
                    break;
                case 2:
                    Console.WriteLine("You stumble upon a hidden cave filled with treasure, but as you reach out to grab it, a trap is triggered, releasing poisonous gas.");
                    Console.WriteLine("You lose 2 units of health and 1 unit of magic");
                    health -= 2;
                    magic -= 1;
                    break;
                case 3:
                    Console.WriteLine("While traversing a dense forest, you encounter a friendly group of elves who offer to guide you to safety.");
                    Console.WriteLine("You gain 1 unit of health and 2 units of magic");
                    health += 1;
                    magic += 2;
                    break;
                case 4:
                    Console.WriteLine("As you venture into a dark dungeon, you accidentally awaken a powerful ancient guardian. In a fierce battle, you manage to defeat the guardian, but not without sustaining injuries. You feel powerful.");
                    Console.WriteLine("You lose 3 units of health, but gain 2 units of magic.");
                    health -= 3;
                    magic += 2;
                    break;
                case 5:
                    Console.WriteLine("You saved a fellow traveler from a headless horseman.");
                    Console.WriteLine("The traveler granted you 2 units of health, magic and lives");
                    health += 2;
                    magic += 2;
                    lives += 2;
                    break;
                case 6:
                    Console.WriteLine("You babysat for a women who lived in a house that resembled a shoe (she had a lot of kids).");
                    Console.WriteLine("You gain 3 units of health and magic");
                    health += 3;
                    magic += 3;
                    break;
                case 7:
                    Console.WriteLine("While exploring a haunted mansion, you encounter a mischievous ghost who challenges you to a game of riddles. Successfully solving the riddles, you impress the ghost and gain its favor.");
                    Console.WriteLine("You gain 1 unit of health and 1 unit of magic");
                    health += 1;
                    magic += 1;
                    break;
                case 8:
                    Console.WriteLine("You meet a shady traveling merchant who sells you an amulet. It makes you feel stronger, but a part of you feels missing.");
                    Console.WriteLine("You gain 3 units of magic, but lose 2 of your lives");
                    magic += 3;
                    lives -= 2;
                    break;
                case 9:
                    Console.WriteLine("You meet a lowly necromancer who teaches you some of his tricks.");
                    Console.WriteLine("You gain 2 magic, but lose 1 health and 1 life");
                    health -= 1;
                    magic += 2;
                    lives -= 1;
                    break;
                default:
                    Console.WriteLine("You saved a unicorn from a mean wizard.");
                    Console.WriteLine("You gain 2 lives and 2 units of magic");
                    magic += 2;
                    lives += 2;
                    break;
            }
        }

        private static int chooseDirection()
        {
            Console.WriteLine("You have come to a crossroad, enter 1 to travel left and 2 to travel right");
            int direction = int.Parse(Console.ReadLine());
            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }

        private static void initValues(ref int lives, ref int magic, ref int health, Random r)
        {
            lives = r.Next(10) + 1;
            magic = r.Next(15) + 5;
            health = r.Next(14) + 5;
        }
    }
}