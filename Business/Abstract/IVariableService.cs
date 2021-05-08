using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Business.Abstract
{
   public interface IVariableService
    {
        
        public string VariablesSpiner(string inputText, DataGridView data);
    }
}
