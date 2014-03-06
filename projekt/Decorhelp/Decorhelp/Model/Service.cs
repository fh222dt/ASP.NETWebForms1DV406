using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Decorhelp.Model.DAL;
using System.ComponentModel.DataAnnotations;

namespace Decorhelp.Model
{
    public class Service
    {
        //fält
        private decorareaDAL _decorareaDAL;
        private decoritemDAL _decoritemDAL;
        private placedDAL _placedDAL;

        //Egenskaper
        private decorareaDAL DecorareaDAL
        {
            get { return _decorareaDAL ?? (_decorareaDAL = new decorareaDAL()); }
        }

        private decoritemDAL DecoritemDAL
        {
            get { return _decoritemDAL ?? (_decoritemDAL = new decoritemDAL()); }
        }

        private placedDAL PlacedDAL
        {
            get { return _placedDAL ?? (_placedDAL = new placedDAL()); }
        }

        //create/update metoder
        public void SaveDecorArea(decorarea decorarea)
        {
            ICollection<ValidationResult> validationResults;
            if (!decorarea.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            //create
            if (decorarea.decorAreaID == 0) // Ny post om decorareaID är 0
            {
                DecorareaDAL.InsertDecorArea(decorarea);
            }
            //update
            else
            {
                DecorareaDAL.UpdateDecorArea(decorarea);
            }
        }

        public void SaveDecorItem(decoritem decoritem)
        {
            ICollection<ValidationResult> validationResults;
            if (!decoritem.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            //create
            if (decoritem.decorAreaID == 0) // Ny post om decorareaID är 0
            {
                DecoritemDAL.InsertDecorItem(decoritem);
            }
            //update
            else
            {
                DecoritemDAL.UpdateDecorItem(decoritem);
            }
        }

        //read metoder
        public decorarea GetDecorArea(int decorAreaID)
        {
            return DecorareaDAL.GetDecorAreaById(decorAreaID);
        }

        public decoritem GetDecorItem(int decorItemID)
        {
            return DecoritemDAL.GetDecorItemById(decorItemID);
        }
        
        public IEnumerable<decorarea> GetDecorAreas()
        {
            return DecorareaDAL.GetDecorAreas();
        }

        public IEnumerable<decoritem> GetDecorItems()
        {
            return DecoritemDAL.GetDecorItems();
        }

        
        //delete metoder
        public void DeleteDecorArea(int decorAreaID)
        {
            DecorareaDAL.DeleteDecorArea(decorAreaID);
        }

        public void DeleteDecorItem(int decorItemID)
        {
            DecoritemDAL.DeleteDecorItem(decorItemID);
        }

        //TODO metod för placed
    }
}