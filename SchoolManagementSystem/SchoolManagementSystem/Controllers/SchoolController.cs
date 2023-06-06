using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewCategory;
using SchoolManagementSystem.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Controllers
{
    public class SchoolController : Controller
    {
        private SchoolDbContext db = new SchoolDbContext();
        private readonly IWebHostEnvironment env;

        public SchoolController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        #region Image

        [HttpGet]
        public IActionResult ShowImage(string fileName)
        {
            if (fileName == null) return null;
            var filePath = Path.Combine(env.WebRootPath, "Photo", fileName);
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(fileStream, $"Photo/filename");
        }
        public void DeleteImage(string image)
        {

            if (image != null)
            {
                string imagePath = Path.Combine(env.WebRootPath, "Photo", image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
        }

        public string ImageUpload(IFormFile Photo)
        {
            string fileName = null;

            fileName = $"{Guid.NewGuid()}{Path.GetExtension(Photo.FileName)}";
            var filePath = Path.Combine(env.WebRootPath, "Photo", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(stream);
            }

            return fileName;
        }
        #endregion

        #region Authentication

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String UserName, String Password)
        {
            if(UserName=="Admin" && Password=="admin") return RedirectToAction("Index", "Home");
            return View();
        }

        #endregion

        #region Teacher
        [HttpGet]
        public IActionResult Teacher()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TeacherList()
        {
            return View();
        }
        #endregion

        #region Staff
        [HttpGet]
        public IActionResult Staff()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StuffList()
        {
            return View();
        }
        [HttpGet]
        public IActionResult StuffSalary ()
        {
            return View();
        }

        #endregion

        #region Student
        [HttpGet]
        public IActionResult Student()
        {
            ViewData["Campus"] = db.Campuses.ToList();
            ViewData["Class"] = db.Classes.ToList();
            ViewData["Shift"] = db.Shifts.ToList();
            ViewData["Group"] = db.Groups.ToList();
            ViewData["Session"] = db.Sessions.ToList();
            ViewData["Section"] = db.Sections.ToList();
            ViewData["Curriculum"] = db.Curricula.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult StudentList()
        {
            var s = db.Students.ToList();
            List<string> c = new List<string>();
            foreach(var list in s)
            {
                var Class = db.Classes.Find(list.ClassId);
                Console.WriteLine(Class);
                c.Add(Class.ClassName);
            }
            ViewData["Class"] = c;
            return View(s);
        }

        //[Bind("CampusId, SectionId, GroupId, SessionId, ShiftId, ClassId, FirstName, LastName, Photo, Gender, RollNumber, DateOfBirth, BirthCertificate, AdmissionDate, Religion, Nationality, PreviousSchool, Gpa, FatherName, MotherName, FatherNid, MotherNid, FatherOccupation, MotherOccupation, FatherPhoneNumber, FatherEmail, MotherPhoneNumber, MotherEmail, PresentAddress, PermanentAddress")]

        [HttpPost]
        public IActionResult StudentAdmission(VmAdmission model)
        {
            string? sfileName = model.Photo != null ? ImageUpload(model.Photo) : null;
            string? fFileName = model.FatherPhoto != null ? ImageUpload(model.FatherPhoto) : null;
            string? mFileName = model.MotherPhoto != null ? ImageUpload(model.MotherPhoto) : null;
            string? gFileName = model.GuardianPhoto != null ? ImageUpload(model.GuardianPhoto) : null;
            
            Student s = new Student();
            s.StudentId = 0;
            s.CampusId = model.CampusId;
            s.SectionId = model.SectionId;
            s.GroupId = model.GroupId;
            s.SessionId = model.SessionId;
            s.ShiftId = model.ShiftId;
            s.ClassId = model.ClassId;
            s.FirstName = model.FirstName;
            s.LastName = model.LastName;
            s.StudentPhoto = sfileName;
            s.StudentBloodGroup = model.StudentBloodGroup;
            s.CurriculumId = model.CurriculumId;
            s.PhoneNumber = model.PhoneNumber;
            s.Email = model.Email;
            s.Gender = model.Gender;
            s.RollNumber = model.RollNumber;
            s.DateOfBirth = model.DateOfBirth;
            s.BirthCertificate = model.BirthCertificate;
            s.AdmissionDate = model.AdmissionDate;
            s.Religion = model.Religion;
            s.Nationality = model.Nationality;
            s.PreviousSchool = model.PreviousSchool;
            s.Gpa = model.Gpa;
            s.FatherName = model.FatherName;
            s.MotherName = model.MotherName;
            s.FatherNid = model.FatherNid;
            s.MotherNid = model.MotherNid;
            s.FatherOccupation = model.FatherOccupation;
            s.FatherPhoneNumber = model.FatherPhoneNumber;
            s.FatherEmail = model.FatherEmail;
            s.MotherOccupation = model.MotherOccupation;
            s.MotherPhoneNumber = model.MotherPhoneNumber;
            s.MotherEmail = model.MotherEmail;
            s.PresentAddress = model.PresentAddress;
            s.PermanentAddress = model.PermanentAddress;
            s.FatherPhoto = fFileName;
            s.MotherPhoto = mFileName;
            s.FatherBloodGroup = model.FatherBloodGroup;
            s.MotherBloodGroup = model.MotherBloodGroup;
            s.GuardianName = model.GuardianName;
            s.GuardianAddress = model.GuardianAddress;
            s.GuardianOccupation = model.GuardianOccupation;
            s.GuardianRelation = model.GuardianRelation;
            s.GuardianPhone = model.GuardianPhone;
            s.GuardianEmail = model.GuardianEmail;
            s.GuardianPhoto = gFileName;
            db.Entry(s).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Student");
        }

        #endregion

        #region StudentPromote
        [HttpGet]
        public IActionResult StudentPromote()
        {
            return View();
        }       

        [HttpGet]
        public IActionResult PromoteList()
        {
            return View();
        }
        #endregion

        #region StudentPayment
        [HttpGet]
        public IActionResult StudentPayment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PaymentList()
        {
            return View();
        }
        #endregion

        #region StudentAttendance
        [HttpGet]
        public IActionResult StudentAttendance()
        {
            return View();
        }
        public IActionResult AttendanceList()
        {
            return View();
        }
        #endregion

        #region Session
        [HttpGet]
        public IActionResult Session()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SessionProgrameSettings()
        {
            return View();
        }
        #endregion

        #region Subject
        [HttpGet]
        public IActionResult Subject()
        {
            return View();
        }

        #endregion

        #region Class
        [HttpGet]
        public IActionResult Class()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Class(Class model)
        {
            db.Entry(model).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Class");
        }

        [HttpGet]
        public IActionResult ClassSubject()
        {
            return View();
        }

        #endregion


        #region Class Routine
        [HttpGet]
        public IActionResult AddStudentClass()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StudentClassRoutine()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTeacherClass()
        {
            return View();
        }


        [HttpGet]
        public IActionResult TeacherClassRoutine()
        {
            return View();
        }

        #endregion

        #region Exam

        [HttpGet]
        public IActionResult AddExam()
        {
            return View();
        }
        [HttpGet]


        public IActionResult StudentExam()
        {
            return View();
        }


        [HttpGet]
        public IActionResult StudentExamRoutine()
        {
            return View();
        }

        public IActionResult TeacherExam()
        {
            return View();
        }


        [HttpGet]
        public IActionResult TeacherExamRoutine()
        {
            return View();
        }


        #endregion

        #region Exams Sheet

        [HttpGet]
        public IActionResult AddExamSubject()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExamSchedule()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddMarksheet()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExamMarksheet()
        {
            return View();
        }

        #endregion

        #region Branch

        [HttpGet]
        public IActionResult Branch()
        {
            var b = db.Branches.ToList();
            return View(b);
        }
        [HttpGet]
        public IActionResult BranchInsert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BranchInsert(Branch b)
        {
            db.Branches.Add(b);
            db.SaveChanges();
            return RedirectToAction("Branch");
        }
        #endregion

        #region Building
        [HttpGet]
        public IActionResult Buiding()
        {
            ViewData["Campus"] = db.Campuses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Buiding(ViewCampus model)
        {    
            return RedirectToAction("Building");
        }
        #endregion

        #region Shift
        [HttpGet]
        public IActionResult Shift()
        {
            return View(db.Shifts.ToList());
        }
        [HttpGet]
        public IActionResult ShiftInsert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ShiftInsert(Shift s)
        {
            db.Shifts.Add(s);
            db.SaveChanges();
            return RedirectToAction("Shift");
        }
        #endregion

        #region Campus
        [HttpGet]
        public IActionResult Campus() // Campus View
        {
            return View(db.Campuses.ToList());
        }
        [HttpGet]
        public IActionResult CampusDetails(ActionCategory ac) // Campus Details View or Edit View
        {
            var c = db.Campuses.Find(ac.Id);
            var campus = new ViewCampus();
            if (c != null)
            {
                campus.CampusId = c.CampusId;
                campus.BranchId = (long)c.BranchId;
                campus.CampusName = c.CampusName;
                campus.Location = c.Location;
                var b = db.Branches.Find(campus.BranchId);
                campus.BranchId = b.BranchId;
                campus.BranchName = b.BranchName;
                campus.BranchLocation = b.BranchLocation;
                var s = db.CampusShifts.Where(x => x.CampusId == campus.CampusId).ToList();
                var shlist = new List<ViewCampus.ViewShift>();
                foreach (var list in s)
                {
                    var s2 = db.Shifts.Where(x=>x.ShiftId == list.ShiftId).ToList();
                    foreach(var item in  s2)
                    {
                        var sh = new ViewCampus.ViewShift();
                        sh.ShiftId = item.ShiftId;
                        sh.ShiftType = item.ShiftType;
                        sh.ShiftName = item.ShiftName;
                        sh.StarTime = item.StartTime;
                        sh.EndTime = item.EndTime;
                        shlist.Add(sh);
                    }
                }
                campus.Shifts = shlist;
                var Cr = db.CampusCurricula.Where(x => x.CampusId == campus.CampusId).ToList();
                var crList = new List<ViewCampus.ViewCurriculum>();
                foreach (var list in Cr)
                {
                    var crFind = db.Curricula.Where(x => x.CurriculumId == list.CurriculumId).ToList();
                    foreach (var item in crFind)
                    {
                        var cr1 = new ViewCampus.ViewCurriculum();
                        cr1.CurriculumId = item.CurriculumId;
                        cr1.CurriculumName = item.CurriculumName;
                        crList.Add(cr1);
                    }
                }
                campus.Curriculums = crList;
            }
            if (ac.ActionName == "Update")
            {
                ViewData["Branch"] = db.Branches.ToList();
                ViewData["Shift"] = db.Shifts.ToList();
                ViewData["Curriculum"] = db.Curricula.ToList();
                return View("CampusEdit", campus);
            }
            return View(campus);
        }

        [HttpGet]
        public IActionResult CampusInsert() // Campus submission Form View
        {
            ViewData["Branch"] = db.Branches.ToList();
            ViewData["Shift"] = db.Shifts.ToList();
            ViewData["Curriculum"] = db.Curricula.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CampusUpdate(ViewCampus model) // Campus Update Action
        {
            var c = new Campus();
            var cslist = new List<CampusShift>();
            c.CampusId = model.CampusId;
            c.BranchId = model.BranchId;
            c.CampusName = model.CampusName;
            c.Location = model.Location;
            db.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var csr = db.CampusShifts.Where(x=>x.CampusId == c.CampusId).ToList();
            db.CampusShifts.RemoveRange(csr);
            db.SaveChanges();
            for (int i = 0; i < model.ShiftId.Length; i++)
            {
                var cs = new CampusShift();
                cs.ShiftId = model.ShiftId[i];
                cs.CampusId = c.CampusId;
                cslist.Add(cs);
            }
            db.CampusShifts.AddRange(cslist);
            db.SaveChanges();
            var ccr = db.CampusCurricula.Where(x => x.CampusId == c.CampusId).ToList();
            db.RemoveRange(ccr);
            db.SaveChanges();
            var ccList = new List<CampusCurriculum>();
            for (int i = 0; i < model.CurriculumId.Length; i++)
            {
                var cc = new CampusCurriculum();
                cc.CurriculumId = model.CurriculumId[i];
                cc.CampusId = c.CampusId;
                ccList.Add(cc);
            }
            db.CampusCurricula.AddRange(ccList);
            db.SaveChanges();
            return RedirectToAction("Campus");
        }

        [HttpGet]
        public IActionResult DeleteCampus(Guid id) // Campus Remove Action
        {
            var cs = db.CampusShifts.Where(m => m.CampusId == id).ToList();
            var cc = db.CampusCurricula.Where(m => m.CampusId == id).ToList();
            var c = db.Campuses.Where(m => m.CampusId == id).ToList();
            if (cc.Any())
            {
                db.CampusCurricula.RemoveRange(cc);
                db.CampusShifts.RemoveRange(cs);
                db.Campuses.RemoveRange(c);
                db.SaveChanges();
            }
            return RedirectToAction("Campus");
        }

        [HttpPost]
        public IActionResult CampusInsert(ViewCampus model) // Campus Submission Action
        {
            var c = new Campus();
            var cslist = new List<CampusShift>();
            c.CampusId = Guid.NewGuid();
            c.BranchId = model.BranchId;
            c.CampusName = model.CampusName;
            c.Location = model.Location;
            db.Campuses.Add(c);
            db.SaveChanges();
            for (int i = 0; i < model.ShiftId.Length; i++)
            {
                var cs = new CampusShift();
                cs.ShiftId = model.ShiftId[i];
                cs.CampusId = c.CampusId;
                cslist.Add(cs);
            }
            db.CampusShifts.AddRange(cslist);
            var ccList = new List<CampusCurriculum>();
            for (int i = 0; i < model.CurriculumId.Length; i++)
            {
                var cc = new CampusCurriculum();
                cc.CurriculumId = model.CurriculumId[i];
                cc.CampusId = c.CampusId;
                ccList.Add(cc);
            }
            db.CampusCurricula.AddRange(ccList);
            db.SaveChanges();
            return RedirectToAction("Campus");
        }
        #endregion

        #region Curriculum
        [HttpGet]
        public IActionResult Curriculum()
        {
            return View(db.Curricula.ToList());
        }
        [HttpGet]
        public IActionResult CurriculumInsert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CurriculumInsert(Curriculum c)
        {
            db.Curricula.Add(c);
            db.SaveChanges();
            return RedirectToAction("Curriculum");
        }
        #endregion
    }
}
