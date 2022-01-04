using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_odev_proje2
{
    class Operations
    {
        public static List<BoardCard> cardList = new List<BoardCard>();
        public static List<Person> personList = new List<Person>();


        public void InitCardList()
        {

            cardList.AddRange(new List<BoardCard> {
                new BoardCard
                {
                    Title = "Make logo",
                    Content = "Logo...",
                    PersonId = 1,
                    Size = 3,
                    Status = "todo"
                },
                new BoardCard
                {
                    Title = "Shopping",
                    Content = "Shopping...",
                    PersonId = 2,
                    Size = 2,
                    Status = "inprogress"
                },
                new BoardCard
                {
                    Title = "Write something",
                    Content = "Writing...",
                    PersonId = 2,
                    Size = 4,
                    Status = "done"
                },
                new BoardCard
                {
                    Title = "Task 1",
                    Content = "Task 1...",
                    PersonId = 1,
                    Size = 2,
                    Status = "todo"
                },
                new BoardCard
                {
                    Title = "Task 2",
                    Content = "Task 2...",
                    PersonId = 1,
                    Size = 2,
                    Status = "todo"
                }


            });

        }

        public void InitPersonList()
        {
            personList.AddRange(new List<Person> {
                new Person
                {
                    Id = 1,
                    Name = "John"
                },
                new Person
                {
                    Id = 2,
                    Name = "Bilbo"
                },
                new Person
                {
                    Id = 3,
                    Name = "Frodo"
                }




            });


        }



        public void ReadOperation()
        {
            Console.WriteLine("Choose operation");
            Console.WriteLine("(1) Print board");
            Console.WriteLine("(2) Add card");
            Console.WriteLine("(3) Delete card");
            Console.WriteLine("(4) Move card");



            bool isInputNumber = int.TryParse(Console.ReadLine(), out int selectedOperation);

            if (isInputNumber)
            {
                if (selectedOperation >= 1 && selectedOperation <= 4)
                {
                    switch (selectedOperation)
                    {
                        case 1:
                            PrintBoard();
                            break;
                        case 2:
                            AddCard();
                            break;
                        case 3:
                            DeleteCard();
                            break;
                        case 4:
                            MoveCard();
                            break;
                        default:
                            break;

                    }

                }
                else
                {
                    Console.WriteLine("Invalid input");
                    ReadOperation();
                }

            }
            else
            {
                Console.WriteLine("Invalid input");
                ReadOperation();
            }

        }







        public void MoveCard()
        {
            Console.WriteLine("Enter title of card that you want move");
            string targetTitle = Console.ReadLine();

            BoardCard targetCard = cardList.Find(x => x.Title == targetTitle);

            if (targetCard != null)
            {
                Console.WriteLine("Select line");
                Console.WriteLine("(1) To do");
                Console.WriteLine("(2) In progress");
                Console.WriteLine("(3) Done");
                int targetLine = Convert.ToInt32(Console.ReadLine());
                if (targetLine == 1)
                {
                    targetCard.Status = "todo";
                }
                else if (targetLine == 2)
                {
                    targetCard.Status = "inprogress";
                }
                else if (targetLine == 3)
                {
                    targetCard.Status = "done";
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            }
            else
            {
                Console.WriteLine("Can not find card");
            }


            ReadOperation();


        }






        public void DeleteCard()
        {
            Console.WriteLine("Enter title of card that you want delete");
            string targetTitle = Console.ReadLine();

            BoardCard targetCard = cardList.Find(x => x.Title == targetTitle);

            if (targetCard != null)
            {
                cardList.Remove(targetCard);
                Console.WriteLine("Card deleted");
            }
            else
            {
                Console.WriteLine("Can not find card");
            }


            ReadOperation();
        }






        public void AddCard()
        {
            Console.Write("Title: ");
            string cardTitle = Console.ReadLine();
            Console.Write("Content: ");
            string cardContent = Console.ReadLine();
            Console.Write("Person Id: ");
            int cardPersonId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Card size: ");
            int cardSize = Convert.ToInt32(Console.ReadLine());

            cardList.Add(new BoardCard
            {
                Title = cardTitle,
                Content = cardContent,
                PersonId = cardPersonId,
                Size = cardSize,
            });

            ReadOperation();

        }





        public void PrintBoard()
        {
            List<BoardCard> toDoLine = new List<BoardCard>();
            List<BoardCard> inProgressLine = new List<BoardCard>();
            List<BoardCard> doneLine = new List<BoardCard>();

            foreach (var item in cardList)
            {
                switch (item.Status)
                {
                    case "todo":
                        toDoLine.Add(item);
                        break;
                    case "inprogress":
                        inProgressLine.Add(item);
                        break;
                    case "done":
                        doneLine.Add(item);
                        break;
                    default:
                        break;

                }
            }

            Console.WriteLine("To do :");
            foreach (var item in toDoLine)
            {
                WriteCard(item);
            }

            Console.WriteLine("In progress :");
            foreach (var item in inProgressLine)
            {
                WriteCard(item);
            }

            Console.WriteLine("Done :");
            foreach (var item in doneLine)
            {
                WriteCard(item);
            }


            ReadOperation();
        }








        public void WriteCard(BoardCard item)
        {
            Console.WriteLine($"Title: {item.Title}");
            Console.WriteLine($"Content: {item.Content}");
            Console.WriteLine($"Person: {item.PersonId}");
            Console.WriteLine($"Size: {item.Size}");
            Console.WriteLine("");
        }








    }



    class BoardCard
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int PersonId { get; set; }

        public int Size { get; set; }

        public string Status = "todo";

    }


    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }



}
