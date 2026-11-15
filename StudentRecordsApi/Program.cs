var builder = WebApplication.CreateBuilder(args);

// HTML sayfasinin API'ye erismesine izin ver
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy =>
    policy
        .WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
        .AllowAnyHeader()
        .AllowAnyMethod()
);

// ogrencileri Linked List icinde tut
var students = new StudentLinkedList();

// ogrenci bilgilerini kontrol et
bool IsValidStudent(Student student)
{
    return student.StudentId > 0
        && !string.IsNullOrWhiteSpace(student.FullName)
        && student.Age >= 16
        && student.Age <= 100
        && !string.IsNullOrWhiteSpace(student.Department)
        && double.IsFinite(student.GPA)
        && student.GPA >= 0
        && student.GPA <= 4;
}

// API ana sayfasi
app.MapGet("/", () => "Atlas Student API is running!");

// tum ogrencileri getir
app.MapGet("/api/students", () =>
{
    return Results.Ok(students.GetAllStudents());
});

// ogrenciyi ID ile ara
app.MapGet("/api/students/{id:int}", (int id) =>
{
    var student = students.SearchStudent(id);

    return student == null ? Results.NotFound("Student not found") : Results.Ok(student);
});

// yeni ogrenci ekle
app.MapPost("/api/students", (Student student) =>
{
    if (!IsValidStudent(student))
    {
        return Results.BadRequest("Invalid student information");
    }

    if (students.SearchStudent(student.StudentId) != null)
    {
        return Results.Conflict("Student ID already exists");
    }

    students.AddStudent(student);

    return Results.Created($"/api/students/{student.StudentId}", student);
});

// ogrenci bilgilerini guncelle
app.MapPut("/api/students/{id:int}", (int id, Student updated) =>
{
    var student = students.SearchStudent(id);

    if (student == null)
    {
        return Results.NotFound("Student not found");
    }

    if (updated.StudentId != id || !IsValidStudent(updated))
    {
        return Results.BadRequest("Invalid student information");
    }

    student.FullName = updated.FullName;
    student.Age = updated.Age;
    student.Department = updated.Department;
    student.GPA = updated.GPA;

    return Results.Ok(student);
});

// ogrenci sil
app.MapDelete("/api/students/{id:int}", (int id) =>
{
    bool deleted = students.DeleteStudent(id);

    return deleted ? Results.NoContent() : Results.NotFound("Student not found");
});

app.Run();
