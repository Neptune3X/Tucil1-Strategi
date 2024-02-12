using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

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
            string[] listchar;
            int buffer_size;
            int matrix_width;
            int matrix_height;
            int sequence_count;
            string pattern = @"[A-Z0-9]{2}";

            Console.Write("Masukkan ukuran buffer yang diinginkan");
            buffer_size = Convert.ToInt32(Console.ReadLine());

            Console.Write("Masukkan lebar dan tinggi matrix : ");
            string userInput = Console.ReadLine();
            string[] userProcessedInput = userInput.Split(" ");
            matrix_width = Convert.ToInt32(userProcessedInput[0]);
            matrix_height = Convert.ToInt32(userProcessedInput[1]);
            string[,] matrix = new string[matrix_width,matrix_height];

            for(int i = 0; i < matrix_width; i++){
                for(int j = 0; j < matrix_height; j++){
                    string userInputIntoMatrix = Console.ReadLine();
                    if(!Regex.IsMatch(userInputIntoMatrix,pattern)){
                        matrix[i,j] = randomString();
                    }
                    else{
                        matrix[i,j] = userInputIntoMatrix;
                    }

                    if(j == matrix_height - 1){
                        Console.WriteLine(matrix[i,j] + " ");
                    }
                    else{
                        Console.Write(matrix[i,j] + " ");
                    }
                }
            }

            



        }
    }
}