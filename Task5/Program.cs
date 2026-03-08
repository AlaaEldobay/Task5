namespace Task5
{
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; } = [];

        public bool Enroll(Course course)
        {
            if (course == null)
            {
                throw new Exception("course not found");
            }
            else
            {
                Courses.Add(course);
                return true;
            }
        }
        public string PrintDetails()
        {

            return ($"ID : {StudentId} , Name: {Name} , Age : {Age} , Courses : {Courses.Count}");
        }
    }
    class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string PrintDetails()
        {
            return ($"Instructor ID : {InstructorId} , Name : {Name} , Specialization : {Specialization}");
        }
    }
    class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public string PrintDetails()
        {
            return ($"Course ID: {CourseId}, Title: {Title}, Instructor: {Instructor.Name}");
        }
    }
    class StudentManager
    {
        public List<Student> Students { get; set; } = [];
        public List<Course> Courses { get; set; } = [];
        public List<Instructor> Instructors { get; set; } = [];

        public bool AddStudent(Student student)
        {
            Students.Add(student);
            return true;
        }

        public bool AddCourse(Course course)
        {
            Courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    return Students[i];
                }
            }
            return null;
        }


        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return Courses[i];
                }
            }
            return null;
        }


        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    return Instructors[i];
                }
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            return student.Enroll(course);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            bool exit = true;

            while (exit)
            {
                Console.WriteLine("--- Student Management System ---");
                Console.WriteLine("1 : Add Student");
                Console.WriteLine("2 : Add Instructor");
                Console.WriteLine("3 : Add Course");
                Console.WriteLine("4 : Enroll Student in Course");
                Console.WriteLine("5 : Show All Students");
                Console.WriteLine("6 : Show All Courses");
                Console.WriteLine("7 : Show All Instructors");
                Console.WriteLine("8 : Find Student by ID");
                Console.WriteLine("9 : Find Course by ID");
                Console.WriteLine("10. Check if the student enrolled in specific course");
                Console.WriteLine("11. Return the instructor name by course name");
                Console.WriteLine("12 : Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Student ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Student Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Student Age: ");
                        int age = int.Parse(Console.ReadLine());

                        Student student = new Student { StudentId = id, Name = name, Age = age };
                        manager.AddStudent(student);
                        Console.WriteLine("Student added successfully");
                        break;

                    case "2":
                        Console.Write("Enter Instructor ID: ");
                        int Id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Instructor Name: ");
                        string iname = Console.ReadLine();
                        Console.Write("Enter Specialization: ");
                        string spec = Console.ReadLine();

                        Instructor instructor = new Instructor { InstructorId = Id, Name = iname, Specialization = spec };
                        manager.AddInstructor(instructor);
                        Console.WriteLine("Instructor added successfully");
                        break;

                    case "3":
                        Console.Write("Enter Course ID: ");
                        int cid = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Instructor ID for course : ");
                        int instId = int.Parse(Console.ReadLine());

                        Instructor inst = manager.FindInstructor(instId);
                        Course course = new Course { CourseId = cid, Title = title, Instructor = inst };
                        manager.AddCourse(course);
                        Console.WriteLine("Course added successfully");
                        break;

                    case "4":
                        Console.Write("Enter Student ID: ");
                        int stId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course ID: ");
                        int coId = int.Parse(Console.ReadLine());

                        if (manager.EnrollStudentInCourse(stId, coId))
                            Console.WriteLine("Student enrolled successfully");
                        else
                            Console.WriteLine("failed enroll");
                        break;

                    case "5":
                        for (int i = 0; i < manager.Students.Count; i++)
                        {
                            Console.WriteLine(manager.Students[i].PrintDetails());
                        }
                        break;


                    case "6":
                        for (int i = 0; i < manager.Courses.Count; i++)
                        {
                            Console.WriteLine(manager.Courses[i].PrintDetails());
                        }
                        break;


                    case "7":
                        for (int i = 0; i < manager.Instructors.Count; i++)
                        {
                            Console.WriteLine(manager.Instructors[i].PrintDetails());
                        }
                        break;


                    case "8":
                        Console.Write("Enter Student ID : ");
                        int fsid = int.Parse(Console.ReadLine());
                        Student foundStudent = manager.FindStudent(fsid);
                        if (foundStudent != null)
                            Console.WriteLine(foundStudent.PrintDetails());
                        else Console.WriteLine("Student not found");
                        break;

                    case "9":
                        Console.Write("Enter Course ID: ");
                        int fcid = int.Parse(Console.ReadLine());
                        Course foundCourse = manager.FindCourse(fcid);
                        if (foundCourse != null)
                            Console.WriteLine(foundCourse.PrintDetails());
                        else Console.WriteLine("Student not found");
                        break;

                    case "10":
                        Console.Write("Enter Student ID: ");
                        int checkStudentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course ID: ");
                        int checkCourseId = int.Parse(Console.ReadLine());

                        Student checkStudent = manager.FindStudent(checkStudentId);
                        if (checkStudent != null)
                        {
                            bool enrolled = false;
                            for (int i = 0; i < checkStudent.Courses.Count; i++)
                            {
                                if (checkStudent.Courses[i].CourseId == checkCourseId)
                                {
                                    enrolled = true;
                                    break;
                                }
                            }
                            if (enrolled)
                                Console.WriteLine("Student is enrolled in this course");
                            else Console.WriteLine("Student is not enrolled in this course");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                        break;

                    case "11":
                        Console.Write("Enter Course Title : ");
                        string courseTitle = Console.ReadLine();

                        Instructor foundInstructor = null;
                        for (int i = 0; i < manager.Courses.Count; i++)
                        {
                            if (manager.Courses[i].Title == courseTitle)
                            {
                                foundInstructor = manager.Courses[i].Instructor;
                                break;
                            }
                        }

                        if (foundInstructor != null)
                            Console.WriteLine($"Instructor : {foundInstructor.Name}");
                        else
                            Console.WriteLine("not found");
                        break;

                    case "12":
                        exit = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
