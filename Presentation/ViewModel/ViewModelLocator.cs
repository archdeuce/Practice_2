using DAL.Services;

namespace Presentation.ViewModel
{
    public class ViewModelLocator
    {
        private readonly IStudentService studentService;

        public StudentViewModel StudentViewModel
        {
            get
            {
                return new StudentViewModel(this.studentService);
            }
        }
     
        public ViewModelLocator()
        {
            this.studentService = new StudentService();
        }
    }
}