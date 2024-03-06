using System;
using System.Linq;

namespace ControleEstoque
{
    public class Product
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Singer { get; set; }
        public string ReleaseYear { get; set; }
        public string Genre { get; set; }
        public Product(string name, string price, string singer, string releaseYear, string genre)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = 0;
            this.Singer = singer;
            this.ReleaseYear = releaseYear;
            this.Genre = genre;
        }
    }
    class Program
    {
        static void NewRecord(ref Product[] ProductsList)
        {
            Console.WriteLine("Informe o nome do disco: ");
            string name = Console.ReadLine();
            Console.WriteLine("Informe o preço: ");
            string price = Console.ReadLine();
            Console.WriteLine("Informe o artista ou a banda: ");
            string singer = Console.ReadLine();
            Console.WriteLine("Informe o ano de lançamento: ");
            string releaseYear = Console.ReadLine();
            Console.WriteLine("Informe o gênero: ");
            string genre = Console.ReadLine();

            int newSize = ProductsList.Length + 1;
            Array.Resize(ref ProductsList, newSize);

            ProductsList[newSize - 1] = new Product(name, price, singer, releaseYear, genre); ;
            Console.WriteLine("Disco adicionado!");
        }

        static void RemoveRecord(ref Product[] ProductsList)
        {
            int positionToRemove = InformPosition(ProductsList.Length);
            positionToRemove -= 1;
            ProductsList = ProductsList.Where((product, index) => index != positionToRemove).ToArray();
            Console.WriteLine("Disco removido!");
        }

        static void ShowRecords(ref Product[] ProductsList, int position = -1)
        {
            int initialPosition = position > 0 ? (position - 1) : 0;
            int finalPosition = position > 0 ? position : ProductsList.Length;
            for (int i = initialPosition, displayNumber = 1; i < finalPosition; i++, displayNumber++)
            {
                Console.WriteLine($"{displayNumber}. {ProductsList[i].Name} (R${ProductsList[i].Price}) - Cantor/Banda: {ProductsList[i].Singer} - Ano de lançamento: {ProductsList[i].ReleaseYear} - Gênero: {ProductsList[i].Genre} - {ProductsList[i].Quantity} no estoque");
            }
        }

        static int InformPosition(int arraySize)
        {
            int recordPosition = 0;
            do 
            {
                Console.WriteLine("Informe a posição do disco: ");
                string recordPositionStr = Console.ReadLine();
                if (int.TryParse(recordPositionStr, out recordPosition) == false)
                {
                    Console.WriteLine("Digite um valor válido!");
                    Console.WriteLine(recordPosition);
                }
                else
                {
                    if (recordPosition > arraySize)
                    {
                        Console.WriteLine("Digite um valor entre 1 e " + arraySize);
                        recordPosition = 0;
                    }
                }
            }
            while (recordPosition <= 0);
            return recordPosition;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Aluna: Juliana Elias Tocci.");
            Product[] ProductsList = new Product[0];
            int option;
            do
            {
                Console.WriteLine("[1]Novo");
                Console.WriteLine("[2]Listar produtos");
                Console.WriteLine("[3]Remover produtos");
                Console.WriteLine("[4]Entrada estoque");
                Console.WriteLine("[5]Saída estoque");
                Console.WriteLine("[0]Sair");
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    NewRecord(ref ProductsList);
                }   

                if (option == 2)
                 {
                    Console.WriteLine("Lista de Produtos:");
                    ShowRecords(ref ProductsList);
                } 

                if (option == 3)
                {
                    RemoveRecord(ref ProductsList);
                }

                if (option == 4)
                {
                    int recordPosition = InformPosition(ProductsList.Length);
                    Console.WriteLine("Informe a quantidade de entrada: ");
                    int stockEntrance = int.Parse(Console.ReadLine());

                    ProductsList[recordPosition - 1].Quantity += stockEntrance;
                    ShowRecords(ref ProductsList, recordPosition);
                }

                if ( option == 5)
                {
                    int recordPosition = InformPosition(ProductsList.Length);
                    Console.WriteLine("Informe a quantidade de saída: ");
                    int stockEntrance = int.Parse(Console.ReadLine());

                    ProductsList[recordPosition - 1].Quantity -= stockEntrance;
                    ShowRecords(ref ProductsList, recordPosition);
                }
            } while (option != 0);
        }
    }
}
