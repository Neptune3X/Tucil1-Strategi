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
            string pattern = @"^[A-Z0-9]{2}\z";

            Console.Write("Masukkan ukuran buffer yang diinginkan : ");
            buffer_size = Convert.ToInt32(Console.ReadLine());

            string[] listchar = new string[buffer_size];

            Console.Write("Masukkan lebar dan tinggi matrix : ");
            string userInput = Console.ReadLine();
            string[] userProcessedInput = userInput.Split(" ");
            matrix_width = Convert.ToInt32(userProcessedInput[0]);
            matrix_height = Convert.ToInt32(userProcessedInput[1]);
            string[,] matrix = new string[matrix_width,matrix_height];

            int i = 0;
            int count = 1;
            while(i < matrix_width){
                Console.Write("Masukkan code pada baris ke-" + count + " : ");
                string userInputCode = Console.ReadLine();
                string[] userProcessedCode = userInputCode.Split(" ");
                string[] randomProcessedCode = new string[matrix_height];
                if(userProcessedCode.Length != matrix_height){
                    for(int j = 0; j < matrix_height; j++){
                        randomProcessedCode[j] = randomString();
                        matrix[i,j] = randomProcessedCode[j];
                    }
                }
                else{
                    for(int j = 0;j < matrix_height; j++){
                        if(!Regex.IsMatch(userProcessedCode[j],pattern)){
                            userProcessedCode[j] = randomString();
                        }
                        matrix[i,j] = userProcessedCode[j];
                    }
                }

                i++;
                count++;
            }
            Console.WriteLine("++++++++++++++++");
            for(int a = 0; a < matrix_width; a++){
                for(int j = 0; j < matrix_height; j++){
                    if(j == matrix_height - 1){
                        Console.WriteLine(matrix[a,j] + " ");
                    }
                    else{
                        Console.Write(matrix[a,j] + " ");
                    }
                }
            }
            Console.WriteLine("++++++++++++++++");
            Console.Write("Masukkan jumlah sequence yang diinginkan : ");
            sequence_count = Convert.ToInt32(Console.ReadLine());

            int[] sequence_reward = new int[sequence_count];
            List<List<string>> sequence_list = new List<List<string>>();
            Random rnd = new Random();
            for(int k = 0;k < sequence_count; k++){
                List<string> list_sequence_code = [matrix[0,0]];
                Console.Write("Masukkan code pada sequence ke-" + (k+1) + " : ");
                string userInputCode = Console.ReadLine();
                string[] userProcessedCode = userInputCode.Split(" ");
                string[] randomProcessedCode = new string[buffer_size];

                if(userProcessedCode.Length > buffer_size){
                    for(int j = 0; j < buffer_size - 1; j++){
                        randomProcessedCode[j] = randomString();
                        list_sequence_code.Add(randomProcessedCode[j]);
                        if(rnd.Next(0,20) < 10){
                            break;
                        }
                    }
                }
                else{
                    for(int j = 0;j < userProcessedCode.Length; j++){
                        if(Regex.IsMatch(userProcessedCode[j],pattern)){
                            list_sequence_code.Add(userProcessedCode[j]);
                        }
                        else{
                            userProcessedCode[j] = randomString();
                            list_sequence_code.Add(userProcessedCode[j]);
                        }
                        
                    }
                }
                for(int f = 0; f < list_sequence_code.Count;f++){
                    if(f == list_sequence_code.Count - 1){
                        Console.WriteLine(list_sequence_code[f] + " ");
                    }
                    else{
                        Console.Write(list_sequence_code[f] + " ");
                    }
                }
                sequence_list.Add(list_sequence_code);
                Console.Write("Masukkan nilai reward pada sequence ke-" + (k+1) + " : ");
                sequence_reward[k] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("++++++++++++++++");
            for(int f = 0; f < sequence_list.Count;f++){
                for(int g = 0 ; g < sequence_list[f].Count;g++){
                    if(g == sequence_list[f].Count - 1){
                        Console.WriteLine(sequence_list[f][g] + " ");
                    }
                    else{
                        Console.Write(sequence_list[f][g] + " ");
                    }
                }
            }
            Console.WriteLine("++++++++++++++++");
            int sum = 0;
            int movecount = 0;
            int pos_x = 0;
            int pos_y = 0;
            int buffer_count = 1;
            int max = 0;
            int index = -1;

            Stopwatch stopwatch = new Stopwatch();
            string[,] copy_matrix = new string[matrix_width,matrix_height];
            for(int f = 0; f < matrix_width; f++){
                for(int g = 0; g < matrix_height; g++){
                    copy_matrix[f,g] = matrix[f,g];
                }
            }
            listchar[0] = matrix[0,0];
            
            int c = 0;
            bool endsearch = false;
            while(!endsearch){
                int x = 0;
                int y = 0;
                int f = 0;
                List<int> indexList = new List<int>();
                bool not_found = false;
                
                while(!not_found){
                    if(copy_matrix[x,y] == sequence_list[f][c] && c < sequence_list[f].Count){
                        x = 0;
                        y = 0;
                        c++;
                    }
                    else if (copy_matrix[x,y] == sequence_list[f][c] && c >= sequence_list[f].Count){
                        c = 0;
                        indexList.Add(f);
                    }
                    else{
                        if(f == sequence_list.Count){
                            not_found = true;
                        }
                        else{
                            if(x == matrix_width && y == matrix_height && copy_matrix[x,y] != sequence_list[f][c]){
                                f++;
                            }
                            else if(y == matrix_height - 1 && copy_matrix[x,y] != sequence_list[f][c]){
                                y = 0;
                                x++;
                            }
                            else{
                                y++;
                            }
                        }
                    }
                }
            }
        }
    }
}