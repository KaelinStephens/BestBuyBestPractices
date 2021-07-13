using System;
using System.Collections.Generic;
using System.Text;

namespace ORMDapperExercise1
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        
    }
}
