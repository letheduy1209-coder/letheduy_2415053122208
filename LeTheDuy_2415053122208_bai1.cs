using System;

namespace HelloCSharp.CSharp
{
    class VariableExample
    {
        static void Main(string[] args)
        {
           // hihihihihi
            // Bạn không thể gán giá trị mới cho hằng số.
            const int MAX_SCORE = 100;

            // Khai báo một biến có kiểu int.
            int score = 0;

            // Gán giá trị mới cho biến score.
            score = 98;

            // Khai báo một chuỗi (string)
            string studentName = "LE THE DUL";

            // In giá trị của biến ra màn hình Console.
            Console.WriteLine("Hi, {0}", studentName);
            Console.WriteLine("Your score: {0}/{1}", score, MAX_SCORE);

            // Chờ người dùng nhập vào gì đó và nhấn Enter trước khi kết thúc chương trình
            Console.ReadLine();
        }
    }
}
