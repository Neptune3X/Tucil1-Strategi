using System;
using System.IO;
using System.Text;
using System.Text.RegularExpression;
using System.Diagnostics;
using Math.Random;

namespace program{
    class Program{
        public static string randomString(){
            var numchars = "0123456789ABCDEFGHIJKLMNOPQRSRTUVWXYZ";
            var stringChars = new char[2];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++){
                stringChars[i] = numchars[random.Next(numchars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        static void Main(string[] args){
            string[] listChar;
            int bufferCount;
            int matrix_X;
            int matrix_Y;
            string[][] matriksMain;
            string pattern = @"[0-9A-Z]{2}";
            int sequenceCount;
            string sequenceCode;
            bool sequenceEnd = false;
            int[] sequenceReward;
            Random randomNumber = new Random();
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
                matrix_X = Convert.ToInt32(splittedItems[0]);
                matrix_Y = Convert.ToInt32(splittedItems[1]);

                Console.Write("Masukkan string yang diinginkan untuk diinput ke dalam matriks : ");
                userInput = Console.ReadLine();
                splittedItems = userInput.Split(' ');
                if(splittedItems.Length != matrix_X * matrix_Y){
                    Console.Write("Maaf, jumlah imput tidak sama dengan perkalian antara baris X dengan kolum Y");
                }
                else{
                    int k = 0;
                    for(int i  = 0; i < matrix_X; i++){
                        for(int j = 0; j < matrix_Y; j++){
                            matriksMain[i][j] = splittedItems[k];
                            if(!Regex.IsMatch(matriksMain[i][j], pattern)){
                                string newString = randomString();
                                matriksMain[i][j] = newString;
                                if(j == matrix_Y - 1){
                                    Console.WriteLine(matriksMain[i][j] + " ");
                                }
                                else{
                                    Console.Write(matriksMain[i][j] + " ");
                                }
                            }
                            k++;
                        }
                    }
                    Console.Write("Masukkan jumlah sequence yang diinginkan : ");
                    sequenceCount = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < sequenceCount; i++){
                        int index = 0;
                        while (sequenceEnd != true){
                            string[] newSequenceString;
                            if (index == 0){
                                newSequenceString[index] = matriksMain[0][0];
                            }
                            else{
                                sequenceCode = randomString();
                                newSequenceString[index] = sequenceCode;
                            }
                            
                            if(index == 0){
                                index++;
                            }
                            else{
                                if(randomNumber.Next(0,100) <= 55){
                                    Console.WriteLine(newSequenceString[index] + " ");
                                    sequenceEnd = true;
                                }
                                else{
                                    Console.Write(newSequenceString[index] + " ");
                                    index++;
                                }
                            }
                        }
                        sequenceReward[i] = randomNumber.Next(1,50);
                    }
                }
            }
        }
    }
}