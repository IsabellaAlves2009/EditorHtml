using System;
using System.Text.RegularExpressions;

namespace EditorHtml 
{
    public static class Viewer
    {
        public static void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.WriteLine("Modo Visualização");
            Console.WriteLine("--------------");
            Replace(text);
            Console.WriteLine("--------------");
            Console.WriteLine("precione qualquer tecla pra voltar ao menu");
            Console.ReadKey();
            Menu.Show();

        }
        public static void Replace(string text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var words = text.Split(' ');

            for(var i = 0; i <= words.Length; i++)
            {
                if(strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            (
                                words[i].LastIndexOf('<') - 1 -
                                words[i].LastIndexOf('>')
                            )
                            
                        )
                    );
                    Console.Write(" ");
                }else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
        }
    }
}