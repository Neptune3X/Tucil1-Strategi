using System;
using System.IO;
using System.Text;
using System.Text.RegularExpression;
using System.Diagnostics;
using Math.Random;

namespace program{
    class program{
        private string randomString(){
            var numchars = "0123456789ABCDEFGHIJKLMNOPQRSRTUVWXYZ";
            var stringChars = new char[2];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++){
                stringChars[i] = numchars[random.Next(numchars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        private static void main(){
            string[] listChar;
            int bufferCount;
            int matrix_X;
            int matrix_Y;
            string[][] matriksMain;
            string pattern = @"[0-9A-Z]{2}";
            int sequenceCount;
            string sequenceCode;
            bool sequenceEnd;
            int sum;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.Write("Masukkan Jumlah Buffer yang diinginkan : ");
            bufferCount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Masukkan Ukuran Matriks yang diinginkan : ");
            string userInput = Console.ReadLine();

            var splittedItems = userInput.Split(' ');
            if(splittedItems.Length != 2){
                Console.Write("Maaf, jumlah imput tidak sama dengan dua");
            }
            else{
                matrix_X = splittedItems[0];
                matrix_Y = splittedItems[1];

                Console.Write("Masukkan string yang diinginkan untuk diinput ke dalam matriks : ");
                userInput = Console.ReadLine();
                splittedItems = userInput.Split(' ');
                if(splittedItems.Length != matrix_X * matrix_Y){
                    Console.Write("Maaf, jumlah imput tidak sama dengan perkalian antara baris X dengan kolum Y");
                }
                else{
                    for(int i  = 0; i < matrix_X; i++){
                        for(int j = 0; j < matrix_Y; j++){
                            matriksMain[i][j] = splittedItems;
                        }
                    }
                }
            }
        }
    }
}