using System;
using listar_alunos;
using static System.Console;

class Program 
{
    static void Main(string [] args)
    {

     Student[] students = new Student[5];
     int indiceStudent = 0;
     string optionUser = GetOptionUser();

     while (optionUser.ToUpper() != "X")
       {
         switch(optionUser)
           {
                case "1":
                    WriteLine("Informe o nome do aluno:");
                    Student student = new Student();
                    student.Name = Console.ReadLine();

                    WriteLine("Informe a nota do aluno:");
                    if (decimal.TryParse(ReadLine(), out decimal note))
                    {
                        student.Note = note;
                    }
                    else
                    {
                        throw new ArgumentException("Valor da nota deve ser decimal!");
                    }

                    students[indiceStudent] = student;
                    indiceStudent++;

                    break;
                case "2":
                    foreach(var a in students)
                    {
                        if(!string.IsNullOrEmpty(a.Name))
                        {
                            WriteLine($"ALUNO: {a.Name} - NOTA: {a.Note}");
                        }
                        
                    }
                    break;
                case "3":
                    decimal noteTotal = 0;
                    var nrStudents = 0;

                    for(int i = 0; i < students.Length; i++)
                    {
                        if(!string.IsNullOrEmpty(students[i].Name))
                        {
                            noteTotal = noteTotal + students[i].Note;
                            nrStudents++;
                        }
                    }

                    var mediaGeral = noteTotal / nrStudents;
                    WriteLine($"MÉDIA GERAL : {mediaGeral}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            optionUser = GetOptionUser();

        } 
    }

    private static string GetOptionUser()
    {
        WriteLine("Informe a opção desejada:");   
        WriteLine("1 - Inserir novo aluno");   
        WriteLine("2 - Listar alunos");   
        WriteLine("3 - Calcular média geral");   
        WriteLine("X - Sair");  

        string opcaoUsuario = ReadLine();
        return opcaoUsuario;

    }
}

