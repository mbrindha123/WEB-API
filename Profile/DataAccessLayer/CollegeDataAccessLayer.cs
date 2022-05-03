using PROFILE.Models;
using Microsoft.EntityFrameworkCore;
namespace PROFILE.DataAccessLayer
{
    public class CollegeDataAccessLayer:ICollegeDataAccessLayer
    {
       private CollegeContext _db = DataFactory.DbContextDataFactory.GetDbContextObject();  
        public bool AddCollege(College college)
        {
            if (college == null)
                throw new ArgumentNullException("Location can't be null");
            try
            {
                _db.Colleges.Add(college);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
        }
         public bool RemoveCollege(int collegeId)
        {
            if (collegeId == 0)
                throw new ArgumentNullException("Location Id is not provided ");

            try
            {
                var college = _db.Colleges.Find(collegeId);
                college.IsActive = false;
                _db.Colleges.Update(college);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }

        }
         public List<College> GetColleges()
        {
            try
            {
                return _db.Colleges.ToList();
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                throw new OperationCanceledException();
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                throw new Exception();
            }
        }


        
    }
}