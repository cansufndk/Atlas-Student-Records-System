using System;

// ogrenci listesi
StudentLinkedList students = new StudentLinkedList();

// ana menu
while (true)
{
    Console.WriteLine("\n===== STUDENT RECORDS SYSTEM =====");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Search Student");
    Console.WriteLine("3. Update Student");
    Console.WriteLine("4. Delete Student");
    Console.WriteLine("5. Display All Students");
    Console.WriteLine("6. Exit");

    Console.WriteLine("Choose an option:");
    string choice = Console.ReadLine() ?? "";

    // programdan cik
    if (choice == "6")
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    // ogrenci ekle
    else if (choice == "1")
    {
        Student student = new Student();

        // Student ID
        int studentId;

        while (true)
        {
            Console.WriteLine("Enter Student ID:");

            if (int.TryParse(Console.ReadLine(), out studentId) && studentId > 0)
            {
                // ayni ID var mi
                if (students.SearchStudent(studentId) != null)
                {
                    Console.WriteLine("Student ID already exists!");
                    continue;
                }

                break;
            }

            Console.WriteLine("Invalid Student ID! Try again.");
        }

        student.StudentId = studentId;

        // Full Name
        while (true)
        {
            Console.WriteLine("Enter Full Name:");

            string name = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(name))
            {
                student.FullName = name.Trim();
                break;
            }

            Console.WriteLine("Name cannot be empty!");
        }

        // Age
        int age;

        while (true)
        {
            Console.WriteLine("Enter Age (16-100):");

            if (int.TryParse(Console.ReadLine(), out age) && age >= 16 && age <= 100)
            {
                break;
            }

            Console.WriteLine("Invalid Age! Try again.");
        }

        student.Age = age;

        // Department
        while (true)
        {
            Console.WriteLine("Enter Department:");

            string department = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(department))
            {
                student.Department = department.Trim();
                break;
            }

            Console.WriteLine("Department cannot be empty!");
        }

        // GPA
        double gpa;

        while (true)
        {
            Console.WriteLine("Enter GPA (0-4):");

            if (double.TryParse(Console.ReadLine(), out gpa) && gpa >= 0 && gpa <= 4)
            {
                break;
            }

            Console.WriteLine("Invalid GPA! Try again.");
        }

        student.GPA = gpa;

        students.AddStudent(student);

        Console.WriteLine("Student added successfully!");
    }
    // ogrencileri listele
    else if (choice == "5")
    {
        students.DisplayStudents();
    }
    // ogrenci ara
    else if (choice == "2")
    {
        Console.WriteLine("Enter Student ID:");

        // girilen ID gecerli mi
        if (int.TryParse(Console.ReadLine(), out int searchId) && searchId > 0)
        {
            // ogrenciyi listede ara
            Student? foundStudent = students.SearchStudent(searchId);

            if (foundStudent != null)
            {
                Console.WriteLine("Student found!");
                Console.WriteLine("ID: " + foundStudent.StudentId);
                Console.WriteLine("Name: " + foundStudent.FullName);
                Console.WriteLine("Age: " + foundStudent.Age);
                Console.WriteLine("Department: " + foundStudent.Department);
                Console.WriteLine("GPA: " + foundStudent.GPA);
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }
        else
        {
            Console.WriteLine("Invalid Student ID!");
        }
    }
    // ogrenci bilgilerini guncelle
    else if (choice == "3")
    {
        Console.WriteLine("Enter Student ID:");

        // ogrenci numarasini kontrol et
        if (int.TryParse(Console.ReadLine(), out int updateId) && updateId > 0)
        {
            Student? studentToUpdate = students.SearchStudent(updateId);

            if (studentToUpdate != null)
            {
                Console.WriteLine("Current Name: " + studentToUpdate.FullName);
                Console.WriteLine("Enter New Name:");

                string newName = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(newName))
                {
                    studentToUpdate.FullName = newName.Trim();

                    // yeni yas bilgisini al
                    int newAge;

                    while (true)
                    {
                        Console.WriteLine("Enter New Age (16-100):");

                        if (
                            int.TryParse(Console.ReadLine(), out newAge)
                            && newAge >= 16
                            && newAge <= 100
                        )
                        {
                            studentToUpdate.Age = newAge;
                            break;
                        }

                        Console.WriteLine("Invalid Age! Try again.");
                    }

                    // yeni bolum bilgisini al
                    while (true)
                    {
                        Console.WriteLine("Enter New Department:");

                        string newDepartment = Console.ReadLine() ?? "";

                        if (!string.IsNullOrWhiteSpace(newDepartment))
                        {
                            studentToUpdate.Department = newDepartment.Trim();
                            break;
                        }

                        Console.WriteLine("Department cannot be empty!");
                    }

                    // yeni GPA bilgisini al
                    double newGpa;

                    while (true)
                    {
                        Console.WriteLine("Enter New GPA (0-4):");

                        if (
                            double.TryParse(Console.ReadLine(), out newGpa)
                            && newGpa >= 0
                            && newGpa <= 4
                        )
                        {
                            studentToUpdate.GPA = newGpa;
                            break;
                        }

                        Console.WriteLine("Invalid GPA! Try again.");
                    }

                    Console.WriteLine("Student updated successfully!");
                }
                else
                {
                    Console.WriteLine("Name cannot be empty!");
                }
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }
        else
        {
            Console.WriteLine("Invalid Student ID!");
        }
    }
    // ogrenci sil
    else if (choice == "4")
    {
        Console.WriteLine("Enter Student ID:");

        // girilen ID gecerli mi
        if (int.TryParse(Console.ReadLine(), out int deleteId) && deleteId > 0)
        {
            // ogrenciyi listeden sil
            bool deleted = students.DeleteStudent(deleteId);

            if (deleted)
            {
                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }
        else
        {
            Console.WriteLine("Invalid Student ID!");
        }
    }
    else
    {
        Console.WriteLine("Invalid option! Try again.");
    }
}
