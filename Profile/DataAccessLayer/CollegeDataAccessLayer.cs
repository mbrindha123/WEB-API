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
                throw new ArgumentNullException("College can't be null");
            try
            {
                _db.Colleges.Add(college);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                
                return false;
            }
            catch (OperationCanceledException)
            {
                
                return false;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
         public bool RemoveCollege(int collegeId)
        {
            if (collegeId == 0)
                throw new ArgumentNullException("College Id is not provided ");

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
                // "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //  "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //  "unknown exception occured "
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
                // "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //  "Opreation cancelled exception"
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
