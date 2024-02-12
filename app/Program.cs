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

            var finalString = new string(stringChars);
            return finalString;
        }
        static void Main(string[] args){
            int buffer_size;
            int matrix_width;
            int matrix_height;
            int sequence_count;
            string pattern = @"[A-Z0-9]{2}";

            Console.Write("Masukkan ukuran buffer yang diinginkan");
            buffer_size = Convert.ToInt32(Console.ReadLine());

            string[] listchar = new string[buffer_size];

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

            Console.Write("Masukkan jumlah sequence yang diinginkan : ");
            sequence_count = Convert.ToInt32(Console.ReadLine());

            int[] sequence_reward = new int[sequence_count];
            List<string> sequence_list = new List<string>();
            Random rnd = new Random();
            for(int k = 0;k < sequence_count; k++){
                bool sequence_end = false;
                int x = 1;
                int check = 3;
                while(!sequence_end){
                    List<string> list_sequence_code = [matrix[0,0]];

                    userInput = Console.ReadLine();
                    if(!Regex.IsMatch(userInput,pattern)){
                        list_sequence_code.Add(randomString());
                    }
                    else{
                        list_sequence_code.Add(userInput);
                    }

                    if(rnd.Next(1,10) < check){
                        sequence_end = true;
                        sequence_list.AddRange(list_sequence_code);
                    }
                    else{
                        if(x <= buffer_size){
                            sequence_end = true;
                            sequence_list.AddRange(list_sequence_code);
                        }
                        else{
                            x++;
                            check++;
                        }
                    }
                }
                Console.Write("Masukkan nilai reward pada sequence ke-" + k+1 + " : ");
                sequence_reward[k] = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}