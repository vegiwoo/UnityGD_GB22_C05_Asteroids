# UnityGD_GB22_C05_Asteroids
Игра для 1 курса 2 четверти факультета "Разработка игр на Unity", Geekbrains, 2022

1. Проанализировал ранее написаные проекты на предмет антипаттернов. В основном это Too many managers, Ravioli code и Fear of complexity. Взял на заметку :)
2. Архитектура программных проектов нужна для:
    1. Правильной композиции системы, отвечающей за взаимодействие модулей и организацию потоков данных 
    2. Возможности в полной мере тестировать и масштабировать программный продукт 
    3. Введения в проект стандартов программирования, понятных другим разработчикам
    
Рефаторинг 
```csharp
namespace SomeTrash
{
    class Program
    {
        private const string Greeting = "Добрый день, Вас приветствует математическая программа!";
        private const string WelcomeText = "Введите пожалуйста число: ";
        private const ConsoleKey QuitKey = ConsoleKey.Q;
        private const int ReferenceNumber = 1;
        
        static void Main(string[] args) {
            
            Console.Clear();
            Print(Greeting, null, true);

            while (true)
            {
                Print(WelcomeText, null, false);
                if (int.TryParse(Console.ReadLine(), out var receivedNumber))
                {
                    var items = Calculation(receivedNumber);
                    Print("Факториал равен: ", items.factorial, true);
                    Print( $"Сумма от {ReferenceNumber} до {receivedNumber} равна: ", items.sum, true);
                    Print( $"Максимальное четное число меньше {receivedNumber} равно", items.maxEven, true);
                    Console.ReadLine(); 
                    break;
                }
                
                if (Console.ReadKey().Key == QuitKey)
                {
                    break;
                }
            }
        }

        private static (int factorial, int sum, int maxEven) Calculation(int number)
        {
             int factorial = ReferenceNumber, sum = 0, maxEven = 0;
             
             for (var i = ReferenceNumber; i <= number; i++) {
                 factorial *= i; 
                 sum += i; 
                 if (i % 2 == 0) {
                     maxEven = i; 
                 }
             }

             return (factorial, sum, maxEven);
        }

        private static void Print(string text, int? number, bool isNewLine)
        {
            if (number.HasValue)
            {
                Console.Write(isNewLine? $"{text}: {number.Value}\n" : $"{text}: {number.Value}");
            }
            else
            {
                Console.Write(isNewLine? $"{text}\n" : $"{text}");
            }
        }
    }
}
```
