using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public double MathScore { get; set; }
    public double PhysicsScore { get; set; }
    public double ChemistryScore { get; set; }

    public double AverageScore => (MathScore + PhysicsScore + ChemistryScore) / 3;

    public string AcademicPerformance
    {
        get
        {
            if (AverageScore >= 8)
                return "Giỏi";
            else if (AverageScore >= 6.5)
                return "Khá";
            else if (AverageScore >= 5)
                return "Trung Bình";
            else
                return "Yếu";
        }
    }
}

class Program
{
    static List<Student> students = new List<Student>();

    static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("\n----- MENU -----");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Cập nhật thông tin sinh viên bởi ID");
            Console.WriteLine("3. Xóa sinh viên bởi ID");
            Console.WriteLine("4. Tìm kiếm sinh viên theo tên");
            Console.WriteLine("5. Sắp xếp sinh viên theo điểm trung bình (GPA)");
            Console.WriteLine("6. Sắp xếp sinh viên theo tên");
            Console.WriteLine("7. Sắp xếp sinh viên theo ID");
            Console.WriteLine("8. Hiển thị danh sách sinh viên");
            Console.WriteLine("9. Thoát");

            Console.Write("Chọn chức năng (1-9): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    await Task.Run(() => AddStudent());
                    break;
                case 2:
                    await Task.Run(() => UpdateStudent());
                    break;
                case 3:
                    await Task.Run(() => DeleteStudent());
                    break;
                case 4:
                    await Task.Run(() => SearchStudentByName());
                    break;
                case 5:
                    await Task.Run(() => SortByGPA());
                    break;
                case 6:
                    await Task.Run(() => SortByName());
                    break;
                case 7:
                    await Task.Run(() => SortById());
                    break;
                case 8:
                    await Task.Run(() => DisplayStudents());
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Chức năng không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Student student = new Student();

        Console.Write("Nhập tên sinh viên: ");
        student.Name = Console.ReadLine();

        Console.Write("Nhập giới tính: ");
        student.Gender = Console.ReadLine();

        Console.Write("Nhập tuổi: ");
        student.Age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Nhập điểm Toán: ");
        student.MathScore = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhập điểm Lý: ");
        student.PhysicsScore = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhập điểm Hóa: ");
        student.ChemistryScore = Convert.ToDouble(Console.ReadLine());

        student.Id = students.Count + 1;

        students.Add(student);

        Console.WriteLine("Thêm sinh viên thành công.");
    }

    static void UpdateStudent()
    {
        Console.Write("Nhập ID sinh viên cần cập nhật: ");
        int idToUpdate = Convert.ToInt32(Console.ReadLine());

        Student studentToUpdate = students.FirstOrDefault(s => s.Id == idToUpdate);

        if (studentToUpdate != null)
        {
            Console.Write("Nhập tên mới: ");
            studentToUpdate.Name = Console.ReadLine();

            Console.Write("Nhập giới tính mới: ");
            studentToUpdate.Gender = Console.ReadLine();

            Console.Write("Nhập tuổi mới: ");
            studentToUpdate.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhập điểm Toán mới: ");
            studentToUpdate.MathScore = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập điểm Lý mới: ");
            studentToUpdate.PhysicsScore = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập điểm Hóa mới: ");
            studentToUpdate.ChemistryScore = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Cập nhật thông tin sinh viên thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên có ID được nhập.");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Nhập ID sinh viên cần xóa: ");
        int idToDelete = Convert.ToInt32(Console.ReadLine());

        Student studentToDelete = students.FirstOrDefault(s => s.Id == idToDelete);

        if (studentToDelete != null)
        {
            students.Remove(studentToDelete);
            Console.WriteLine("Xóa sinh viên thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên có ID được nhập.");
        }
    }

    static void SearchStudentByName()
    {
        Console.Write("Nhập tên sinh viên cần tìm kiếm: ");
        string nameToSearch = Console.ReadLine();

        List<Student> searchResults = students.Where(s => s.Name.ToLower().Contains(nameToSearch.ToLower())).ToList();

        if (searchResults.Any())
        {
            Console.WriteLine("\nKết quả tìm kiếm:");
            DisplayStudentList(searchResults);
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên nào có tên được nhập.");
        }
    }

    static void SortByGPA()
    {
        List<Student> sortedList = students.OrderByDescending(s => s.AverageScore).ToList();
        Console.WriteLine("\nDanh sách sinh viên được sắp xếp theo điểm trung bình (GPA):");
        DisplayStudentList(sortedList);
    }

    static void SortByName()
    {
        List<Student> sortedList = students.OrderBy(s => s.Name).ToList();
        Console.WriteLine("\nDanh sách sinh viên được sắp xếp theo tên:");
        DisplayStudentList(sortedList);
    }

    static void SortById()
    {
        List<Student> sortedList = students.OrderBy(s => s.Id).ToList();
        Console.WriteLine("\nDanh sách sinh viên được sắp xếp theo ID:");
        DisplayStudentList(sortedList);
    }

    static void DisplayStudents()
    {
        Console.WriteLine("\nDanh sách sinh viên:");
        DisplayStudentList(students);
    }

    static void DisplayStudentList(List<Student> studentList)
    {
        Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-5} {4,-5} {5,-5} {6,-5} {7,-10} {8,-10}",
            "ID", "Tên", "Giới tính", "Tuổi", "Toán", "Lý", "Hóa", "Điểm TB", "Học lực");

        foreach (var student in studentList)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-5} {4,-5} {5,-5} {6,-5} {7,-10} {8,-10}",
                student.Id, student.Name, student.Gender, student.Age,
                student.MathScore, student.PhysicsScore, student.ChemistryScore,
                student.AverageScore.ToString("F2"), student.AcademicPerformance);
        }
    }
}
