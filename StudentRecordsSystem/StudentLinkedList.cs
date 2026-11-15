public class StudentLinkedList
{
    // listenin ilk elemani
    private StudentNode? head;

    // yeni ogrenci ekleme
    public void AddStudent(Student student)
    {
        // ogrenci icin yeni node olustur
        StudentNode newNode = new StudentNode(student);

        // yeni node'u listenin basina ekle
        newNode.Next = head;
        head = newNode;
    }

    // tum ogrencileri terminalde listele
    public void DisplayStudents()
    {
        // ilk ogrenciden basla
        StudentNode? current = head;

        // liste bitene kadar devam et
        while (current != null)
        {
            Console.WriteLine("ID: " + current.Data.StudentId);
            Console.WriteLine("Name: " + current.Data.FullName);
            Console.WriteLine("Age: " + current.Data.Age);
            Console.WriteLine("Department: " + current.Data.Department);
            Console.WriteLine("GPA: " + current.Data.GPA);
            Console.WriteLine("--------------------");

            // sonraki ogrenciye gec
            current = current.Next;
        }
    }

    // tum ogrencileri API icin liste olarak getir
    public List<Student> GetAllStudents()
    {
        List<Student> students = new List<Student>();

        // ilk ogrenciden basla
        StudentNode? current = head;

        // linked list icindeki ogrencileri gez
        while (current != null)
        {
            students.Add(current.Data);

            // sonraki ogrenciye gec
            current = current.Next;
        }

        return students;
    }

    // numaraya gore ogrenci ara
    public Student? SearchStudent(int id)
    {
        // listenin basindan basla
        StudentNode? current = head;

        // tum ogrencileri kontrol et
        while (current != null)
        {
            // ogrenci numarasi ayni mi
            if (current.Data.StudentId == id)
            {
                // ogrenciyi bulduk
                return current.Data;
            }

            // sonraki ogrenciye gec
            current = current.Next;
        }

        // ogrenci bulunamadi
        return null;
    }

    // numaraya gore ogrenci sil
    public bool DeleteStudent(int id)
    {
        // liste bos mu
        if (head == null)
        {
            return false;
        }

        // ilk ogrenci silinecekse
        if (head.Data.StudentId == id)
        {
            head = head.Next;
            return true;
        }

        // diger ogrencileri kontrol et
        StudentNode? current = head;

        while (current.Next != null)
        {
            if (current.Next.Data.StudentId == id)
            {
                // silinecek ogrenciyi atla
                current.Next = current.Next.Next;
                return true;
            }

            current = current.Next;
        }

        // ogrenci bulunamadi
        return false;
    }
}
