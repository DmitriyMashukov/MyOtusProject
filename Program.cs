using System.Text;

namespace MyOtusProject;

class Program
{
    static List<string> booksForRead = new List<string>();
    public static void AddBook()
    {
        Console.WriteLine("Введите через запятую: название книги, имя и фамилию автора, количество страниц.");
        string book = Console.ReadLine();
        booksForRead.Add(book);
        Console.WriteLine($"Книга '{book}' добавлена в список.");
    }

    public static void ShowBooksList()
    {
        if (booksForRead.Count == 0)
        {
            Console.WriteLine("Вы ещё не добавили книг в список.");
        }
        else
        {
            Console.WriteLine("\nСписок книг, которые хочу прочитать:");
            for (int i = 0; i < booksForRead.Count; i++)
                Console.WriteLine($"{i + 1}. {booksForRead[i]}");
        }
    }

    public static void DeleteBook()
    {
        ShowBooksList();

        if (booksForRead.Count == 0)
            return;

        Console.WriteLine("Введите номер книги для удаления:");
        int numberOfBook;

        bool isNumber = int.TryParse(Console.ReadLine(), out numberOfBook);

        if (isNumber && numberOfBook > 0 && numberOfBook <= booksForRead.Count)
        {
            string removedBook = booksForRead[numberOfBook - 1];
            booksForRead.RemoveAt(numberOfBook - 1);
            Console.WriteLine($"Книга '{removedBook}' удалена из списка.");
        }
        else
        {
            Console.WriteLine("Данного номера книги нет в списке.");
        }
    }
    public static void ReturnMenu()
    {
        Console.WriteLine("Для выхода в меню команд нажмите Enter.");
        Console.ReadKey();
    }
    public static void DescriptionOfHelp()
    {
        var text = new StringBuilder("Краткая информация о том, как пользоваться программой:" +
            "\n /start - Команда для начала работы с приложением. С помощью неё вы можете " +
            "зарегистрироватся в приложении, введя своё имя." +
            "\n /help - Команда со справочной информацией по работе с приложением." +
            "\n /info - Предоставляет информацию о версии программы и дате её создания." +
            "\n /echo - При вводе этой команды с аргументом (например, Hello), программа " +
            "возвращает введенный текст (в данном примере \"Hello\"). Становится доступной только " +
            "после ввода имени." +
            "\n /addtask - Позволяет добавить новую книгу в список." +
            "\n /showtasks - Отображает список всех добавленных книг." +
            "\n /removetask - Позволяет удалять книги по номеру в списке." +
            "\n /exit - Команда для завершения работы приложения.");
        Console.WriteLine(text.ToString());
    }
    static void Main(string[] args)
    {
        bool isContinue = true;
        string name = "";

        do
        {
            if (name != "")
                Console.WriteLine($"Приветствую, {name}! Чем могу помочь?" +
                "\n /start \n /help \n /info \n /echo \n /addtask \n /showtasks \n /removetask \n /exit");
            else
                Console.WriteLine($"Приветствую, пользователь! Список доступных команд:" +
                "\n /start \n /help \n /info \n /addtask \n /showtasks \n /removetask \n /exit");

            var input = Console.ReadLine();
            switch (input)
            {
                case "/start":
                    Console.WriteLine("Пожалуйста, введите ваше имя:");
                    name = Console.ReadLine();
                    Console.WriteLine($"Имя {name} успешно установлено.");
                    ReturnMenu();
                    break;
                case "/help":
                    DescriptionOfHelp();
                    ReturnMenu();
                    break;
                case "/info":
                    Console.WriteLine("Версия программы 1.0. Дата создания: 26.02.2025");
                    ReturnMenu();
                    break;
                case "/echo":
                    if (name == "")
                    {
                        Console.WriteLine("Чтобы активировать эту команду введите своё имя.");
                        ReturnMenu();
                        break;
                    }
                    Console.WriteLine("Введите аргумент:");
                    var arg = Console.ReadLine();
                    Console.WriteLine(arg);
                    ReturnMenu();
                    break;
                case "/addtask":
                    AddBook();
                    ReturnMenu();
                    break;
                case "/showtasks":
                    ShowBooksList();
                    ReturnMenu();
                    break;
                case "/removetask":
                    DeleteBook();
                    ReturnMenu();
                    break;
                case "/exit":
                    Console.WriteLine("Завершение работы программы.");
                    isContinue = false;
                    break;
                default:
                    Console.WriteLine("Введена некорректная команда.");
                    ReturnMenu();
                    break;
            }
        } while (isContinue);
    }
}
